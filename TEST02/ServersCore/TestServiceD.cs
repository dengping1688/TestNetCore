using IServersCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServersCore
{
    public class TestServiceD: ITestServicesD
    {
        public TestServiceD(ITestServicesC testServicesC)
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }
        public void Show()
        {
            Console.WriteLine("D123456");
        }
    }
}
