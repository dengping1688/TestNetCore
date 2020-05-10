using IServersCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServersCore
{
    public class TestServiceA : ITestServicesA
    {
        public TestServiceA()
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }
        public void Show()
        {
            Console.WriteLine("A123456");
        }

 

    }
}
