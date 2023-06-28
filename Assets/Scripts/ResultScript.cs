using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshPro winnerText;
    void Start()
    {
        winnerText.text = MatchMan.WinnerName;
        StartCoroutine(LoadMenu(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadMenu(int secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene("Menu");
    }
}
