using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkeletonState : MonoBehaviour
{
    protected SkeletonManager skeletonManager;
    protected LifeManager lifeManager;
    protected GameManager gameManager;
    protected JumpManager jumpManager;
    protected SpriteRenderer sprite;
    protected GameObject player;

    void Awake()
    {
        skeletonManager = GetComponent<SkeletonManager>();
        lifeManager = GetComponentInChildren<LifeManager>();
        gameManager = FindObjectOfType<GameManager>();
        jumpManager = GetComponentInChildren<JumpManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public abstract void Init();

    public abstract void ManageStateChange();

    public abstract void UpdateSkeleton();

    protected bool IsPlayerInAttackRange()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        bool isNext = false;

        //Joueur à droite
        if (playerPosition.x == skeletonManager.GetRoomPosition().x + Utils.UNIT_SIZE && playerPosition.y == skeletonManager.GetRoomPosition().y)
            isNext = true;
        //Joueur à gauche
        else if (playerPosition.x == skeletonManager.GetRoomPosition().x - Utils.UNIT_SIZE && playerPosition.y == skeletonManager.GetRoomPosition().y)
            isNext = true;
        //Joueur en haut
        else if (playerPosition.y == skeletonManager.GetRoomPosition().y + Utils.UNIT_SIZE && playerPosition.x == skeletonManager.GetRoomPosition().x)
            isNext = true;
        //Joueur en bas
        else if (playerPosition.y == skeletonManager.GetRoomPosition().y - Utils.UNIT_SIZE && playerPosition.x == skeletonManager.GetRoomPosition().x)
            isNext = true;

        return isNext;
    }
}
