using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TraficManager : MonoBehaviour
{
    [SerializeField] private Transform[] traficPoints;
    [SerializeField] private GameObject car;

    private void Start()
    {
        StartCoroutine(TraficDelay());
    }

    private void SpawnTrafic(int start1, int end1)
    {

        var car1 = Instantiate(car, traficPoints[start1].position, traficPoints[start1].rotation);
        car1.GetComponent<CarMovement>().SetPointsAndSpeed(traficPoints[start1], traficPoints[end1], Random.Range(8f, 13f));
    }
    
    private IEnumerator TraficDelay()
    {
        while (true)
        {
            int point = GetRandomPoint();
            SpawnTrafic(point, point+2);
            yield return new WaitForSeconds(Random.Range(3, 5));
            
        }
        
    }

    private int GetRandomPoint()
    {
        return Random.Range(0, 2);
    }
    
}
