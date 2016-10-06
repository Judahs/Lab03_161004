using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public interface IVehicle
    {
        string Name { get; }
        double GetMetersPerSecond { get; } //Force classes to have a getter for speed in m/s
        void SetSpeed(double input);
        double GetSpeed();
        string RandomNames();
    }
    public enum VehicleType { unidentified, car, boat, motorcycle, all, search}
}
