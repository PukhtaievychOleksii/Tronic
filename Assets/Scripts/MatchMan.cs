using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchMan : MonoBehaviour
{
    [SerializeField] private List<Score> scores;
    [SerializeField] private Timer timer;
    [SerializeField] float secondsToPlay;
    [SerializeField] private Spawner spawner;
    public static string WinnerName;
    void Start()
    {
        ResetScores();
        ResetTimer();
        startRound();
        timer.SetMatchMan(this);
    }

    private void ResetScores()
    {
        foreach (Score score in scores) score.SetScore(0);
    }

    private void ResetTimer()
    {
        timer.SetStartTime(secondsToPlay);
    }

    public void UpdateScores(GameObject playerWhichScored)
    {
        foreach(Score score in scores)
        {
            if (score.GetRepresenter() == playerWhichScored) score.IncreaseScore(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startRound()
    {
        spawner.SpawnObjects();
    }

    public void DecideTheWinner()
    {
        int maxScore = scores[0].GetScore();
        Score theHighestScore = scores[0];
        bool areDifferent = false;
        foreach(Score score in scores)
        {
            if (score.GetScore() != maxScore) areDifferent = true;
            if(score.GetScore() > maxScore)
            {
                maxScore = score.GetScore();
                theHighestScore = score;
            }
        }

        if (!areDifferent) WinnerName = "Everybody";
        else WinnerName = theHighestScore.GetRepresenter().name;
    }

    public void EndRound()
    {
        DecideTheWinner();
        SceneManager.LoadScene("ResultScene");
    }
}
