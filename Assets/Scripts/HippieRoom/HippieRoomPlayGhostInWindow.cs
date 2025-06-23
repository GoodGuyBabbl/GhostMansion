using System.Collections;
using UnityEngine;

public class HippieRoomPlayGhostInWindow : MonoBehaviour 
{
    private Animator Animator;
    public string Trigger = "PlayGhost";

    public AK.Wwise.Event PlayDrinkThrowAway;
    

    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.SetTrigger(Trigger);
        PlayDrinkThrowAway.Post(gameObject);
        StartCoroutine(WaitAndPlayAgain());
        Debug.Log("test");
    }



    private IEnumerator WaitAndPlayAgain()
    {
        Debug.Log("Playing");
        yield return new WaitForSeconds(25f);
        Animator.SetTrigger(Trigger);
        PlayDrinkThrowAway.Post(gameObject);
        StartCoroutine(WaitAndPlayAgain());
    }
}
