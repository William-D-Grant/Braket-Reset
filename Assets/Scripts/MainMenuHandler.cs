// Filename:            MainMenuHandler.cs
// Author:              Professor Wolfe, Edited by Mars Dunn
// Creation Date:       1/29/2026
// Last Modified:       5/7/2026
// Current Version:     0.3
// Previous Version:    0.1.1
// Project:             Braket reset
// Purpose:             Handles the main menu scene transitions
// Version Changes:     Adapted for Braket reset, added credit integration
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The initial screen UI")]
    private GameObject _mainScreen;

    [SerializeField]
    [Tooltip("The settings screen UI")]
    private GameObject _settingScreen;

    [SerializeField]
    [Tooltip("The credit settings screen UI")]
    private GameObject _creditScreen;

    [SerializeField]
    [Tooltip("start of level 1")]
    private int levelSceneIndex;

    // Name:        Start
    // Description: Called immediately before its first Update frame
    // Parameters:  None
    // Returns:     None
    void Start()
    {
        _mainScreen.SetActive(true);
        _settingScreen.SetActive(false);
        _creditScreen.SetActive(false);
    }


    // Name:        SettingsToMain
    // Description: Transitions from the settings screen to the main screen
    // Parameters:  None
    // Returns:     None
    public void SettingsToMain()
    {
        _mainScreen.SetActive(true);
        _settingScreen.SetActive(false);
    }

    // Name:        MainToSettings
    // Description: Transitions from the main screen to the settings screen
    // Parameters:  None
    // Returns:     None
    public void MainToSettings()
    {
        _mainScreen.SetActive(false);
        _settingScreen.SetActive(true);
    }

    // Name:        MainToCredit
    // Description: Transitions from the main screen to the credit screen
    // Parameters:  None
    // Returns:     None
    public void MainToCredit()
    {
        _mainScreen.SetActive(false);
        _creditScreen.SetActive(true);
    }

    // Name:        MainToCredit
    // Description: Transitions from the credit screen to the main screen
    // Parameters:  None
    // Returns:     None
    public void CreditToMain()
    {
        _mainScreen.SetActive(true);
        _creditScreen.SetActive(false);
    }


    // Name:        ExitGame
    // Description: Closes the game
    // Parameters:  None
    // Returns:     None
    public void ExitGame()
    {
        Application.Quit();
        //# Taken from Google AI on 1/29/2026 upon searching for
        //#   "How to exit game in editor Unity"
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Name:        StartRace
    // Description: Loads the race scene
    // Parameters:  None
    // Returns:     None
    public void StartLevel()
    {
        SceneManager.LoadScene("BloxSelection");
    }
}