using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCrontrol
{
    public class MainCtrl : IDisposable
    {

        protected Process _Process { get; set; }
        protected string _Prog { get; set; }
        protected string _Args { get; set; }

        // MainCtrl default constructor
        public MainCtrl()
        {
            // do stuff eventually
        }
        // run program
        public Process RunProg(string prog)
        {
            _Prog = prog;
            return Execute();
        }

        // kill program
        public void KillProg()
        {
            _Process.Kill();
        }

        // start streams
        private Process Execute()
        {
            // init process and start info
            _Process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();            
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = _Prog;
            //startInfo.Arguments = "/C dir";
            // set startinfo and return process
            _Process.StartInfo = startInfo;
            return _Process;           
        }

        public void Dispose() {
            // dispose things
            _Process = null;
            _Prog = null;
           
            // dispose finalize
            GC.SuppressFinalize(this);
        }

    }
}
