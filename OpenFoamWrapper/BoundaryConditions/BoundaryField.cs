using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFoamWrapper.BoundaryConditions
{
    class BoundaryField
    {
        public string Name { get; set; }
        public Pressure P { get; set; }
        public Velocity V { get; set; }
        public Temperature T { get; set; }

        public BoundaryField() { }
    }
}
