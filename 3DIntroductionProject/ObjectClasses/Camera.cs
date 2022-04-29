using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Camera : Object
    {
        #region Fields
        private const double DEG_TO_RAD = 0.0174532925199433;
        private Point _screenSize, _halfScreenSize;
        private double _aspectRatio;

        private OrthonormalBasis _basis;

        private double _fov;

        private double invYTan;
        private double invZTan;
        #endregion

        #region Properties
        public OrthonormalBasis Basis { get { return _basis; } set { _basis = value; } }
        public Point ScreenSize { get { return _screenSize; } set { _screenSize = value; } }
        public double FOV { get { return _fov; } set { _fov = value; } }
        #endregion

        #region Constructors
        public Camera(Vector3 forward, Vector3 up, Vector3 position, Point screenSize)
        {
            InitializeCamera(forward, up, position, 70, screenSize);
        }
        public Camera(Vector3 forward, Vector3 up, Vector3 position, double fieldOfView, Point screenSize)
        {
            InitializeCamera(forward, up, position, fieldOfView, screenSize);
        }
        #endregion

        #region Instance Methods
        public void InitializeCamera(Vector3 forward, Vector3 up, Vector3 position, double fieldOfView, Point screenSize)
        {
            _basis = new OrthonormalBasis(forward, up);
            _basis.Position = position;
            _basis.generateBasis(forward, up);
            _screenSize = screenSize;
            _aspectRatio = ((double)_screenSize.X) / _screenSize.Y;
            _halfScreenSize = new Point(_screenSize.X / 2, _screenSize.Y / 2);
            

            SetFieldOfView(fieldOfView);
        }
        public void SetFieldOfView(double fieldOfView)
        {
            double fieldOfViewRad = fieldOfView * DEG_TO_RAD * 0.5; //(FOV in radians) / 2

            _fov = fieldOfView;

            //Calculate tangent reciprocals for quick computation of quotients (via multiplication)
            invYTan = 1.0 / Math.Tan(fieldOfViewRad);
            invZTan = 1.0 / (Math.Tan(fieldOfViewRad / _aspectRatio));
        }
        /// <summary>
        /// Calculates the Screen Coordinates of a given vertex.
        /// </summary>
        /// <param name="proj">Vector3 relative to Camera</param>
        /// <returns> A PointF Object </returns>
        public PointF ToScreen(Vector3 proj)
        {
            proj = ToCameraCoordinates(proj);
            PointF screen = new PointF();

            double x = proj.X, y = proj.Y, z = proj.Z;

            if (x < 0)
            {
                screen.X = (float)(y / x * invYTan * _halfScreenSize.X + _halfScreenSize.X);
                screen.Y = (float)(z / x * invZTan * _halfScreenSize.Y + _halfScreenSize.Y);
            }

            return screen;
        }

        /// <summary>
        /// Converts a Vector3 relative 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector3 ToCameraCoordinates(Vector3 v)
        {
            return _basis.projectOntoAxes(v, true);
        }
        #endregion
    }
}
