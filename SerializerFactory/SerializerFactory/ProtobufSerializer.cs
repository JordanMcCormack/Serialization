using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace SerializerFactory
{
    class ProtoBufSerializer : ISerializer
    {
        public void Deserialize(Stream myStream)
        {
            Console.WriteLine("Reading from Memory Stream... \n");

            myStream.Position = 0;
            StreamReader st = new StreamReader(myStream);
            Model str = Serializer.Deserialize<Model>(myStream);
            Console.WriteLine("First Name: " + str.Fname);
            Console.WriteLine("Second Name: " + str.Lname);
            Console.WriteLine("Age:  " + str.Age);
            Console.WriteLine("Gender:  " + str.Gender);

        }

        public void Serialize(object details, Stream myStream)
        {
            Console.WriteLine("Writing to Memory Stream... \n");

                Serializer.Serialize(myStream, details);
                var byteArray = myStream;
                myStream.Position = 0;
                Console.WriteLine(byteArray);
        }
    }
}
