using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            gameManager.StartLevel(0.01f, gameManager.GetNextLevel());
        }
    }
}
