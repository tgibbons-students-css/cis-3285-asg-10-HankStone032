using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author Alexander Hagmann
//date 11/10/2019
namespace CurrencyTrader.AdoNet
{
    //creates a decorator class that allows Asyncronous processing
    public class AsyncTradeStorage : ITradeStorage
    {

        private readonly ILogger logger;
        private ITradeStorage SyncTradeStorage;

        public AsyncTradeStorage(ILogger logger)
        {
            this.logger = logger;
            SyncTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Starting sync trade storage");
            //SyncTradeStorage.Persist(trades);
            Task.Run(() => SyncTradeStorage.Persist(trades));
        }
    }
}
