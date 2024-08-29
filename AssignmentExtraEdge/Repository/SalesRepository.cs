using AssignmentExtraEdge.Data;
using AssignmentExtraEdge.Model;
using Microsoft.EntityFrameworkCore;

namespace AssignmentExtraEdge.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApplicationDbContext context;
        public SalesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int AddSale(Sales sale)
        {
            int result = 0;
            context.Sales.Add(sale);
            result=context.SaveChanges();
            return result;
        }

   
      

        public int DeleteSale(int id)
        {
            int result = 0;
            var sale = (from s in context.Sales
                        where s.Id == id
                        select s).FirstOrDefault();

            if (sale != null)
            {
                context.Sales.Remove(sale);
               result= context.SaveChanges();
            }
            return result;
        }

        public Sales GetSaleById(int id)
        {
            var model= (from sale in context.Sales
                        where sale.Id == id
                        select sale).FirstOrDefault();
            return model;
        }

        public IEnumerable<Sales> GetSales()
        {
          var model =   (from sale in context.Sales
                               select sale).ToList();
            return model;
        }

        public int UpdateSale(Sales sale)
        {
            int result = 0;
            var existingSale = (from s in context.Sales
                                where s.Id == sale.Id
                                select s).FirstOrDefault();

            if (existingSale != null)
            {
                existingSale.Date = sale.Date;
                existingSale.MobileId = sale.MobileId;
                existingSale.Quantity = sale.Quantity;
                existingSale.Discount = sale.Discount;
                existingSale.TotalPrice = sale.TotalPrice;

                result =context.SaveChanges();
            }
            return result;
        }
        public int BulkInsertSales(List<Sales> sales)
        {
            int result = 0;
            context.Sales.AddRange(sales);
            result = context.SaveChanges(); 
            return result;
        }

        public int BulkUpdateSales(List<Sales> sales)
        {
            int result = 0;

            foreach (var sale in sales)
            {
                var existingSale = context.Sales.Find(sale.Id);
                if (existingSale != null)
                {
                    existingSale.Date = sale.Date;
                    existingSale.Quantity = sale.Quantity;
                    existingSale.MobileId = sale.MobileId;
                    existingSale.Discount = sale.Discount;
                    existingSale.TotalPrice = sale.TotalPrice;


                }
                else
                {
                    context.Sales.Add(sale);
                }
            }
            result = context.SaveChanges(); 
            return result;
        }

        public int BulkDeleteSales(List<int> saleIds)
        {
            int result = 0;
            var salesToDelete = context.Sales.Where(s => saleIds.Contains(s.Id)).ToList();
            if (salesToDelete.Any())
            {
                context.Sales.RemoveRange(salesToDelete);
                result = context.SaveChanges(); 
            }
            return result;
        }


    }
}
