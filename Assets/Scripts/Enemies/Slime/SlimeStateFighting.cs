using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateFighting : SlimeState
{
    private int MAX_COOLDOWN = 2;
    [SerializeField] private int SLIME_DAMAGE = 5;

    private Animator animator;
    private int cooldown;

    public override void Init()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateSlime()
    {
        cooldown -= 1;
        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
            if (playerPosition.x < slimeManager.GetRoomPosition().x)
                animator.SetTrigger("Attack_Left");
            else if (playerPosition.x > slimeManager.GetRoomPosition().x)
                animator.SetTrigger("Attack_Right");
            else if (playerPosition.y < slimeManager.GetRoomPosition().y)
                animator.SetTrigger("Attack_Bottom");
            else if (playerPosition.y > slimeManager.GetRoomPosition().y)
                animator.SetTrigger("Attack_Top");

            jumpManager.Jump();
            gameManager.RemoveTime(SLIME_DAMAGE, true);
        }
    }

    public override void ManageStateChange()
    {
        if (!IsPlayerInAttackRange())
            slimeManager.ChangeSlimeState(SlimeManager.SlimeStateToSwitch.Normal);
    }
}
