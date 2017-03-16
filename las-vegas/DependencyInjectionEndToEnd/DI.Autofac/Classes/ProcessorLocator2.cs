using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace DI
{
    public class ProcessorLocator2 : IProcessorLocator2
    {
        public ProcessorLocator2(ILifetimeScope container)
        {
            _Container = container;

            ((IProcessorLocator2)this).CreateScope();
        }

        ILifetimeScope _Scope = null;

        ILifetimeScope _Container = null;
        void IProcessorLocator2.CreateScope()
        {
            _Scope = _Container.BeginLifetimeScope(); // Program.Container.BeginLifetimeScope(); (required by some containers)
        }

        T IProcessorLocator2.GetProcessor<T>()
        {
            return _Scope.Resolve<T>();
        }

        void IProcessorLocator2.ReleaseScope()
        {
            _Scope.Dispose();
        }
    }
}
