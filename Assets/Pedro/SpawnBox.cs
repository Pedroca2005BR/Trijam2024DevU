using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] List<Transform> locations;
    [SerializeField] GameObject boxPrefab;
    [SerializeField] ScoreManager scoreManager;
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

        scoreManager.UpdateScore(this, 1);
        PlayerPrefs.SetInt("Pontuacao", PlayerPrefs.GetInt("Pontuacao", 0) + 1);

        do
        {
            random = Random.Range(0, locations.Count);
        } while (random == lastSpawn);


        GameObject box = Instantiate(boxPrefab, locations[random].position, Quaternion.identity, transform);
        lastSpawn = random;
    }
}
