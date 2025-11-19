using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model;

public record CustomerType(string CustomerId, string CustomerCode,
    string CustomerName, string Alamat, string Wilayah,
    double Latitude, double Longitude, double Accuracy,
    long CoordinateTimeStamp, string CoordinateUser, bool IsUpdated) : ICustomerKey
{
    public CustomerType SetLocation(double lat, double lon, double accuracy, long coordinateTimeStamp,
        string coordinateUser)
    {
        var result = this with
        {
            Latitude = lat,
            Longitude = lon,
            Accuracy = accuracy,
            CoordinateTimeStamp = coordinateTimeStamp,
            CoordinateUser = coordinateUser,
            IsUpdated = true
        };
        return result;
    }
}

public record CustomerKey(string CustomerId) : ICustomerKey;
public interface ICustomerKey
{
    string CustomerId { get; }
}