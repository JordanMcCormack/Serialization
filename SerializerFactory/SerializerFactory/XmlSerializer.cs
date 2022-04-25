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

            Console.WriteLine("Reading from Memory Stream... \n");
            myStream.Position = 0;
            var xmlDeserializer = new XmlSerializer(typeof(Model));

            try
            {
                using (StreamReader stream = new StreamReader(myStream))
                {
                    var StreamReader = new XmlTextReader(stream);
                    var result = (Model)xmlDeserializer.Deserialize(StreamReader);

                    Console.WriteLine("First Name: " + result.Fname);
                    Console.WriteLine("Last Name: " + result.Lname);
                    Console.WriteLine("Age: " + result.Age);
                    Console.WriteLine("Gender: " + result.Gender);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void Serialize(object details, Stream myStream)
        {

            Console.WriteLine("Writing to Memory Stream... \n");

            var xmlSerializer = new XmlSerializer(typeof(Model));
            using (var stream = new StringWriter())
            {
                xmlSerializer.Serialize(stream, details);
                var xmlContent = stream.ToString();
                var sw = new StreamWriter(myStream);
                sw.Write(xmlContent);
                sw.Flush();
                Console.WriteLine(xmlContent + "\n");
            }


        }
    }
}
