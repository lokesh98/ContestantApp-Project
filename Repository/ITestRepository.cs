using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestantApplications.Repository
{
    public interface ITestRepository
    {
        IEnumerable<DistrictViewModel> getAll();
    }
}
