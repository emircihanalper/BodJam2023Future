using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void StartGame()
    {
        LoadNextLevel();        
    }
    public void Credits()
    {
        SceneManager.LoadScene(8);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelIndex);
    }
}
