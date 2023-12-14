using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSoure;

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    public static BackgroundMusic instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayBGMusic();
    }

    private void PlayBGMusic()
    {
        musicAudioSoure.Play();
    }
}
