using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenFoamWrapper.System
{
    public class Control
    {
        public string ModelVersion { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public float DeltaT { get; set; }
        public float WriteInterval { get; set; }
        public int WritePrecision { get; set; }

        public Control() { }

        public Control(string path, ILog Log)
        {
            using(StreamReader r = new StreamReader(Path.Combine(path, "controlDict")))
            {
                string[] fileText = r.ReadToEnd().Split("\n");

                this.ModelVersion = fileText.FirstOrDefault(e => e.Contains("version")).Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace(";", "");
                this.StartTime = float.Parse(fileText.FirstOrDefault(e => e.StartsWith("startTime")).Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace(";", ""));
                this.EndTime = float.Parse(fileText.FirstOrDefault(e => e.StartsWith("endTime")).Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace(";", ""));
                this.DeltaT = float.Parse(fileText.FirstOrDefault(e => e.StartsWith("deltaT")).Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace(";", ""));
                this.WriteInterval = float.Parse(fileText.FirstOrDefault(e => e.StartsWith("writeInterval")).Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace(";", ""));
                this.WritePrecision = Int32.Parse(fileText.FirstOrDefault(e => e.StartsWith("writePrecision")).Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace(";", ""));

                Log.Info($"Model version: {this.ModelVersion}");
                Log.Info($"Simulation start time: {this.StartTime}");
                Log.Info($"Simulation end time: {this.EndTime}");
                Log.Info($"Simulation step: {this.DeltaT}");
                Log.Info($"Simulation results write interval: {this.WriteInterval}");
                Log.Info($"Simulation results write precision: {this.WritePrecision}");
            }
        }
    }
}
