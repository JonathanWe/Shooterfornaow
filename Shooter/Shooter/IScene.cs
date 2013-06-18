using System;
using System.Collections.Generic;
using System.Text;

namespace Shooter
{
    public interface IScene
    {
        void Load();
        void Update();
        void Draw();
    }
}
