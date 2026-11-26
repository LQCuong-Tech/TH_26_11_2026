using System;

namespace _6_6_BankAtmMdiSystem.DTO
{
    public class AtmTransactionDTO
    {
        public string MaGiaoDich { get; set; }
        public string MaTram { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public string LoaiGiaoDich { get; set; }
        public decimal SoTienCoreBanking { get; set; }
        public decimal SoTienAtmLog { get; set; }
        public string KetLuan { get; set; }
    }
}