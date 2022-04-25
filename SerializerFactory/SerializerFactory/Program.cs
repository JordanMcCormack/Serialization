using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SerializerFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Model details = new Model
            {
                Fname = "Jordannnnnnn",
                Lname = "McCormack",
                Age = 22,
                Gender = "Male"
            };


            var timer = new Stopwatch();
            var myStream = new MemoryStream();
            myStream.Seek(0, SeekOrigin.Begin);

            var mySerializer = SerializerFactory.GetSerializer(SerializerType.Protobuf);
            mySerializer.Serialize(details, myStream);
            mySerializer.Deserialize(myStream);


        }
    }


}
