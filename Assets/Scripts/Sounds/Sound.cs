using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string _name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.8f, 1.1f)]
    public float pitch = 1f;

    [HideInInspector]
    public AudioSource sourse;

    public MixerGroupType mixerGroupType;

}

public enum MixerGroupType
{
    Master,
    Sounds,
    Music
}
