using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("AudioManager is NULL!");
            }

            return _instance;
        }
    }

    [SerializeField]
    private AudioSource _voiceOverAudioSource;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _coinSound;
    [SerializeField]
    private AudioSource _music;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        if(!TryGetComponent(out _audioSource))
        {
            Debug.Log("AudioSource is NULL!");
        }
    }

    public void PlayCoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
    }

    public void PlayVoiceOverSound(AudioClip clip)
    {
        _voiceOverAudioSource.clip = clip;
        _voiceOverAudioSource.Play();
    }

    public void PlayBackgroundMusic()
    {
        _music.Play();
    }
}
