using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class CursorScript : MonoBehaviour
{
    Vector3 mousePos;
    RectTransform rectTransform;
    TMP_Text text;
    //string user;

    [SerializeField]
    RectTransform tip;
    public RectTransform overlap;
    public RectTransform overlapInitial;
    public bool overSomething;
    Canvas canvas;
    Image cursorImage;
    //bool grabbingSomething;

    public enum MouseState { Hover, Drag };
    public MouseState state;

    string userID;
    bool Drawing;

    public RectTransform GetTip()
    {
        return tip;
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();
        canvas = GetComponentInParent<Canvas>();
        cursorImage = GetComponentInChildren<Image>();

        transform.SetAsLastSibling();
    }

    public void Update()
    {
        GreenHeatEventManager.OnGreenHeatHover += MoveCursor;
        GreenHeatEventManager.OnGreenHeatClick += Click;
        GreenHeatEventManager.OnGreenHeatRelease += Release;
        GreenHeatEventManager.OnGreenHeatDrag += Drag;
        
        rectTransform.position = mousePos;

        if (state == MouseState.Hover)
        {
            if (overSomething == true)
            {
                overSomething = false;
                overlapInitial = null;
            }
        }
        
        if (ObjectDirectory.IsOverlapping(tip, overlap) && overlap != null)
        {
            if (overSomething == false)
            {
                overSomething = true;
                if (state == MouseState.Hover) overlapInitial = overlap;
            }

            if (overlapInitial.GetComponent<IconScript>() != null)
            {
                if (state == MouseState.Drag)
                {
                    overlap.GetComponent<IconScript>().StartApp();
                }
            }
            else if (overlapInitial.GetComponent<TitleBarScript>() != null && overlapInitial.GetComponent<TitleBarScript>().canBeMoved)
            {
                if (state == MouseState.Drag)
                {
                    overlapInitial.GetComponentInParent<WindowScript>().transform.SetParent(this.transform);
                    overlapInitial.GetComponentInParent<WindowScript>().transform.SetAsFirstSibling();
                }
                else
                {
                    overlapInitial.GetComponentInParent<WindowScript>().transform.SetParent(canvas.transform);
                    transform.SetAsLastSibling();
                }
            }
            else if (overlapInitial.gameObject.GetComponent<Button>() != null && state == MouseState.Drag)
            {
                switch (overlapInitial.gameObject.name)
                {
                    case "CloseButton":
                        overlapInitial.GetComponentInParent<WindowScript>().CloseWindow();
                        overlap = null;
                        overlapInitial = null;
                        return;

                    case "Play Button (Pong)":
                        ObjectDirectory.Instance.Pong.PlayGame();
                        return;

                    case "Quit Button (Pong)":
                        ObjectDirectory.Instance.Pong.QuitApp();
                        return;

                    case "AssignButtonLeft":
                        ObjectDirectory.Instance.Pong.AssignPlayer1(userID);
                        //HideCursorNoId();
                        return;

                    case "AssignButtonRight":
                        ObjectDirectory.Instance.Pong.AssignPlayer2(userID);
                        //HideCursorNoId();
                        return;

                    case "Back to Title Screen (Pong)":
                        ObjectDirectory.Instance.Pong.BackToTitleScreen();
                        return;
                }
            }
            else if (overlapInitial.gameObject.GetComponent<PaintColourOption>() != null && state == MouseState.Drag)
            {
                overlapInitial.GetComponent<PaintColourOption>().Click();
            }
        }

    }

    public void DefineCursor(string id, Canvas cvs)
    {
        userID = id;
        text.text = id;

        rectTransform = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();
        canvas = cvs;
        cursorImage = GetComponentInChildren<Image>();
    }

    public void HideCursorNoId()
    {
        cursorImage.enabled = false;
        text.enabled = false;
    }

    public void HideCursor(string id)
    {
        if (id == userID)
        {
            cursorImage.enabled = false;
            text.enabled = false;
        }
    }

    public void ShowCursor()
    {
        cursorImage.enabled = true;
        text.enabled = true;
    }

    public void MoveCursor(GreenHeatMessage message)
    {
        if (message.id == userID)
        {
            mousePos = new Vector3(message.x * 1280, 720 - (message.y * 720), 1);
        }
        //ghmsg = message;
    }

    public void Click(GreenHeatMessage message)
    {
        //Change to Drag State
        if (message.id == userID) state = MouseState.Drag;
        //mousePos = new Vector3(message.x * 1280, 720 - (message.y * 720), 0);
    }

    public void Drag(GreenHeatMessage message)
    {
        if (message.id == userID) mousePos = new Vector3(message.x * 1280, 720 - (message.y * 720), 1);
        
    }

    public void Release(GreenHeatMessage message)
    {
        //change to hover state
        //grabbingSomething = false;
        if (message.id == userID) state = MouseState.Hover;
        //mousePos = new Vector3(message.x * 1280, 720 - (message.y * 720), 0);
    }
}
