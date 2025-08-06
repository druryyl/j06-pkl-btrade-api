using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model;

public record SalesPersonType(string SalesPersonId, string SalesPersonCode,
    string SalesPersonName);

public interface ISalesPersonKey
{
    string SalesPersonId { get; }
}