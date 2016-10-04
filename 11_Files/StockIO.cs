using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _11_Files
{
    class StockIO
    {

        public void WriteStock(StringWriter sw, Stock stock)
        {
            sw.WriteLine(stock.Symbol);
            sw.WriteLine(stock.PricePerShare);
            sw.WriteLine(stock.NumShares);
        }

        public void WriteStock(FileInfo file, Stock stock)
        {

            StreamWriter writer;
            writer = new StreamWriter(file.ToString());
            writer.WriteLine(stock.Symbol);
            writer.WriteLine(stock.PricePerShare);
            writer.WriteLine(stock.NumShares);
            writer.Close();

        }

        public Stock ReadStock(StringReader sr)
        {
            return new Stock(
                sr.ReadLine(),
                Convert.ToDouble(sr.ReadLine()),
                Convert.ToInt32(sr.ReadLine())
            );
        }

        public Stock ReadStock(FileInfo file)
        {

            StreamReader reader = new StreamReader(file.ToString());

            Stock s = new Stock();
            s.Symbol        = reader.ReadLine();
            s.PricePerShare = Convert.ToDouble(reader.ReadLine());
            s.NumShares     = Convert.ToInt32(reader.ReadLine());

            reader.Close();

            return s;

        }

    }
}
