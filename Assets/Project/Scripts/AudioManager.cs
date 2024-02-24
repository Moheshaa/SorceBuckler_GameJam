using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public float volume;
    public AudioMixer mixer;

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }
}
