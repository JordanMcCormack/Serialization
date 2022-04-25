using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace SerializerFactory
{
    public class JsonSerializer : ISerializer
    {
        public void Deserialize(Stream myStream)
        {
            Console.WriteLine("Reading from Memory Stream... \n");
            myStream.Position = 0;
            StreamReader stream = new StreamReader(myStream);

            Model deSerializedData = JsonConvert.DeserializeObject<Model>(stream.ReadToEnd());
            Console.WriteLine("\nDeSerialized Data: ");
            Console.WriteLine($"First Name: {deSerializedData.Fname}");
            Console.WriteLine($"Last Name: {deSerializedData.Lname}");
            Console.WriteLine($"Age: {deSerializedData.Age}");
            Console.WriteLine($"Gender: {deSerializedData.Gender}");

        }

        public void Serialize(object details, Stream myStream)
        {

            string JsonSer = JsonConvert.SerializeObject(details);
            var sw = new StreamWriter(myStream);
            Console.WriteLine("Serialized Data: " + JsonSer + "\n");
            Console.WriteLine("Writing to Memory Stream... \n");
            sw.Write(JsonSer);
            sw.Flush();


        }
    }
}
