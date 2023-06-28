using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : MonoBehaviour, Spawnable
{
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private float speed;
    [SerializeField] private Transform spawnPoint;


    public void Spawn()
    {
        transform.position = spawnPoint.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float width = GetComponent<SpriteRenderer>().bounds.size.x;

        if (transform.localPosition.x - width / 2 < leftBound.localPosition.x)
        {
            transform.localPosition = new Vector3(leftBound.localPosition.x + width / 2 + 0.01f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x + width / 2 > rightBound.localPosition.x)
        {
            transform.localPosition = new Vector3(rightBound.localPosition.x - width / 2 - 0.01f, transform.localPosition.y, transform.localPosition.z);
        }
        else transform.localPosition += new Vector3(moveX, 0, 0) * Time.deltaTime * speed;
    }
}
