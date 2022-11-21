using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour
{
    protected Vector2 roomPosition;
    protected bool playerNear = false;
    protected RoomManager roomManager;
    protected MovingManager movements;


    protected void Init()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        movements = gameObject.GetComponent<MovingManager>();
        roomPosition = gameObject.transform.position;
    }
    public abstract void UpdateEnemy();

    public bool IsMyPosition(Vector2 position)
    {
        return position.Equals(roomPosition);
    }
    public Vector2 GetRoomPosition()
    {
        return roomPosition;
    }

    public bool IsPlayerNear()
    {
        return playerNear;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNear = false;
        }
    }

    public void UpdateRoomPosition(Vector2Int offset)
    {
        roomPosition = roomManager.MoveTo(roomPosition, offset.x, offset.y);
        movements.UpdateTargetPosition(roomPosition.x, roomPosition.y);
    }
}
