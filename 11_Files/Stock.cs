using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{

    public interface Asset
    {

        double GetValue();

        String GetName();

    }

    public class Stock : Asset
    {

        public String Symbol;
        public double PricePerShare;
        public int    NumShares;
        public long   Id = 0;

        public Stock() { }

        public Stock(string Symbol, double PricePerShare, int NumShares)
        {
            this.Symbol        = Symbol;
            this.PricePerShare = PricePerShare;
            this.NumShares     = NumShares;
        }

        public double GetValue()
        {
            return this.PricePerShare * this.NumShares;
        }

        public static double TotalValue(Stock[] stocks)
        {

            double total = 0;

            foreach (Stock stock in stocks)
            {
                total += stock.GetValue();
            }

            return total;

        }

        public static double TotalValue(Asset[] portfolio)
        {

            double total = 0;

            foreach (Asset asset in portfolio)
            {
                total += asset.GetValue();
            }

            return total;

        }

        public override String ToString()
        {
            return "Stock[symbol=" +
                   Symbol +
                   ",pricePerShare=" +
                   PricePerShare.ToString().Replace(',','.') +
                   ",numShares=" +
                   NumShares.ToString().Replace(',', '.') +
                   "]";
        }

        public override bool Equals(object obj)
        {

            Stock _obj = (Stock)obj;

            if (this.Symbol != _obj.Symbol)
                return false;

            if (this.PricePerShare != _obj.PricePerShare)
                return false;

            if (this.NumShares != _obj.NumShares)
                return false;

            return true;

        }

        public String GetName()
        {
            return Symbol;
        }

    }
}
