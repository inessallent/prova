using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOutsideScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Mummy_Scene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetSceneByName("Outside");

            if (scene.IsValid() && scene.isLoaded)
            {
                SceneManager.UnloadScene("Outside");
            }
            else
            {
                SceneManager.LoadScene("Outside", LoadSceneMode.Additive);
            }
        }
    }
}
