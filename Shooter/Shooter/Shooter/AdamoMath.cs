using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public static class AdamoMath
    {
        public static Vector2 PositionInMiddle(Vector2 Size, Vector2 Position2, Vector2 Size2) 
        {
            return new Vector2((Size2.X / 2) - (Size.X/2) + Position2.X, (Size2.Y / 2) - (Size.Y/2) + Position2.Y);
        }
        public static int MakePositiveint(int value)
        {
            if (value < 0)
            {
                return -value;
            }
            return value;
        }
        public static float MakePositiveFloat(float value) 
        {
            if (value < 0)
            {
                return -value;
            }
            return value;
        }
        public static Vector2 MakePositiveVector2(Vector2 value)
        {
            if (value.X < 0)
            {
                value.X = -value.X;
            }
            if (value.Y < 0)
            {
                value.Y = -value.Y;
            }
            return value;
        }
        public static float Phytagoras(float X, float Y) 
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public static bool IsBetween(float LowValue, float HighValue, float Value) 
        {
            return LowValue < Value && HighValue > Value;
        }
        public static float ToRadians(float Degrees) 
        {
            return (float)Math.PI * Degrees / 180;
        }
        public static float BiggestValue(float Value1, float Value2) 
        {
            if (Value1 > Value2)
            {
                return Value1;
            }
            else return Value2;
        }
        public static float SmalestValue(float Value1, float Value2)
        {
            if (Value1 < Value2)
            {
                return Value1;
            }
            else return Value2;
        }
        public static float Between(float Value1, float Value2, float n)
        {
            return (Value2 - Value1) * n + Value1;
        }
    }
}
