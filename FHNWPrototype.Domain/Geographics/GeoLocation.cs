using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Domain.Geographics
{
    /// <summary>
    /// For the Harvesine formula check <see cref="http://www.movable-type.co.uk/scripts/latlong.html"/>
    /// to create the static maps <seealso cref="https://google-developers.appspot.com/maps/documentation/staticmaps/index#Limits"/>
    /// developer's guide for Google API <see cref="https://google-developers.appspot.com/maps/documentation/javascript/tutorial"/>
    /// For Geolocation API in HTML5 <see cref="http://dev.w3.org/geo/api/spec-source.html"/>
    /// To determine geolocation respect to cities <see cref="http://www.gpsvisualizer.com/geocode"/>

    /// </summary>
    public class GeoLocation
    {

        public virtual int GeoLocationID { get; set; }

        public virtual double  Latitude { get; set; }
        public virtual double  Longitude { get; set; }
        public virtual double Altitude { get; set; }

        public virtual double Accuracy { get; set; }
        public virtual double AltitudeAccuracy { get; set; }

        public virtual double Heading { get; set; }
        public virtual double Speed { get; set; }

        public static double  CalculateDistanceBetweenCoordinates(GeoLocation location1, GeoLocation location2)
        {
            double  radiusOfEarth = 6371;
            double deltaLatitude = ConvertToRadians(location2.Latitude - location1.Latitude);
            double deltaLongitude = ConvertToRadians(location2.Longitude - location1.Longitude);

            double latitude1InRadians = ConvertToRadians(location1.Latitude);
            double latitude2InRadians = ConvertToRadians(location2.Latitude);

            double a = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                       Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2) *
                       Math.Cos(latitude1InRadians) * Math.Cos(latitude2InRadians);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = radiusOfEarth * c;

            return distance;
        }

        public static double ConvertToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

    }
}
