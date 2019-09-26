using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.DataAccessLayer.Models;

namespace BOOKLOUD.DataAccessLayer.Interfaces
{
    public interface ICourseDataAccessService
    {
        List<CourseDetailsDALModel> FetchCoursesByUniversityId(int id);
    }
}
