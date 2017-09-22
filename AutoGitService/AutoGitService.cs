using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;

namespace AutoGitService
{
    public partial class AutoGitService : ServiceBase
    {
        public AutoGitService()
        {
            InitializeComponent();
        }
        string filePath = "F:\\temp.txt";
        static int i = 0;
        Timer _timer = new Timer();

        protected override void OnStart(string[] args)
        {
            _timer.AutoReset = true;
            _timer.Interval = 2000;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Stream fs = File.OpenWrite(filePath);
            TextWriter sw = new StreamWriter(fs);
            i++;
            sw.WriteLine(i.ToString() + ", hi, this is my first Services");
            sw.Flush();
            sw.Close();
        }

        protected override void OnStop()
        {
            Stream fs = File.OpenWrite(filePath);
            TextWriter sw = new StreamWriter(fs);
            sw.WriteLine("panel !!!!!!!!!!!!!!!");
            sw.Flush();
            sw.Close();
        }
    }
}
