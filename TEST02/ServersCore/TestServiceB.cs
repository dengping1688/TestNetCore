using IServersCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServersCore
{
    public class TestServiceB: ITestServicesB
    {
        public TestServiceB()
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }
        public void Show()
        {
            Console.WriteLine("B123456");
        }
    }
}
