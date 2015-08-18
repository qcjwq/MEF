using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        //http://blog.csdn.net/yiruoyun/article/details/6580238

        static void Main(string[] args)
        {
            //1、指定装配
            //var container = new CompositionContainer();
            //var batch = new CompositionBatch();
            //var client = new Client();
            //batch.AddPart(new StringProvider1());
            //batch.AddPart(client);
            //container.Compose(batch);

            //2、通过程序集
            //var container = new CompositionContainer(new AssemblyCatalog(typeof(Client).Assembly));
            //var client = new Client();
            //container.SatisfyImportsOnce(client);

            //3、DirectoryCatalog，该目标路径下的所有程序集都会被遍历查询
            //var container = new CompositionContainer(new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.exe"));
            //var client = new Client();
            //container.SatisfyImportsOnce(client);

            //4、程序集和DirectoryCatalog相结合
            IClient client = new Client();
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IClient).Assembly));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(client);

            client.Print();

            Console.ReadKey();
        }
    }

    public class StringProvider1
    {
        [Export]
        public string OutPut => "Hello world";
    }

    [Export(typeof(IClient))]
    public class Client : IClient
    {
        [Import]
        public string message = null;

        public void Print()
        {
            Console.WriteLine(this.message);
        }
    }

    public interface IClient
    {
        void Print();
    }
}
