using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPeople
{
    class Program
    {
        interface IPosition
        {
            string Title { get; }
        }

        //-------------------------------------

        class Manager : IPosition
        {
            public string Title
            {
                get
                {
                    return "Manager";
                }
            }
        }

        //------------------------------------

        class Clerk : IPosition
        {
            public string Title
            {
                get
                {
                    return "Clerk";
                }
            }
        }

        //------------------------------------

        class Programmer : IPosition
        {
            public string Title
            {
                get
                {
                    return "Programmer";
                }
            }
        }

        //------------------------------------

        static class Factory
        {
            
            public static IPosition EscogeYCreaPersonage()
            {
                /*CODIGO MALO
                switch (id)
                {
                    case 0:
                        return new Manager();
                    case 2:
                        return new Clerk();
                    case 3:
                    default:
                        return new Programmer();
                }*/

                //CODIGO WENO (implementado por Reflexion)
                var relationDictionary = new Dictionary<string, Type>();
                relationDictionary.Add("Manager", typeof(Manager));
                relationDictionary.Add("Programmer", typeof(Programmer));
                relationDictionary.Add("Clerk", typeof(Clerk));

                Console.WriteLine("\nEscribe tipo de People a crear: (Manager, Programmer o Clerk)");
                var lectura = Console.ReadLine();
                var type = (from a in relationDictionary
                            where a.Key == lectura
                            select a.Value).FirstOrDefault();

                if (type == null)
                    throw new System.ArgumentNullException("...valor de typo nulo::EL TIPO INTRODUCIDO NO EXISTE");

                var item = Activator.CreateInstance(type);

                Console.WriteLine("...instancia de tipo " + type + " creada en el metodo estatico");

                return (IPosition)item ;
            }
        }

        //------------------------------------

        static void Main()
        {

            var position = Factory.EscogeYCreaPersonage();
            Console.WriteLine("(en Main)INSTANCE = {0} ", position.Title + " created");
        }
    }

}
