using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float currentTime;
    [SerializeField] private TextMeshProUGUI textBox;
    private MatchMan matchMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMatchMan(MatchMan matchMan) {
        this.matchMan = matchMan;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime >= 0) UpdateTimer();
        else matchMan.EndRound();

        if (currentTime <= 6) textBox.color = Color.red;
    }

    public void SetStartTime(float startTime)
    {
        currentTime = startTime + 1;
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        textBox.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
