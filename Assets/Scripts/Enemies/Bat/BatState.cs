using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BatState : MonoBehaviour
{
    protected BatManager batManager;
    protected LifeManager lifeManager;
    protected GameManager gameManager;
    protected SpriteRenderer sprite;
    protected GameObject player;

    void Awake()
    {
        batManager = GetComponent<BatManager>();
        lifeManager = GetComponentInChildren<LifeManager>();
        gameManager = FindObjectOfType<GameManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public abstract void Init();

    public abstract void ManageStateChange();

    public abstract void UpdateBat();

    protected bool IsPlayerInAttackRange()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        bool isNext = false;

        //Joueur en haut à droite
        if (playerPosition.x == batManager.GetRoomPosition().x + Utils.UNIT_SIZE && playerPosition.y == batManager.GetRoomPosition().y + Utils.UNIT_SIZE)
            isNext = true;
        //Joueur en haut à gauche
        else if (playerPosition.x == batManager.GetRoomPosition().x - Utils.UNIT_SIZE && playerPosition.y == batManager.GetRoomPosition().y + Utils.UNIT_SIZE)
            isNext = true;
        //Joueur en bas à droite
        else if (playerPosition.x == batManager.GetRoomPosition().x + Utils.UNIT_SIZE && playerPosition.y == batManager.GetRoomPosition().y - Utils.UNIT_SIZE)
            isNext = true;
        //Joueur en bas à gauche
        else if (playerPosition.x == batManager.GetRoomPosition().x - Utils.UNIT_SIZE && playerPosition.y == batManager.GetRoomPosition().y - Utils.UNIT_SIZE)
            isNext = true;

        return isNext;
    }
}
