using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    float transitionTime = 1.0F;

    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadLevel(currentSceneIndex + 1));
    }

    public void FirstScene()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void FinalScene()
    {
        StartCoroutine(LoadLevel(2));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
