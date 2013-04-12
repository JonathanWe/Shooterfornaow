using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public static class AdamoMath
    {
        /// <summary>
        /// Used to center an object inside another object. Instance, if you need to place a square in another square (think texture) you use this to find the center in both
        /// squares so you can place things in the centre
        /// </summary>
        /// <returns>the vector2 value for the center</returns>

        public static Vector2 PositionInMiddle(Vector2 Size, Vector2 Position2, Vector2 Size2) 
        {
            return new Vector2((Size2.X / 2) - (Size.X/2) + Position2.X, (Size2.Y / 2) - (Size.Y/2) + Position2.Y);
        }

        /// <summary>
        /// Changes an int value from negative to positive.
        /// </summary>
        /// <param name="value">A negative value</param>
        /// <returns>A positive value</returns>
        public static int MakePositiveint(int value)
        {
            if (value < 0)
            {
                return -value;
            }
            return value;
        }

        /// <summary>
        /// Changes float value from negative to positive
        /// </summary>
        /// <param name="value">A negative value</param>
        /// <returns>A positive value</returns>
        public static float MakePositiveFloat(float value) 
        {
            if (value < 0)
            {
                return -value;
            }
            return value;
        }

        /// <summary>
        /// Changes a vector2 value from negative to positive
        /// </summary>
        /// <param name="value">The value you want to change</param>
        /// <returns>Returns the vector2 as positive</returns>
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

        /// <summary>
        /// calculates phytagoras where the X and Y values are sides of a triangle
        /// </summary>
        /// <returns>Returns the hypotenuse of the two values</returns>
        public static float Phytagoras(float X, float Y) 
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        /// Bool value of wether a value is between two other values. Returnes true if the value is between LowValue and HighValue
        /// </summary>
        /// <param name="LowValue">The minimum value</param>
        /// <param name="HighValue">The maximum value</param>
        /// <param name="Value">Check value</param>
        /// <returns>True or false depending on the value is between the minimum and maximum value</returns>
        public static bool IsBetween(float LowValue, float HighValue, float Value) 
        {
            return LowValue < Value && HighValue > Value;
        }

        /// <summary>
        /// Changes value from Degrees to radians
        /// </summary>
        /// <param name="Degrees">Input degrees
        /// <returns>degree in radians</returns>
        public static float ToRadians(float Degrees) 
        {
            return (float)Math.PI * Degrees / 180;
        }

        /// <summary>
        /// Finds the biggest value of two inputs
        /// </summary>
        /// <returns>Returns the biggest value</returns>
        public static float BiggestValue(float Value1, float Value2) 
        {
            if (Value1 > Value2)
            {
                return Value1;
            }
            else return Value2;
        }

        /// <summary>
        /// Find the smallest value
        /// </summary>
        /// <returns>The smallest value</returns>
        public static float SmalestValue(float Value1, float Value2)
        {
            if (Value1 < Value2)
            {
                return Value1;
            }
            else return Value2;
        }
    }
}
