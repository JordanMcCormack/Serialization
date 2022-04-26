using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace SerializerFactory
{
    class JsonSerializerUtf8 : ISerializer
    {

        public void Deserialize(Stream myStream)
        {


               try
               {
                   var ms = myStream as MemoryStream;
                   byte[] bytes = ms.ToArray();
                   var utf8Reader = new Utf8JsonReader(bytes);
                   Model str = System.Text.Json.JsonSerializer.Deserialize<Model>(ref utf8Reader)!;
#if DEBUG
                Console.WriteLine("First Name: " + str.Fname);
                Console.WriteLine("Last Name: " + str.Lname);
                Console.WriteLine("Age: " + str.Age);
                Console.WriteLine("Gender" + str.Gender);
#endif
               }
               catch (Exception e)
               {
                   Console.WriteLine(e);
               }
               

        }

        public void Serialize(object details, Stream myStream)
        {
#if DEBUG
            Console.WriteLine("Writing to Memory Stream... \n");
#endif

            var st = new BinaryWriter(myStream);
            byte[] jsonUtf8Bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(details);
            st.Write(jsonUtf8Bytes);
            st.Flush();


        }
    }
}
