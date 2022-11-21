using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMover : MonoBehaviour
{
    [SerializeField] private MovingManager movements;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;
    [SerializeField] private int TURN_COOLDOWN = 3;
    [SerializeField] private GameManager gameManager;
    private jumpManager jumpManager;
    private RoomManager roomManager;
    private Vector2 roomPosition;
    private GameObject player;
    private int nbOfTurnLeft;

    private void Start()
    {
        jumpManager = GetComponentInChildren<jumpManager>();
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        roomPosition = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("player");
        nbOfTurnLeft = 0;
    }

    public void move()
    {
        nbOfTurnLeft -= 1;
        print(nbOfTurnLeft);
        Vector2 playerPosition = player.GetComponent<PlayerControlls>().getRoomPosition();
        if (playerPosition.x > roomPosition.x) {
            sprite.flipX = true;
        }
        else if(playerPosition.x < roomPosition.x)
        {
            sprite.flipX = false;
        }
        if(nbOfTurnLeft<=0) {
            nbOfTurnLeft = TURN_COOLDOWN;
            //Verify if closer horizontally ou vertically
            if (Math.Abs(playerPosition.x - roomPosition.x) > Math.Abs(playerPosition.y - roomPosition.y))
            {
                //horizontal
                if (playerPosition.x - roomPosition.x > 0)
                {
                    animator.SetBool("IsBottom", false);
                    animator.SetBool("IsTop", false);
                    Vector2 target = new Vector2(roomPosition.x + 1, roomPosition.y);
                    if (!player.GetComponent<PlayerControlls>().IsMyPosition(target))
                    {
                        roomPosition = roomManager.MoveTo(roomPosition, 1, 0);
                    }
                    else
                    {
                        gameManager.RemoveTime(5, true);
                    }
                }
                else if (playerPosition.x - roomPosition.x < 0)
                {
                    animator.SetBool("IsBottom", false);
                    animator.SetBool("IsTop", false);
                    Vector2 target = new Vector2(roomPosition.x - 1, roomPosition.y);
                    if (!player.GetComponent<PlayerControlls>().IsMyPosition(target))
                    {
                        roomPosition = roomManager.MoveTo(roomPosition, -1, 0);
                    }
                    else
                    {
                        gameManager.RemoveTime(5, true);
                    }
                }
            }
            else
            {
                //vertical
                if (playerPosition.y - roomPosition.y > 0)
                {
                    animator.SetBool("IsBottom", false);
                    animator.SetBool("IsTop", true);
                    Vector2 target = new Vector2(roomPosition.x, roomPosition.y+1);
                    if (!player.GetComponent<PlayerControlls>().IsMyPosition(target))
                    {
                        roomPosition = roomManager.MoveTo(roomPosition, 0, 1);
                    }
                    else
                    {
                        gameManager.RemoveTime(5, true);
                    }
                }
                else if (playerPosition.y - roomPosition.y < 0)
                {
                    animator.SetBool("IsTop", false);
                    animator.SetBool("IsBottom", true);
                    Vector2 target = new Vector2(roomPosition.x, roomPosition.y - 1);
                    if (!player.GetComponent<PlayerControlls>().IsMyPosition(target))
                    {
                        roomPosition = roomManager.MoveTo(roomPosition, 0, -1);
                    }
                    else
                    {
                        gameManager.RemoveTime(5, true);
                    }
                }
            }
            jumpManager.jump();
            movements.UpdateTargetPosition(roomPosition.x * Utils.UNIT_SIZE, roomPosition.y * Utils.UNIT_SIZE);
        }
    }

    public bool IsMyPosition(Vector2 position)
    {
        return position.Equals(roomPosition);
    }
}
