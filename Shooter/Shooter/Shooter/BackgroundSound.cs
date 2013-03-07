using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Shooter
{
    public class BackgroundSound
    {

        Song Sound;
        bool songstart = false;
        ContentManager Content = Engine.Content;


        public void Load()
        {
            Sound = Content.Load<Song>("Sounds/Background sounds/BackgroundSound");
            MediaPlayer.IsRepeating = true;
        }

        public void Update()
        {
            if (!songstart)
            {
                MediaPlayer.Play(Sound);
                songstart = true;
            }
        }
    }
}
