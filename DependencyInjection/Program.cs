using System;
using System.Configuration;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DependencyInjection
{
    class MainClass
    {
        private readonly IDraw obj;
        public MainClass(IDraw obj)
        {
            this.obj = obj;

        }
        static void Main()
        {
            /*            IUnityContainer container = new UnityContainer();
                        container.RegisterType<MainClass>();
                        container.RegisterType<IDraw, DrawCircle>();
                        container.RegisterType<IDraw, DrawSquare>();

                        MainClass letsDraw = container.Resolve<MainClass>();*/



            /*            var container = new UnityContainer();
                        //container.LoadConfiguration();
                        var section = new UnityConfigurationSection();
                        //section.Configure(container);
                        section.Configure(container, "unity");*/

            /*            var container = new UnityContainer();
                        container.LoadConfiguration();*/


            UnityContainer container = new UnityContainer();
            UnityConfigurationSection configSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configSection.Configure(container);



            MainClass letsDraw = container.Resolve<MainClass>();
            letsDraw.obj.MovePencil();

            Console.ReadKey();



        }
    }

    public interface IDraw
    {
        void MovePencil();


    }

    public class DrawCircle : IDraw
    {

        public void MovePencil()
        {
            Console.WriteLine("To Draw A Circle Move the Pencil in Round Motion");
        }
    }

    public class DrawSquare : IDraw
    {

        public void MovePencil()
        {

            Console.WriteLine("To Draw a Square Move the Pencil to Draw Two Parallel Equal Lines then Enclose those parallel lines with another pair of parallel lines to make a enclosed box");

        }

    }
}
