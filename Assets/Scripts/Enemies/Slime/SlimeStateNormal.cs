using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateNormal : SlimeState
{
    private int MAX_COOLDOWN = 2;

    private int cooldown;

    public override void Init() {}

    public override void UpdateSlime()
    {
        cooldown -= 1;
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();

        //Rotation
        if (playerPosition.x > slimeManager.GetRoomPosition().x)
        {
            sprite.flipX = true;
        }
        else if (playerPosition.x < slimeManager.GetRoomPosition().x)
        {
            sprite.flipX = false;
        }


        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            //Vérification si le joueur est plus près horizontalement ou verticalement
            if (Math.Abs(playerPosition.x - slimeManager.GetRoomPosition().x) > Math.Abs(playerPosition.y - slimeManager.GetRoomPosition().y))
            {
                //Horizontalement
                if (playerPosition.x - slimeManager.GetRoomPosition().x > 0)
                {
                    slimeManager.UpdateRoomPosition(new Vector2Int(Utils.UNIT_SIZE, 0));
                }
                else if (playerPosition.x - slimeManager.GetRoomPosition().x < 0)
                {
                    slimeManager.UpdateRoomPosition(new Vector2Int(-Utils.UNIT_SIZE, 0));
                }
            }
            else
            {
                //Verticalement
                if (playerPosition.y - slimeManager.GetRoomPosition().y > 0)
                {
                    slimeManager.UpdateRoomPosition(new Vector2Int(0, Utils.UNIT_SIZE));
                }
                else if (playerPosition.y - slimeManager.GetRoomPosition().y < 0)
                {
                    slimeManager.UpdateRoomPosition(new Vector2Int(0, -Utils.UNIT_SIZE));
                }
            }
            jumpManager.Jump();
        }
    }

    public override void ManageStateChange()
    {
        if (!slimeManager.IsPlayerNear())
            slimeManager.ChangeSlimeState(SlimeManager.SlimeStateToSwitch.Scouting);
        if (IsPlayerInAttackRange())
            slimeManager.ChangeSlimeState(SlimeManager.SlimeStateToSwitch.Fighting);
    }
}
