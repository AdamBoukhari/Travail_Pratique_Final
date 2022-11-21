using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    private Animator anim;
    private bool activated;
    private AudioSource audio;
    private GameManager gameManager;
    [SerializeField] private int Damage = 10;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& !activated)
        {
            activated = true;
            gameManager.RemoveTime(Damage, true);
            audio.Play();
            anim.SetTrigger("activate");
        }
    }
}
