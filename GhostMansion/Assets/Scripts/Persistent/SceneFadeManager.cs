using UnityEngine;
using UnityEngine.UI;

public class SceneFadeManager : MonoBehaviour
{
    public static SceneFadeManager instance;

    [SerializeField] private Image _FadeOutImage;
    [Range(0.1f, 10f), SerializeField] private float _FadeOutSpeed = 5f;
    [Range(0.1f, 10f), SerializeField] private float _FadeInSpeed = 5f;

    [SerializeField] private Color FadeOutColor;

    public bool IsFadingOut { get; private set; }
    public bool IsFadingIn { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        FadeOutColor.a = 0f;
    }

    private void Update()
    {
        if (IsFadingOut)
        {
            if (_FadeOutImage.color.a < 1f)
            {
                FadeOutColor.a += Time.deltaTime * _FadeOutSpeed;
                _FadeOutImage.color = FadeOutColor;
                Debug.Log(FadeOutColor.a);
            }
            else
            {
                IsFadingOut = false;
            }
        }

        if(IsFadingIn)
        {
            if(_FadeOutImage.color.a > 0f)
            {
                FadeOutColor.a -= Time.deltaTime * _FadeInSpeed; 
                _FadeOutImage.color = FadeOutColor;
            }
            else
            {
                IsFadingIn = false;
            }
        }
    }

    public void StartFadeOut()
    {
        _FadeOutImage.color = FadeOutColor;
        IsFadingOut = true;

    }

    public void StartFadeIn()
    {
        if(FadeOutColor.a >= 1f)
        {
            _FadeOutImage.color = FadeOutColor;
            IsFadingIn = true;
        }

    }


}
