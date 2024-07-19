using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class pointManager : MonoBehaviour
{
    public static pointManager instance;
    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = score.ToString();
    }

    public void AddPoint(int point)
    {
        score+=point;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);

    }

    public void MinusPoint(int point)
    {
        score -= point;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
    }

}

//public string returnPoint()
//{
//    return "POINTS: " + score.ToString();
//}
//}
