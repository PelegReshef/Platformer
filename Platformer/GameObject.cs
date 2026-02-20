using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    internal class GameObject
    {
        public Vector2 Vector2 { get; set; } = Vector2.Zero;

        List<Component> components = new List<Component>();
        public GameObject()
        {

        }
        public void AddComponent(Component component)
        {
            components.Add(component);
        }
    }
}
