using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.Abstraction
{
    public class BillingProcessor : IBillingProcessor
    {
        public BillingProcessor()//(IDataRepository dataRep)
        {
            //_DataRep = dataRep;
        }

        IDataRepository _DataRep;

        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine(string.Format("Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price));
        }
    }

    public interface IDataRepository
    {
        void Save();
    }
    public class DataRepository : IDataRepository
    {
        public void Save()
        {
            
        }
    }
}
