using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private int MAX_LIFE;
    [SerializeField] private AudioClip deathSound;

    private AudioSource audio;
    [SerializeField] private int life;

    void Start()
    {
        audio = gameObject.GetComponentInChildren<AudioSource>();
        life = MAX_LIFE;
    }

    public void DealDamage(int damage)
    {
        life -= damage;
        
        if (life <= 0)
        {
            if (audio != null)
            {
                audio.PlayOneShot(deathSound);
                audio.transform.parent = null;
            }
            gameObject.SetActive(false);
            
        }
        else
        {
            if (audio != null)
            {
                audio.Play();
            }
        }
    }

    public bool IsLowLife()
    {
        return ((float)life / MAX_LIFE) <= 0.5f;
    }

    public bool IsAlive()
    {
        return life > 0;
    }
}
