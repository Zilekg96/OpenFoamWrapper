using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenFoamWrapper.BoundaryConditions
{
    class BoundaryConditions
    {
        public List<BoundaryField> Boundaries { get; set; }

        public BoundaryConditions() { }

        public BoundaryConditions(string path, ILog Log)
        {
            string TFile = Path.Combine(path, "T");
            string VFile = Path.Combine(path, "V");
            string PFile = Path.Combine(path, "P");
        }
    }
}
