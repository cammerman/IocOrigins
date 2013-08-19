using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins
{
    class CliOptions
    {
        [Option("c", DefaultValue=null, HelpText="Create a normal user.")]
        public string UserToCreate { get; set; }

        [Option("a", DefaultValue=false, HelpText="Create an admin user.")]
        public bool Admin { get; set; }

        [Option("p", DefaultValue=null, HelpText="Promote a user to admin.")]
        public string UserToPromote{ get; set; }

        [Option("d", DefaultValue=null, HelpText="Delete a user.")]
        public string UserToDelete { get; set; }

        [HelpOption]
        public string GetUsage()
        {
          return HelpText.AutoBuild(this,
            (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
