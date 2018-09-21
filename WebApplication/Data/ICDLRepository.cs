using System.Collections.Generic;
using WebApplication.Data.Entities;

namespace WebApplication.Data
{
    public interface ICDLRepository
    {
        IEnumerable<CustomerDriverLicense> GetAllLicenses();
        CustomerDriverLicense GetLicenseById(string id);
        bool SaveAll();
        void AddEntity(object model);
    }
}