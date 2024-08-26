using UnityEngine;

public class GrowingTriangleGenerator : MonoBehaviour
{
    public GameObject cylinderPrefab;  // Assign your cylinder prefab in the Inspector
    public float spacing = 1.0f;       // Initial distance between the cylinders
    public int rows = 3;               // Number of rows in the triangle

    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            // Calculate the Y position for the current row
            float yPos = -i * spacing / 1.5f;
            
            // Calculate the X offset for centering the row
            float xOffset = -i * spacing / 2.0f;

            for (int j = 0; j <= i; j++)
            {
                // Calculate the position of each cylinder in the row
                Vector3 position = new Vector3(xOffset + j * spacing, yPos, 0);

                // Instantiate and rotate the cylinder
                Instantiate(cylinderPrefab, position, Quaternion.Euler(-90, 0, 0), transform);
            }
        }
    }
}