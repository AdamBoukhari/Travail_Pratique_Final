using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private MovementsManager movementsManager;
    [SerializeField] private Particle slashParticle;
    [SerializeField] private int damage = 1;
    private CameraManager cameraManager;
    private GameManager gameManager;

    void Start()
    {
        movementsManager = GameObject.FindGameObjectWithTag("MovementsManager").GetComponent<MovementsManager>();
        cameraManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SwitchWeapon(Weapons newWeapon)
    {
        gameManager.UpdateWeapon(newWeapon);
    }

    public Weapons CurrentWeapon()
    {
        return gameManager.GetWeapon();
    }

    public bool Attack(string orientation, int side, Vector2 position)
    {
        Vector2 target;
        Vector2 slashPosition = position;
        bool move = true;
        if (orientation.Equals("Vertical"))
        {
            target = new Vector2(position.x, position.y + side);
            bool isEnemy = DealDamage(target);
            if (isEnemy)
            {
                move = false;
                slashPosition = target;
            }
            switch (gameManager.GetWeapon())
            {
                case Weapons.LONGSWORD:
                    target = new Vector2(position.x + Utils.UNIT_SIZE, position.y + side);
                    bool isEnemy1 = DealDamage(target);
                    target = new Vector2(position.x - Utils.UNIT_SIZE, position.y + side);
                    bool isEnemy2 = DealDamage(target);
                    if (isEnemy1 || isEnemy2)
                    {
                        move = false;
                        slashPosition = new Vector2(position.x, position.y + side);
                    }
                    break;
                case Weapons.SPEAR:
                    target = new Vector2(position.x , position.y+side*2);
                    bool dealt = DealDamage(target);
                    if (dealt)
                    {
                        move = false;
                        slashPosition = new Vector2(position.x , position.y + side * 1.5f);
                    }
                    break;
            }
        }
        else
        {
            target = new Vector2(position.x + side, position.y);
            bool isEnemy = DealDamage(target);
            if (isEnemy)
            {
                move = false;
                slashPosition = target;
            }
            //Cibles supplémentaires des autres armes
            switch (gameManager.GetWeapon())
            {
                case Weapons.LONGSWORD:
                    target = new Vector2(position.x + side, position.y + Utils.UNIT_SIZE);
                    bool isEnemy1 = DealDamage(target);
                    target = new Vector2(position.x + side, position.y - Utils.UNIT_SIZE);
                    bool isEnemy2 = DealDamage(target);
                    if (isEnemy1 || isEnemy2)
                    {
                        move = false;
                        slashPosition = new Vector2(position.x + side, position.y);

                    }
                    break;
                case Weapons.SPEAR:
                    target = new Vector2(position.x + side*2, position.y);
                    bool dealt = DealDamage(target);
                    if (dealt)
                    {
                        move = false;
                        slashPosition = new Vector2(position.x + side * 1.5f, position.y);
                    }
                    break;
            }
        }
        if (!move)
        {
            AnimateSlash(orientation, side, slashPosition);
        }
        return move;
    }

    public void AnimateSlash(string orientation, int side, Vector2 position)
    {
        switch (gameManager.GetWeapon())
        {
            case Weapons.DAGGER:
                slashParticle.PlayAnim("dagger", position);
                slashParticle.gameObject.SetActive(true);
                break;
            case Weapons.LONGSWORD:
                slashParticle.PlayAnim("longsword", position);
                slashParticle.gameObject.SetActive(true);
                if (orientation.Equals("Vertical"))
                {
                    slashParticle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    slashParticle.gameObject.GetComponent<SpriteRenderer>().flipX = side == -1;
                }
                break;
            case Weapons.SPEAR:
                slashParticle.PlayAnim("spear", position);
                slashParticle.gameObject.SetActive(true);
                if (orientation.Equals("Vertical"))
                {
                    slashParticle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    slashParticle.gameObject.GetComponent<SpriteRenderer>().flipX = side == -1;
                }
                break;
        }

        if (orientation.Equals("Horizontal"))
        {
            slashParticle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            slashParticle.gameObject.GetComponent<SpriteRenderer>().flipX = side == -1;
        }
    }

    public bool DealDamage(Vector2 target)
    {
        GameObject enemy = movementsManager.GetEnemyAtLocation(target);
        if (enemy != null)
        {
            cameraManager.Shake(0.1f, 0.1f);
            enemy.GetComponent<LifeManager>().DealDamage(damage);
            return true;
        }
        return false;
    }

}
