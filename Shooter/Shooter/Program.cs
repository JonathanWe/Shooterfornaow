using System;
using Adamo;

namespace Shooter
{
    static class Program
    {
        static void Main(string[] args)
        {
			Window window = new Window();
			window.Initialize (new AdamoOpenGL.OpenGLDevice ());
			window.Start(new Game1());
        }
    }
}

