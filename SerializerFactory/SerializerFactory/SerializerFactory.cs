using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializerFactory
{
      class SerializerFactory // Factory Class
      {

          public static ISerializer GetSerializer(SerializerType type)
        {

            switch (type)
            {
                case SerializerType.Json:
                    return new JsonSerializer();
                case SerializerType.Xml:
                    return new XmlSerialization();
                case SerializerType.Protobuf:
                    return new ProtoBufSerializer();
                case SerializerType.JsonUTF:
                    return new JsonSerializerUtf8();
                case SerializerType.Binary:
                    return new BinarySerializer();
                default:
                    throw new NotImplementedException();
            }


        }



    }
}
