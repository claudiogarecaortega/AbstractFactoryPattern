using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // creamos un objeto abstracto pero instanciando un objeto concreto
            VehiculoFactory vehiculo = new VehiculoFosilFactory();
            //proporcionamos a un cliente que 
            MundoAutomotor mundo = new MundoAutomotor(vehiculo);


            mundo.Run();
            //
            // creamos un objeto abstracto pero instanciando un objeto concreto
            VehiculoFactory factory2 = new VehiculoRenobaleFactory();
            MundoAutomotor client2 = new MundoAutomotor(factory2);
            client2.Run();

            // Wait for user input
            Console.ReadKey();
        }
    }
    /// <summary>
    ///  Declaramos una interface que nos permitira crear objetos abtractos, 
    /// 
    /// </summary>
    abstract class VehiculoFactory
    {
        public abstract Abstractvehiculo CreateVehiculo();
        public abstract AbstractCombustible CreateCombustible();
    }
    /// <summary>
    /// implementamos la operacion para la creacion de objetos de tipo concreto, es decir productos concretos
    /// </summary>
    class VehiculoFosilFactory : VehiculoFactory
    {
        public override Abstractvehiculo CreateVehiculo()
        {
            return new Camion();
        }
        public override AbstractCombustible CreateCombustible()
        {
            return new CombustibleFosil();
        }
    }
    /// <summary>
    /// implementamos la operacion para la creacion de objetos de tipo concreto, es decir productos concretos
    /// </summary>
    class VehiculoRenobaleFactory : VehiculoFactory
    {
        public override Abstractvehiculo CreateVehiculo()
        {
            return new Pirus();
        }
        public override AbstractCombustible CreateCombustible()
        {
            return new Hidrogeno();
        }
    }

    /// <summary>
    /// declaramos una interface abstracta base   para un tipo de producto o objeto concreto
    /// </summary>
    abstract class AbstractCombustible
    {
    }

    /// <summary>
    /// declaramos una interface abstracta base para un tipo de producto o objeto concreto
    /// </summary>
    abstract class Abstractvehiculo
    {
        public abstract void Interact(AbstractCombustible a);
    }


    /// <summary>
    /// Define un objeto para ser creado por el factory correspondiente,
    /// e implementa un tipo de producto abstracto :
    /// </summary>
    class CombustibleFosil : AbstractCombustible
    {
    }

    /// <summary>
    /// Define un objeto para ser creado por el factory correspondiente
    /// e implementa un tipo de producto abstracto :
    /// </summary>
    class Camion : Abstractvehiculo
    {
        public override void Interact(AbstractCombustible a)
        {
            Console.WriteLine(this.GetType().Name +
              " Funciona con: " + a.GetType().Name);
        }
    }

    /// <summary>
    /// Define un objeto para ser creado por el factory correspondiente,
    /// e implementa un tipo de producto abstracto :
    /// </summary>
    class Hidrogeno : AbstractCombustible
    {
    }

    /// <summary>
    /// Define un objeto para ser creado por el factory correspondiente
    /// e implementa un tipo de producto abstracto :
    /// </summary>
    class Pirus : Abstractvehiculo
    {
        public override void Interact(AbstractCombustible a)
        {
            Console.WriteLine(this.GetType().Name +
              " Funciona con: " + a.GetType().Name);
        }
    }

    /// <summary>
    /// en el client utilizaremos interfaces declaradas por el abtractfactory y el abtractproduct 
    /// para poder interactuar a con b
    /// </summary>
    class MundoAutomotor
    {
        private AbstractCombustible _abstractCombustible;
        private Abstractvehiculo _abstractVehiculo;

        // Constructor
        public MundoAutomotor(VehiculoFactory factory)
        {
            _abstractCombustible = factory.CreateCombustible();
            _abstractVehiculo = factory.CreateVehiculo();
        }

        public void Run()
        {
            _abstractVehiculo.Interact(_abstractCombustible);
        }
    }
}
