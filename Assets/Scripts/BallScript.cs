using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour

{
    [SerializeField] private float speed;
    [SerializeField] private GameObject tronic;
    [SerializeField] private Transform spawnPoint;
    private Vector2 movingVector = new Vector2(1, 1);
    private Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //rigidBody.AddForce(movingVector * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += new Vector3(movingVector.x, movingVector.y, 0) * Time.deltaTime * speed; 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "HorObst")
        {
            rigidBody.velocity *= new Vector2(1, -1);
        }
        if (collision.gameObject.tag == "VerObst")
        {
            rigidBody.velocity *= new Vector2(-1, 1);
        }
        if(collision.gameObject.name == "Tronic")
        {
            rigidBody.velocity = getAfterBounceVector().normalized * speed;
            tronic.GetComponent<TronicAgent>().Reward();
        }
        if(collision.gameObject.name == "WallD")
        {
            tronic.GetComponent<TronicAgent>().Punish();
        }
    }

    private Vector2 getAfterBounceVector()
    {
        float length = tronic.GetComponent<SpriteRenderer>().bounds.size.x;
        float leftEdge = tronic.transform.localPosition.x - length / 2;
        float rightEdge = tronic.transform.localPosition.x + length / 2;
        float coef = (transform.localPosition.x - leftEdge) / length;
        float angle = 180 * coef;
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector2(-x, y);

    }

    public void respawn()
    {
        transform.localPosition = spawnPoint.localPosition;
        chooseRandomDirection();
    }

    private void chooseRandomDirection()
    {
        movingVector = new Vector2(Random.Range(-1f, 1f), Random.Range(0.4f, 1f)).normalized;
        rigidBody.velocity = movingVector * speed;
    }
}
