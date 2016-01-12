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
        /// ID for each Ride
        /// </summary>
        public ulong ID { get; set; }
        /// <summary>
        /// Start Location of Ride
        /// </summary>
        public Geopoint StartLocation { get; set; }
        /// <summary>
        /// End Location of Ride`
        /// </summary>
        public Geopoint EndLocation { get; set; }
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
        /// Vacancy in Ride
        /// </summary>
        public int Vacancy { get; set; }
        /// <summary>
        /// TimeSpan
        /// </summary>
        public TimeSpan Time { get; set; }
    }

    public class ShareRide : Ride
    {

    }

    public class GetRide : Ride
    {

    }
}
