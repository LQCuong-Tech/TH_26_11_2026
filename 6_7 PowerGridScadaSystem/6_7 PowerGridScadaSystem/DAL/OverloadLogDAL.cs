using _6_7_PowerGridScadaSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _6_7_PowerGridScadaSystem.DAL
{
    public class OverloadLogDAL
    {
        public void Insert(OverloadLogDTO log)
        {
            const string sql = @"INSERT INTO OverloadLogs (MaTram, ThoiGianGhiNhan, DienApKV, MucMangTaiPercent, MucDoCanhBao, ChuKyQuet)
                                 VALUES (@MaTram, @ThoiGianGhiNhan, @DienApKV, @MucMangTaiPercent, @MucDoCanhBao, @ChuKyQuet)";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTram", log.MaTram);
                cmd.Parameters.AddWithValue("@ThoiGianGhiNhan", log.ThoiGianGhiNhan);
                cmd.Parameters.AddWithValue("@DienApKV", log.DienApKV);
                cmd.Parameters.AddWithValue("@MucMangTaiPercent", log.MucMangTaiPercent);
                cmd.Parameters.AddWithValue("@MucDoCanhBao", log.MucDoCanhBao);
                cmd.Parameters.AddWithValue("@ChuKyQuet", log.ChuKyQuet);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<OverloadLogDTO> GetRecentBySubstation(string maTram, int top = 20)
        {
            var list = new List<OverloadLogDTO>();
            string sql = $@"SELECT TOP ({top}) l.LogId, l.MaTram, s.TenTram, l.ThoiGianGhiNhan,
                                   l.DienApKV, l.MucMangTaiPercent, l.MucDoCanhBao, l.ChuKyQuet
                            FROM OverloadLogs l
                            INNER JOIN Substations s ON l.MaTram = s.MaTram
                            WHERE l.MaTram = @MaTram
                            ORDER BY l.ThoiGianGhiNhan DESC";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTram", maTram);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new OverloadLogDTO
                        {
                            LogId = Convert.ToInt32(reader["LogId"]),
                            MaTram = reader["MaTram"].ToString(),
                            TenTram = reader["TenTram"].ToString(),
                            ThoiGianGhiNhan = Convert.ToDateTime(reader["ThoiGianGhiNhan"]),
                            DienApKV = Convert.ToDouble(reader["DienApKV"]),
                            MucMangTaiPercent = Convert.ToInt32(reader["MucMangTaiPercent"]),
                            MucDoCanhBao = reader["MucDoCanhBao"].ToString(),
                            ChuKyQuet = Convert.ToInt32(reader["ChuKyQuet"])
                        });
                    }
                }
            }
            return list;
        }
    }
}