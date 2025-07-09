using UnityEngine;

public class PostWwiseEventPuff : MonoBehaviour
{
    public AK.Wwise.Event PlayPuff;

    public void puff()
    {
        PlayPuff.Post(gameObject);
    }
}
