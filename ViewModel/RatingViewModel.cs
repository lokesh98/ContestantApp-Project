using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContestantApplications.ViewModel
{
    public class RatingViewModel
    {
        public int Id { get; set; }
        public decimal Average { get; set; }
        public int? ContestantId { get; set; }
        [Display(Name = "Average Rating")]
        public int? Rating { get; set; }
        public ContestantViewModel Contestant { get; set; }
        public DateTime? RatedDate { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public IEnumerable<RatingViewModel> RatingList { get; set; }
    }
}