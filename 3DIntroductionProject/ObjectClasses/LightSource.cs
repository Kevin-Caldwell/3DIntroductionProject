using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject.ObjectClasses
{
    internal class LightSource : Object
    {
        private double _intensity = 1;
        
        public double Intensity { get { return _intensity; } set { _intensity = value; } }
    }
}
