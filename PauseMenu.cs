using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    public static bool gameIsPaused = false;
    public static bool inStatsMenu = false;

    public GameObject pauseMenuUI, statsMenuPanelUI, statsMenuUI, healthBar;

    public GameObject strengthButton, constitutionButton, intelligenceButton, dexterityButton, wisdomButton;

    public void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ShowStatsButtons();
    }

    public void ShowStatsButtons()
    {
        if (UIManager.Instance.newPlayer.GetComponent<Player>().playerStats.statsPoints >= 1)
        {
            strengthButton.SetActive(true);
            constitutionButton.SetActive(true);
            dexterityButton.SetActive(true);
            intelligenceButton.SetActive(true);
            wisdomButton.SetActive(true);
        }
        else
        {
            strengthButton.SetActive(false);
            constitutionButton.SetActive(false);
            dexterityButton.SetActive(false);
            intelligenceButton.SetActive(false);
            wisdomButton.SetActive(false);
        }
    }
}
