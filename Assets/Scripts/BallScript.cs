using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour, Spawnable

{
    [SerializeField] private float speed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private MatchMan matchMan;
    [SerializeField] private TronicTrain tronicTrain;
    private AudioSource audioSource;
    private SpriteRenderer renderer;
    private GameObject kepper;
    private Vector2 movingVector = new Vector2(1, 1);
    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
        if(collision.gameObject.tag == "Platform")
        {
            rigidBody.velocity = getAfterBounceVector(collision.gameObject).normalized * speed;
            if (SceneManager.GetActiveScene().name != "Trainingfield")
            {
                kepper = collision.gameObject;
                renderer.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
                audioSource.Play();
            }
            else
            {
                tronicTrain.Reward();
            }
            
        }
        if(collision.gameObject.tag == "Gate")
        {
            if (SceneManager.GetActiveScene().name == "Trainingfield") tronicTrain.Punish();
            if(kepper != null) matchMan.UpdateScores(kepper);
        }
        if(collision.gameObject.tag == "Wall")
        {
            this.Spawn();
        }
    }

   

    private Vector2 getAfterBounceVector(GameObject tronic)
    {
        float length = tronic.GetComponent<SpriteRenderer>().bounds.size.x;
        float leftEdge = tronic.transform.position.x - length / 2;
        float rightEdge = tronic.transform.position.x + length / 2;
        float coef = (transform.position.x - leftEdge) / length;
        float angle = 180 * coef;
        float x = Mathf.Abs(Mathf.Cos(angle * Mathf.Deg2Rad));
        float y = Mathf.Abs(Mathf.Sin(angle * Mathf.Deg2Rad));
        int mult = 1;
        if (rigidBody.velocity.normalized.y > 0) mult = -1;
        return new Vector2(x * (coef > 0.5 ? 1 : -1), y * rigidBody.velocity.normalized.y > 0 ? -1 : 1);

    }

    public void Spawn()
    {
        transform.position = spawnPoint.position;
        rigidBody.velocity = new Vector2(0, 0);
        renderer.color = Color.white;
        kepper = null;
        StartCoroutine(chooseRandomDirection((float)1));
    }

    private IEnumerator chooseRandomDirection(float waitForSeconds)
    {
        yield return new WaitForSeconds(waitForSeconds);
        movingVector = new Vector2(Random.Range(-1f, 1f), Random.Range(0.4f, 1f)).normalized;
        rigidBody.velocity = movingVector * speed;
    }
}
