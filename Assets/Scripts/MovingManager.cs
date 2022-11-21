using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingManager : MonoBehaviour
{
    private Vector2 targetPosition;
    [SerializeField] private float speed = 3;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        ManageMovements();
    }

    private void ManageMovements()
    {
        float xOffset = transform.position.x + ((targetPosition.x - transform.position.x) * speed * Time.deltaTime);
        float yOffset = transform.position.y + ((targetPosition.y - transform.position.y) * speed * Time.deltaTime);
        transform.position = new Vector2(xOffset, yOffset);
    }

    public void UpdateTargetPosition(float xTarget, float yTarget)
    {
        targetPosition.x = xTarget;
        targetPosition.y = yTarget;
    }
}
