using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateScouting : SkeletonState
{
    private int MAX_COOLDOWN = 4;
    private int SCOUTING_LIMIT = 2 * Utils.UNIT_SIZE;

    private Vector2 minPosition;
    private Vector2 maxPosition;
    private int cooldown;

    public override void Init()
    {
        minPosition.x = skeletonManager.GetRoomPosition().x - SCOUTING_LIMIT;
        minPosition.y = skeletonManager.GetRoomPosition().y - SCOUTING_LIMIT;
        maxPosition.x = skeletonManager.GetRoomPosition().x + SCOUTING_LIMIT;
        maxPosition.y = skeletonManager.GetRoomPosition().y + SCOUTING_LIMIT;
    }

    public override void UpdateSkeleton()
    {
        cooldown -= 1;

        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            //Déplacement aléatoire vertical ou horizontal
            if (Random.Range(0, 2) == 0) //Horizontal
            {
                //Déplacement aléatoire à droite ou à gauche
                if (Random.Range(0, 2) == 0) //Droite
                {
                    sprite.flipX = true;
                    //Verify limit
                    if (skeletonManager.GetRoomPosition().x + Utils.UNIT_SIZE <= maxPosition.x)
                    {
                        skeletonManager.UpdateRoomPosition(new Vector2Int(Utils.UNIT_SIZE, 0));
                    }
                }
                else //Gauche
                {
                    sprite.flipX = false;
                    //Vérification des limites
                    if (skeletonManager.GetRoomPosition().x - Utils.UNIT_SIZE >= minPosition.x)
                    {
                        skeletonManager.UpdateRoomPosition(new Vector2Int(-Utils.UNIT_SIZE, 0));
                    }
                }
            }
            else //Vertical
            {
                //Déplacement aléatoire vers le haut ou le bas
                if (Random.Range(0, 2) == 0) //Haut
                {
                    //Verify limit
                    if (skeletonManager.GetRoomPosition().y + Utils.UNIT_SIZE <= maxPosition.y)
                    {
                        skeletonManager.UpdateRoomPosition(new Vector2Int(0, Utils.UNIT_SIZE));
                    }
                }
                else //Bas
                {
                    //Vérification des limites
                    if (skeletonManager.GetRoomPosition().y - Utils.UNIT_SIZE >= minPosition.y)
                    {
                        skeletonManager.UpdateRoomPosition(new Vector2Int(0, -Utils.UNIT_SIZE));
                    }
                }
            }
            jumpManager.Jump();
        }
    }

    public override void ManageStateChange()
    {
        if (skeletonManager.IsPlayerNear())
            skeletonManager.ChangeSkeletonState(SkeletonManager.SkeletonStateToSwitch.Normal);
    }
}
