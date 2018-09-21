using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data.Entities;

namespace WebApplication.Data
{
    public class CDLRepository : ICDLRepository
    {
        private readonly CDLContext _ctx;
        private readonly ILogger<CDLRepository> _logger;

        public CDLRepository(CDLContext ctx, ILogger<CDLRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<CustomerDriverLicense> GetAllLicenses()
        {
            try
            {
                _logger.LogInformation("GetAllLicenses was called");
                return _ctx.Licenses.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Licenses: {ex}");
                return null;
            }
        }

        public CustomerDriverLicense GetLicenseById(string id)
        {
            try
            {
                _logger.LogInformation("GetLicenseById was called");
                return _ctx.Licenses.FirstOrDefault(l => l.ID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get the License #{id}: {ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}