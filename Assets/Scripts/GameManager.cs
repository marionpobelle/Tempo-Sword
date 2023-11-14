using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    public float startTime = 3.0f;
    public int score = 0;
    public float life = 1.0f;
    public int hitBlockScore = 10;
    public float missBlockLife = 0.1f;
    public float wrongBlockLife = 0.08f;
    public float lifeRegenRate = 0.1f;

    public VelocityTracker leftSwordTracker;
    public VelocityTracker rightSwordTracker;
    public float swordHitVelocityThreshold = 0.1f;


    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // increase lifetime over time
        life = Mathf.MoveTowards(life, 1.0f, lifeRegenRate * Time.deltaTime);
        if (life <= 0.0f) LoseGame();
        GameUI.instance.UpdateLifeBar();
    }

    public void AddScore()
    {
        score += hitBlockScore;
        GameUI.instance.UpdateScoreText();
    }

    public void MissBlock()
    {
        life -= missBlockLife;
    }

    public void HitWrongBlock()
    {
        life -= wrongBlockLife;
    }

    //When the song is over
    public void WinGame()
    {
        SceneManager.LoadScene(0);
    }

    //When the player's life reaches 0
    public void LoseGame()
    {
        SceneManager.LoadScene(0);
    }

}
