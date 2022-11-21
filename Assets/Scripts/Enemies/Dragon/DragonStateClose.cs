using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DragonStateClose : DragonState
{
    protected Animator animator;

    public override void Init()
    {
        animator = GetComponentInChildren<Animator>();
    }

    protected void Attack()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        if (playerPosition.x < dragonManager.GetRoomPosition().x - (0.5f * Utils.UNIT_SIZE) && playerPosition.y < dragonManager.GetRoomPosition().y - (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Bottom_Left");
        else if (playerPosition.x < dragonManager.GetRoomPosition().x - (0.5f * Utils.UNIT_SIZE) && playerPosition.y > dragonManager.GetRoomPosition().y + (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Top_Left");
        else if (playerPosition.x > dragonManager.GetRoomPosition().x + (0.5f * Utils.UNIT_SIZE) && playerPosition.y < dragonManager.GetRoomPosition().y - (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Bottom_Right");
        else if (playerPosition.x > dragonManager.GetRoomPosition().x + (0.5f * Utils.UNIT_SIZE) && playerPosition.y > dragonManager.GetRoomPosition().y + (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Top_Right");
        else if (playerPosition.x < dragonManager.GetRoomPosition().x - (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Left");
        else if (playerPosition.x > dragonManager.GetRoomPosition().x + (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Right");
        else if (playerPosition.y < dragonManager.GetRoomPosition().y - (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Bottom");
        else if (playerPosition.y > dragonManager.GetRoomPosition().y + (0.5f * Utils.UNIT_SIZE))
            animator.SetTrigger("Attack_Top");
    }
}
