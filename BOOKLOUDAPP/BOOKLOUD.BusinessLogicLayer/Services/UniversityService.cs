using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.BusinessLogicLayer.Interfaces;
using BOOKLOUD.BusinessLogicLayer.Models;
using BOOKLOUD.DataAccessLayer.Models;
using BOOKLOUD.DataAccessLayer.Services;

namespace BOOKLOUD.BusinessLogicLayer.Services
{
    public class UniversityService : IUniversityService
    {
        private UniversityDataAccessService _dataAccessService;

        public UniversityService(UniversityDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        public List<UniversityDetailsDALModel> FetchAllUniversities()
        {
            var result = new List<UniversityDetailsDALModel>();
            try
            {
                result = _dataAccessService.FetchAllUniversities();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }
    }
}
