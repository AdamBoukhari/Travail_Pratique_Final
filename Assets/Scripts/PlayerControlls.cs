using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField] private MovingManager movements;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private JumpManager jumpManager;
    [SerializeField] private Particle moveParticle;
    [SerializeField] private Particle damageParticle;
    private AudioSource damageSound;
    private RoomManager roomManager;
    private MovementsManager movementsManager;
    private float cooldown;
    private const float MOVEMENT_COOLDOWN = 0.3f;
    private Vector2 roomPosition;
    private AttackManager attack;
   

    private void Start()
    {
        damageSound = GetComponent<AudioSource>();
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        movementsManager = GameObject.FindGameObjectWithTag("MovementsManager").GetComponent<MovementsManager>();
        roomPosition = new Vector2(0, 0);
        attack = GetComponent<AttackManager>();
    }


    void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;
        if (Input.GetAxisRaw("Vertical")!=0 && cooldown<=0)
        {
            Move("Vertical");
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && cooldown <= 0)
        {
            Move("Horizontal");
        }
    }

    private void Move(string direction) 
    {
        jumpManager.Jump();
        cooldown = MOVEMENT_COOLDOWN;
        int movement = -Utils.UNIT_SIZE;
        if (Input.GetAxisRaw(direction) > 0)
        {
            movement = Utils.UNIT_SIZE;
        }
        bool move = attack.Attack(direction, movement, roomPosition);
        if (move)
        {
            moveParticle.PlayAnim("move", roomPosition);
            if (direction.Equals("Vertical"))
            {
                roomPosition = roomManager.MoveTo(roomPosition, 0, movement);
            }
            else
            {
                moveParticle.GetComponent<SpriteRenderer>().flipX = movement == Utils.UNIT_SIZE;
                sprite.flipX = Input.GetAxisRaw("Horizontal") < 0;
                roomPosition = roomManager.MoveTo(roomPosition, movement, 0);
            }
            movements.UpdateTargetPosition(roomPosition.x * Utils.UNIT_SIZE, roomPosition.y * Utils.UNIT_SIZE);
        }
        movementsManager.PlayerMoved();
    }

    public Vector2 GetRoomPosition()
    {
        return roomPosition;
    }

    public void Damage()
    {
        damageParticle.PlayAnim("damage",transform.position);
        damageSound.Play();
    }

    public bool IsMyPosition(Vector2 position)
    {
        return position.Equals(roomPosition);
    }
}
