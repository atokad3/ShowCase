using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vrooom : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfxVroom;

    public void Vroooom()
    {
        src.clip = sfxVroom;
        src.Play();
    }
}
