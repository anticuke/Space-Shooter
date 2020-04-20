using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource deathSong;
    public AudioSource winSong;

    public bool levelSong = true;
    public bool DeathSong = false;
    public bool WinSong = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelMusic()
    {
        levelSong = true;
        DeathSong = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if (!deathSong.isPlaying && DeathSong == false)
        {
            deathSong.Play();
            DeathSong = true;
        }
    }

    public void WinSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if (!winSong.isPlaying && WinSong == false)
        {
            winSong.Play();
            WinSong = true;
        }
    }
}
