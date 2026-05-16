using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _upgradeUI;

    public void ShowUpgradeScreen()
    {
        _upgradeUI.SetActive(true);
    }

    public void UpgradeStat(string chosenStat)
    {
        switch (chosenStat)
        {
            case "ATTACK":
                foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                {
                    blox.GetComponent<ClassVitals>().UpgradeAttack(1);
                    Debug.Log(blox.GetComponent<ClassVitals>().GetAttack());

                }//end foreach
                break;

            case "DEFENSE":
                foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                {
                    blox.GetComponent<ClassVitals>().UpgradeDefense(1);
                }//end foreach
                break;

            case "HYPE":
                foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                {
                    blox.GetComponent<ClassVitals>().UpgradeHype(1);
                }//end foreach
                break;

            case "TM":
                foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                {
                    blox.GetComponent<ClassVitals>().UpgradeTileMovement(1);
                }//end foreach
                break;
        }//end switch
    }//end UpgradeStat

    public void NextRoom()
    {
        SceneManager.LoadScene("DialogueRoom");
    }
}
