using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    bool isCombat = true;
    private AudioSource[] musics;
    [SerializeField] private float switchTiming = 1;
    [SerializeField] private float musicVolume = 0.5f;

    public void SetCombat(bool combat)
    {
        isCombat = combat;
    }

    void Start()
    {
        musics = GetComponents<AudioSource>();
        musics[0].volume = 0;
        musics[1].volume = musicVolume;
    }

    void Update()
    {
        float volumeChanges = Time.deltaTime / switchTiming;
        if (isCombat)
        {
            if (musics[0].volume > 0)
            {
                musics[0].volume -= volumeChanges* musicVolume;
            }
            if (musics[1].volume < musicVolume)
            {
                musics[1].volume += volumeChanges* musicVolume;
            }
        }
        else
        {
            if (musics[1].volume > 0)
            {
                musics[1].volume -= volumeChanges* musicVolume;
            }
            if (musics[0].volume < musicVolume)
            {
                musics[0].volume += volumeChanges* musicVolume;
            }
        }
    }
}
