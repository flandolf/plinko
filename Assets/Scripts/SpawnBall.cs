using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // Assign the ball prefab in the Inspector

    public GameObject variables;
    // This method is called when the button is clicked
    public void SpawnBall()
    {
        // check for money
        if (variables.GetComponent<Variables>().money < variables.GetComponent<Variables>().dropValue)
        {
            return;
        }
        for (int i = 0; i < variables.GetComponent<Variables>().dropAmount; i++)
        {
            variables.GetComponent<Variables>().money -= variables.GetComponent<Variables>().dropValue;
            float x = Random.Range(-1.0f, 1.0f);
            Instantiate(ballPrefab, new Vector3(x,19, 0), Quaternion.identity);
        }
    }
    
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Increase the drop amount by 1
            variables.GetComponent<Variables>().dropValue = variables.GetComponent<Variables>().dropValue * 2 ;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Decrease the drop amount by 1
            variables.GetComponent<Variables>().dropValue = variables.GetComponent<Variables>().dropValue / 2 ;
        }
    }

}