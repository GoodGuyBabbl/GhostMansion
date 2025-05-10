using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeInteraction : TriggerInteraction
{
    private bool start;
    int i;
    private Interactions Interactions;
    private Animator Animator;
    public GameObject Wood;
    public Vector2 WoodSpawn;


    private void Awake()
    {
        WoodSpawn = transform.position;
        WoodSpawn.y = this.gameObject.transform.position.y + 0.5f;
        Interactions = FindFirstObjectByType<Interactions>();
        Animator = GetComponent<Animator>();
    }


    public override void Interact()
    {
        Debug.Log("Interact");
        start = true;
    }



    private void Update()
    {
        base.Update();

        if (start)
        {
            Debug.Log("a");
            if (Interactions.GetHolding())
            {
                i++;
                Debug.Log(i);
                if (i >= 350 && Animator.GetBool("IsChopped") == false)
                {
                    Animator.SetBool("IsChopped", true);
                    i = 0;
                    Instantiate(Wood, WoodSpawn, Quaternion.identity);
                    Instantiate(Wood, WoodSpawn, Quaternion.identity);

                    //this.gameObject.SetActive(false);
                }
            }
            else if(Interactions.WasInteractReleased)
            {
                start = false;
                i = 0;
            }
        }
    }


    


}