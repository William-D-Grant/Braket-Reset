using UnityEngine;
using UnityEngine.SceneManagement;

public class LossHandler : MonoBehaviour
{
    private GameObject _lossScreen;

    private void Awake()
    {
        _lossScreen.SetActive(false);
    }


    public void ActivateScreen()
    {
        _lossScreen.SetActive(true);
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
