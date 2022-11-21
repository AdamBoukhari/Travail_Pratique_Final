using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private  Weapons weaponType;
    private SpriteRenderer sprite;
    private AudioSource sound;
    [SerializeField] private List< Sprite> sprites;

    void Start()
    {
        sprite=GetComponent<SpriteRenderer>();
        sound = GetComponentInChildren<AudioSource>();
        SwitchSprite();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AttackManager player = collision.gameObject.GetComponent<AttackManager>();
            Weapons oldWeapon = player.CurrentWeapon();
            player.SwitchWeapon(weaponType);
            weaponType = oldWeapon;
            if (sound != null)
            {
                sound.Play();
            }
            SwitchSprite();
        }
    }

    private void SwitchSprite()
    {
        switch (weaponType)
        {
            case Weapons.DAGGER:
                sprite.sprite = sprites[0];
                break;
            case Weapons.LONGSWORD:
                sprite.sprite = sprites[1];
                break;
            case Weapons.SPEAR:
                sprite.sprite = sprites[2];
                break;
        }
    }

}
