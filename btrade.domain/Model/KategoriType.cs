using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model;

public record KategoriType(string KategoriId, string KategoriName, string ServerId) : IKategoriKey;

public interface IKategoriKey : IServerId
{
    string KategoriId { get; }
}   
