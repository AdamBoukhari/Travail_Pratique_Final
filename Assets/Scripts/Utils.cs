using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    DAGGER,
    LONGSWORD,
    SPEAR
}

public class Utils 
{
    public const int UNIT_SIZE = 1;
    
    public enum limitsTypes
    {
        UP,
        DOWN,
        LEFT, 
        RIGHT
    }


    public static float ManageLimits(float number, int min, int max)
    {
        if (number < min)
        {
            number = min;
        }
        else if (number > max)
        {
            number = max;
        }
        return number;
    }
}
