using UnityEngine;
using UnityEngine.UI;

public class PaintColourOption : MonoBehaviour
{
    public Material BrushMaterial;
    Color color;

    void Start()
    {
        color = GetComponent<RawImage>().color;
    }

    public void Click()
    {
        GetComponentInParent<PaintColourPicker>().Click(BrushMaterial);
    }
}
