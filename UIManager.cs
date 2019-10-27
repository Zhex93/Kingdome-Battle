using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set;}
    public Text levelValue, experienceValue, strengthValue, constitutionValue, intelligenceValue, dexterityValue, wisdomValue, pointsValue;
    public GameObject player, newPlayer;

    public static Vector3 playerInstantiate;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        newPlayer = Instantiate(player, playerInstantiate, Quaternion.Euler(0, 0, 0));
    }

    private void Update()
    {
        levelValue.text = "" + CharacterStats.level;
        experienceValue.text = "" + CharacterStats.experience;
        strengthValue.text = "" + CharacterStats.strength;
        constitutionValue.text = "" + CharacterStats.constitution;
        dexterityValue.text = "" + CharacterStats.dexterity;
        intelligenceValue.text = "" + CharacterStats.intelligence;
        wisdomValue.text = "" + CharacterStats.wisdom;
        pointsValue.text = "" + CharacterStats.statsPoints;
    }

    public void SaveLocalStats()
    {
        CharacterStats.level = newPlayer.GetComponent<Player>().playerStats.level;
        CharacterStats.experience = newPlayer.GetComponent<Player>().playerStats.experience;
        CharacterStats.strength = newPlayer.GetComponent<Player>().playerStats.strength;
        CharacterStats.constitution = newPlayer.GetComponent<Player>().playerStats.constitution;
        CharacterStats.dexterity = newPlayer.GetComponent<Player>().playerStats.dexterity;
        CharacterStats.intelligence = newPlayer.GetComponent<Player>().playerStats.intelligence;
        CharacterStats.wisdom = newPlayer.GetComponent<Player>().playerStats.wisdom;
        CharacterStats.statsPoints = newPlayer.GetComponent<Player>().playerStats.statsPoints;
    }

    public void ClearLocalStats()
    {
        CharacterStats.level = 1;
        CharacterStats.experience = 0;
        CharacterStats.strength = 1;
        CharacterStats.constitution = 1;
        CharacterStats.dexterity = 1;
        CharacterStats.intelligence = 1;
        CharacterStats.wisdom = 1;
        CharacterStats.statsPoints = 0;
        CharacterStats.maxHp = 0;
        CharacterStats.maxMp = 0;
        CharacterStats.hp = 0;
        CharacterStats.mp = 0;
    }

    public void StrengthUp()
    {
        newPlayer.GetComponent<Player>().playerStats.statsPoints--;
        newPlayer.GetComponent<Player>().playerStats.strength++;
        SaveLocalStats();
    }

    public void ConstitutionUp()
    {
        newPlayer.GetComponent<Player>().playerStats.statsPoints--;
        newPlayer.GetComponent<Player>().playerStats.constitution++;
        newPlayer.GetComponent<Player>().playerStats.maxHp = Formulas.GetMaxHp(newPlayer.GetComponent<Player>().playerStats);
        newPlayer.GetComponent<Player>().playerStats.hp = Formulas.GetMaxHp(newPlayer.GetComponent<Player>().playerStats);
        SaveLocalStats();
    }

    public void DexterityUp()
    {
        newPlayer.GetComponent<Player>().playerStats.statsPoints--;
        newPlayer.GetComponent<Player>().playerStats.dexterity++;
        SaveLocalStats();
    }

    public void IntelligenceUp()
    {
        newPlayer.GetComponent<Player>().playerStats.statsPoints--;
        newPlayer.GetComponent<Player>().playerStats.intelligence++;
        newPlayer.GetComponent<Player>().playerStats.maxMp = Formulas.GetMaxMp(newPlayer.GetComponent<Player>().playerStats);
        newPlayer.GetComponent<Player>().playerStats.mp = Formulas.GetMaxMp(newPlayer.GetComponent<Player>().playerStats);
        SaveLocalStats();
    }

    public void WisdomUp()
    {
        newPlayer.GetComponent<Player>().playerStats.statsPoints--;
        newPlayer.GetComponent<Player>().playerStats.wisdom++;
        newPlayer.GetComponent<Player>().playerStats.maxMp = Formulas.GetMaxMp(newPlayer.GetComponent<Player>().playerStats);
        newPlayer.GetComponent<Player>().playerStats.mp = Formulas.GetMaxMp(newPlayer.GetComponent<Player>().playerStats);
        SaveLocalStats();
    }

    public void LoadStartPlay()
    {
        ClearLocalStats();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }

    public void LoadCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

    public void LoadQuitGame()
    {
        Application.Quit();
    }
}
