using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesDisplay;
    [SerializeField] GameObject[] hearts;

    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI resultsTextDisplay;
    [SerializeField] string winText = "Complete!";
    [SerializeField] string loseText = "Game Over!";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives(int value)
    {
        livesDisplay.text = "Lives: " + value.ToString();
        hearts[value].SetActive(false);
    }

    public void displayResults(bool isWin)
    {
        resultsPanel.SetActive(true);
        if (isWin)
        {
            resultsTextDisplay.text = winText;
        }
        else
        {
            resultsTextDisplay.text = loseText;
        }
    }
}
