using UnityEngine.Audio;
using UnityEngine;
using System;

/*
===============================================================================
The AudioManager class characterize an object that will be able to play and control sounds.
===============================================================================
*/
public class AudioManager : MonoBehaviour
{

    //List of all sounds available
    public Sound[] sounds;

    //Instance of the audio manager
    public static AudioManager instance;

    /*
    ====================
    Awake()
        Awake is called when an enabled script instance is being loaded. It is used to set up the audio manager and all of the available sounds.
    ====================
    */
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /*
    ====================
    Play()
        Play an audio clip.
        @param name : String that represents the name of the sound we want to play.
    ====================
    */
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    /*
    ====================
    Pause()
        Pause an audio clip.
        @param name : String that represents the name of the sound we want to pause.
    ====================
    */
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    /*
    ====================
    Unpause()
        Unpause an audio clip.
        @param name : String that represents the name of the sound we want to unpause.
    ====================
    */
    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }

    /*
    ====================
    Stop()
        Stop an audio clip.
        @param name : String that represents the name of the sound we want to stop playing.
    ====================
    */
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    /*
    ====================
    IsPlaying()
        Check if an audio clip is playing.
        @param name : String that represents the name of the sound we want to check if it's playing.
    ====================
    */
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    /*
    ====================
    PlayOneShot()
        Play an audio clip without cancelling clips that are already being played by AudioSource.PlayOneShot() and AudioSource.Play().
        @param name : String that represents the name of the sound we want to play.
    ====================
    */
    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }
}
