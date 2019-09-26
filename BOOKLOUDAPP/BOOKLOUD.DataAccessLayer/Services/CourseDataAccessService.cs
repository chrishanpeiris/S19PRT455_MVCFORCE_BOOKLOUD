using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOOKLOUD.DataAccessLayer.DataContext;
using BOOKLOUD.DataAccessLayer.Interfaces;
using BOOKLOUD.DataAccessLayer.Models;

namespace BOOKLOUD.DataAccessLayer.Services
{
    public class CourseDataAccessService : ICourseDataAccessService
    {
        private BookCloudDbContext _dbContext;

        public CourseDataAccessService (BookCloudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CourseDetailsDALModel> FetchCoursesByUniversityId(int id)
        {
            var efModel = _dbContext.Course.Where(a => a.University.Id == id).ToList();
            var returnObject = new List<CourseDetailsDALModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new CourseDetailsDALModel()
                {
                    CourseName = item.CourseName,
                });
            }

            return returnObject;
        }
    }
}
