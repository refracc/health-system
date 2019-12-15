using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;

namespace DataLayer
{
    public sealed class LoadSingleton
    {
        private LoadSingleton() { }

        private static readonly Lazy<LoadSingleton> loadSingleton = new Lazy<LoadSingleton>(() => new LoadSingleton());

        public static LoadSingleton Instance => loadSingleton.Value;

        public void LoadType(string type)
        {
            PeopleFactory pf = new PeopleFactory();
            pf.FactoryMethod(type);
        }
    }
}
