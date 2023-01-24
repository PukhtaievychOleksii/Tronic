using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color baseColor;
    [SerializeField] private float breakLenght;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        baseColor = renderer.color;
        
    }

    private IEnumerator waitBreak()
    {
        yield return new WaitForSeconds(breakLenght);
        renderer.color = baseColor;
    }

    public void SetWin()
    {
        renderer.color = Color.green;
        StartCoroutine(waitBreak());
    }

    public void SetLost()
    {
        renderer.color = Color.red;
        StartCoroutine(waitBreak());
    }
}
