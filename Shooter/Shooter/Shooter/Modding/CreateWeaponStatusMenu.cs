using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Modding
{
    public class CreateWeaponStatusMenu : IScene
    {
        Weapon weapon;
        public CreateWeaponStatusMenu(SpriteSheet Sheet) 
        {
            weapon = new Weapon(Sheet);
        }
        public void Load()
        {
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
