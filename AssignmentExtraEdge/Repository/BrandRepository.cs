using AssignmentExtraEdge.Data;
using AssignmentExtraEdge.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AssignmentExtraEdge.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
           this._context = context;
        }
        public int AddBrand(Brand brand)
        {
            int result = 0;
            _context.brand.Add(brand);
            result=  _context.SaveChanges();
            return result;
        }
        public int DeleteBrand(int id)
        {
            Brand brand = _context.brand.Find(id);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            _context.brand.Remove(brand);
            _context.SaveChanges();
            return id;
        }

        public Brand GetBrandById(int id)
        {
            return _context.brand.Find(id);
        }

        public IEnumerable<Brand> GetBrand()
        {
            return _context.brand.ToList();
        }

        public int UpdateBrand(Brand brand)
        {
            int result = 0;
            var existingbrand = (from m in _context.brand
                                  where m.Id == brand.Id
                                  select m).FirstOrDefault();

            if (existingbrand != null)
            {
                existingbrand.Name = brand.Name;
               

                result = _context.SaveChanges();
            }
            return result;
        }
        public int BulkInsertBrands(List<Brand> brands)
        {
            int result = 0;
            _context.brand.AddRange(brands);
            result=_context.SaveChanges();
            return result;
        }

        public int BulkUpdateBrands(List<Brand> brands)
        {
            int result = 0;

            foreach (var brand in brands)
            {
                var existingBrand = _context.brand.Find(brand.Id);
                if (existingBrand != null)
                {
                    existingBrand.Name = brand.Name;
                }
                else
                {
                    _context.brand.Add(brand);
                }
            }
            result=_context.SaveChanges();
            return result;
        }
        public int BulkDeleteBrands(List<int> brandIds)
        {
            int result = 0;
            var brandsToDelete = _context.brand.Where(b => brandIds.Contains(b.Id)).ToList();
            if (brandsToDelete.Any())
            {
                _context.brand.RemoveRange(brandsToDelete);
               result= _context.SaveChanges();
            }
            return result;
        }
    }
}
