using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DragonStateRange : DragonState
{
    private int FIREBALL_SPEED = 7;
    private Vector2 FIREBALL_OFFSET = new Vector2(-Utils.UNIT_SIZE, 0.5f * Utils.UNIT_SIZE);
    private float MOUTH_OFFSET = 0.5f * Utils.UNIT_SIZE;

    private GameObject fireball;

    public override void Init()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>(true))
        {
            if (child.gameObject.name == "Fireball")
                fireball = child.gameObject;
        }
    }

    protected void TryToShoot()
    {
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().GetRoomPosition();
        if (playerPosition.y == dragonManager.GetRoomPosition().y + MOUTH_OFFSET)
        {
            ShootFireball(playerPosition);
        }
        else if (playerPosition.y > dragonManager.GetRoomPosition().y + MOUTH_OFFSET)
        {
            dragonManager.UpdateRoomPosition(new Vector2Int(0, Utils.UNIT_SIZE));
        }
        else if (playerPosition.y < dragonManager.GetRoomPosition().y + MOUTH_OFFSET)
        {
            dragonManager.UpdateRoomPosition(new Vector2Int(0, -Utils.UNIT_SIZE));
        }
    }

    private void ShootFireball(Vector2 playerPosition)
    {
        fireball.SetActive(true);
        if (playerPosition.x < dragonManager.GetRoomPosition().x)
        {
            fireball.transform.position = new Vector2(transform.position.x + FIREBALL_OFFSET.x, transform.position.y + FIREBALL_OFFSET.y);
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-FIREBALL_SPEED, 0);
            fireball.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            fireball.transform.position = new Vector2(transform.position.x - FIREBALL_OFFSET.x, transform.position.y + FIREBALL_OFFSET.y);
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(FIREBALL_SPEED, 0);
            fireball.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
