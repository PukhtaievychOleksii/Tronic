using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private GameObject representer;
    [SerializeField] private TextMeshProUGUI textBox;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        textBox.text = score.ToString();
    }

    public void IncreaseScore(int increaseByNumber)
    {
        score += increaseByNumber;
        textBox.text = score.ToString();
    }
    

    public int GetScore()
    {
        return score;
    }

    public GameObject GetRepresenter()
    {
        return representer;
    }
}
