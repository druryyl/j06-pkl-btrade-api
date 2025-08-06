using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model;

public record KategoriType(string KategoriId, string KategoriName);

public interface IKategoriKey
{
    string KategoriId { get; }
}   
