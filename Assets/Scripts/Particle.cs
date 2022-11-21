using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnim(string animation, Vector2 position)
    {
        transform.position = new Vector2(position.x*Utils.UNIT_SIZE, position.y*Utils.UNIT_SIZE);
        anim.SetTrigger(animation);
    }
}
