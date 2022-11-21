using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DragonStateFar : DragonState
{
    protected void Rotate()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        if (playerPosition.x > dragonManager.GetRoomPosition().x)
        {
            sprite.flipX = true;
        }
        else if (playerPosition.x < dragonManager.GetRoomPosition().x)
        {
            sprite.flipX = false;
        }
    }
    protected void Move()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        if (Math.Abs(playerPosition.x - dragonManager.GetRoomPosition().x) > Math.Abs(playerPosition.y - dragonManager.GetRoomPosition().y))
        {
            //Déplacement horizontal
            if (playerPosition.x - dragonManager.GetRoomPosition().x > 0)
            {
                dragonManager.UpdateRoomPosition(new Vector2Int(Utils.UNIT_SIZE, 0));
            }
            else if (playerPosition.x - dragonManager.GetRoomPosition().x < 0)
            {
                dragonManager.UpdateRoomPosition(new Vector2Int(-Utils.UNIT_SIZE, 0));
            }
        }
        else
        {
            //Déplacement vertical
            if (playerPosition.y - dragonManager.GetRoomPosition().y > 0)
            {
                dragonManager.UpdateRoomPosition(new Vector2Int(0, Utils.UNIT_SIZE));
            }
            else if (playerPosition.y - dragonManager.GetRoomPosition().y < 0)
            {
                dragonManager.UpdateRoomPosition(new Vector2Int(0, -Utils.UNIT_SIZE));
            }
        }
    }
}
