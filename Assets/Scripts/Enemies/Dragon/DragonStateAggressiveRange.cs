using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStateAggressiveRange : DragonStateRange
{
    private int MAX_COOLDOWN = 2;

    private int cooldown;

    public override void Init()
    {
        base.Init();
        GetComponentInChildren<Animator>().SetBool("Aggressive", true);
    }

    public override void ManageStateChange()
    {
        if (IsPlayerInCloseCombatRange())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveClose);
        else if (!IsPlayerInShootingRange())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveFar);
    }

    public override void UpdateDragon()
    {
        cooldown -= 1;
        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;
            TryToShoot();
        }
    }
}
