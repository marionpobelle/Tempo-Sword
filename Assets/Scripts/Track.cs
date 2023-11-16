using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
===============================================================================
The Track class characterize the sound track by the song and the blocks associated with its beats.
===============================================================================
*/
public class Track : MonoBehaviour
{
    //Data for the track's song
    public SongData song;
    //Audio source for the song
    public AudioSource audioSource;
    //List containing all the blocks that can be placed on the track
    public List<GameObject> blocks;
    //Transform of the track
    public Transform parent;

    /*
    ====================
    Awake()
        Awake is called when an enabled script instance is being loaded. It is used to set up the blocks on the track.
    ====================
    */
    void Awake()
    {
        int randomNumberLeft;
        int randomNumberRight;
        for (int i = 0; i < 200; i++)
        {
            randomNumberLeft = Random.Range(0, blocks.Count);
            randomNumberRight = Random.Range(0, blocks.Count);
            float beatLength = 60.0f / (float)song.bpm;
            float beatDist = beatLength * song.speed;

            GameObject cloneLeft = Instantiate(blocks[randomNumberLeft], transform.localPosition + new Vector3(-0.5f, 1f, i * beatDist), Quaternion.identity, parent);
            GameObject cloneRight = Instantiate(blocks[randomNumberRight], transform.localPosition + new Vector3(0.5f, 1f, i * beatDist), Quaternion.identity, parent);
            cloneLeft.transform.Rotate(0.0f, 180.0f, 0.0f);
            cloneRight.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    /*
    ====================
    Start()
        Start is called before the first frame update. It is used to set up the track's position and start the song.
    ====================
    */
    void Start()
    {
        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
    }

    /*
    ====================
    Update()
        Update is called once per frame. It is used to move the track towards the player.
    ====================
    */
    void Update()
    {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    /*
    ====================
    StartSong()
        Ask the audio source to play the song for the current track.
    ====================
    */
    void StartSong()
    {
        audioSource.PlayOneShot(song.song);
        Invoke("SongIsOver", song.song.length);
    }

    /*
    ====================
    SongIsOver()
        Indicate to the Game Manager that the second has been gone through entirely.
    ====================
    */
    void SongIsOver()
    {
        GameManager.instance.WinGame();
    }

    /*
    ====================
    OnDrawGizmos()
        Draw the beats on the track lines as white lines.
    ====================
    */
    void OnDrawGizmos()
    {
        for (int i = 0; i < 200; i++)
        {
            float beatLength = 60.0f / (float)song.bpm;
            float beatDist = beatLength * song.speed;
            Gizmos.DrawLine(transform.position + new Vector3(-1, 0, i * beatDist), transform.position + new Vector3(1, 0, i * beatDist));
        }
    }
}
