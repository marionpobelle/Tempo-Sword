using UnityEngine.Audio;
using UnityEngine;

/*
===============================================================================
The Sound class characterize all elements describing a sound.
===============================================================================
*/
[System.Serializable]
public class Sound
{
    //Name of the sound
    public string name;
    //File for the sound
    public AudioClip clip;
    
    //Volume of the sound
    [Range(0f, 1f)]
    public float volume;
    //Pitch of the sound
    [Range(.1f, 3f)]
    public float pitch;

    //If the sound needs to be looped or not
    public bool loop;

    //The audio source that is gonna play the sound
    [HideInInspector]
    public AudioSource source;

}
