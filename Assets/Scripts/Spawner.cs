using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Spawnable
{
    void Spawn();
}
public class Spawner : MonoBehaviour
{
    [SerializeField] private BallScript ball;
    [SerializeField] private TronicAgent tronicAgent;
    [SerializeField] private PlayerAgent playerAgent;
    

 
    public void Start()
    {
       
    }
    public void SpawnObjects()
    {
        tronicAgent.Spawn();
        playerAgent.Spawn();
        ball.Spawn();

    }
}
