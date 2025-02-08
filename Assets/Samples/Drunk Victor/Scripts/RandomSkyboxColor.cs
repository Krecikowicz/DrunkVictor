using UnityEngine;
using System.Collections;

public class RandomSkyboxColor : MonoBehaviour
{
    public float changeInterval = 1f; // Time interval in seconds to change the color

    void Start()
    {
        // Ensure there is a skybox material assigned in Render Settings
        if (RenderSettings.skybox == null)
        {
            Debug.LogError("No skybox material assigned in Render Settings!");
            enabled = false; // Disable the script
            return;
        }

        // Start the color-changing coroutine
        StartCoroutine(ChangeSkyboxColor());
    }

    IEnumerator ChangeSkyboxColor()
    {
        while (true)
        {
            // Generate a random color
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // Apply the color to the skybox material
            RenderSettings.skybox.SetColor("_Tint", randomColor);

            // Notify Unity that the material has changed
            DynamicGI.UpdateEnvironment();

            // Wait for the specified interval
            yield return new WaitForSeconds(changeInterval);
        }
    }

    void OnDestroy()
    {
        // Reset the skybox color when the script is destroyed or the game stops
        if (RenderSettings.skybox != null)
        {
            RenderSettings.skybox.SetColor("_Tint", Color.white); // Reset to default white
        }
    }
}