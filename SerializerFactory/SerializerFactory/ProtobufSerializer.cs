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

            myStream.Position = 0;
            Model str = Serializer.Deserialize<Model>(myStream);

#if DEBUG
            Console.WriteLine("Reading from Memory Stream... \n");
             Console.WriteLine("First Name: " + str.Fname);
            Console.WriteLine("Second Name: " + str.Lname);
            Console.WriteLine("Age:  " + str.Age);
            Console.WriteLine("Gender:  " + str.Gender);
#endif

          

        }

        public void Serialize(object details, Stream myStream)
        {

            Serializer.Serialize(myStream, details);
            var byteArray = myStream;

#if DEBUG
            Console.WriteLine("Writing to Memory Stream... \n");
             Console.WriteLine(byteArray);
#endif

        }
    }
}
