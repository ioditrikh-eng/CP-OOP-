using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public interface IJsonSerializable
    {
        void SaveToJson(string path);
        void LoadFromJson(string path);
    }
}
