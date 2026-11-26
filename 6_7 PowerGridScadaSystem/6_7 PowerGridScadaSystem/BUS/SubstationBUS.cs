using _6_7_PowerGridScadaSystem.DAL;
using _6_7_PowerGridScadaSystem.DTO;
using System.Collections.Generic;

namespace _6_7_PowerGridScadaSystem.BUS
{
    public class SubstationBUS
    {
        private readonly SubstationDAL _substationDal = new SubstationDAL();
        private readonly OverloadLogDAL _overloadLogDal = new OverloadLogDAL();

        public List<SubstationDTO> GetAllSubstations()
        {
            return _substationDal.GetAll();
        }

        public List<OverloadLogDTO> GetRecentOverloadLogs(string maTram)
        {
            return _overloadLogDal.GetRecentBySubstation(maTram);
        }
    }
}