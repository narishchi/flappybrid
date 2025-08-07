using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;
    public float baseSpawnTime = 3f; // เมฆเกิดช้ากว่าเสาเล็กน้อย
    private float currentSpawnTime;
    private float timer = 0f;

    public float heightOffset = 5f;

    void Start()
    {
        currentSpawnTime = baseSpawnTime;
    }

    void OnEnable()
    {
        LogicScript.OnScoreChanged += AdjustSpawnRate;
    }

    void OnDisable()
    {
        LogicScript.OnScoreChanged -= AdjustSpawnRate;
    }

    void AdjustSpawnRate(int score)
    {
        currentSpawnTime = Mathf.Max(1.2f, baseSpawnTime - 0.05f * score);
    }

    void Update()
    {
        if (timer < currentSpawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float minY = transform.position.y - heightOffset;
            float maxY = transform.position.y + heightOffset;

            Instantiate(cloud,
                new Vector3(transform.position.x, Random.Range(minY, maxY), 0),
                transform.rotation);

            timer = 0;

            Debug.Log("Cloud spawned at Y: " + transform.position.y);
        }
    }
}

