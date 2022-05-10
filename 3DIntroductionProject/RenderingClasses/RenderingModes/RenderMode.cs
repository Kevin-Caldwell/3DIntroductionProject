using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    /// <summary>
    /// Parent class of all Rendering modes
    /// </summary>
    abstract internal class RenderMode
    {
        protected readonly Graphics _graphics;
        protected readonly Camera ViewportCamera;

        public RenderMode(Graphics graphics, Camera cam)
        {
            _graphics = graphics; 
            ViewportCamera = cam;
        }

        public abstract void Render(List<object> ObjectAttributes);
    }
}
