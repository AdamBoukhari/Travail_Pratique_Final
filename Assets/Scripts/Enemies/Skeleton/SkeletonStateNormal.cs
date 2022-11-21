using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateNormal : SkeletonState
{
    private int MAX_COOLDOWN = 3;

    private Animator animator;
    private int cooldown;

    public override void Init()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public override void UpdateSkeleton()
    {
        cooldown -= 1;
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();

        //Rotation
        if (playerPosition.x > skeletonManager.GetRoomPosition().x)
        {
            sprite.flipX = true;
        }
        else if (playerPosition.x < skeletonManager.GetRoomPosition().x)
        {
            sprite.flipX = false;
        }


        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            //Vérification si le joueur est plus près verticalement ou horizontalement
            if (Math.Abs(playerPosition.x - skeletonManager.GetRoomPosition().x) > Math.Abs(playerPosition.y - skeletonManager.GetRoomPosition().y))
            {
                //Horizontalment
                animator.SetBool("IsBottom", false);
                animator.SetBool("IsTop", false);
                if (playerPosition.x - skeletonManager.GetRoomPosition().x > 0)
                {
                    skeletonManager.UpdateRoomPosition(new Vector2Int(Utils.UNIT_SIZE, 0));
                }
                else if (playerPosition.x - skeletonManager.GetRoomPosition().x < 0)
                {
                    skeletonManager.UpdateRoomPosition(new Vector2Int(-Utils.UNIT_SIZE, 0));
                }
            }
            else
            {
                //Verticalement
                if (playerPosition.y - skeletonManager.GetRoomPosition().y > 0)
                {
                    animator.SetBool("IsBottom", false);
                    animator.SetBool("IsTop", true);
                    skeletonManager.UpdateRoomPosition(new Vector2Int(0, Utils.UNIT_SIZE));
                }
                else if (playerPosition.y - skeletonManager.GetRoomPosition().y < 0)
                {
                    animator.SetBool("IsBottom", true);
                    animator.SetBool("IsTop", false);
                    skeletonManager.UpdateRoomPosition(new Vector2Int(0, -Utils.UNIT_SIZE));
                }
            }
            jumpManager.Jump();
        }
    }

    public override void ManageStateChange()
    {
        if (!skeletonManager.IsPlayerNear())
            skeletonManager.ChangeSkeletonState(SkeletonManager.SkeletonStateToSwitch.Scouting);
        if (IsPlayerInAttackRange())
            skeletonManager.ChangeSkeletonState(SkeletonManager.SkeletonStateToSwitch.Fighting);
    }
}
