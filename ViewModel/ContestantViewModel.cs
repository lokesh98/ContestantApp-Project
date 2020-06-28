using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestantApplications.ViewModel
{
    public class ContestantViewModel
    {
        public ContestantViewModel()
        {
            PhotoUrl = "~/Content/img/2.jpg";
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        [Required]
        public string Address { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public SelectList DistrictList { get; set; }
        public DistrictViewModel Districts { get; set; }



    }

    public class ContestantPageViewModel
    {
        public ContestantViewModel Contestant { get; set; }
        public IEnumerable<ContestantViewModel> ContestantList { get; set; }
        public int ContestantPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(ContestantList.Count() / (double)ContestantPerPage));
        }
        public IEnumerable<ContestantViewModel> PaginatedContestant()
        {
            int start = (CurrentPage - 1) * ContestantPerPage;
            return ContestantList.OrderBy(b => b.Id).Skip(start).Take(ContestantPerPage);
        }
    }
}