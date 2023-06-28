using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEditor;



public class TronicAgent : Agent, Spawnable
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject background;
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private float speed;
    [SerializeField] private List<BlockScript> blocks;
    [SerializeField] private Transform spawnPoint;
    private float previousStepDistance = 0f;
    private float currentStepDistance = 0f;

    public override void OnEpisodeBegin()
    {
       // transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
       // ball.GetComponent<BallScript>().respawn();
      /*  foreach(BlockScript block in blocks){
            block.ResetColor();
        }*/
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
        currentStepDistance = Mathf.Abs(transform.localPosition.x - ball.transform.localPosition.x);
        sensor.AddObservation(currentStepDistance);

        if (currentStepDistance < previousStepDistance)
        {
            SetReward(0.02f);
        }
        else
        {
            SetReward(-0.01f);
        }

        previousStepDistance = currentStepDistance;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float width = GetComponent<SpriteRenderer>().bounds.size.x;

        if(transform.localPosition.x - width / 2 < leftBound.localPosition.x)
        {
            transform.localPosition = new Vector3(leftBound.localPosition.x + width / 2 + 0.01f, transform.localPosition.y, transform.localPosition.z);
        } else if(transform.localPosition.x + width / 2 > rightBound.localPosition.x)
        {
            transform.localPosition = new Vector3(rightBound.localPosition.x - width / 2 - 0.01f, transform.localPosition.y, transform.localPosition.z);
        } else transform.localPosition += new Vector3(moveX, 0, 0) * Time.deltaTime * speed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> actionSegment = actionsOut.ContinuousActions;
        actionSegment[0] = Input.GetAxis("Horizontal");
    }

    public void Reward()
    {
        SetReward(1f);
        try {
            background.GetComponent<Background>().SetWin();
        }
        catch{}
       // EndEpisode();
    }

    public void Punish()
    {
        SetReward(-1f);
        try
        {
            background.GetComponent<Background>().SetLost();
        }
        catch { }
        EndEpisode();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") Reward();
    }

    public void Spawn()
    {
        transform.position = spawnPoint.position;
    }
}
