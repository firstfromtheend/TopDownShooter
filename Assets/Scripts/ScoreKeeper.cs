using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int playerScore = 0;
    public int PlayerScore { 
        get { return playerScore; } 
        set { playerScore += value;
            playerScore = Mathf.Clamp(playerScore, 0, int.MaxValue);
            Debug.Log($"{playerScore}");
        } 
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
