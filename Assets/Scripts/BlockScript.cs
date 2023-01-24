using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] List<Color> breakColors;
    void Start()
    {
        if(breakColors.Count > 0)
        {
            GetComponent<SpriteRenderer>().color = breakColors[0];
            breakColors.RemoveAt(0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
    public void OnBlockEnter2D()
    {
        if (breakColors.Count > 0)
        {
            GetComponent<SpriteRenderer>().color = breakColors[0];
            breakColors.RemoveAt(0);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
