using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DIntroductionProject
{
    internal class ObjectManager
    {
        #region Fields
        private List<Object> _objects;
        private int _size;
        private DataGridView _grid;
        private Camera _camera;

        private Object _selectedObject;
        #endregion

        #region Properties
        public int Size { get { return _size; } }
        public Object SelectedObject { get { return _selectedObject; } set { _selectedObject = value; } }
        public List<Object> Objects { get { return _objects; } set { _objects = value; } }
        public Camera ViewportCamera { get { return _camera; } set { _camera = value; } }
        #endregion

        #region Constructor
        public ObjectManager(DataGridView grid, Camera viewportCamera)
        {
            _objects = new List<Object>();
            _size = 0;
            _grid = grid;
            _camera = viewportCamera;
        }
        #endregion

        #region Instance Methods
        public void registerObject(Object newObject)
        {
            _objects.Add(newObject);
            if (newObject.Name.Equals("") || newObject.Name == null)
            {
                newObject.Name = "Object";
            }
            assignName(newObject);
            _grid.Rows.Add(newObject.Name);
            _size++;
            _selectedObject = newObject;
        }

        public void unregisterObject(string objectName)
        {
            for (int i = 0; i < Size; i++)
            {
                if (_objects[i].Name.Equals(objectName))
                {
                    _objects.Remove(_objects[i]);
                    _grid.Rows.RemoveAt(i);
                }
            }
            _size--;
        }

        public Object GetObject(int index)
        {
            return _objects[index];
        }

        public Object GetObject(string name)
        {
            Object requiredObject = null;
            foreach (Object obj in _objects)
            {
                if (obj.Name.Equals(name))
                {
                    requiredObject = obj;
                }
            }
            return requiredObject;
        }

        public void assignName(Object unnamedObject)
        {
            int index = 0;
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].Name.Contains(unnamedObject.Name))
                {
                    index++;
                }
            }

            if (index > 0)
            {
                unnamedObject.Name += index;
            }
        }

        public List<string> getObjectNameList()
        {
            List<string> objectNameList = new List<string>();
            for (int i = 0; i < _size; i++)
            {
                objectNameList.Add(_objects[i].Name);
            }
            return objectNameList;
        }

        public void UpdateTransforms()
        {
            foreach (Object obj in _objects)
            {
                obj.UpdateTransformedVertices();
            }
        }
        #endregion
    }
}
