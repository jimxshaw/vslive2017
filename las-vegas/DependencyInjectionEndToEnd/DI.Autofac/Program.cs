using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core.Activators.Reflection;

namespace DI
{
    class Program
    {
        public static IContainer Container;

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Regular DI usage");
                Console.WriteLine("2 - General service locator");
                Console.WriteLine("3 - Lifetime scope");
                Console.WriteLine("4 - Assembly scanning");
                Console.WriteLine("5 - Module usage");
                Console.WriteLine("6 - One-to-many");
                Console.WriteLine("7 - Post-construction resolve & Property injection");
                Console.WriteLine("8 - Constructor finder");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.Write("Select demo initialization: ");
                string choice = Console.ReadLine();
                if (choice == "0")
                    exit = true;
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "Miguel Castro",
                        Email = "miguelcastro67@gmail.com",
                        Product = "Laptop",
                        Price = 1200,
                        CreditCard = "1234567890"
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing:");
                    Console.WriteLine();

                    ContainerBuilder builder = new ContainerBuilder();

                    switch (choice)
                    {
                        case "1":
                            #region regular container usage
                            builder.RegisterType<Commerce1>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();
                            builder.RegisterType<DataRepository>().As<IDataRepository>();
                            
                            Container = builder.Build();

                            Commerce1 commerce1 = Container.Resolve<Commerce1>();

                            commerce1.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "2":
                            #region general service locator (Commerce2)
                            builder.RegisterType<Commerce2>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();

                            Container = builder.Build();

                            Commerce2 commerce2 = Container.Resolve<Commerce2>();

                            commerce2.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "3":
                            #region lifetime scope & singleton (Commerce3)
                            builder.RegisterType<Commerce3>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<ProcessorLocator2>().As<IProcessorLocator2>();

                            //builder.RegisterType<SingleTester>().As<ISingleTester>();
                            #region singleton
                            builder.RegisterType<SingleTester>().As<ISingleTester>().SingleInstance();
                            #endregion

                            Container = builder.Build();

                            #region sample lifetime scope resolving
                            //using (ILifetimeScope scope = Container.BeginLifetimeScope())
                            //{
                            //    Commerce4 scopedCommerce = scope.Resolve<Commerce4>();
                            //}
                            
                            // if dependencies were 'Disposable', they would now be disposed and released
                            // without lifetime scope, the container would hold on to disposable components
                            #endregion

                            Commerce3 commerce3 = Container.Resolve<Commerce3>();

                            commerce3.ProcessOrder(orderInfo);

                            Console.WriteLine("Press 'Enter' to process again...");
                            Console.ReadLine();

                            commerce3 = Container.Resolve<Commerce3>();
                            commerce3.ProcessOrder(orderInfo);
                            
                            #endregion

                            break;
                        case "4":
                            #region assembly scanning (Commerce4)
                            builder.RegisterType<Commerce4>();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));

                            Container = builder.Build();

                            Commerce4 commerce4 = Container.Resolve<Commerce4>();

                            commerce4.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "5":
                            #region module usage (Commerce5)
                            builder.RegisterType<Commerce5>();
                            builder.RegisterModule<ProcessorRegistrationModule>();

                            Container = builder.Build();

                            Commerce5 commerce5 = Container.Resolve<Commerce5>();

                            commerce5.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "6":
                            #region one-to-many (Commerce6)
                            builder.RegisterType<Commerce6>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();

                            Container = builder.Build();

                            Commerce6 commerce6 = Container.Resolve<Commerce6>();

                            commerce6.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "7":
                            #region post-construction resolve & property injection (Commerce7)
                            builder.RegisterType<Commerce7>().PropertiesAutowired();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();
                            
                            Container = builder.Build();

                            Commerce7 commerce7 = Container.Resolve<Commerce7>();
                            #region post-construction injection
                            //Commerce7 commerce7 = new Commerce7();
                            #endregion

                            commerce7.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "8":
                            #region constructor finder (Commerce8)
                            //builder.RegisterType<Commerce8>().WithParameters(new List<Autofac.Core.Parameter>() {
                            //new NamedParameter("a", 1), 
                            //new NamedParameter("b", 1),
                            //new NamedParameter("c", 1), 
                            //new NamedParameter("d", 1) });
                            #region fix
                            builder.RegisterType<Commerce8>().WithParameters(new List<Autofac.Core.Parameter>() {
                                new NamedParameter("a", 1), 
                                new NamedParameter("b", 1),
                                new NamedParameter("c", 1), 
                                new NamedParameter("d", 1) }).FindConstructorsWith(new AwesomeConstructorFinder());
                            #endregion
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();

                            Container = builder.Build();

                            Commerce8 commerce8 = Container.Resolve<Commerce8>();

                            commerce8.ProcessOrder(orderInfo);
                            #endregion

                            break;
                    }

                    Container.Dispose();

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' for menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
