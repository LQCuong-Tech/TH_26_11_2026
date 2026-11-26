using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _6_6_BankAtmMdiSystem.DTO;

namespace _6_6_BankAtmMdiSystem.DAL
{
    public class AtmTransactionDAL
    {
        public List<AtmTransactionDTO> GetMismatchedTransactionsByDate(DateTime ngayDoiSoat)
        {
            var list = new List<AtmTransactionDTO>();
            const string sql = @"
                SELECT MaGiaoDich, MaTram, NgayGiaoDich, LoaiGiaoDich, SoTienCoreBanking, SoTienAtmLog, KetLuan
                FROM AtmTransactions
                WHERE NgayGiaoDich = @NgayDoiSoat AND KetLuan <> N'Khớp đúng'
                ORDER BY MaGiaoDich";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@NgayDoiSoat", SqlDbType.Date).Value = ngayDoiSoat.Date;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AtmTransactionDTO
                        {
                            MaGiaoDich = reader["MaGiaoDich"].ToString(),
                            MaTram = reader["MaTram"].ToString(),
                            NgayGiaoDich = Convert.ToDateTime(reader["NgayGiaoDich"]),
                            LoaiGiaoDich = reader["LoaiGiaoDich"].ToString(),
                            SoTienCoreBanking = Convert.ToDecimal(reader["SoTienCoreBanking"]),
                            SoTienAtmLog = Convert.ToDecimal(reader["SoTienAtmLog"]),
                            KetLuan = reader["KetLuan"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}