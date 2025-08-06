using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model;

public record WilayahType(string WilayahId, string WilayahName) : IWilayahKey;

public interface IWilayahKey
{
    string WilayahId { get; }
}
