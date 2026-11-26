using _6_7_PowerGridScadaSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _6_7_PowerGridScadaSystem.DAL
{
    public class SubstationDAL
    {
        public List<SubstationDTO> GetAll()
        {
            var list = new List<SubstationDTO>();
            const string sql = "SELECT MaTram, TenTram, CapDienApDinhMuc, TrangThai FROM Substations ORDER BY MaTram";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SubstationDTO
                        {
                            MaTram = reader["MaTram"].ToString(),
                            TenTram = reader["TenTram"].ToString(),
                            CapDienApDinhMuc = Convert.ToDecimal(reader["CapDienApDinhMuc"]),
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}