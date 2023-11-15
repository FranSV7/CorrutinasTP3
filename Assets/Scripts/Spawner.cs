using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform spawner1;
    [SerializeField] private Transform spawner2;
    [SerializeField] private int objectsToSpawn = 5;
    [SerializeField] private float minSpawnTime = 0.3f;
    [SerializeField] private float maxSpawnTime = 2f;
    [SerializeField] private GameObject spawnersParent;
   

    [Header("Countdown screen")]
    [SerializeField] private TextMeshProUGUI gameStartText;
    [SerializeField] private TextMeshProUGUI numbers;

    private bool gameStarted = false;
    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(CountdownScreen());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameStarted && !isSpawning)
        {
            StartCoroutine(CallSpawn(spawner1, objectsToSpawn));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && gameStarted && !isSpawning)
        {
            StartCoroutine(CallSpawn(spawner2, objectsToSpawn));
        }
    }

    private void SpawnObject(Transform spawner)
    {
        GameObject instantiatedObject = Instantiate(objectPrefab, spawner.position, Quaternion.identity);

        Destroy(instantiatedObject, 2f);
    }


    private IEnumerator CallSpawn(Transform spawner, int spawnsAmount)
    {
        isSpawning = true;
        if (spawner == spawner1)
        {
            for (int i = 0; i < spawnsAmount; i++)
            {
                SpawnObject(spawner);
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < spawnsAmount; i++)
            {
                SpawnObject(spawner);
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            }     
        }
        isSpawning = false;
    }

    private IEnumerator CountdownScreen()
    {
        gameStartText.enabled = true;
        yield return new WaitForSeconds(1f);
        gameStartText.enabled = false;
        numbers.text = "3";
        yield return new WaitForSeconds(1f);
        numbers.text = "2";
        yield return new WaitForSeconds(1f);
        numbers.text = "1";
        yield return new WaitForSeconds(1f);
        spawnersParent.SetActive(true);
        numbers.enabled = false;
        gameStarted = true;
    }


}
