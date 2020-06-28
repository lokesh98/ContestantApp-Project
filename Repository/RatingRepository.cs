using ContestantApplications.Models;
using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestantApplications.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ContestantDBEntities _db;
        public RatingRepository(ContestantDBEntities db)
        {
            _db = db;
        }
        public IEnumerable<RatingViewModel> getAll()
        {
            var contestant = from c in _db.Contestants
                             join d in _db.Districts on c.DistrictId equals d.Id
                             join r in _db.ContestantRatings on c.Id equals r.ContestantId into ps
                             from r in ps.DefaultIfEmpty()

                             select new RatingViewModel()
                             {
                                 ContestantId = c.Id,
                                 RatedDate = r.RatedDate,
                                 Rating = r.Rating,
                                 Contestant = new ContestantViewModel()
                                 {
                                     Address = c.Address,
                                     DateOfBirth = c.DateOfBirth,
                                     Firstname = c.Firstname,
                                     Gender = c.Gender,
                                     Id = c.Id,
                                     FullName = c.Firstname + " " + c.Lastname,
                                     IsActive = c.IsActive.HasValue ? c.IsActive.Value : false,
                                     Lastname = c.Lastname,
                                     DistrictId = c.DistrictId,
                                     PhotoUrl = c.PhotoUrl,
                                     Districts = new DistrictViewModel() { Name = d.Name }
                                 }
                             };


            return contestant;
        }


        public IEnumerable<RatingViewModel> getContestantWithRating(DateTime? fromdate, DateTime? todate)
        {
            var res = _db.sp_Get_AVG_Rating(fromdate, todate).ToList();
            var contestant = res.Select(x => new RatingViewModel()
            {
                ContestantId = x.CId,
                Average = x.AvgRating,
                Contestant = new ContestantViewModel()
                {
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    Id = x.CId,
                    FullName = x.Fullname,
                    Districts = new DistrictViewModel() { Name = x.District }
                }
            });

            return contestant;
        }


        //public IEnumerable<RatingViewModel> getAlssl()
        //{

        //    var res = _db.Database.SqlQuery<string>(@"SELECT c.Address,c.Firstname+' '+Lastname as Fullname,DateOfBirth,
        //                            'District' = d.Name, Firstname, Lastname, DateOfBirth, IsActive,
        //                            'AvgRating' = ISNULL(AVG(Rating), 0), c.Id as CId

        //                             FROM Contestant c INNER JOIN District d
        //                            ON c.DistrictId = d.Id
        //                            LEFT JOIN ContestantRating r
        //                            ON c.Id = r.ContestantId
        //                            GROUP BY c.Address, c.Firstname, c.Lastname, c.DateOfBirth, d.Name, c.IsActive, c.Id");




        //}



        public int rateContestant(int rate_val, int ContestantId)
        {
            try
            {
                ContestantRating ContestantRating = new ContestantRating()
                {
                    Rating = rate_val,
                    ContestantId = ContestantId,
                    RatedDate = DateTime.Today
                };
                _db.ContestantRatings.Add(ContestantRating);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateContestant(ContestantViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}