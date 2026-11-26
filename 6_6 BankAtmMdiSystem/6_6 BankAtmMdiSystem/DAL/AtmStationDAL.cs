using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using _6_6_BankAtmMdiSystem.DTO;

namespace _6_6_BankAtmMdiSystem.DAL
{
    public class AtmStationDAL
    {
        public List<AtmStationDTO> GetAll()
        {
            var list = new List<AtmStationDTO>();
            const string sql = "SELECT MaTram, DiaChi, TonQuy, TrangThai, DuongDanAnh FROM AtmStations ORDER BY MaTram";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AtmStationDTO
                        {
                            MaTram = reader["MaTram"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TonQuy = Convert.ToDecimal(reader["TonQuy"]),
                            TrangThai = reader["TrangThai"].ToString(),
                            DuongDanAnh = reader["DuongDanAnh"] == DBNull.Value
                                ? string.Empty
                                : reader["DuongDanAnh"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Exists(string maTram)
        {
            const string sql = "SELECT COUNT(1) FROM AtmStations WHERE MaTram = @MaTram";
            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTram", maTram);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool Insert(AtmStationDTO station)
        {
            const string sql = @"INSERT INTO AtmStations (MaTram, DiaChi, TonQuy, TrangThai, DuongDanAnh)
                                 VALUES (@MaTram, @DiaChi, @TonQuy, @TrangThai, @DuongDanAnh)";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTram", station.MaTram);
                cmd.Parameters.AddWithValue("@DiaChi", station.DiaChi);
                cmd.Parameters.AddWithValue("@TonQuy", station.TonQuy);
                cmd.Parameters.AddWithValue("@TrangThai", station.TrangThai);
                cmd.Parameters.AddWithValue("@DuongDanAnh",
                    string.IsNullOrWhiteSpace(station.DuongDanAnh) ? (object)DBNull.Value : station.DuongDanAnh);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(AtmStationDTO station, string oldMaTram)
        {
            const string sql = @"UPDATE AtmStations
                                 SET MaTram = @NewMaTram, DiaChi = @DiaChi, TonQuy = @TonQuy,
                                     TrangThai = @TrangThai, DuongDanAnh = @DuongDanAnh
                                 WHERE MaTram = @OldMaTram";

            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NewMaTram", station.MaTram);
                cmd.Parameters.AddWithValue("@DiaChi", station.DiaChi);
                cmd.Parameters.AddWithValue("@TonQuy", station.TonQuy);
                cmd.Parameters.AddWithValue("@TrangThai", station.TrangThai);
                cmd.Parameters.AddWithValue("@DuongDanAnh",
                    string.IsNullOrWhiteSpace(station.DuongDanAnh) ? (object)DBNull.Value : station.DuongDanAnh);
                cmd.Parameters.AddWithValue("@OldMaTram", oldMaTram);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string maTram)
        {
            const string sql = "DELETE FROM AtmStations WHERE MaTram = @MaTram";
            using (SqlConnection conn = DbConnectionHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTram", maTram);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}