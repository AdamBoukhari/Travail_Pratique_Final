using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject exit;
    private LifeManager lifeManager;

    private void Start()
    {
        lifeManager = gameObject.GetComponentInChildren<LifeManager>();
    }

    private void Update()
    {
        if(!lifeManager.IsAlive())
        {
            exit.SetActive(true);
        }
    }
}
