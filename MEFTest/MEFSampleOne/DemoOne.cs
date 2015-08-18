using System.ComponentModel.Composition;
using IMEFSampleOne;

namespace MEFSampleOne
{
    public class DemoOne
    {
        [Export]
        IDemo demo;

        public void Run()
        {
            demo.Send("DemoOne run");
        }
    }
}