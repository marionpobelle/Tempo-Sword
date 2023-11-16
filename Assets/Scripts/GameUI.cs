using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
===============================================================================
The GameUI class contains methods used to show informative signes on the system status.
===============================================================================
*/
public class GameUI : MonoBehaviour
{
    //Instance of the UI
    public static GameUI instance;
    //Text used to display the score value
    public TextMeshProUGUI scoreText;
    //Image used to display the lifebar fill amount.
    public Image lifeBar;

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
    UpdateScoreText()
        Update the player' score on the UI.
    ====================
    */
    public void UpdateScoreText()
    {
        scoreText.text = string.Format("Score\n{0}", GameManager.instance.score.ToString());
    }

    /*
    ====================
    UpdateLifeBar()
        Update the player' life on the UI.
    ====================
    */
    public void UpdateLifeBar()
    {
        lifeBar.fillAmount = GameManager.instance.life;
    }


}
