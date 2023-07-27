using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal sealed class GameObject
    {
        internal static List<GameObject> s_rootGameObjects = new List<GameObject> ();

        public bool Active = true;
        public Vector2f Position;

        internal List<GameObject> _children = new List<GameObject>();
        internal GameObject? _parent;
        internal List<Behavior> _components = new List<Behavior>();

        public GameObject() 
        {
            s_rootGameObjects.Add(this);
        }

        public GameObject(Vector2f position) 
        {
            this.Position = position;
            s_rootGameObjects.Add(this);
        }

        public GameObject(GameObject parent)
        {
            _parent = parent;
            parent._children.Add(this);
        }

        public GameObject(Vector2f position, GameObject parent)
        {
            this.Position = position;
            _parent = parent;
            parent._children.Add(this);
        }

        public void AddComponent(Behavior behavior)
        {
            this._components.Add(behavior);
            behavior._setGameObject(this);
        }

        public MyComponent? GetComponent<MyComponent>() where MyComponent : Behavior
        {
            foreach (var component in _components)
            {
                if (component is MyComponent)
                {
                    return (MyComponent)component;
                }
            }

            return null;
        }

        public static void UpdateRoot(float deltaTime)
        {
            foreach (var rootObject in s_rootGameObjects)
            {
                rootObject.Update(deltaTime);
            }
        }

        public static void DrawRoot(RenderWindow window)
        {
            foreach (var rootObject in s_rootGameObjects)
            {
                rootObject.Draw(window);
            }
        }

        public static void StartRoot()
        {
            foreach (var rootObject in s_rootGameObjects)
            {
                rootObject.Start();
            }
        }

        public void Start()
        {
            if (Active)
            {
                foreach (var component in _components)
                {
                    component.Start();
                }

                foreach (var child in _children)
                {
                    child.Start();
                }
            }
        }

        public void Update(float deltaTime)
        {
            if (Active)
            {
                foreach (var component in _components)
                {
                    component.Update(deltaTime);
                }

                foreach (var child in _children)
                {
                    child.Update(deltaTime);
                }
            }
        }

        internal void Draw(RenderWindow window)
        {
            if (Active)
            {
                foreach (var component in _components)
                {
                    component.Draw(window);
                }

                foreach (var child in _children)
                {
                    child.Draw(window);
                }
            }
        }
    }
}
