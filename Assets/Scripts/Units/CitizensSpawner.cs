using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class CitizensSpawner : MonoBehaviour
{
    [SerializeField] [ItemCanBeNull] private List<Citizen> citizens;
    [SerializeField] private int countCitizens;
    [SerializeField] private List<Transform> _movePoints;


    private void Start()
    {
        StartSpawn();
    }

    private void Spawn()
    {
       Citizen typeOfCitizen = GetRandomCitizen();
       var currCitizen = Instantiate(typeOfCitizen, GetRandomPoint().position, GetRandomPoint().rotation);
       currCitizen.SetMovePoints(_movePoints);
       //OnDie
    }

    private Transform GetRandomPoint()
    {
        return _movePoints[Random.Range(0, _movePoints.Count)];
    }

    private Citizen GetRandomCitizen()
    {
        return citizens[Random.Range(0, citizens.Count)];
    }

    private void StartSpawn()
    {
        for (int i = 0; i < countCitizens; i++)
        {
            Spawn();
        }
    }
    
}
