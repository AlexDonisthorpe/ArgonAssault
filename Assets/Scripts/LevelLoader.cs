using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay= 5f;

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            Invoke("LoadNextLevel", levelLoadDelay);
        }
    }

    // todo: There must be a tidier way to do this, can we cann function parameters with invoke?
    //          IEnumerator maybe?
    public void ReloadLevel()
    {
        Invoke("LoadSameLevel", levelLoadDelay);
    }

    private void LoadSameLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
