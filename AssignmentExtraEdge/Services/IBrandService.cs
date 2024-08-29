using AssignmentExtraEdge.Model;

namespace AssignmentExtraEdge.Services
{
    public interface IBrandService
    {
        IEnumerable<Brand> GetBrand();
        Brand GetBrandById(int id);
        int AddBrand(Brand sale);
        int UpdateBrand(Brand sale);
        int DeleteBrand(int id);

        int BulkInsertBrands(List<Brand> brands);
         int BulkUpdateBrands(List<Brand> brands);
        int BulkDeleteBrands(List<int> brandids);
    }
}
