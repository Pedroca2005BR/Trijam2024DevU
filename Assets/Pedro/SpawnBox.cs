using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] List<Transform> locations;
    [SerializeField] GameObject boxPrefab;
    int lastSpawn;


    #region Singleton Pattern

    public static SpawnBox instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }

    #endregion


    public void RespawnBox()
    {
        int random;

        do
        {
            random = Random.Range(0, locations.Count);
        } while (random == lastSpawn);


        GameObject box = Instantiate(boxPrefab, locations[random].position, Quaternion.identity, transform);
        lastSpawn = random;
    }
}
