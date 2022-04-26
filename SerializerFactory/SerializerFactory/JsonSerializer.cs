using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace SerializerFactory
{
    public class JsonSerializer : ISerializer
    {
        public void Deserialize(Stream myStream)
        {
#if DEBUG
             Console.WriteLine("Reading from Memory Stream... \n");
#endif
            StreamReader stream = new StreamReader(myStream);
            Model deSerializedData = JsonConvert.DeserializeObject<Model>(stream.ReadToEnd());


#if DEBUG
            Console.WriteLine("\nDeSerialized Data: ");
            Console.WriteLine($"First Name: {deSerializedData.Fname}");
            Console.WriteLine($"Last Name: {deSerializedData.Lname}");
            Console.WriteLine($"Age: {deSerializedData.Age}");
            Console.WriteLine($"Gender: {deSerializedData.Gender}");
#endif

        }

        public void Serialize(object details, Stream myStream)
        {

            string JsonSer = JsonConvert.SerializeObject(details);
            var sw = new StreamWriter(myStream);
#if DEBUG
            Console.WriteLine("Serialized Data: " + JsonSer + "\n");
            Console.WriteLine("Writing to Memory Stream... \n");
#endif
            sw.Write(JsonSer);
            sw.Flush();

        }
    }
}
