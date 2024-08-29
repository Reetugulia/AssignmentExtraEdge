using AssignmentExtraEdge.Model;

namespace AssignmentExtraEdge.Services
{
    public interface ISalesServices
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
