using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatePassiveClose : DragonStateClose
{
    private int MAX_COOLDOWN = 3;
    [SerializeField] private int DRAGON_DAMAGE = 10;

    private int cooldown;

    public override void ManageStateChange()
    {
        if(lifeManager.IsLowLife())
        {
            dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.AggressiveClose);
        }
        else if (!IsPlayerInCloseCombatRange())
        {
            if(IsPlayerInShootingRange())
                dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.PassiveRange);
            else
                dragonManager.ChangeDragonState(DragonManager.DragonStateToSwitch.PassiveFar);
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
