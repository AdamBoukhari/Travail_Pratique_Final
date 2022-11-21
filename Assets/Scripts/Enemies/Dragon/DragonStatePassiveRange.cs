using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatePassiveRange : DragonStateRange
{
    private int MAX_COOLDOWN = 3;

    private int cooldown;


    public override void ManageStateChange()
    {
        if (lifeManager.IsLowLife())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveRange);
        else if (IsPlayerInCloseCombatRange())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.PassiveClose);
        else if (!IsPlayerInShootingRange())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.PassiveFar);
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
