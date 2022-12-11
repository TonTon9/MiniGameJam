using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChinChanChopa : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private Transform _spawnPoint;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
       _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void GetNextPoint()
    {
        
    }

    public void GetSpawnPoint(Transform point)
    {
        _spawnPoint = point;
    }
}
