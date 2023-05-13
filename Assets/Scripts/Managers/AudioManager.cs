using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundEffectUI;
    public AudioClip[] soundEffectInGame;

    public float volume;

    public void Hover()
    {
        audioSource.PlayOneShot(soundEffectUI[0], volume);
    }

    public void Confirm()
    {
        audioSource.PlayOneShot(soundEffectUI[1], volume);
    }

    public void Decline()
    {
        audioSource.PlayOneShot(soundEffectUI[2], volume);
    }

    public void UseItem()
    {
        audioSource.PlayOneShot(soundEffectUI[3], volume);
    }

    public void Pause()
    {
        audioSource.PlayOneShot(soundEffectUI[4], volume);
    }

    public void Unpause()
    {
        audioSource.PlayOneShot(soundEffectUI[5], volume);
    }

    public void Buy()
    {
        audioSource.PlayOneShot(soundEffectUI[6], volume);
    }

    public void Thunder()
    {
        audioSource.PlayOneShot(soundEffectInGame[0], volume);
    }

    public void Slash()
    {
        audioSource.PlayOneShot(soundEffectInGame[1], volume);
    }

    public void Hit()
    {
        audioSource.PlayOneShot(soundEffectInGame[2], volume);
    }

    public void StepOnGrass()
    {
        audioSource.PlayOneShot(soundEffectInGame[3], volume);
    }

    public void Miss()
    {
        audioSource.PlayOneShot(soundEffectInGame[4], volume);
    }

    public void Flee()
    {
        audioSource.PlayOneShot(soundEffectInGame[5], volume);
    }

    public void Death()
    {
        audioSource.PlayOneShot(soundEffectInGame[6], volume);
    }
}
