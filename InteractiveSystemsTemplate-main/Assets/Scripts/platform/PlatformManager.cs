using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<platform> platforms; // List of platforms to choose from

    void Start()
    {
        StartCoroutine(ManagePlatformMovements());
    }

    private IEnumerator ManagePlatformMovements()
    {
        // Wait for the initial 10 seconds
        yield return new WaitForSeconds(10.0f);

        // Stage 1: Move 1 platform
        TriggerRandomPlatforms(1);
        yield return new WaitForSeconds(10.0f);

        // Stage 2: Move 2-3 platforms
        TriggerRandomPlatforms(Random.Range(2, 4));
        yield return new WaitForSeconds(10.0f);

        // Stage 3: Move 4 platforms
        TriggerRandomPlatforms(4);
    }

    private void TriggerRandomPlatforms(int count)
    {
        List<int> chosenIndices = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex;

            // Ensure a unique platform is chosen
            do
            {
                randomIndex = Random.Range(0, platforms.Count);
            } while (chosenIndices.Contains(randomIndex));

            chosenIndices.Add(randomIndex);
            platforms[randomIndex].TriggerShakeAndBlink();
        }
    }
}
