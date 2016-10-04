﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    public interface IStockRepository
    {
        long NextId();

        void SaveStock(Stock stock);

        Stock LoadStock(long id);

        void Clear();

        List<Stock> FindAllStocks();

    }

}
