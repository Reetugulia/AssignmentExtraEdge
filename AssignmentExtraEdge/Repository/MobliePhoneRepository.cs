using AssignmentExtraEdge.Data;
using AssignmentExtraEdge.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AssignmentExtraEdge.Repository
{
    public class MobliePhoneRepository : IMobilePhoneRepository
    {
        private readonly ApplicationDbContext _context;
        public MobliePhoneRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public int AddMobile(MobilePhones mobile)
        {
            int result = 0;
            _context.mobilephone.Add(mobile);
            result = _context.SaveChanges();
            return result;
        }

        public int DeleteMobile(int id)
        {

            int result = 0;
            var mobile = (from m in _context.mobilephone
                          where m.Id == id
                          select m).FirstOrDefault();

            if (mobile != null)
            {
                _context.mobilephone.Remove(mobile);
                result = _context.SaveChanges();
            }
            return result;
        }

        public MobilePhones GetMobileById(int id)
        {
            var mobile = (from m in _context.mobilephone
                          where m.Id == id
                          select m).FirstOrDefault();
            return mobile;
        }

        public IEnumerable<MobilePhones> GetMobiles()
        {
            var mobiles = (from m in _context.mobilephone
                           select m).ToList();
            return mobiles;
        }

        public int UpdateMobile(MobilePhones mobile)
        {
            int result = 0;
            var existingMobile = (from m in _context.mobilephone
                                  where m.Id == mobile.Id
                                  select m).FirstOrDefault();

            if (existingMobile != null)
            {
                existingMobile.Name = mobile.Name;
                existingMobile.Price = mobile.Price;
                existingMobile.BrandId = mobile.BrandId;

                result = _context.SaveChanges();
            }
            return result;
        }
        public int BulkInsertMobiles(List<MobilePhones> mobiles)
        {
            int result = 0;
            _context.mobilephone.AddRange(mobiles);
            result = _context.SaveChanges(); 
            return result;
        }

        public int BulkUpdateMobiles(List<MobilePhones> mobiles)
        {
            int result = 0;

            foreach (var mobile in mobiles)
            {
                var existingMobile = _context.mobilephone.Find(mobile.Id);
                if (existingMobile != null)
                {
                    existingMobile.Name = mobile.Name;
                    existingMobile.Price = mobile.Price;
                    existingMobile.BrandId = mobile.BrandId;
                 
                }
                else
                {
                    _context.mobilephone.Add(mobile);
                }
            }
            result = _context.SaveChanges(); 
            return result;
        }

        public int BulkDeleteMobiles(List<int> mobileIds)
        {
            int result = 0;
            var mobilesToDelete = _context.mobilephone.Where(m => mobileIds.Contains(m.Id)).ToList();
            if (mobilesToDelete.Any())
            {
                _context.mobilephone.RemoveRange(mobilesToDelete);
                result = _context.SaveChanges();
            }
            return result;
        }
    }
}
