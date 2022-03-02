using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        Debug.Log(healthSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreKeeper.PlayerScore.ToString();
        healthSlider.value = playerHealth.GetHealth();
    }
}
