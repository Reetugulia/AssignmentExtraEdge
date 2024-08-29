using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Repository;

namespace AssignmentExtraEdge.Services
{
    public class SalesReportService:ISalesReportService
    {
        private readonly ISalesReportRepository repo;
        public SalesReportService(ISalesReportRepository repo) {

            this.repo = repo;

        }

        public IEnumerable<MobileSales> GetBrandSalesReport(DateTime previous, DateTime current)
        {
            return repo.GetBrandSalesReport(previous, current);
        }

        public decimal GetProfitLossReport(DateTime previous, DateTime current)
        {
            return  repo.GetProfitLossReport(previous, current);
        }

        public IEnumerable<SalesReport> GetSalesReport(DateTime previous, DateTime current)
        {
           return repo.GetSalesReport(previous, current);
        }
    }
}
