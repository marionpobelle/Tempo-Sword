using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
===============================================================================
The Game Manager class is used to run the main game loop.
===============================================================================
*/
public class GameManager : MonoBehaviour
{
    //Instance of the game manager
    public static GameManager instance;

    //Beginning of the game according to the game manager.
    public float startTime = 3.0f;
    //Current score
    public int score = 0;
    //Current life
    public float life = 1.0f;
    //Amount of points gain upon hitting a block
    public int hitBlockScore = 10;
    //Amount of life lost upon missing a block
    public float missBlockLife = 0.1f;
    //Amount of life lost upon hitting the wrong block
    public float wrongBlockLife = 0.08f;
    //Amount if life regenerating little by little with time
    public float lifeRegenRate = 0.1f;

    //Tracker for the left controller
    public VelocityTracker leftSwordTracker;
    //Tracker for the right controller
    public VelocityTracker rightSwordTracker;
    //Treshhold velocity in order to consider if a block was hit
    public float swordHitVelocityThreshold = 0.1f;

    /*
    ====================
    Awake()
        Awake is called when an enabled script instance is being loaded.
    ====================
    */
    void Awake()
    {
        instance = this;
    }

    /*
	====================
	Update()
		Update is called once per frame. It is used to.
	====================
	*/
    void Update()
    {
        //Increase life over time
        life = Mathf.MoveTowards(life, 1.0f, lifeRegenRate * Time.deltaTime);
        if (life <= 0.0f) LoseGame();
        GameUI.instance.UpdateLifeBar();
    }

    /*
	====================
	AddScore()
		Increase the score.
	====================
	*/
    public void AddScore()
    {
        score += hitBlockScore;
        GameUI.instance.UpdateScoreText();
    }

    /*
	====================
	MissBlock()
		Decrease the life by the amount given when missing a block.
	====================
	*/
    public void MissBlock()
    {
        life -= missBlockLife;
    }

    /*
	====================
	HittingWrongBlock()
		Decrease the life by the amount given when hitting the wrong block.
	====================
	*/
    public void HitWrongBlock()
    {
        life -= wrongBlockLife;
    }

    /*
	====================
	WinGame()
		Triggers when the song is over.
	====================
	*/
    public void WinGame()
    {
        SceneManager.LoadScene(0);
    }

    /*
	====================
	LoseGame()
		Triggers when the player's life reaches 0.
	====================
	*/
    public void LoseGame()
    {
        SceneManager.LoadScene(0);
    }

}
