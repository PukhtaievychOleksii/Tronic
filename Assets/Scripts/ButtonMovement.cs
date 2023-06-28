using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions{
    Left,
    Rigth
}
public class ButtonMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Directions directionToStart;
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    private Vector3 velocity = new Vector3(0, 0, 0);
    void Start()
    {
        UpdateVelocity();
    }

    void Update()
    {
        
        float width = GetComponent<RectTransform>().rect.width;

        if (transform.localPosition.x - width / 2 < leftBound.localPosition.x)
        {
            UpdateVelocity();
            //transform.localPosition = new Vector3(leftBound.localPosition.x + width / 2 + 0.01f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x + width / 2 > rightBound.localPosition.x)
        {
            UpdateVelocity();
            //transform.localPosition = new Vector3(rightBound.localPosition.x - width / 2 - 0.01f, transform.localPosition.y, transform.localPosition.z);
        }
        
        transform.localPosition += velocity * Time.deltaTime * speed;

    }

    private void UpdateVelocity()
    {
        if(velocity == new Vector3(0, 0, 0))
        {
            velocity = new Vector3(-1, 0, 0);
            if (directionToStart == Directions.Left) velocity = new Vector3(1, 0, 0);
        }

        velocity = -velocity;
    }
}
