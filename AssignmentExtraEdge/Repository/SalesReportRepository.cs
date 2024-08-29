using AssignmentExtraEdge.Data;
using AssignmentExtraEdge.Model;

namespace AssignmentExtraEdge.Repository
{
    public class SalesReportRepository : ISalesReportRepository
    {
        private readonly ApplicationDbContext _context;
        public SalesReportRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public IEnumerable<SalesReport> GetSalesReport(DateTime previous, DateTime current)
        {
            if (previous > current)
            {
                throw new ArgumentException("The 'previous month' date should greater than 'current month' date.");
            }

            var sales = _context.SalesReport
                .Where(s => s.DateTime >= previous && s.DateTime <= current)
                .Select(s => new SalesReport
                {
                    SaleId = s.SaleId,
                    MobileId = s.MobileId,
                    Quantity = s.Quantity,
                    Discount = s.Discount,
                    DateTime = s.DateTime,
                    TotalPrice = s.TotalPrice
                })
                .ToList();

            return sales;
        }
        public decimal GetProfitLossReport(DateTime previous, DateTime current)
        {
            if (previous > current)
            {
                throw new ArgumentException("The 'previous' date must be less than or equal to the 'current' date.");
            }

            var sales = _context.SalesReport
                .Where(s => s.DateTime >= previous && s.DateTime <= current)
                .ToList();

            var totalSales = sales.Sum(s => s.TotalPrice);

            var totalCosts = sales.Where(s => s.Quantity < 0).Sum(s => s.TotalPrice);

            return totalSales - totalCosts;
        }
        public IEnumerable<MobileSales> GetBrandSalesReport(DateTime previous, DateTime current)
        {
            if (previous > current)
            {
                throw new ArgumentException("The 'previous' date must be less than or equal to the 'current' date.");
            }

  
            var sales = (from sale in _context.SalesReport
                         join mobile in _context.mobilephone on sale.MobileId equals mobile.Id
                         join brand in _context.brand on mobile.BrandId equals brand.Id
                         where sale.DateTime >= previous && sale.DateTime <= current
                         group sale by brand.Name into saleGroup
                         select new MobileSales
                         {
                             BrandName = saleGroup.Key,
                             TotalSales = saleGroup.Sum(s => s.Quantity)  
                         })
               .ToList();

            return sales;
        }
    }
}
