using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateScouting : SlimeState
{
    private int MAX_COOLDOWN = 3;
    private int SCOUTING_LIMIT = 2 * Utils.UNIT_SIZE;

    private Vector2 minPosition;
    private Vector2 maxPosition;
    private int cooldown;

    public override void Init()
    {
        minPosition.x = slimeManager.GetRoomPosition().x - SCOUTING_LIMIT;
        minPosition.y = slimeManager.GetRoomPosition().y - SCOUTING_LIMIT;
        maxPosition.x = slimeManager.GetRoomPosition().x + SCOUTING_LIMIT;
        maxPosition.y = slimeManager.GetRoomPosition().y + SCOUTING_LIMIT;
    }

    public override void UpdateSlime()
    {
        cooldown -= 1;

        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            //Déplcement aléatoire horizontal ou vertical
            if(Random.Range(0, 2) == 0) //Horizontal
            {
                //Déplecement aléatoire à droite ou à gauche
                if(Random.Range(0, 2) == 0) //Droite
                {
                    sprite.flipX = true;
                    //Vérification des limites
                    if (slimeManager.GetRoomPosition().x + Utils.UNIT_SIZE <= maxPosition.x)
                    {
                        slimeManager.UpdateRoomPosition(new Vector2Int(Utils.UNIT_SIZE, 0));
                    }
                }
                else //Gauche
                {
                    sprite.flipX = false;
                    //Vérification des limites
                    if (slimeManager.GetRoomPosition().x - Utils.UNIT_SIZE >= minPosition.x)
                    {
                        slimeManager.UpdateRoomPosition(new Vector2Int(-Utils.UNIT_SIZE, 0));
                    }
                }
            }
            else //Vertical
            {
                //Déplecement aléatoire vers le haut ou le bas
                if (Random.Range(0, 2) == 0) //Haut
                {
                    //Verify limit
                    if (slimeManager.GetRoomPosition().y + Utils.UNIT_SIZE <= maxPosition.y)
                    {
                        slimeManager.UpdateRoomPosition(new Vector2Int(0, Utils.UNIT_SIZE));
                    }
                }
                else //Bas
                {
                    //Vérification des limites
                    if (slimeManager.GetRoomPosition().y - Utils.UNIT_SIZE >= minPosition.y)
                    {
                        slimeManager.UpdateRoomPosition(new Vector2Int(0, -Utils.UNIT_SIZE));
                    }
                }
            }
            jumpManager.Jump();
        }
    }

    public override void ManageStateChange()
    {
        if (slimeManager.IsPlayerNear())
            slimeManager.ChangeSlimeState(SlimeManager.SlimeStateToSwitch.Normal);
    }
}
