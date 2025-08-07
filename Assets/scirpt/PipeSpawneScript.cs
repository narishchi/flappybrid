using UnityEngine;

public class PipeSpawneScript : MonoBehaviour
{
    public GameObject pipe;
    public float baseSpawnTime = 2f;    
    private float currentSpawnTime;
    private float timer = 0f;

    public float heightOfSet = 10f;

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
        currentSpawnTime = Mathf.Max(0.6f, baseSpawnTime - 0.05f * score);
    }

    void Update()
    {
        if (timer < currentSpawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float minY = transform.position.y - heightOfSet;
            float maxY = transform.position.y + heightOfSet;

            Instantiate(pipe,
                new Vector3(transform.position.x, Random.Range(minY, maxY), 0),
                transform.rotation);

            timer = 0;

            Debug.Log("Pipe spawned at Y: " + transform.position.y);
        }
    }
}
