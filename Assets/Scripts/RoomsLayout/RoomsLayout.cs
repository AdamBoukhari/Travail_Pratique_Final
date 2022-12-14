using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Level { TEST, FIRST, SECOND, LAST};
public class RoomsLayout 
{

    public static char[,] GetRoom(Level level)
    {
        switch (level)
        {
            case Level.FIRST:
                return FIRST_LEVEL_ROOM;
            case Level.SECOND:
                return SECOND_LEVEL_ROOM;
            case Level.LAST:
                return LAST_LEVEL_ROOM;
            default:
                return TEST_ROOM;
        }
    }

    public static Vector2 GetDecal(Level level)
    {
        switch (level)
        {
            case Level.FIRST:
                return FIRST_LEVEL_ROOM_DECAL;
            case Level.SECOND:
                return SECOND_LEVEL_ROOM_DECAL;
            case Level.LAST:
                return LAST_LEVEL_ROOM_DECAL;
            default:
                return TEST_ROOM_DECAL;
        }
    }

    public static int[] GetLimits(Level level)
    {
        switch (level)
        {
            case Level.FIRST:
                return FIRST_LEVEL_ROOM_LIMITS;
            case Level.SECOND:
                return SECOND_LEVEL_ROOM_LIMITS;
            case Level.LAST:
                return LAST_LEVEL_ROOM_LIMITS;
            default:
                return TEST_ROOM_LIMITS;
        }
    }

    //Test room
    public static char[,] TEST_ROOM = new char[10, 17] 
    {
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ','X',' ',' ',' ',' ',' ',' ',' ','X',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
    };

    public static Vector2 TEST_ROOM_DECAL = new Vector2(8, 6);

    public static int[] TEST_ROOM_LIMITS = {-10, -6, 6, 10};

    //Premier niveau
    public static char[,] FIRST_LEVEL_ROOM = new char[33, 67]
    {
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X',' ',' ',' ','X','X','X',' ','X',' ',' ',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X',' ',' ','X',' ',' ',' ',' ','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X',' ',' ',' ',' ',' ','X',' ','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X',' ',' ','X','X',' ',' ','X','X','X','X','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X',' ',' ',' ',' ',' ','X',' ',' ','X',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X',' ',' ',' ',' ','X',' ',' ',' ',' ','X',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X',' ',' ',' ',' ','X',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X',' ',' ',' ',' ',' ','X',' ',' ','X',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
    };
    //                             (Mesure ? partir de la gauche, Mesure ? partir du bas)
    public static Vector2 FIRST_LEVEL_ROOM_DECAL = new Vector2(8, 18);

    public static int[] FIRST_LEVEL_ROOM_LIMITS = {-10, -19, 17, 61};

    //Deuxi?me niveau
    public static char[,] SECOND_LEVEL_ROOM = new char[40, 67]
    {
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X',' ','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'}

    };  

    public static Vector2 SECOND_LEVEL_ROOM_DECAL = new Vector2(25, 5);

    public static int[] SECOND_LEVEL_ROOM_LIMITS = { -27, -6, 38, 27 };


    //Dernier niveau
    public static char[,] LAST_LEVEL_ROOM = new char[13, 13]
    {
        {'X','X','X','X','X','X','X','X','X','X','X','X','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ','X',' ',' ',' ',' ',' ','X',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ','X',' ',' ',' ',' ',' ','X',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
        {'X','X','X','X','X','X','X','X','X','X','X','X','X'}
    };

    public static Vector2 LAST_LEVEL_ROOM_DECAL = new Vector2(2, 3);

    public static int[] LAST_LEVEL_ROOM_LIMITS = { -5, -5, 13, 13 };

}
