using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRendering : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = (int) -transform.position.y;
    }
}
