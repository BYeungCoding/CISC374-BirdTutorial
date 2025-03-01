using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject pipesPrefab;
    private float timer = 0;
    public float spawnTime = 15f;
    public float heightOffset = 10;
    public float speedIncreaseFactor = 0.5f;

    public float spawnXOffset = 10f;

    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer -= spawnTime; // Ensure we don’t lose small fractions of time
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float spawnX = transform.position.x + spawnXOffset;
        
        Instantiate(pipesPrefab, new Vector3(spawnX, Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);

        Debug.Log("Pipe spawned at X: " + spawnX + ", spawnTime: " + spawnTime);
    }

    [ContextMenu("Test Increase Speed")]
    public void IncreaseSpeed()
    {
        Debug.Log("Old spawnTime: " + spawnTime);
        spawnTime -= speedIncreaseFactor;
        Debug.Log("New spawnTime: " + spawnTime);
    }

    [ContextMenu("Test Change Background Color")]
    public void ChangeBackgroundColor()
    {
        Camera.main.backgroundColor = new Color(Random.value, Random.value, Random.value);
    }
}