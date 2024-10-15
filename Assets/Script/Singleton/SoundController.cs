using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{

    AudioSource shootAudio;
    AudioSource powerUpAudio;
    AudioSource explodeAudio;


    private void Start()
    {
        powerUpAudio = GetComponents<AudioSource>()[0];
        shootAudio = GetComponents<AudioSource>()[1];
        explodeAudio = GetComponents<AudioSource>()[2];

    }

    public void ShootAudioPlay()
    {
        if (shootAudio != null && shootAudio.clip != null)
        {
            shootAudio.Stop();
            shootAudio.Play();
        }

    }

    public void PowerUpAudioPlay()
    {
        if (powerUpAudio != null && powerUpAudio.clip != null)
        {
            powerUpAudio.Stop();
            powerUpAudio.Play();
        }
    }

    public void ExplodeAudioPlay()
    {
        if (explodeAudio != null && explodeAudio.clip != null)
        {
            explodeAudio.Stop();
            explodeAudio.Play();
        }
    }


}
