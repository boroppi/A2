using System;

namespace _200383524
{
    public class GasEngine : IInternalCombustion

    {
        public Enum FuelType { get; private set; }
        public bool Running { get; private set; }
        public double AverageFuelRatePerSecond { get; private set; }
        public int MaximumPowerOutput { get; private set; }
        public IVehicle Vehicle { get; private set; }
        public int Cylinders { get; private set; }
        public int Displacement { get; private set; }

        public GasEngine(Enum fuelType, double averageFuelRatePerSecond, int maximumPowerOutput,
            int cylinders, int displacement, bool running = false, IVehicle vehicle = null)
        {
            FuelType = fuelType;
            Running = running;
            AverageFuelRatePerSecond = averageFuelRatePerSecond;
            MaximumPowerOutput = maximumPowerOutput;
            Vehicle = vehicle;
            Cylinders = cylinders;
            Displacement = displacement;

        }
        
        /// <summary>
        /// Returns number of Cylinders
        /// </summary>
        /// <returns>int</returns>
        public int GetCylinders()
        {
            return Cylinders;
        }

        /// <summary>
        /// Returns displacement value of the engine
        /// </summary>
        /// <returns>int</returns>
        public int GetDisplacement()
        {
            return Displacement;
        }

        /// <summary>
        /// Returns Maximum output of the engine
        /// </summary>
        /// <returns>int</returns>
        public int GetMaximumPowerOutput()
        {
            return MaximumPowerOutput;
        }

        /// <summary>
        /// Returns true if the engine is not running and if the vehicle has fuel left and sets Running property to true.
        /// </summary>
        /// <returns>bool</returns>
        public bool Start()
        {
            if (!Running && Vehicle.FuelRemaining > 0)
            {
                Running = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if the engine is running and sets Running property to false
        /// </summary>
        /// <returns>bool</returns>
        public bool Stop()
        {
            if (Running)
            {
                Running = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Used to set Vehicle property of this class when IVehicle object is constructed
        /// </summary>
        /// <param name="vehicle"></param>
        public void RegisterToCar(IVehicle vehicle)
        {
            if (vehicle != null)
                Vehicle = vehicle;
        }

        /// <summary>
        /// Checks if the engine is running and has fuel left then consumes the remaining fuel based on AverageFuelRatePerSecond property
        /// </summary>
        /// <param name="timeSpan"></param>
        public void ConsumeFuel(TimeSpan timeSpan)
        {
            var previousSecond = DateTime.Now.Second;
            while (true)
            {
                if (DateTime.Now.Second != previousSecond)
                {
                    timeSpan = timeSpan.Subtract(new TimeSpan(0, 0, 1));
                    previousSecond = DateTime.Now.Second;
                    if (Running && Vehicle.FuelRemaining > 0)
                    {
                        Vehicle.UpdateFuelRemaining(AverageFuelRatePerSecond);
                    }

                    Console.WriteLine("{2} : Remaining Fuel for {0,7}: {1,4:F1} ",
                        Vehicle.Name, Vehicle.FuelRemaining, timeSpan);

                }
            }
        }
    }
}
