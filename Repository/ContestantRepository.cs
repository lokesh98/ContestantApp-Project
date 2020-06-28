using ContestantApplications.Models;
using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestantApplications.Repository
{
    public class ContestantRepository : IContestantRepository
    {
        private readonly ContestantDBEntities _db;
        public ContestantRepository(ContestantDBEntities db)
        {
            _db = db;
        }
        public int addNewContestant(ContestantViewModel model)
        {
            try
            {
                Contestant contestant = new Contestant()
                {
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    IsActive = model.IsActive,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    PhotoUrl = model.PhotoUrl,
                    Gender = model.Gender,
                    DistrictId = model.DistrictId
                };
                _db.Contestants.Add(contestant);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeleteContestant(int id)
        {
            try
            {
                var contestant = _db.Contestants.SingleOrDefault(x => x.Id == id);
                if (contestant != null)
                {
                    _db.Contestants.Remove(contestant);
                }
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return (0);
            }
        }

        public IEnumerable<ContestantViewModel> getAllContestant()
        {
            var contestant = from c in _db.Contestants
                             join d in _db.Districts on c.DistrictId equals d.Id
                             select new ContestantViewModel()
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
                                 Districts = new DistrictViewModel() { Name =d.Name}
                             };

            return contestant;
        }

        public ContestantViewModel getContestantById(int? id)
        {
            var contestants = _db.Contestants.Where(x => x.Id == id).FirstOrDefault();
            var contestant = new ContestantViewModel()
            {
                Address = contestants.Address,
                DateOfBirth = contestants.DateOfBirth,
                Firstname = contestants.Firstname,
                Gender = contestants.Gender,
                Id = contestants.Id,
                FullName = contestants.Firstname + " " + contestants.Lastname,
                IsActive = contestants.IsActive.HasValue ? contestants.IsActive.Value : false,
                Lastname = contestants.Lastname,
                DistrictId = contestants.DistrictId,
                PhotoUrl = contestants.PhotoUrl
            };
            return contestant;
        }

        public int UpdateContestant(ContestantViewModel model)
        {
            var _contestant = _db.Contestants.Where(x => x.Id == model.Id).FirstOrDefault();
            if (_contestant != null)
            {
                _contestant.Address = model.Address;
                _contestant.DateOfBirth = model.DateOfBirth;
                _contestant.Firstname = model.Firstname;
                _contestant.Gender = model.Gender;
                _contestant.Id = model.Id;
                _contestant.IsActive = model.IsActive;
                _contestant.Lastname = model.Lastname;
                _contestant.DistrictId = model.DistrictId;
                _contestant.PhotoUrl = model.PhotoUrl;
            }
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
              //  throw;
            }
           
        }
    }
}