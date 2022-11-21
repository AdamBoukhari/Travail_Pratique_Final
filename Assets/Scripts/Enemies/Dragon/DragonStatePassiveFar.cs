using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatePassiveFar : DragonStateFar
{
    private int MAX_COOLDOWN = 3;

    private int cooldown;

    public override void Init(){}

    public override void ManageStateChange()
    {
        if (lifeManager.IsLowLife())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveFar);
        else if (IsPlayerInCloseCombatRange())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.PassiveClose);
        else if (IsPlayerInShootingRange())
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.PassiveRange);
    }

    public override void UpdateDragon()
    {
        cooldown -= 1;

        Rotate();

        if (cooldown <= 0)
        {
            cooldown = MAX_COOLDOWN;
            Move();
        }
    }
}
