using System;
using System.Collections.Generic;
using System.Linq;

namespace DI
{
    public class CustomerProcessor : ICustomerProcessor
    {
        public CustomerProcessor() //IDataRepository dr)
        {
            //_Dr = dr;
        }

        //IDataRepository _Dr;
        void ICustomerProcessor.UpdateCustomerOrder(string customer, string product)
        {
            //_Dr.Save();

            // update customer record with purchase
            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product));
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
            Console.WriteLine("In Data Repository");
        }
    }

}