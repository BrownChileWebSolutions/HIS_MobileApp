using GoogleMap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Configuration;

namespace GoogleMap.Services
{
    public class UserService
    {
        private string strMsg=string.Empty;
        public int IsAuthorized(User objuser)
        {
            int UserID;
            using (System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["GMapCon"].ConnectionString))
                {
                  using (System.Data.SqlClient.SqlCommand sqlCmd = sqlCon.CreateCommand())
                  {
                     sqlCon.Open();
                      sqlCmd.Connection = sqlCon;
                      sqlCmd.CommandType = CommandType.Text;
                      sqlCmd.CommandText = "select  isnull(UserID,0) from UserName where UserName='" + objuser.UserName + "' and Password='" + objuser.Password + "'";
                      UserID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                      sqlCon.Close();
                  }
               }
            return UserID;            
        }        
    }
}