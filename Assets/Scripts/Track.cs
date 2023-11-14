using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public SongData song;
    public AudioSource audioSource;

    public List<GameObject> blocks;
    public Transform parent;

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
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    void StartSong()
    {
        audioSource.PlayOneShot(song.song);
        Invoke("SongIsOver", song.song.length);
    }

    void SongIsOver()
    {
        GameManager.instance.WinGame();
    }


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
