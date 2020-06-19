using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Resolution;
using UnityDemo.Interfaces;
using UnityDemo.Services;

namespace UnityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Init();
            Context.FirstServiceImpl.Method1();

            Person p = Context.Instance.Resolve<Person>();
            p.Say();

            FristService firstService = (FristService)Context.Instance.Resolve<IFirstService>(new Unity.Resolution.ResolverOverride[] {
                new PropertyOverride("Property1","fffffff")
            }) ;
            Console.WriteLine(firstService.Property1);

            Console.WriteLine(Context.Instance.Resolve<IFirstService>() == Context.Instance.Resolve<IFirstService>());
            Console.Read();
        }
    }

    public class Person
    {
        
        IFirstService _firstServiceImple;

        public Person(IFirstService firstService)
        {
            _firstServiceImple = firstService;
        }

        public void Say()
        {
            _firstServiceImple.Method1();
            Console.WriteLine((_firstServiceImple as FristService).Property1);
        }

        public void SayPerson(Person p)
        {
            Console.WriteLine("fadf");
        }

    }

    public class StudentFactory
    {
        public Student CreatePerson()
        {
            return new Student();
        }
    }

    public class Student
    { }

    public class Context
    {
        private static IUnityContainer unityContainer;
        static Context() {
            unityContainer = new UnityContainer();
        }

        public static void Init()
        {
            unityContainer.RegisterType<Person, Person>();

            unityContainer.RegisterFactory<Student>(container => { return new Student(); });
            unityContainer.RegisterType<IFirstService, FristService>( new InjectionMember[] { 
                new InjectionMethod("Method2"),
                new InjectionProperty("Property1","fafda")
            });
        }

        public static IFirstService FirstServiceImpl
        {
            get
            {
                return unityContainer.Resolve<IFirstService>();
            }
        }

        public static IUnityContainer Instance
        {
            get
            {
                return unityContainer;
            }
        }
    }
}
