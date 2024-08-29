using AssignmentExtraEdge.Model;

namespace AssignmentExtraEdge.Services
{
    public interface ISalesReportService
    {
        IEnumerable<SalesReport> GetSalesReport(DateTime previous, DateTime current);
        IEnumerable<MobileSales> GetBrandSalesReport(DateTime previous, DateTime current);

        decimal GetProfitLossReport(DateTime previous, DateTime current);
    }
}
