using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    private int Maximum;

    private void Start()
    {

    }

    public void GetMaximum(int Max)
    {
        Maximum = Max;
    }
    public void SetCurrentFill(int Current)
    {
        float fillAmount = (float)Current / (float)Maximum;
        transform.localScale = new Vector3 (fillAmount, transform.localScale.y, transform.localScale.z);
    }
}
