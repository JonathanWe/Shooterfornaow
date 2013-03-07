using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Shooter
{
    public class GameSoundEffect
    {
        SoundEffect effect;
        SoundEffectInstance effectInstance;

        ContentManager content = Engine.Content;


        public void Load(string File)
        {
            effect = SoundEffect.FromStream(new MemoryStream(System.IO.File.ReadAllBytes(File)));
        }
        
        
        
        public void Play()
        {
            if (effectInstance != null && effectInstance.State == SoundState.Playing) 
            {
                effectInstance.Stop();
            }
            effectInstance = effect.CreateInstance();
            effectInstance.Play();
        }
        

    }
}
