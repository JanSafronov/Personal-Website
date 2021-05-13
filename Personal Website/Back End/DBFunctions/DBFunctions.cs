using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Personal_Website.Back_End.DBFunctions
{
    public class ISUD
    {
        public static void InsertNewMessage(string name, string type, string message)
        {
            // Init connection
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // Open connection
            conn.Open();

            // Command building
            SqlCommandBuilder cmdb = new SqlCommandBuilder();
            SqlCommand sqlc = cmdb.GetInsertCommand();
            sqlc.Parameters.AddRange(new SqlParameter[] { new SqlParameter("Name", name), new SqlParameter("Message", message) });

            // Command insertion
            SqlCommand sqc = new SqlCommand(sqlc.CommandText, conn);
            sqc.ExecuteReader();

            // Close connection
            conn.Close();
        }
    }
}
