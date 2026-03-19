using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor.Build;

public class TitleBarScript : MonoBehaviour//, IDragHandler, IPointerDownHandler
{
    //Variables
    WindowScript windowScript;
    RectTransform draggingTransform; 
    //Canvas canvas;
    //Image titleBarImage;
    UIGradient gradient;

    public Color colour1;
    public Color colour2;
    public bool canBeMoved;

    void Start()
    {
        //Sets the variables
        windowScript = GetComponentInParent<WindowScript>();
        draggingTransform = windowScript.GetComponent<RectTransform>();
        //canvas = ThemeManager.instance.ui;
        //titleBarImage = GetComponent<Image>();

        gradient = GetComponentInChildren<UIGradient>();
        gradient.m_color1 = colour1;
        gradient.m_color2 = colour2;

        if (colour1.r <= 0.5f && colour1.g <= 0.5f && colour1.b <= 0.5f)
        {
            GetComponentInChildren<Text>().color = Color.white;
        }
        else
        {
            GetComponentInChildren<Text>().color = Color.black;
        }
    }
}
