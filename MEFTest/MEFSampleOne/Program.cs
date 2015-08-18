using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMEFSampleOne;

namespace MEFSampleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new DemoOne();

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IDemo).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(demo);
            demo.Run();

            Console.ReadLine();
        }
    }
}
