using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateFighting : SkeletonState
{
    private int MAX_COOLDOWN = 3;
    [SerializeField] private int SKELETON_DAMAGE = 5;

    private Animator animator;
    private int cooldown;

    public override void Init()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        if (playerPosition.y < skeletonManager.GetRoomPosition().y)
        {
            animator.SetBool("IsTop", false);
            animator.SetBool("IsBottom", true);
        }
        else if (playerPosition.y > skeletonManager.GetRoomPosition().y)
        {
            animator.SetBool("IsTop", true);
            animator.SetBool("IsBottom", false);
        }
        else
        {
            animator.SetBool("IsTop", false);
            animator.SetBool("IsBottom", false);
        }
    }

    public override void UpdateSkeleton()
    {
        cooldown -= 1;
        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
            if (playerPosition.x < skeletonManager.GetRoomPosition().x)
                animator.SetTrigger("Attack_Left");
            else if (playerPosition.x > skeletonManager.GetRoomPosition().x)
                animator.SetTrigger("Attack_Right");
            else if (playerPosition.y < skeletonManager.GetRoomPosition().y)
                animator.SetTrigger("Attack_Bottom");
            else if (playerPosition.y > skeletonManager.GetRoomPosition().y)
                animator.SetTrigger("Attack_Top");

            jumpManager.Jump();
            gameManager.RemoveTime(SKELETON_DAMAGE, true);
        }
    }

    public override void ManageStateChange()
    {
        if (!IsPlayerInAttackRange())
            skeletonManager.ChangeSkeletonState(SkeletonManager.SkeletonStateToSwitch.Normal);
    }
}
