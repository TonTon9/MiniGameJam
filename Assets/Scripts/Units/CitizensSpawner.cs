using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class CitizensSpawner : MonoBehaviour
{
    [SerializeField] private List<SimpleCitizen> citizens;
    [SerializeField]  private List<Policeman> policemanPrefab;
    [SerializeField] private int countCitizens;
    [SerializeField] private int countPoliceman;
    [SerializeField] private List<Transform> _movePoints;


    private void Start() {
        SimpleCitizen.OnDie += SpawnCitizen;
        Policeman.OnDie += SpawnPoliceman;
        StartSpawn();
    }

    private void SpawnCitizen()
    {
        SimpleCitizen typeOfCitizen = GetRandomCitizen();
       var currCitizen = Instantiate(typeOfCitizen, GetRandomPoint().position, GetRandomPoint().rotation);
       currCitizen.Init(_movePoints);
    }

    private void SpawnPoliceman() {
        Policeman typeOfCitizen = GetRandomPoliceman();
        var currentPoliceman = Instantiate(typeOfCitizen, GetRandomPoint().position, GetRandomPoint().rotation);
        currentPoliceman.Init(_movePoints);
    }

    private Transform GetRandomPoint()
    {
        return _movePoints[Random.Range(0, _movePoints.Count)];
    }

    private SimpleCitizen GetRandomCitizen()
    {
        return citizens[Random.Range(0, citizens.Count)];
    }
    private Policeman GetRandomPoliceman()
    {
        return policemanPrefab[Random.Range(0, policemanPrefab.Count)];
    }

    private void StartSpawn()
    {
        for (int i = 0; i < countCitizens; i++)
        {
            SpawnCitizen();
        }
        for (int i = 0; i < countPoliceman; i++)
        {
            SpawnPoliceman();
        }
    }

    private void OnDestroy() {
        SimpleCitizen.OnDie -= SpawnCitizen;
        Policeman.OnDie -= SpawnPoliceman;
    }

}
