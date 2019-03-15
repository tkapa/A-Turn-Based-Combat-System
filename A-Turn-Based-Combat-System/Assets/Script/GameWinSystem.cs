using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameWinSystem : MonoBehaviour {

    public Resource health;

    public GameObject skillUI;
    public GameObject winUI;

    public TextMeshProUGUI winLoseText;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchUI()
    { 
        skillUI.SetActive(false);
        winUI.SetActive(true);

        if (health.currentValue <= 0)
            winLoseText.text = "You Lose!";
        else
            winLoseText.text = "You Win!";
    }
}
