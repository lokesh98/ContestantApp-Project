using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestantApplications.Repository
{
   public interface IRatingRepository
    {
        IEnumerable<RatingViewModel> getAll();
        int rateContestant(int rate_val, int ContestantId);
        int UpdateContestant(ContestantViewModel model);
        IEnumerable<RatingViewModel> getContestantWithRating(DateTime? fromdate, DateTime? todate);
        //ContestantViewModel getContestantById(int? id);
        //int DeleteContestant(int id);
    }
}
