using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestantApplications.Repository
{
    public interface IContestantRepository
    {
        IEnumerable<ContestantViewModel> getAllContestant();
        int addNewContestant(ContestantViewModel model);
        int UpdateContestant(ContestantViewModel model);
        ContestantViewModel getContestantById(int? id);
        int DeleteContestant(int id);
    }
}
