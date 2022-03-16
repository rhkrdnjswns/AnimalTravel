using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    [SerializeField] private AudioClip[] backGroundMusic;
    [SerializeField] private AudioSource audioSource;

    public  static SoundManager Instance { get => instance; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance);
        
        
    }
    private void Start()
    {
        SetMainBGM();
    }
    public void SetMainBGM()
    {
        audioSource.clip = backGroundMusic[0];
        PlayAudio();
    }
    public void SetStageBGM(bool isClear = false)
    {
        if (isClear)
        {
            audioSource.clip = null;
        }
        audioSource.clip = backGroundMusic[1];
        PlayAudio();
    }
    public void PauseAudio()
    {
        audioSource.Pause();
    }
    public void PlayAudio()
    {
        audioSource.Play();
    }
    
}
