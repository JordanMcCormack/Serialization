using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializerFactory
{
    public class XmlSerialization : ISerializer
    {

        public void Deserialize(Stream myStream)
        {
#if DEBUG

            Console.WriteLine("Reading from Memory Stream... \n");
#endif

            myStream.Position = 0;
            var xmlDeserializer = new XmlSerializer(typeof(Model));

            try
            {
                using (StreamReader stream = new StreamReader(myStream))
                {
                    var StreamReader = new XmlTextReader(stream);
                    var result = (Model)xmlDeserializer.Deserialize(StreamReader);

#if DEBUG
                    Console.WriteLine("First Name: " + result.Fname);
                    Console.WriteLine("Last Name: " + result.Lname);
                    Console.WriteLine("Age: " + result.Age);
                    Console.WriteLine("Gender: " + result.Gender);
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

            var xmlSerializer = new XmlSerializer(typeof(Model));
            using (var stream = new StringWriter())
            {
                xmlSerializer.Serialize(stream, details);
                var xmlContent = stream.ToString();
                var sw = new StreamWriter(myStream);
                sw.Write(xmlContent);
                sw.Flush();
#if DEBUG
                Console.WriteLine(xmlContent + "\n");

                Console.WriteLine("Writing to Memory Stream... \n");
#endif
            }


        }
    }
}
