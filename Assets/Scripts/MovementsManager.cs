using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsManager : MonoBehaviour
{
    [SerializeField] private MusicManager music;
    private GameObject[] enemies;
    private GameObject boss;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    public void PlayerMoved()
    {
        //Enemies
        foreach (GameObject enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.GetComponent<EnemyManager>().UpdateEnemy();
            }
        }
        if (boss != null)
        {
            if (boss.activeSelf)
            {
                boss.GetComponent<DragonManager>().UpdateDragon();
            }
        }
        gameManager.RemoveTime(1);
        if (IsEnemyLeft())
        {
            music.SetCombat(true);
        }
        else
        {
            music.SetCombat(false);
        }
    }

    private bool IsEnemyLeft()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                return true;
            }
        }
        if (boss != null)
        {
            if (boss.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject GetEnemyAtLocation(Vector2 position)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyManager>().IsMyPosition(position) && enemy.activeSelf)
            {
                return enemy.gameObject;
            }
        }
        if (boss != null)
        {
            if (boss.activeSelf && boss.GetComponent<DragonManager>().IsMyPosition(position))
                return boss;
        }

        return null;
    }
}
