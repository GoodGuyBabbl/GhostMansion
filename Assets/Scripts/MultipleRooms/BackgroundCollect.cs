using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class BackgroundCollect : MonoBehaviour
{
    public float MoveDuration;
    public float StayDuration;
    public float FadeDuration;

    private RectTransform ThisRectTransform;

    private Image Image;
    public Image SpriteImage;

    private void OnEnable()
    {
        ThisRectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();

    }

    public void DoCoroutine(Sprite Sprite)
    {
        SpriteImage.sprite = Sprite;
        StartCoroutine(PopupCollect());
    }

    public IEnumerator PopupCollect()
    {
        Vector2 Startposition = new Vector2(-117, -78);
        Vector2 Endposition = Startposition + new Vector2(0, 195);

        float TimePassed = 0f;
        while(TimePassed < MoveDuration)
        {
            ThisRectTransform.anchoredPosition = Vector3.Lerp(Startposition, Endposition, TimePassed/MoveDuration);
            TimePassed += Time.deltaTime;
            yield return null;
        }
        ThisRectTransform.anchoredPosition = Endposition;

        yield return new WaitForSeconds(StayDuration);

        TimePassed = 0f;
        while (TimePassed < FadeDuration)
        {
            float Alpha = 1f - (TimePassed / FadeDuration);
            Color CurrentColor = Image.color;
            CurrentColor.a = Alpha;
            Image.color = CurrentColor;
            SpriteImage.color = CurrentColor;

            TimePassed += Time.deltaTime;
            yield return null;
        }
        
    }

}
