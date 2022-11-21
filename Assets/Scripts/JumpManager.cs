using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] private Transform rootParent;
    [SerializeField] private float gravityForce;
    [SerializeField] private float jumpForce;
    private float verticalSpeed = 0;
    private float verticalOffset = 0;

    public void Jump()
    {
        verticalSpeed = jumpForce;
    }

    void Update()
    {
        verticalOffset +=(verticalSpeed*Time.deltaTime);
        if (verticalOffset < 0)
        {
            verticalOffset = 0;
        }
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, rootParent.position.y+verticalOffset);
        verticalSpeed -= gravityForce*Time.deltaTime;
    }
}
