using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonClip;

    [SerializeField] AudioSource mainAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainAudioSource = GameObject.Find("SFXController").GetComponent<AudioSource>();
    }

    public void ButtonPress()
    {
        audioSource.PlayOneShot(buttonClip);
    }

    public void CallMainButton()
    {
        mainAudioSource.PlayOneShot(buttonClip);
    }

}
