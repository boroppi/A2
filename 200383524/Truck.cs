using System;
using System.Collections.Generic;

namespace _200383524
{
    public class Truck : IVehicle
    {
        public string Name { get; protected set; }
        public string Latitude { get; protected set; }
        public string Longitue { get; protected set; }
        public int GrossWeight { get; protected set; }
        public int FuelCapacity { get; protected set; }
        public double FuelRemaining { get; private set; }
        public int CargoCapacityLbs { get; private set; }
        public List<Seat> Seats { get; private set; }
        public List<IPowerPlant> PowerPlants { get; private set; }
        public List<Stereo> Stereos { get; }

        public Truck(string name, string latitude, string longitue, int grossWeight, int fuelCapacity, double fuelRemaining,
            int cargoCapacityLbs = 0, List<Stereo> stereos = null, List<Seat> seats = null, List<IPowerPlant> powerPlants = null)
        {
            Name = name;
            Latitude = latitude;
            Longitue = longitue;
            GrossWeight = grossWeight;
            FuelCapacity = fuelCapacity;
            FuelRemaining = fuelRemaining;
            CargoCapacityLbs = cargoCapacityLbs;
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
            return PowerPlants[0].FuelType;
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
        /// Checks if it can contain the cargo and updates the cargo weight
        /// </summary>
        /// <param name="weightLbs"></param>
        /// <returns>bool</returns>
        public bool LoadCargo(int weightLbs)
        {
            if (CargoCapacityLbs + weightLbs <= GrossWeight)
            {
                CargoCapacityLbs += weightLbs;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if weight of the cargo to unload is smaller or equal to weight of loaded cargo 
        /// if so returns true and unloads the cargo otherwise returns false
        /// </summary>
        /// <param name="weightLbs"></param>
        /// <returns></returns>
        public bool UnloadCargo(int weightLbs)
        {
            if (weightLbs <= CargoCapacityLbs)
            {
                CargoCapacityLbs -= weightLbs;
                return true;
            }
            return false;
        }


    }
}