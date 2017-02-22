using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Repository;
namespace DataAccess.Repository
{
     public class SalesEntryRepository
    {
        Repository<Sale> salRep = new Repository<Sale>();
        Repository<SalesItem> SaleItemRep = new Repository<SalesItem>();
        Repository<Stock> StkRep = new Repository<Stock>();
        ASITPOSDBEntities db = new ASITPOSDBEntities();

        public int InsertSales(Sale _sales)
        {
            salRep.Add(_sales);
            return _sales.ID;
        }

        public void InsertSalesItem(int _salesID, string[] _stockID, string[] _qty, string[] _rate, string[] _amt)
        {
            int count = _stockID.Count();
            for (int i = 0; i < count; i++)
            {
                SalesItem _salesItem = new SalesItem();
                _salesItem.SalesID = _salesID;

                _salesItem.StockID = Convert.ToInt32(_stockID[i]);
                _salesItem.Rate = Convert.ToDecimal(_rate[i]);
                _salesItem.Qty = Convert.ToInt32(_qty[i]);
                _salesItem.Amount = Convert.ToDecimal(_amt[i]);
                SaleItemRep.Add(_salesItem);
            }
        }

        public void UpdateStock(string[] _stockID, string[] _qty)
        {
            for (int i = 0, y = _stockID.Count(); i < y; i++)
            {
                int getStockID = Convert.ToInt32(_stockID[i]);
                int getQty = Convert.ToInt32(_qty[i]);
                Stock stock = new Stock();
                UpdateStock(getStockID, getQty);
            }
        }

        public void UpdateStock(int getStockID, int getQty)
        {
            Stock stock = new Stock();
            stock = db.Stocks.Find(getStockID);
            stock.Qty = stock.Qty - getQty;
            db.SaveChanges();
        }
        public Sale GetSales(int? salesId)
        {
            var _sales = from s in db.Sales
                         where s.ID == salesId
                         select s;

            return _sales.FirstOrDefault();
        }
    }
}
