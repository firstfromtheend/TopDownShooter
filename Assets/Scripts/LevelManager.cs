using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayBeforeLoadScene = 2f;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }
    
    public void loadMainManu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void loadGameOver()
    {
        StartCoroutine(WaitAndLoad(2, delayBeforeLoadScene));
    }

    public void QuitGame()
    {
        Debug.Log("quitting the game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndexInBuild, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndexInBuild);
    }
}
