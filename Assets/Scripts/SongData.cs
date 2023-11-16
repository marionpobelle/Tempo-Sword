using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
===============================================================================
The SongData characterize all elements needed in order to desbribe a song in the context of the game.
===============================================================================
*/
[CreateAssetMenu(fileName = "Song Data", menuName = "New Song Data")]
public class SongData : ScriptableObject
{
    //File for the song
    public AudioClip song;
    //Beats per minute
    public int bpm;
    //When the song actually starts in case it has an intro
    public float startTime;
    //The speed of the song
    public float speed;
}

