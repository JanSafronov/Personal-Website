using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Data;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Personal_Website.Back_End.DBFunctions;
using Personal_Website.Back_End.Security;

namespace Personal_Website.Pages
{

    public class ContactModel : PageModel
    {
        public string Status { get; set; } = "get";

        public void OnGet()
        {
            Status = "";
        }
        public void OnPost()
        {
            Status = "Message sent";
        }
    }

    
}
