using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model;

public record CustomerType(string CustomerId, string CustomerCode,
    string CustomerName, string Alamat, string Wilayah) : ICustomerKey;

public interface ICustomerKey
{
    string CustomerId { get; }
}