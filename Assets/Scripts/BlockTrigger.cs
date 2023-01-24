using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<BlockScript>().OnBlockEnter2D();
    }
}
