using System;
using System.Collections.Generic;
using _6_6_BankAtmMdiSystem.DAL;
using _6_6_BankAtmMdiSystem.DTO;

namespace _6_6_BankAtmMdiSystem.BUS
{
    public class AtmStationBUS
    {
        private readonly AtmStationDAL _stationDal = new AtmStationDAL();

        public List<AtmStationDTO> GetAllStations()
        {
            return _stationDal.GetAll();
        }

        public void AddStation(AtmStationDTO station)
        {
            ValidateStation(station);
            if (_stationDal.Exists(station.MaTram))
            {
                throw new InvalidOperationException($"Mã trạm '{station.MaTram}' đã tồn tại trong hệ thống.");
            }
            _stationDal.Insert(station);
        }

        public void UpdateStation(AtmStationDTO station, string oldMaTram)
        {
            ValidateStation(station);
            if (!station.MaTram.Equals(oldMaTram, StringComparison.OrdinalIgnoreCase)
                && _stationDal.Exists(station.MaTram))
            {
                throw new InvalidOperationException($"Mã trạm mới '{station.MaTram}' bị trùng với trạm khác.");
            }
            _stationDal.Update(station, oldMaTram);
        }

        public void DeleteStation(string maTram)
        {
            if (string.IsNullOrWhiteSpace(maTram))
            {
                throw new ArgumentException("Mã trạm không hợp lệ.");
            }
            _stationDal.Delete(maTram);
        }

        private void ValidateStation(AtmStationDTO station)
        {
            if (string.IsNullOrWhiteSpace(station.MaTram))
                throw new ArgumentException("Vui lòng nhập Mã trạm ATM.");

            if (string.IsNullOrWhiteSpace(station.DiaChi))
                throw new ArgumentException("Vui lòng nhập Địa chỉ đặt máy.");

            if (station.TonQuy < 0)
                throw new ArgumentException("Số tiền tồn quỹ không được nhỏ hơn 0.");
        }
    }
}