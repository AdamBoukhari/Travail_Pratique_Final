using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] Level level;
    private char[,] actualRoom;
    private Vector2 roomDecal;
    private int[] roomLimits;
    private GameObject[] enemies;

    void Awake()
    {
        actualRoom = RoomsLayout.GetRoom(level);
        roomDecal = RoomsLayout.GetDecal(level);
        roomLimits = RoomsLayout.GetLimits(level);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public Vector2 MoveTo(Vector2 position, int offsetX, int offsetY)
    {
        int indexY = actualRoom.GetLength(0)-((int)position.y + offsetY + (int)roomDecal.y);
        int indexX = (int)position.x + offsetX + (int)roomDecal.x;
        if (actualRoom[indexY, indexX] == ' '  && IsPositionEmpty(new Vector2(position.x + offsetX, position.y + offsetY)))
        {
            position.x += offsetX;
            position.y += offsetY;
        }

        return position;
    }

    private bool IsPositionEmpty(Vector2 position)
    {
        bool isEmpty = true;
        foreach(GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyManager>().GetRoomPosition() == position)
                isEmpty = false;
        }
        return isEmpty;
    }

    public int GetRoomLimit(Utils.limitsTypes type) 
    {
        switch (type)
        {
            case Utils.limitsTypes.LEFT:
                return roomLimits[0];
            case Utils.limitsTypes.DOWN:
                return roomLimits[1];
            case Utils.limitsTypes.UP:
                return roomLimits[2];
            case Utils.limitsTypes.RIGHT:
                return roomLimits[3];
        }
        return 0;
    }
}
