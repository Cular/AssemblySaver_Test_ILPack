using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = MyTypeBuilder.CompileResultTypeInfo();
            var obj = MyTypeBuilder.CreateNewObject(type) as dynamic;
            obj.YourProp1 = "hello";

            AssemblySaver.SaveAssembly(Assembly.GetAssembly(type.AsType()));

            //var type = new MyDynamicType();
            //type.YourProp1 = "asdasd";
            //type.YourProp2 = 5;
        }

    }

    public static class AssemblySaver
    {
        public static void SaveAssembly(Assembly assembly)
        {
            var generator = new Lokad.ILPack.AssemblyGenerator(assembly);
            generator.GenerateAssembly("C:\\myasm");
        }
    }
}
