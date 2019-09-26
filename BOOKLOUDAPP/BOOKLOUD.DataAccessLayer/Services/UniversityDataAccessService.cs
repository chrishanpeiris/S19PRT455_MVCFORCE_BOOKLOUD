using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOOKLOUD.DataAccessLayer.DataContext;
using BOOKLOUD.DataAccessLayer.Interfaces;
using BOOKLOUD.DataAccessLayer.Models;

namespace BOOKLOUD.DataAccessLayer.Services
{
    public class UniversityDataAccessService : IUniversityDataAccessService
    {
        private BookCloudDbContext _dbContext;

        public UniversityDataAccessService(BookCloudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UniversityDetailsDALModel> FetchAllUniversities()
        {
            var efModel = _dbContext.University.ToList();
            var returnObject = new List<UniversityDetailsDALModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new UniversityDetailsDALModel()
                {
                    UniversityName = item.UniversityName,
                });
            }

            return returnObject;
        }
    }
}
