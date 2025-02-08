using TMPro;
using UnityEngine;

public class StaticText : MonoBehaviour
{
    void Start()
    {
        // Create a new TextMeshPro object
        GameObject textObject = new GameObject("StaticText");
        textObject.transform.position = Vector3.zero; // Set position to (0,0,0)

        // Add TextMeshPro component
        TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();

        // Set some default properties
        textMesh.text = "Hello, World!";
        textMesh.fontSize = 5;
        textMesh.alignment = TextAlignmentOptions.Center;

        // Optional: Make sure it's visible in the scene
        textObject.transform.position = new Vector3(0, 2, 0); // Adjust position if needed
    }
}
