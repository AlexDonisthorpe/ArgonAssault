using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Invoke("loadNextLevel", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
