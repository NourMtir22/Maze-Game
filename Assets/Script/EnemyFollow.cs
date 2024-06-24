using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField] private float timer = 2;
 

   
    public Transform spawnPoint;

  

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        
    }

  

    
}
