using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _200383524
{
    class Program
    {
        static void Main(string[] args)
        {
            var steroes = new List<Stereo>();
            var stereo = new Stereo(true, true);
            steroes.Add(stereo);

            var powerPlants = new List<IPowerPlant>();
            var powerPlant = new GasEngine(FuelType.Gas, 0.238888, 205, 4, 2000);
            powerPlants.Add(powerPlant);
            
            var seat1 = new Seat(Material.Leather, Type.Bucket);
            var seat2 = new Seat(Material.Leather, Type.Bucket);
            var seat3 = new Seat(Material.Leather, Type.Bench);
            var seat4 = new Seat(Material.Leather, Type.Bench);
            var seat5 = new Seat(Material.Leather, Type.Bench);
            var seats = new List<Seat> { seat1, seat2, seat3, seat4, seat5 };


            var car = new Car("BRZ", "44.411960", "-79.669053", 1670, 50, 23, BodyType.Coupe, 2, true,
                stereos: steroes, powerPlants: powerPlants, seats: seats);


            seat1 = new Seat(Material.Cloth, Type.Captain);
            seat2 = new Seat(Material.Cloth, Type.Captain);
            seats = new List<Seat> { seat1, seat2 };

            stereo = new Stereo(true, true);
            steroes = new List<Stereo> { stereo };

            powerPlants = new List<IPowerPlant>
            {
                new DieselEngine(FuelType.Diesel,0.8333,210,4,5100)
            };

            

            var truck = new Truck("Hino", "44.411960", "-79.669053", 20500, 114, 66, stereos: steroes, seats: seats, powerPlants: powerPlants);

            seat1 = new Seat(Material.Leather, Type.Bucket);
            seat2 = new Seat(Material.Leather, Type.Bucket);
            seat3 = new Seat(Material.Leather, Type.Bench);
            seat4 = new Seat(Material.Leather, Type.Bench);
            seat5 = new Seat(Material.Leather, Type.Bench);
            seats = new List<Seat> { seat1, seat2, seat3, seat4, seat5 };

            stereo = new Stereo(true, false);
            steroes = new List<Stereo> { stereo };

            powerPlants = new List<IPowerPlant>
            {
                new ElectricMotor(FuelType.Electric,0.02777,258)
            };

            var tesla = new Car("Model 3", "44.411960", "-79.669053", 3814, 75, 55, BodyType.Sedan, 4, true, steroes, seats, powerPlants);

            var vehicles = new List<IVehicle> { car, truck, tesla };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine("{0} runs on {1}", vehicle.Name, vehicle.GetFuelType());
                if (vehicle is Car)
                {
                    var c = (Car)vehicle;
                    var pPlant = c.PowerPlants[0];

                    Console.WriteLine("Trunk is Opened: {0}", c.OpenTrunk());
                    Console.WriteLine("Trunk is Closed: {0}", c.CloseTrunk());
                    Console.WriteLine("Maximum Power Output of {0} is {1}, Number of Cylinders is {2}, Displacement is {3}",
                        c.Name, pPlant.MaximumPowerOutput,
                       pPlant.GetType().ToString().Contains("GasEngine") ? ((GasEngine)pPlant).GetCylinders() : 0,
                       pPlant.GetType().ToString().Contains("GasEngine") ? ((GasEngine)pPlant).GetDisplacement() : 0);
                }
                if (vehicle is Truck)
                {
                    var t = (Truck)vehicle;
                    Console.WriteLine("Current Cargo {0} lbs", t.CargoCapacityLbs);
                    Console.WriteLine("Current Cargo {1} lbs Cargo Loaded: {0}", t.LoadCargo(200), t.CargoCapacityLbs);
                    Console.WriteLine("Current Cargo {1} lbs Cargo Unloaded: {0}", t.UnloadCargo(200), t.CargoCapacityLbs);
                   
                }  
            }


            TimeSpan timeSpan = new TimeSpan(0, 20, 0);

            car.StartPowerPlant();
            truck.StartPowerPlant();
            tesla.StartPowerPlant();

            var previousSecond = DateTime.Now.Second;

            Parallel.For(0, vehicles.Count, v =>
            {
               
                if (vehicles[v] is Car)
                {

                    ((Car)vehicles[v]).PowerPlants[0].ConsumeFuel(timeSpan);
                }
                else
                    ((Truck)vehicles[v]).PowerPlants[0].ConsumeFuel(timeSpan);
            });

        }
    }
}
