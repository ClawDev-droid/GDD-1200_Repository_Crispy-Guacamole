using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public Transform[] SpawnPoints;
    public float SpawnRate = 5.0f;

    private void Start()
    {
        StartCoroutine(nameof(RunWave));
    }
    
    private void StartWave()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            var enemyTypeIndex = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[enemyTypeIndex], SpawnPoints[i].position, Enemies[enemyTypeIndex].transform.rotation);
        }
    }

    private IEnumerator RunWave()
    {
        while (true)
        {
            StartWave();
            yield return new WaitForSeconds(SpawnRate);
        }
    }

    

    
    
    
}
