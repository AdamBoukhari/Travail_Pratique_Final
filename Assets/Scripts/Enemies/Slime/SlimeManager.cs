using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : EnemyManager
{
    public enum SlimeStateToSwitch { Scouting, Normal, Fighting }
    private SlimeState slimeState;

    private void Start()
    {
        Init();
        slimeState = GetComponent<SlimeStateScouting>();
        slimeState.enabled = true;
        slimeState.Init();
    }

    public override void UpdateEnemy()
    {
        slimeState.ManageStateChange();
        slimeState.UpdateSlime();
    }

    public void ChangeSlimeState(SlimeStateToSwitch nextState)
    {
        slimeState.enabled = false;
        switch (nextState)
        {
            case SlimeStateToSwitch.Scouting:
                {
                    slimeState = gameObject.GetComponent<SlimeStateScouting>();
                    break;
                }
            case SlimeStateToSwitch.Normal:
                {
                    slimeState = gameObject.GetComponent<SlimeStateNormal>();
                    break;
                }
            case SlimeStateToSwitch.Fighting:
                {
                    slimeState = gameObject.GetComponent<SlimeStateFighting>();
                    break;
                }
        }
        slimeState.enabled = true;
        slimeState.Init();
    }
}
