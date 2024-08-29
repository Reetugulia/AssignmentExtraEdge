using AssignmentExtraEdge.Model;

namespace AssignmentExtraEdge.Repository
{
    public interface ISalesRepository
    {
        IEnumerable<Sales> GetSales();
        Sales GetSaleById(int id);
        int AddSale(Sales sale);
        int UpdateSale(Sales sale);
        int DeleteSale(int id);

        int BulkInsertSales(List<Sales> sales);
        int BulkUpdateSales(List<Sales> sales);
        int BulkDeleteSales(List<int> saleids);

    }
}
