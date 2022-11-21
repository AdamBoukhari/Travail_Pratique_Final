using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStateScouting : BatState
{
    private int MAX_COOLDOWN = 2;
    private int SCOUTING_LIMIT = 2 * Utils.UNIT_SIZE;

    private Vector2 minPosition;
    private Vector2 maxPosition;
    private int cooldown;

    public override void Init()
    {
        minPosition.x = batManager.GetRoomPosition().x - SCOUTING_LIMIT;
        minPosition.y = batManager.GetRoomPosition().y - SCOUTING_LIMIT;
        maxPosition.x = batManager.GetRoomPosition().x + SCOUTING_LIMIT;
        maxPosition.y = batManager.GetRoomPosition().y + SCOUTING_LIMIT;
    }

    public override void UpdateBat()
    {
        cooldown -= 1;

        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            //Direction aléatoire
            int horizontalMovement = Random.Range(0, 2);
            if (horizontalMovement == 0) horizontalMovement = -Utils.UNIT_SIZE;
            if (horizontalMovement == 1) horizontalMovement = Utils.UNIT_SIZE;
            int verticalMovement = Random.Range(0, 2);
            if (verticalMovement == 0) verticalMovement = -Utils.UNIT_SIZE;
            if (verticalMovement == 1) verticalMovement = Utils.UNIT_SIZE;

            //Verification des limites
            if (batManager.GetRoomPosition().x + horizontalMovement > maxPosition.x || batManager.GetRoomPosition().x + horizontalMovement < minPosition.x)
            {
                horizontalMovement = 0;
                verticalMovement = 0;
            }
            if (batManager.GetRoomPosition().y + verticalMovement > maxPosition.y || batManager.GetRoomPosition().y + verticalMovement < minPosition.y)
            {
                horizontalMovement = 0;
                verticalMovement = 0;
            }
            batManager.UpdateRoomPosition(new Vector2Int(horizontalMovement, verticalMovement));
        }
    }

    public override void ManageStateChange()
    {
        if (batManager.IsPlayerNear())
            batManager.ChangeBatState(BatManager.BatStateToSwitch.Normal);
    }
}
