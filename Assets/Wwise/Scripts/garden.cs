using UnityEngine;

public class garden : MonoBehaviour
{
    public AK.Wwise.Event PlayFrogJump;
    public void frogjump()
    {
        PlayFrogJump.Post(gameObject);
    }
}
