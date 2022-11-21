using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : EnemyManager
{
    public enum BatStateToSwitch { Scouting, Normal, Fighting }
    private BatState batState;

    private void Start()
    {
        Init();
        batState = GetComponent<BatStateScouting>();
        batState.enabled = true;
        batState.Init();
    }

    public override void UpdateEnemy()
    {
        batState.ManageStateChange();
        batState.UpdateBat();
    }

    public void ChangeBatState(BatStateToSwitch nextState)
    {
        batState.enabled = false;
        switch (nextState)
        {
            case BatStateToSwitch.Scouting:
                {
                    batState = gameObject.GetComponent<BatStateScouting>();
                    break;
                }
            case BatStateToSwitch.Normal:
                {
                    batState = gameObject.GetComponent<BatStateNormal>();
                    break;
                }
            case BatStateToSwitch.Fighting:
                {
                    batState = gameObject.GetComponent<BatStateFighting>();
                    break;
                }
        }
        batState.enabled = true;
        batState.Init();
    }
}
