using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _200383524
{
   
    public class Car : IVehicle
    {
        public string Name { get; protected set; }
        public string Latitude { get; protected set; }
        public string Longitue { get; protected set; }
        public int GrossWeight { get; protected set; }
        public int FuelCapacity { get; protected set; }
        public double FuelRemaining { get; private set; }
        public BodyType CarBody { get; private set; }
        public int Doors { get; private set; }
        public bool HasTrunk { get; private set; }
        public bool TrunkOpen { get; private set; }
        public List<Seat> Seats { get; private set; }
        public List<IPowerPlant> PowerPlants { get; private set; }
        public List<Stereo> Stereos { get; private set; }

        public Car(string name, string latitude, string longitue, int grossWeight, int fuelCapacity,
            double fuelRemaining, BodyType carBody, int doors, bool hasTrunk, List<Stereo> stereos = null, List<Seat> seats = null,
            List<IPowerPlant> powerPlants = null, bool trunkOpen = false)
        {
            Name = name;
            Latitude = latitude;
            Longitue = longitue;
            GrossWeight = grossWeight;
            FuelCapacity = fuelCapacity;
            FuelRemaining = fuelRemaining;
            CarBody = carBody;
            Doors = doors;
            HasTrunk = hasTrunk;
            TrunkOpen = trunkOpen;
            Seats = new List<Seat>();

            if (seats != null)
            {
                Seats = seats;
                foreach (var seat in seats)
                {
                    seat.RegisterToCar(this);
                }
            }

            PowerPlants = new List<IPowerPlant>();

            if (powerPlants != null)
            {
                PowerPlants = powerPlants;
                foreach (var powerPlant in powerPlants)
                {
                    powerPlant.RegisterToCar(this);
                }
            }
            Stereos = new List<Stereo>();
          
            if (stereos != null)
            {
                Stereos = stereos;
                foreach (var stereo in stereos)
                {
                    stereo.RegisterToCar(this);
                }
            }

        }

        /// <summary>
        /// Checks if FuelRemaining is greater than consumedFuel if so substrack the consumed amount from it and updates it otherwise sets it to zero.
        /// </summary>
        /// <param name="consumedFuel"></param>
        public void UpdateFuelRemaining(double consumedFuel)
        {
            if (FuelRemaining > consumedFuel)
                FuelRemaining -= consumedFuel;
            else
            {
                FuelRemaining = 0;
            }
        }

        /// <summary>
        /// Loops through powerplants and sets calls Start method which checks if they are not running and has fuel remanining 
        /// if so returns true and sets Running to true otherwise returns false
        /// </summary>
        /// <returns>bool</returns>
        public bool StartPowerPlant()
        {
            foreach (var powerPlant in PowerPlants)
            {
                if (powerPlant.Start())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Loops through powerplants and sets calls Stop method which checks if they are running if so returns true 
        /// and sets Running to false otherwise returns false
        /// </summary>
        /// <returns>bool</returns>
        public bool ShutdownPowerPlant()
        {
            foreach (var powerPlant in PowerPlants)
            {
                if (powerPlant.Stop())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the type fuel the engine runs on.
        /// </summary>
        /// <returns>Enum</returns>
        public Enum GetFuelType()
        {
            return PowerPlants[0].FuelType; // I don't know what to do if the car has multiple fuel types UML says return only one enum
        }

        /// <summary>
        /// Returns false if TrunkOpen is true otherwise returns true and sets TrunkOpen to true
        /// </summary>
        /// <returns>bool</returns>
        public bool OpenTrunk()
        {
            if (TrunkOpen)
                return false;

            TrunkOpen = true;
            return true;
        }

        /// <summary>
        /// Returns false if TrunkOpen is false otherwise returns true and sets TrunkOpen to false
        /// </summary>
        /// <returns>bool</returns>
        public bool CloseTrunk()
        {
            if (!TrunkOpen)
                return false;

            TrunkOpen = false;
            return true;
        }



    }
}