using System;

namespace _6_7_PowerGridScadaSystem.DTO
{
    public class TelemetryDataDTO
    {
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public double DienApKV { get; set; }
        public int MucMangTaiPercent { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public int ChuKyQuet { get; set; }
        public bool IsOverload => MucMangTaiPercent > 85;
    }
}