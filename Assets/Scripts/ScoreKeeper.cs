using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;

    private int playerScore = 0;
    public int PlayerScore { 
        get { return playerScore; } 
        set { playerScore += value;
            playerScore = Mathf.Clamp(playerScore, 0, int.MaxValue);
            Debug.Log($"{playerScore}");
        } 
    }

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
    public int Getscore()
    {
        return playerScore;
    }
}
