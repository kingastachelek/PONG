using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public TextMeshProUGUI leftPlayerScoreText;
    public TextMeshProUGUI rightPlayerScoreText;

    public int leftPlayerScore;
    public int rightPlayerScore;

    private void Start()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        leftPlayerScoreText.text = leftPlayerScore.ToString();
        rightPlayerScoreText.text = rightPlayerScore.ToString();
    }

    public void IncrementLeftPlayerScore()
    {
        leftPlayerScore++;
        leftPlayerScoreText.text = leftPlayerScore.ToString();
    }

    public void IncrementRightPlayerScore()
    {
        rightPlayerScore++;
        rightPlayerScoreText.text = rightPlayerScore.ToString();
    }
}
