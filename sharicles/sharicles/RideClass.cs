using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace sharicles
{
    /// <summary>
    /// Abstract Base class for ShareRide & GetRide
    /// </summary>
    public abstract class Ride
    {
        /// <summary>
        /// ID = 
        /// </summary>
        public ulong ID { get; set; }
        /// <summary>
        /// Location of Ride
        /// </summary>
        public Geopoint Location { get; set; }
        /// <summary>
        /// RideMode
        /// </summary>
        public enum RideMode
        {
            Bike,
            Car,
            Cycle
        }
        /// <summary>
        /// Ride get set
        /// </summary>
        public RideMode ride { get; set; }
        /// <summary>
        /// Availability
        /// </summary>
        public int Number { get; set; }
    }

    public class ShareRide : Ride
    {

    }

    public class GetRide : Ride
    {

    }
}
