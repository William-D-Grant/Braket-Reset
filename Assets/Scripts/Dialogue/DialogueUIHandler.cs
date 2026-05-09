using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIHandler : MonoBehaviour
{
  
    private Image _playerSprite;

    private Image _enemySprite;

    private TextMeshProUGUI _talkingName;

    private TextMeshProUGUI _talkingDialogue;

    public void DisplayText(DialogueData data)
    {
        _talkingName.text = data.talkingName;
        _talkingDialogue.text = data.dialogueline;

        if(data.isPlayerTalking == true)
        {
            _playerSprite.sprite = data.talkingSprite;
        }//end if

        else if(data.isPlayerTalking == false)
        {
            _enemySprite.sprite = data.talkingSprite;
        }//end else if

    }


}
