using System;
using System.ComponentModel.Composition;
using IMEFSampleOne;

namespace MEFSampleOne
{
    [Export(typeof(IDemo))]
    public class DemoImplement : IDemo
    {
        public void Send(string msg)
        {
            Console.WriteLine("DemoImplement send{0}", msg);
        }
    }
}