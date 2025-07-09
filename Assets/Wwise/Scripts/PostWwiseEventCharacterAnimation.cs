using UnityEngine;

public class PostWwiseEventCharacterAnimation : MonoBehaviour
{
    public AK.Wwise.Event ChoppingWood;
    public AK.Wwise.Event MiningStone;
    public AK.Wwise.Event MiningIron;
    public AK.Wwise.Event CatchingInsects;
    public AK.Wwise.Event Sichel;

    public void PlayChoppingWood()
    {
        ChoppingWood.Post(gameObject);
    }
    public void PlayMining()
    {
        if (GameObject.FindWithTag("Stone"))
        {
            Debug.Log("Stone");
            MiningStone.Post(gameObject);
        }
        else 
        {
            Debug.Log("Iron");
            MiningIron.Post(gameObject);
        }
    }
    public void PlayCatchingInsects()
    {
        CatchingInsects.Post(gameObject);   
    }
    
    public void PlaySichel()
    {
        if (GameObject.FindWithTag("Sichel"))
        {
            Sichel.Post(gameObject);
            Debug.Log("PlaySichel");
        }
        else
        {
            Sichel.Stop(gameObject);
        }

    }
}
