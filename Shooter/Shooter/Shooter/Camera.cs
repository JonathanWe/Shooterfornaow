using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Camera
    {
        Vector2 position;
        public Vector2 Offset;
        public Vector2 Position { get { return position; } 
            set
            {
                position = value;
                
            } 
        }
    }
}
