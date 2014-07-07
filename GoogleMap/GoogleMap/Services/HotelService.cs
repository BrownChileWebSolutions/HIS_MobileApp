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
        public List<Hotel> GetHotelList(string Latitude, string Longitude)
        {            
               System.Data.DataTable sqlDt = new System.Data.DataTable();
                using (System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["GMapCon"].ConnectionString))
                {
                    using (System.Data.SqlClient.SqlCommand sqlCmd = sqlCon.CreateCommand())
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "SELECT * FROM (SELECT Name,Address,Description,Latitude,Longitude ,(3959 * acos( cos( radians(" + Latitude + ") ) * cos( radians( Latitude) ) * cos( radians( Longitude ) - radians(" + Longitude + ") ) + sin( radians(" + Latitude + ") ) * sin( radians( Latitude) ) ) ) AS distance  FROM Hotel)  Hoteltbl Where distance < 25 ORDER BY distance ";
                        System.Data.SqlClient.SqlDataAdapter sqlAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCmd);
                        sqlAdapter.SelectCommand = sqlCmd;
                        sqlAdapter.Fill(sqlDt);
                        foreach (DataRow dr in sqlDt.Rows)
                        {
                            objHotelList.Add(new Hotel
                            {
                                Name = dr[0].ToString(),
                                Address = dr[1].ToString(),
                                Description = dr[2].ToString(),
                                Latitude = Convert.ToDouble(dr[3]),
                                Longitude = Convert.ToDouble(dr[4].ToString())
                            });
                        }                       
                    }
                }
                return objHotelList;
        }
    }
}