using GoogleMap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace GoogleMap.Services
{
    public class HotelService
    {
        List<Hotel> objHotelList = new List<Hotel>();
        public List<Hotel> GetHotelList(string Latitude, string Longitude, int? Mile = null, int? HotelLimit=null)
        {
            if(!HotelLimit.HasValue)
                HotelLimit = Convert.ToInt32(ConfigurationManager.AppSettings["HotelLimit"]);
            if (!Mile.HasValue)
                Mile = Convert.ToInt32(ConfigurationManager.AppSettings["Mile"]);
            System.Data.DataTable sqlDt = new System.Data.DataTable();
            using (System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["GMapCon"].ConnectionString))
            {
                using (System.Data.SqlClient.SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "SELECT top " + HotelLimit + " * FROM (SELECT group_name,address1 as Description,(city + '-' + state + '-' + phone) as Address,latitude,longitude ,(3959 * acos( cos( radians(" + Latitude + ") ) * cos( radians( Latitude) ) * cos( radians( Longitude ) - radians(" + Longitude + ") ) + sin( radians(" + Latitude + ") ) * sin( radians( Latitude) ) ) ) AS distance  FROM Hotel)  Hoteltbl Where distance < " + Mile + " ORDER BY distance ";
                    System.Data.SqlClient.SqlDataAdapter sqlAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCmd);
                    sqlAdapter.SelectCommand = sqlCmd;
                    sqlAdapter.Fill(sqlDt);
                    foreach (DataRow dr in sqlDt.Rows)
                    {
                        objHotelList.Add(new Hotel
                        {
                            Name = dr["group_name"].ToString(),
                            Address = dr["Address"].ToString(),
                            Description = dr["Description"].ToString(),
                            Latitude = Convert.ToDouble(dr["latitude"]),
                            Longitude = Convert.ToDouble(dr["longitude"].ToString())
                        });
                    }
                }
            }
            return objHotelList;
        }
    }
}