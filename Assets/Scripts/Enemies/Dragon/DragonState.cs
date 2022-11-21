using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DragonState : MonoBehaviour
{
    protected DragonManager dragonManager;
    protected LifeManager lifeManager;
    protected GameManager gameManager;
    protected SpriteRenderer sprite;
    protected GameObject player;

    void Awake()
    {
        dragonManager = GetComponent<DragonManager>();
        lifeManager = GetComponentInChildren<LifeManager>();
        gameManager = FindObjectOfType<GameManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public abstract void Init();

    public abstract void ManageStateChange();

    public abstract void UpdateDragon();

    protected bool IsPlayerInCloseCombatRange()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        bool isNext = false;

        //Joueur en haut
        if (playerPosition.y == dragonManager.GetRoomPosition().y + (1.5f * Utils.UNIT_SIZE) && playerPosition.x >= dragonManager.GetRoomPosition().x - (1.5f * Utils.UNIT_SIZE) && playerPosition.x <= dragonManager.GetRoomPosition().x + (1.5f * Utils.UNIT_SIZE))
            isNext = true;
        //Joueur en bas
        else if (playerPosition.y == dragonManager.GetRoomPosition().y - (1.5f * Utils.UNIT_SIZE) && playerPosition.x >= dragonManager.GetRoomPosition().x - (1.5f * Utils.UNIT_SIZE) && playerPosition.x <= dragonManager.GetRoomPosition().x + (1.5f * Utils.UNIT_SIZE))
            isNext = true;
        //Joueur à doite
        else if (playerPosition.x == dragonManager.GetRoomPosition().x + (1.5f * Utils.UNIT_SIZE) && playerPosition.y >= dragonManager.GetRoomPosition().y - (1.5f * Utils.UNIT_SIZE) && playerPosition.y <= dragonManager.GetRoomPosition().y + (1.5f * Utils.UNIT_SIZE))
            isNext = true;
        //Joueur à gauche
        else if (playerPosition.x == dragonManager.GetRoomPosition().x - (1.5f * Utils.UNIT_SIZE) && playerPosition.y >= dragonManager.GetRoomPosition().y - (1.5f * Utils.UNIT_SIZE) && playerPosition.y <= dragonManager.GetRoomPosition().y + (1.5f * Utils.UNIT_SIZE))
            isNext = true;

        return isNext;
    }

    protected bool IsPlayerInShootingRange()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        bool isInRange = false;

        if (playerPosition.y <= dragonManager.GetRoomPosition().y + (1.5f * Utils.UNIT_SIZE) && playerPosition.y >= dragonManager.GetRoomPosition().y - (0.5f * Utils.UNIT_SIZE))
            isInRange = true;

        return isInRange;
    }
}
