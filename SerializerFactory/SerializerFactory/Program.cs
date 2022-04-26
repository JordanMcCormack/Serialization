using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CommandLine;

namespace SerializerFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(RunOptions).
                WithNotParsed(HandleParserError);

        }


        private static void RunOptions(CommandLineOptions opts)
        {
            Model details = new Model
            {
                Fname = "Jordan",
                Lname = "McCormack",
                Age = 22,
                Gender = "Male"
            };

            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < opts.loop; i++)
            {
                using (var myStream = new MemoryStream())
                {
                    var mySerializer = SerializerFactory.GetSerializer(opts.type);
                    mySerializer.Serialize(details, myStream);

                    myStream.Seek(0, SeekOrigin.Begin);

                    mySerializer.Deserialize(myStream);

                    
                }
                    
            }
            timer.Start();
            Console.WriteLine(timer.ElapsedMilliseconds);

        }

        private static void HandleParserError(IEnumerable errs)
        {
            Console.WriteLine("TEST TEST");
        }

    }





}
