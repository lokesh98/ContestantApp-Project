using ContestantApplications.Models;
using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestantApplications.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly ContestantDBEntities _db;
        public TestRepository(ContestantDBEntities db)
        {
            _db = db;
        }
        public IEnumerable<DistrictViewModel> getAll()
        {
            var district = _db.Districts.Select(d => new DistrictViewModel()
            {
                Id = d.Id,
                Name = d.Name
            });

            return district;
        }
    }
}