using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft;
using Microsoft.Data;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Data.SqlTypes;
using Microsoft.Net;
using Microsoft.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Personal_Website.Back_End.DBFunctions
{
    public class ISUD
    {
        public static int InsertNewMessage(string name, string type, string message, DateTime date, string ip, string token, string mail = null)
        {
            // Connection to the data source
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Private;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // Open connection
            conn.Open();

            // Initialization
            SqlDataAdapter adapter;
            SqlCommand sqci;

            DateTime dt = GetMaxDate(ip);

            if (dt != SqlDateTime.MinValue.Value)
            {
                bool trip = dt.Year != date.Year || dt.Month != date.Month || dt.Day != date.Day;
                bool limit = (date.Hour - dt.Hour) * 59 + date.Minute - dt.Minute - (date.Second - dt.Second >= 0 ? 0 : 1) >= 59;
                if (trip || limit)
                {
                    // Data adapter
                    adapter = new SqlDataAdapter();

                    // Build Sql command and insert into the adapter
                    sqci = new SqlCommand("[dbo].[Procedure]", conn);
                    sqci.CommandType = CommandType.StoredProcedure;
                    sqci.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@message", message + "postfixstore"), new SqlParameter("@mail", mail), new SqlParameter("@date", new SqlDateTime(date)), new SqlParameter("@ip", ip), new SqlParameter("@token", token) });
                    adapter.InsertCommand = sqci;
                    adapter.InsertCommand.ExecuteNonQuery();

                    conn.Close();

                    return 1;
                }

                conn.Close();

                return 0;
            }

            // Data adapter
            adapter = new SqlDataAdapter();

            // Build Sql command and insert into the adapter
            sqci = new SqlCommand("[dbo].[Procedure]", conn);
            sqci.CommandType = CommandType.StoredProcedure;
            sqci.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@message", message), new SqlParameter("@mail", mail), new SqlParameter("@date", new SqlDateTime(date)), new SqlParameter("@ip", ip), new SqlParameter("@token", token) });
            adapter.InsertCommand = sqci;
            adapter.InsertCommand.ExecuteNonQuery();

            // Close connection
            conn.Close();

            return 1;
        }

        public static int RemoveMessage(DateTime date, string ip)
        {
            // Connection to the data source
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Private;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // Open connection
            conn.Open();

            // Initialization
            SqlDataAdapter adapter;
            SqlCommand sqci;

            DateTime dt = GetMaxDate(ip);

            if (dt != SqlDateTime.MinValue.Value)
            {
                bool trip = dt.Year != date.Year || dt.Month != date.Month || dt.Day != date.Day;
                bool limit = (date.Hour - dt.Hour) * 59 + date.Minute - dt.Minute - (date.Second - dt.Second >= 0 ? 0 : 1) >= 59;

                if (!trip && !limit)
                {
                    // Data adapter
                    adapter = new SqlDataAdapter();

                    // Build Sql command and insert into the adapter
                    sqci = new SqlCommand("[dbo].[Delete]", conn);
                    sqci.CommandType = CommandType.StoredProcedure;
                    sqci.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@ip", ip), new SqlParameter("@date", dt) });
                    adapter.InsertCommand = sqci;
                    adapter.InsertCommand.ExecuteNonQuery();

                    conn.Close();

                    return 1;
                }

                conn.Close();
            }

            return 0;
        }

        public static DateTime GetMaxDate(string ip)
        {
            // Connection to the data source
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Private;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // Open connection
            conn.Open();

            // Retrieve Messages data tables
            SqlCommand sqlcmd = new SqlCommand("[dbo].[UptoDate]", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlcmd.ExecuteReader();
            
            SqlDateTime sdtmax = SqlDateTime.MinValue.Value;
            
            if (!sdr.HasRows)
            {
                sdr.Close();
                return sdtmax.Value;
            }

            while (sdr.Read())
            {
                SqlDateTime sdt = sdr.GetSqlDateTime(1).Value;

                if (sdr.GetTextReader(0).ReadLine().Contains(ip) && SqlDateTime.GreaterThan(sdt, sdtmax).Value)
                {
                    sdtmax = sdt;
                }
            }

            sdr.Close();
            return sdtmax.Value;
        }
    }
}
