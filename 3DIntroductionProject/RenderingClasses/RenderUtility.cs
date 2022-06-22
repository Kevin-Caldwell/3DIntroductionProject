using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace _3DIntroductionProject
{
    internal class RenderUtility
    {
        #region Fields

        private readonly Camera ViewportCamera;
        private readonly ObjectManager ObjectStorage;

        private readonly RenderMode renderTool;
        private readonly BitmapDrawing bitmapDrawing;

        private readonly ObjectPackager packager;

        public bool isRendering = false;
        #endregion

        #region Constructors
        public RenderUtility(ObjectManager OM, PictureBox pictureBox)
        {
            ObjectStorage = OM;
            ViewportCamera = OM.ViewportCamera;

            bitmapDrawing = new BitmapDrawing(pictureBox);
            //renderTool = new WireframeRenderMode(bitmapDrawing.Graphics, ViewportCamera);
            renderTool = new SolidRenderMode(bitmapDrawing.Graphics, ViewportCamera);
            packager = new ObjectPackager();
        }
        #endregion

        #region Instance Methods
        public void Refresh()
        {
            List<object> RenderQueue = packager.PrepareRenderingQueue(ObjectStorage.Objects);
            renderTool.Render(RenderQueue);
            bitmapDrawing.RefreshBitmap();
        }
     
        #endregion
    }
}

