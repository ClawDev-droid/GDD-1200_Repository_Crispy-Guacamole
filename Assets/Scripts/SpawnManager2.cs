using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class SpawnManager2 : MonoBehaviour
{
    public GameObject[] Enemies;
    public Transform[] SpawnPoints;
    public int[] SpawnRarities;
    public float SpawnRate = 5.0f;
    private List<int> RelativeSpawnRarities = new List<int>();
    public int initialSpawnAmount = 1;
    public Transform Player;
    
    private int MasterIndex = 0;

    private void Start()
    {
        
        foreach (int RelativeRarity in SpawnRarities)
        {
            MasterIndex += RelativeRarity;
            RelativeSpawnRarities.Add(MasterIndex);
        }
        for (int i = initialSpawnAmount; i > 0; i--)
        {   
        InitialStartWave();
        }
        StartCoroutine(nameof(RunWave));
    }
    
    private void StartWave()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            var count = 0;
            var enemyTypeIndex = 0;
            var enemyTypeRoll = Random.Range(0, MasterIndex);
            //Debug.Log(enemyTypeRoll);
            foreach (int RarityThreshold in RelativeSpawnRarities)
            {
                
                if (enemyTypeRoll <= RarityThreshold)
                {
                    enemyTypeIndex = count;
                    break;
                }
                count += 1;
                
            }
            Instantiate(Enemies[enemyTypeIndex], SpawnPoints[i].position, Enemies[enemyTypeIndex].transform.rotation);
        }
    }
    private void InitialStartWave()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            var count = 0;
            var enemyTypeIndex = 0;
            var enemyTypeRoll = Random.Range(0, MasterIndex);
            //Debug.Log(enemyTypeRoll);
            foreach (int RarityThreshold in RelativeSpawnRarities)
            {
                
                if (enemyTypeRoll >= RarityThreshold)
                {
                    enemyTypeIndex = count;
                }
                count += 1;
                
            }
            var Pos = new Vector3(Random.Range(-400, 400), Random.Range(-200, 200), 0);
            Instantiate(Enemies[enemyTypeIndex], Pos, Enemies[enemyTypeIndex].transform.rotation);
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
