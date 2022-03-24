using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class ObjectManager
    {
        private List<Object> _objects;
        private int _size;

        public int Size { get { return _size; } }

        public ObjectManager()
        {
            _objects = new List<Object>();
            _size = 0;
        }


        public void registerObject(Object newObject)
        {
            _objects.Add(newObject);
            if (newObject.Name.Equals("") || newObject.Name == null)
            {
                newObject.Name = "Object";
            }
            assignName(newObject);
            _size++;
        }

        public void unregisterObject(string objectName)
        {
            foreach(Object obj in _objects)
            {
                if (obj.Name.Equals(objectName)){
                    _objects.Remove(obj);
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
            foreach(Object obj in _objects)
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
            for(int i=  0; i < _objects.Count; i++)
            {
                if (_objects[i].Name.Contains(unnamedObject.Name)){
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
            for(int i = 0; i < _size; i++)
            {
                objectNameList.Add(_objects[i].Name);
            }
            return objectNameList;
        }
    }
}
