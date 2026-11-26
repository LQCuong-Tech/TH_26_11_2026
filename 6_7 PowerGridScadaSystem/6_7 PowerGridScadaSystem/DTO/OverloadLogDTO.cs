using System;

namespace _6_7_PowerGridScadaSystem.DTO
{
    public class OverloadLogDTO
    {
        public int LogId { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public DateTime ThoiGianGhiNhan { get; set; }
        public double DienApKV { get; set; }
        public int MucMangTaiPercent { get; set; }
        public string MucDoCanhBao { get; set; }
        public int ChuKyQuet { get; set; }
    }
}