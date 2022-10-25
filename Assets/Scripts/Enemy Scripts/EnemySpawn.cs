using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] int mobCap;
    [SerializeField] float spawnInterval;

    public GameObject[] enemyPrefabs;
    public GameObject[] spawnPoints;

    [SerializeField] GameManager gm;


    // Start is called before the first frame update
    void Start()
    {

        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        spawnInterval = gm.spawnInterval;
        mobCap = gm.mobCap;
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        StartCoroutine(BaddieSpawn(mobCap));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BaddieSpawn(int loops)
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < loops; i++)
        {
            int spawnIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnChoice = Random.Range(0, spawnPoints.Length);
            GameObject spawnObj = enemyPrefabs[spawnIndex];
            GameObject spawnPoint = spawnPoints[spawnChoice];
            Instantiate(spawnObj, spawnPoint.transform.position, spawnObj.transform.rotation);

            // Yield execution of this coroutine and return to the main loop until next frame
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
