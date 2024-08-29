using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Repository;

namespace AssignmentExtraEdge.Services
{
    public class SalesService:ISalesServices
    {
        private readonly ISalesRepository repo;
        public SalesService(ISalesRepository repo)
        {
            this.repo = repo;
        }

        public int AddSale(Sales sale)
        {
            return repo.AddSale(sale);
        }

       
        public int DeleteSale(int id)
        {
            return repo.DeleteSale(id);
        }

        public Sales GetSaleById(int id)
        {
            return repo.GetSaleById(id);
        }

        public IEnumerable<Sales> GetSales()
        {
            return repo.GetSales();
        }

        public int UpdateSale(Sales sale)
        {
           return repo.UpdateSale(sale);
        }
        public int BulkDeleteSales(List<int> saleids)
        {
           return repo.BulkDeleteSales(saleids);
        }

        public int BulkInsertSales(List<Sales> sales)
        {
            return repo.BulkInsertSales(sales);
        }

        public int BulkUpdateSales(List<Sales> sales)
        {
            return repo.BulkUpdateSales(sales);
        }

    }
}
