using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;

public class PaintColourPicker : MonoBehaviour
{
    Color[] colours;
    public RawImage[] colourSelectors;
    public PaintLineGenerator paintApp;
    //List<Image> colourSelectionList;
    //public GameObject colourPicker;

    private void Start()
    {
        colourSelectors = GetComponentsInChildren<RawImage>();
        colours = new Color[colourSelectors.Length];
        

        for (int i = 0; i < colours.Length; i++)
        {
            colours[i] = colourSelectors[i].color;
            ObjectDirectory.Instance.AddToList(colourSelectors[i].GetComponent<RectTransform>());
        }
    }

    public void Click(Material mat)
    {
        paintApp.ChangeLineColour(mat);
    }
}
