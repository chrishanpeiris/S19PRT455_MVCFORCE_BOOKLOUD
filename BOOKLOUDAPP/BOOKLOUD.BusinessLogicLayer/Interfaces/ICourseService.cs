using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.DataAccessLayer.Models;

namespace BOOKLOUD.BusinessLogicLayer.Interfaces
{
    public interface ICourseService
    {
        List<CourseDetailsDALModel> FetchCoursesByUniversityId(int id);

    }
}
