using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;

namespace SerializerFactory
{
    [Serializable]
    [ProtoContract]
    public class Model
    {
        [ProtoMember(1)]
        public string Fname { get; set; }
        [ProtoMember(2)]
        public string Lname { get; set; }
        [ProtoMember(3)]
        public int Age { get; set; }
        [ProtoMember(4)]
        public string Gender { get; set; }

    }


}
