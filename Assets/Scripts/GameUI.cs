using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public TextMeshProUGUI scoreText;
    public Image lifeBar;

    void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = string.Format("Score\n{0}", GameManager.instance.score.ToString());
    }

    public void UpdateLifeBar()
    {
        lifeBar.fillAmount = GameManager.instance.life;
    }


}
