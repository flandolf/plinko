using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // Assign the ball prefab in the Inspector
    public GameObject variables;

    private float dropValueMultiplier = 2f;  // Multiplier for increasing or decreasing drop value
    private float spawnDelay = 0.1f;         // 100 milliseconds delay
    private float lastSpawnTime = 0f;        // Time of last spawn

    public void SpawnBall()
    {
        Variables varScript = variables.GetComponent<Variables>();

        // Check for money
        if (varScript.money < varScript.dropValue)
        {
            return;
        }

        for (int i = 0; i < varScript.dropAmount; i++)
        {
            varScript.money -= varScript.dropValue;
            float x = Random.Range(-1.0f, 1.0f);
            Instantiate(ballPrefab, new Vector3(x, 19, 0), Quaternion.identity);
        }
    }

    void Update()
    {
        float currentTime = Time.time;

        if (Input.GetKey(KeyCode.Space))
        {
            if (currentTime - lastSpawnTime >= spawnDelay)
            {
                SpawnBall();
                lastSpawnTime = currentTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Increase the drop amount by a multiplier
            Variables varScript = variables.GetComponent<Variables>();
            varScript.dropValue = Mathf.Round((float)(varScript.dropValue * dropValueMultiplier));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Decrease the drop amount by a divisor
            Variables varScript = variables.GetComponent<Variables>();
            varScript.dropValue = Mathf.Round((float)(varScript.dropValue / dropValueMultiplier));
            
        }
    }
}