using System;

namespace _200383524
{
    public class Stereo
    {
        public String Station { get; set; }
        public bool HasBluetooth { get; private set; }
        public bool HasCD { get; private set; }
        public int CDTrack { get; private set; }
        public bool Power { get; set; }
        public IVehicle Vehicle { get; private set; }

        public Stereo(bool hasBluetooth, bool hasCd, string station = null, int cdTrack = 0, bool power = false, IVehicle vehicle = null)
        {
            Station = station;
            HasBluetooth = hasBluetooth;
            HasCD = hasCd;
            CDTrack = cdTrack;
            Power = power;
            Vehicle = vehicle;
        }

        public void ChangeStation(string station)
        {
            Station = station;
        }

        public void ChangeCDTrack(int track)
        {
            if (HasCD)
                CDTrack = track;
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
    }
}