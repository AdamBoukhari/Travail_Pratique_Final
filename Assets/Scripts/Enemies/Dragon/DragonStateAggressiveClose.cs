using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStateAggressiveClose : DragonStateClose
{
    private int MAX_COOLDOWN = 2;
    [SerializeField] private int DRAGON_DAMAGE = 15;

    private int cooldown;

    public override void Init()
    {
        base.Init();
        animator.SetBool("Aggressive", true);
    }

    public override void ManageStateChange()
    {
        if (!IsPlayerInCloseCombatRange())
        {
            if (IsPlayerInShootingRange())
                dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveRange);
            else
                dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveFar);
        }
    }

    public override void UpdateDragon()
    {
        cooldown -= 1;
        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;

            Attack();
            gameManager.RemoveTime(DRAGON_DAMAGE, true);
        }
    }
}
