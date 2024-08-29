using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Repository;

namespace AssignmentExtraEdge.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository repo;
        public BrandService(IBrandRepository repo) 
        {
            this.repo = repo;
        }

        public int AddBrand(Brand sale)
        {
           return repo.AddBrand(sale);
        }

        public int DeleteBrand(int id)
        {
           return repo.DeleteBrand(id);
        }

        public Brand GetBrandById(int id)
        {
           return repo.GetBrandById(id);
        }

        public IEnumerable<Brand> GetBrand()
        {
            return repo.GetBrand();
        }

        public int UpdateBrand(Brand sale)
        {
           return repo.UpdateBrand(sale);
        }

        public int BulkInsertBrands(List<Brand> brands)
        {
            return repo.BulkInsertBrands(brands);
        }

        public int BulkUpdateBrands(List<Brand> brands)
        {
           return repo.BulkUpdateBrands(brands);
        }

        public int BulkDeleteBrands(List<int> brandids)
        {
            return repo.BulkDeleteBrands(brandids);
        }
    }
}
