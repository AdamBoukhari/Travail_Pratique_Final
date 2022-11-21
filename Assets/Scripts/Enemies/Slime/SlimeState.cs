using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlimeState : MonoBehaviour
{
    protected SlimeManager slimeManager;
    protected LifeManager lifeManager;
    protected GameManager gameManager;
    protected JumpManager jumpManager;
    protected SpriteRenderer sprite;
    protected GameObject player;

    void Awake()
    {
        slimeManager = GetComponent<SlimeManager>();
        lifeManager = GetComponentInChildren<LifeManager>();
        gameManager = FindObjectOfType<GameManager>();
        jumpManager = GetComponentInChildren<JumpManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public abstract void Init();

    public abstract void ManageStateChange();

    public abstract void UpdateSlime();

    protected bool IsPlayerInAttackRange()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        bool isNext = false;

        //Joueur à droite
        if (playerPosition.x == slimeManager.GetRoomPosition().x + Utils.UNIT_SIZE && playerPosition.y == slimeManager.GetRoomPosition().y)
            isNext = true;
        //Joueur à gauche
        else if (playerPosition.x == slimeManager.GetRoomPosition().x - Utils.UNIT_SIZE && playerPosition.y == slimeManager.GetRoomPosition().y)
            isNext = true;
        //Joueur en haut
        else if (playerPosition.y == slimeManager.GetRoomPosition().y + Utils.UNIT_SIZE && playerPosition.x == slimeManager.GetRoomPosition().x)
            isNext = true;
        //Joueur en bas
        else if (playerPosition.y == slimeManager.GetRoomPosition().y - Utils.UNIT_SIZE && playerPosition.x == slimeManager.GetRoomPosition().x)
            isNext = true;

        return isNext;
    }
}
