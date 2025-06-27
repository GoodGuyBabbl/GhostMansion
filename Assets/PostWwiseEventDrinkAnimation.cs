using UnityEngine;

public class PostWwiseEventDrinkAnimation : MonoBehaviour
{
    public AK.Wwise.Event Drink;
    public AK.Wwise.Event Throw;
    public AK.Wwise.Event Glass;

    public void PlayDrink()
    {
        Drink.Post(gameObject);
    }
    public void PlayThrow()
    {
        Throw.Post(gameObject);
    }
    public void PlayGlass()
    {
        Glass.Post(gameObject);
    }
}
