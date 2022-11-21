using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStateFighting : BatState
{
    [SerializeField] private int BAT_DAMAGE = 5;

    private Animator animator;

    public override void Init()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateBat()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        if (playerPosition.x < batManager.GetRoomPosition().x && playerPosition.y < batManager.GetRoomPosition().y)
            animator.SetTrigger("Attack_Bottom_Left");
        else if (playerPosition.x > batManager.GetRoomPosition().x && playerPosition.y < batManager.GetRoomPosition().y)
            animator.SetTrigger("Attack_Bottom_Right");
        else if (playerPosition.x < batManager.GetRoomPosition().x && playerPosition.y > batManager.GetRoomPosition().y)
            animator.SetTrigger("Attack_Top_Left");
        else if (playerPosition.x > batManager.GetRoomPosition().x && playerPosition.y > batManager.GetRoomPosition().y)
            animator.SetTrigger("Attack_Top_Right");

        gameManager.RemoveTime(BAT_DAMAGE, true);
    }

    public override void ManageStateChange()
    {
        if (!IsPlayerInAttackRange())
            batManager.ChangeBatState(BatManager.BatStateToSwitch.Normal);
    }
}
