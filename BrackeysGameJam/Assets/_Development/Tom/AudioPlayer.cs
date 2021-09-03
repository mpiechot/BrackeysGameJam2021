using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Build,
    Laser
}

public class AudioPlayer : MonoBehaviour
{

    private static AudioPlayer instance;

    private AudioSource[] sfxSources;
    [SerializeField] private AudioClip[] clips;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        sfxSources = GetComponentsInChildren<AudioSource>();
        DontDestroyOnLoad(gameObject);

    }

    public static void RequestPlaySound(SoundType type)
    {
        if (instance)
        {
            instance.PlaySound(type);
        }
        else
        {
            print("No Audio Player was found!");
        }
    }

    private void PlaySound(SoundType type)
    {
        int nextAudioSource = NextFreeAudioPlayer();
        sfxSources[nextAudioSource].clip = clips[(int)type];
        sfxSources[nextAudioSource].Play();
    }

    private int NextFreeAudioPlayer()
    {
        for(int i = 1; i < sfxSources.Length; i++)
        {
            if(!sfxSources[i].isPlaying)
            {
                return i;
            }
        }
        return 1;
    }

}
