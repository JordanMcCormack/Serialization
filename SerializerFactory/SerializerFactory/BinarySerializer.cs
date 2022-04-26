using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializerFactory
{
    class BinarySerializer : ISerializer
    {
       public void Deserialize(Stream myStream)
        {

            try
           {
               using (myStream)
               {
                   myStream.Position = 0;
                   BinaryFormatter bf = new BinaryFormatter();
                   Model res = (Model)bf.Deserialize(myStream);
#if DEBUG
                   Console.WriteLine($"First Name: {res.Fname}");
                   Console.WriteLine($"Last Name: {res.Lname}");
                   Console.WriteLine($"Age: {res.Age}");
                   Console.WriteLine($"Gender: {res.Gender}");
#endif
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }
           



        }

        public void Serialize(object details, Stream myStream)
        {
#if DEBUG
     
#endif

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(myStream, details);
            myStream.Flush();

        }
    }
}
