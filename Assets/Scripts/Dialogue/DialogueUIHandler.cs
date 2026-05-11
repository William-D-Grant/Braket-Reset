using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIHandler : MonoBehaviour
{
    [SerializeField]
    private Image _playerSprite;

    [SerializeField]
    private Image _enemySprite;

    [SerializeField]
    private TextMeshProUGUI _talkingName;

    [SerializeField]
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
