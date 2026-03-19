using System.Collections.Generic;
using UnityEngine;

public class ObjectDirectory : MonoBehaviour
{
    public List<RectTransform> mouseTips;
    [Tooltip("The UI elements to check for overlaps.")]
    public List<RectTransform> uiTargets;

    public AdminSettings adminSettings;

    [Header("Apps")]
    public GameObject desktopIcons;
    public PongScript Pong;
    public PaintLineGenerator paint;

    [Header("Misc")]
    public GameObject iconPrefab;

    [Header("Results")]
    public GameObject[] overlappingObjects;

    private static ObjectDirectory _instance;
    public static ObjectDirectory Instance { get { return _instance; } }

    private void Awake() //making it persist across scenes
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddTip(RectTransform tip)
    {
        mouseTips.Add(tip);
        overlappingObjects = new GameObject[mouseTips.Count];
    }

    void Update()
    {
        for (int i = 0; i < mouseTips.Count; i++)
        {
            mouseTips[i].GetComponentInParent<CursorScript>().overlap = null;

            foreach (RectTransform target in uiTargets)
            {
                if (IsOverlapping(mouseTips[i], target))
                {
                    // Assign the overlapping UI element's GameObject to your variable
                    overlappingObjects[i] = target.gameObject;
                    mouseTips[i].GetComponentInParent<CursorScript>().overlap = overlappingObjects[i].GetComponent<RectTransform>();
                    break; // Stop at the first overlap found
                }
            }
        }
        
    }

    public void AddToList(RectTransform rct)
    {
        uiTargets.Add(rct);
    }

    public void RemoveFromList(RectTransform rct)
    {
        uiTargets.Remove(rct);
    }

    public static bool IsOverlapping(RectTransform rectA, RectTransform rectB)
    {
        if (rectA == null || rectB == null) return false;

        Vector3[] cornersA = new Vector3[4];
        Vector3[] cornersB = new Vector3[4];

        rectA.GetWorldCorners(cornersA);
        rectB.GetWorldCorners(cornersB);

        Rect rect1 = new Rect(cornersA[0], cornersA[2] - cornersA[0]);
        Rect rect2 = new Rect(cornersB[0], cornersB[2] - cornersB[0]);

        return rect1.Overlaps(rect2);
    }

    public void ShowAllCursors()
    {
        for (int i = 0; i<mouseTips.Count; i++)
        {
            mouseTips[i].GetComponentInParent<CursorScript>().ShowCursor();
        }
    }
}
