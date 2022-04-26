using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json;

namespace SerializerFactory
{
    public sealed class CommandLineOptions
    {
        [Option('t', "type", Required = true, HelpText = "Serializer Type", Default = "Json")]
        public SerializerType type { get; set; }
        [Option('l', "Loop", Required = false, HelpText = "Iterations", Default = 1)]
        public int loop { get; set; }
    }
}
