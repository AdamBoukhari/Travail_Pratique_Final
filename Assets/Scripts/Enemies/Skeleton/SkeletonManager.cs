using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonManager : EnemyManager
{
    public enum SkeletonStateToSwitch { Scouting, Normal, Fighting }
    private SkeletonState skeletonState;

    private void Start()
    {
        Init();
        skeletonState = GetComponent<SkeletonStateScouting>();
        skeletonState.enabled = true;
        skeletonState.Init();
    }

    public override void UpdateEnemy()
    {
        skeletonState.ManageStateChange();
        skeletonState.UpdateSkeleton();
    }

    public void ChangeSkeletonState(SkeletonStateToSwitch nextState)
    {
        skeletonState.enabled = false;
        switch (nextState)
        {
            case SkeletonStateToSwitch.Scouting:
                {
                    skeletonState = gameObject.GetComponent<SkeletonStateScouting>();
                    break;
                }
            case SkeletonStateToSwitch.Normal:
                {
                    skeletonState = gameObject.GetComponent<SkeletonStateNormal>();
                    break;
                }
            case SkeletonStateToSwitch.Fighting:
                {
                    skeletonState = gameObject.GetComponent<SkeletonStateFighting>();
                    break;
                }
        }
        skeletonState.enabled = true;
        skeletonState.Init();
    }
}
