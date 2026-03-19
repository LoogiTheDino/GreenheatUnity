using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DesktopScript : MonoBehaviour
{
    public ObjectDirectory directory;
    IconScript[] icons;

    private void Start()
    {
        icons = GetComponentsInChildren<IconScript>();

        for (int i = 0; i < icons.Length; i++)
        {
            directory.AddToList(icons[i].GetComponent<RectTransform>());
        }
    }
}
