namespace _200383524
{
    public enum Material { Cloth, Leather }
    public enum Type { Bucket, Bench, Captain }

    public class Seat
    {
        private bool SeatbeltBuckled { get; set; }
        public Material SeatMaterial { get; protected set; }
        public Type SeatType { get; protected set; }
        public IVehicle Vehicle { get; private set; }

        public Seat( Material seatMaterial, Type seatType, IVehicle vehicle = null, bool seatbeltBuckled = false)
        {
            SeatbeltBuckled = seatbeltBuckled;
            SeatMaterial = seatMaterial;
            SeatType = seatType;
            Vehicle = vehicle;
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
        /// Checks if SeatbeltBuckled is false then sets it true and returns true otherwise returns false
        /// </summary>
        /// <returns></returns>
        public bool FastenSeatbelt()
        {
            if (!SeatbeltBuckled)
            {
                SeatbeltBuckled = true;
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Checks if SeatbeltBuckled is true if so returns true and sets it to false otherwise returns false
        /// </summary>
        /// <returns></returns>
        public bool UnBuckleSeatbelt()
        {
            if (SeatbeltBuckled)
            {
                SeatbeltBuckled = false;
                return true;
            }
            return false;
        }
    }
}