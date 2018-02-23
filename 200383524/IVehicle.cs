using System;
using System.Collections.Generic;

namespace _200383524
{
    public enum BodyType { Coupe, Sedan, Hatchback }

    public interface IVehicle
    {
        String Name { get; }
        String Latitude { get; }
        String Longitue { get; }
        int GrossWeight { get; }
        int FuelCapacity { get; }
        double FuelRemaining { get; }
        List<Seat> Seats { get; }
        List<IPowerPlant> PowerPlants { get; }
        List<Stereo> Stereos { get; }

        bool StartPowerPlant();
        bool ShutdownPowerPlant();
        Enum GetFuelType();
        void UpdateFuelRemaining(double consumedFuel);

    }
}