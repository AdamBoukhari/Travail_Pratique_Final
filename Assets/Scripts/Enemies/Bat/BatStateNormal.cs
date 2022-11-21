using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStateNormal : BatState
{
    public override void Init(){}

    public override void UpdateBat()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();

        //Rotation
        if (playerPosition.x > batManager.GetRoomPosition().x)
        {
            sprite.flipX = true;
        }
        else if (playerPosition.x < batManager.GetRoomPosition().x)
        {
            sprite.flipX = false;
        }

        int horizontalMovement = Random.Range(0, 2);
        if (horizontalMovement == 0) horizontalMovement = -Utils.UNIT_SIZE;
        if (horizontalMovement == 1) horizontalMovement = Utils.UNIT_SIZE;
        int verticalMovement = Random.Range(0, 2);
        if (verticalMovement == 0) verticalMovement = -Utils.UNIT_SIZE;
        if (verticalMovement == 1) verticalMovement = Utils.UNIT_SIZE;

        //Déplacement horizontal
        if (playerPosition.x - batManager.GetRoomPosition().x > 0)
        {
            horizontalMovement = Utils.UNIT_SIZE;
        }
        else if (playerPosition.x - batManager.GetRoomPosition().x < 0)
        {
            horizontalMovement = -Utils.UNIT_SIZE;
        }

        //Déplacement vertical
        if (playerPosition.y - batManager.GetRoomPosition().y > 0)
        {
            verticalMovement = Utils.UNIT_SIZE;
        }
        else if (playerPosition.y - batManager.GetRoomPosition().y < 0)
        {
            verticalMovement = -Utils.UNIT_SIZE;
        }

        batManager.UpdateRoomPosition(new Vector2Int(horizontalMovement, verticalMovement));
    }

    public override void ManageStateChange()
    {
        if (!batManager.IsPlayerNear())
            batManager.ChangeBatState(BatManager.BatStateToSwitch.Scouting);
        if (IsPlayerInAttackRange())
            batManager.ChangeBatState(BatManager.BatStateToSwitch.Fighting);
    }
}
