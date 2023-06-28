using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] List<Color> breakColors;
    private int colorIndex = 0;
    void Start()
    {
        ResetColor();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetColor()
    {
        if (breakColors.Count > 0)
        {
            this.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().color = breakColors[0];
            colorIndex = 0;
        }
    }




    public void OnBlockEnter2D()
    {
        if (colorIndex < breakColors.Count - 1)
        {
            colorIndex++;
            GetComponent<SpriteRenderer>().color = breakColors[colorIndex] ;
        }
        else
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
