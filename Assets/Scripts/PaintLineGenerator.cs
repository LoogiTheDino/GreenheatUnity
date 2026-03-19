using System.Collections.Generic;
using UnityEngine;

public class PaintLineGenerator : MonoBehaviour
{
    public ObjectDirectory directory;
    public RectTransform paintApp;
    public GameObject linePrefab;

    public GameObject paintCursor;
    public List<GameObject> mice;
    public List<string> ids;
    bool currentlyDrawing;

    LinePaint activeLine;
    GameObject newline;

    private void Start()
    {
        directory.AddToList(paintApp);
    }

    // Update is called once per frame
    void Update()
    {
        GreenHeatEventManager.OnGreenHeatHover += CreateCursor;
        if (ids.Count > mice.Count)
        {
            mice.Add(Instantiate(paintCursor));
            mice[mice.Count - 1].GetComponent<PaintCursor>().DefineCursor(ids[ids.Count - 1]);
        }
            
        if (currentlyDrawing) //is drawing
        {
            GameObject newLine = Instantiate(linePrefab, gameObject.transform);
            activeLine = newLine.GetComponent<LinePaint>();
            activeLine.transform.SetAsFirstSibling();
        }
        else //is not drawing
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
                //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //replace with cursor position
                //activeLine.UpdateLine(mousePos);
        }
    }

    public void CreateCursor(GreenHeatMessage message)
    {
        if (!ids.Contains(message.id)) ids.Add(message.id);
    }

    public void ChangeLineColour(Material material)
    {
        linePrefab.GetComponent<Renderer>().material = material;
    }

    public void Draw()
    {
        currentlyDrawing = true;
    }

    public void DontDraw()
    {
        currentlyDrawing = false;
        activeLine = null;
    }
}
