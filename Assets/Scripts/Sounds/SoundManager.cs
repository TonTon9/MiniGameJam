using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] walkSounds;
    public Sound[] runSounds;
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _soundsMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;
 
    
    public void PlaySound(string SoundName)
    {
        var audioSource = gameObject.AddComponent<AudioSource>();
        var sound = GetSoundByName(SoundName);
        audioSource.clip = sound.clip;
        switch (sound.mixerGroupType)
        {
            case MixerGroupType.Master:
                audioSource.outputAudioMixerGroup = _masterMixer;
                break;
            case MixerGroupType.Sounds:
                audioSource.outputAudioMixerGroup = _soundsMixer;
                break;
            case MixerGroupType.Music:
                audioSource.outputAudioMixerGroup = _musicMixer;
                break;
        }
        
        
        audioSource.Play();
    }
    

    private Sound GetSoundByName(string SoundName)
    {
        if (SoundName == "Walk")
        {
            return walkSounds[Random.Range(0, walkSounds.Length - 1)];
        }
        if (SoundName == "Run")
        {
            return runSounds[Random.Range(0, runSounds.Length - 1)];
        }
        foreach (var sound in sounds)
        {
            if (sound._name == SoundName)
            {
                return sound;
            }
        }

        throw new Exception("noSound");
    }
    
}