using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.BusinessLogicLayer.Models;
using BOOKLOUD.DataAccessLayer.Models;

namespace BOOKLOUD.BusinessLogicLayer.Interfaces
{
    public interface IUniversityService
    {
        List<UniversityDetailsDALModel> FetchAllUniversities();
    }
}
