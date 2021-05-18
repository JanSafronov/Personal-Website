using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Web;
using Microsoft.VisualStudio.Web.CodeGenerators;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.FileSystemChange;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating.Compilation;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using Microsoft.Net.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.IO;
using System.IO.Pipelines;
using System.IO.Pipes;
using System.IdentityModel;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Formats;
using System.Formats.Asn1;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Data;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Data.SqlTypes;
using Microsoft.AspNetCore.Components;

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
                    sqci.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@message", message + "postfixstore"), new SqlParameter("@mil", mail), new SqlParameter("@date", new SqlDateTime(date)), new SqlParameter("@ip", ip), new SqlParameter("@token", token) });
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
            sqci.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@message", message), new SqlParameter("@mil", mail), new SqlParameter("@date", new SqlDateTime(date)), new SqlParameter("@ip", ip), new SqlParameter("@token", token) });
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
