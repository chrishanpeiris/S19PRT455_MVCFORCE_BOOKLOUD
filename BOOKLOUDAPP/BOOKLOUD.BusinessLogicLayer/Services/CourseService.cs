using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.BusinessLogicLayer.Interfaces;
using BOOKLOUD.DataAccessLayer.Interfaces;
using BOOKLOUD.DataAccessLayer.Models;
using BOOKLOUD.DataAccessLayer.Services;

namespace BOOKLOUD.BusinessLogicLayer.Services
{
    public class CourseService : ICourseService
    {
        private CourseDataAccessService _courseDataAccessService;

        public CourseService(CourseDataAccessService courseDataAccessService)
        {
            _courseDataAccessService = courseDataAccessService;
        }
        public List<CourseDetailsDALModel> FetchCoursesByUniversityId(int id)
        {
            var result = new List<CourseDetailsDALModel>();
            try
            {
                result = _courseDataAccessService.FetchCoursesByUniversityId(id);
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
