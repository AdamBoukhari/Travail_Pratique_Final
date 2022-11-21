using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static string PAUSE_TEXT = "Pause";
    [SerializeField] private List<Text> texts;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<Image> images;


    public void UpdateTimeLeft(int timeLeft)
    {
        texts[0].text = "x" + timeLeft.ToString();
    }

    public void Pause(bool paused)
    {
        if (paused)
        {
            texts[1].text = PAUSE_TEXT;
        }
        else
        {
            texts[1].text = "";
        }
    }

    public void UpdateWeapon(Weapons weapon)
    {
        Sprite sprite = GetSprite(weapon);
        images[0].sprite = sprite;
    }


    private Sprite GetSprite(Weapons weaponType)
    {
        switch (weaponType)
        {
            case Weapons.DAGGER:
                return sprites[0];
            case Weapons.LONGSWORD:
                return sprites[1];
            case Weapons.SPEAR:
                return sprites[2];
        }
        return null;
    }
}

