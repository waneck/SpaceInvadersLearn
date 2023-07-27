using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Components
{
    internal class Enemy : Behavior
    {
        public Laser? laser;

        public override void Start()
        {
            laser!.StartShooting(GameObject.Position);
        }
    }
}
