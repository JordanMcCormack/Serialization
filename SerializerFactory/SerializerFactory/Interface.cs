using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SerializerFactory
{

    public enum SerializerType
    {
        Xml,
        Json,
        Protobuf
    }

    public interface ISerializer
    {

        void Serialize(object details, Stream myStream);
        void Deserialize(Stream myStream);

    }


}
