using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryHandler : MonoBehaviour
{
    private GameObject _winScreen;

    private void Awake()
    {
        _winScreen.SetActive(false);
    }


    public void ActivateScreen()
    {
        _winScreen.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void TryAgain()
    {
        SceneManager.LoadScene("BloxSelection");
    }

    public void Exit()
    {
        Application.Quit();
    }

}