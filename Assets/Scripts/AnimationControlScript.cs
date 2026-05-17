using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    public Animator theAnimator;
    private float animationTimer = 0f;
    void Start()
    {
        theAnimator = GetComponent<Animator>();
    }

    //https://youtu.be/9yFnaLD0PLI?si=td2X-KrcQsyop8qF
    // Update is called once per frame
    void Update()
    {
        if (animationTimer > 0f)
        {
            animationTimer -= Time.deltaTime;
        }
        else
        {
            theAnimator.Play("Idle");
        }
        
    }

    public void PlayAnimation(string givenAnimation)
    {
        Debug.Log("Animation Test");
        animationTimer = 2f;
        theAnimator.Play(givenAnimation);
    }
}
