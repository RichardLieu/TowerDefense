using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Vector3 target;

    private NavMeshAgent navMeshAgent;

    private Enemy enemy;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        target = new Vector3(70, transform.position.y, -70);
        navMeshAgent.SetDestination(target);
    }
    
    void Update()
    {
        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance == 0)
        {
            EndPath();
        }

        enemy.speed = enemy.startSpeed;
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
