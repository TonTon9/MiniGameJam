using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CitizensSpawner : MonoBehaviour
{
    [SerializeField] private List<SimpleCitizen> citizens;
    [SerializeField]  private List<Policeman> policemanPrefabs_1;
    
    [SerializeField]  private List<Policeman> policemanPrefab_2;
    
    [SerializeField]  private List<Policeman> policemanPrefab_3;
    
    [SerializeField] private int countCitizens;
    [SerializeField] private int countPoliceman_1;
    
    [SerializeField] private int countPoliceman_2;
    
    [SerializeField] private int countPoliceman_3;
    
    [SerializeField] private int countPoliceman_4;
    
    [SerializeField] private List<Transform> _movePoints;

    private int _complexity = 1;

    [SerializeField]
    private GameHud _gameHud;

    private void Start() {
        SimpleCitizen.OnDie += SpawnCitizen;
        Policeman.OnDie += SpawnPoliceman;
        StartSpawn();
        Invoke(nameof(IncreaseComplexity), 30f);
        Invoke(nameof(IncreaseComplexity), 60f);
        Invoke(nameof(IncreaseComplexity), 250f);
    }

    private void IncreaseComplexity() {
        _complexity++;
        if (_complexity > 4) _complexity = 4;
        _gameHud.IncreaseComplexity(_complexity);
        if (_complexity == 2) {
            for (int i = 0; i < countPoliceman_2; i++)
            {
                SpawnPoliceman();
            }
        }
        if (_complexity == 3) {
            for (int i = 0; i < countPoliceman_3; i++)
            {
                SpawnPoliceman();
            }
        }
        if (_complexity == 4) {
            for (int i = 0; i < countPoliceman_4; i++)
            {
                SpawnPoliceman();
            }
        }
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
        switch (_complexity) {
            case 1:
                return policemanPrefabs_1[Random.Range(0, policemanPrefabs_1.Count)];     
            case 2:
                return policemanPrefab_2[Random.Range(0, policemanPrefab_2.Count)];     
            case 3:
                return policemanPrefab_3[Random.Range(0, policemanPrefab_3.Count)];     
        }
        return null;
    }

    private void StartSpawn()
    {
        for (int i = 0; i < countCitizens; i++)
        {
            SpawnCitizen();
        }
        for (int i = 0; i < countPoliceman_1; i++)
        {
            SpawnPoliceman();
        }
    }

    private void OnDestroy() {
        SimpleCitizen.OnDie -= SpawnCitizen;
        Policeman.OnDie -= SpawnPoliceman;
    }

}
