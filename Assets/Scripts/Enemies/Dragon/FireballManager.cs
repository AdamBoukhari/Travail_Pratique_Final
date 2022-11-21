using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    [SerializeField] private int FIREBALL_DAMAGE = 5;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "floor")
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            gameManager.RemoveTime(FIREBALL_DAMAGE, true);
    }
}
