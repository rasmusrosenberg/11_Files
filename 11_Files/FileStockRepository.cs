using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _11_Files
{
    class FileStockRepository : IStockRepository, IFileRepository
    {

        private DirectoryInfo Dir;
        private StockIO       Sio;
        public  long          Id;

        public FileStockRepository() { }

        public FileStockRepository(DirectoryInfo dir)
        {
            Dir = dir;
            Sio = new StockIO();
        }

        public long NextId()
        {
            Id++;
            return Id;
        }

        public string StockFileName(long id)
        {
            return "stock" + id + ".txt";
        }

        public string StockFileName(Stock stock)
        {
            return "stock" + stock.Id + ".txt";
        }

        public void SaveStock(Stock stock)
        {

            stock.Id = NextId();

            FileInfo fileinfo = new FileInfo(Dir + StockFileName(stock));

            Sio.WriteStock(fileinfo, stock);

        }

        public Stock LoadStock(long id)
        {

            foreach (FileInfo item in Dir.GetFiles())
            {
                if (item.ToString() == "stock" + id + ".txt")
                {
                    return Sio.ReadStock(new FileInfo(Dir + item.ToString()));
                }
            }

            return new Stock();

        }

        public void Clear()
        {

            foreach (FileInfo item in Dir.GetFiles())
            {
                item.Delete();
            }

        }

        public List<Stock> FindAllStocks()
        {

            List<Stock> stocks = new List<Stock>();

            foreach (FileInfo item in Dir.GetFiles())
            {
                stocks.Add(
                    Sio.ReadStock(
                        new FileInfo(
                            Dir + item.ToString()
                        )
                    )
                );
            }

            return stocks;

        }

    }
}
