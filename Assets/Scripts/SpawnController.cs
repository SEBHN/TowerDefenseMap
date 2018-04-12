using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public float spawnTime;
    public GameObject enemyPrefab;

    private bool spawnEnemy;

    // Use this for initialization
    void Start()
    {
        if (spawnTime <= 0.0f)
        {
            spawnTime = 10.0f;
        }
        spawnEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemy)
        {
            Invoke("SpawnEnemy", spawnTime);
            spawnEnemy = false;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnEnemy = true;
    }
}