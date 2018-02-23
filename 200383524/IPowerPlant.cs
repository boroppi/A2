using System;
using System.Runtime.Remoting.Messaging;

namespace _200383524
{
    public enum FuelType { Gas, Diesel, Electric }
    public interface IPowerPlant
    {
        Enum FuelType { get; }
        bool Running { get; }
        double AverageFuelRatePerSecond { get; }
        int MaximumPowerOutput { get; }
        IVehicle Vehicle { get; }

        void RegisterToCar(IVehicle vehicle);
        int GetMaximumPowerOutput();
        bool Start();
        bool Stop();
        void ConsumeFuel(TimeSpan timeSpan);

    }
}