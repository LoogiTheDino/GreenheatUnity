using TMPro;
using UnityEngine;

public class PaintCursor : MonoBehaviour
{
    float xScale;
    public float yScale;
    [SerializeField]
    Vector2 paintMousePos;
    string userID;
    bool drawing = false;
    PaintLineGenerator linegenerator;
    LinePaint activeLine;

    private void Start()
    {
        linegenerator = ObjectDirectory.Instance.paint;
        xScale = yScale * (16 / 9);
    }

    // Update is called once per frame
    void Update()
    {
        GreenHeatEventManager.OnGreenHeatHover += MoveCursor;
        GreenHeatEventManager.OnGreenHeatDrag += MoveCursor;
        GreenHeatEventManager.OnGreenHeatClick += Click;

        transform.position = paintMousePos;
    }

    public void Click(GreenHeatMessage message)
    {
        drawing = !drawing;
    }

    public void MoveCursor(GreenHeatMessage message)
    {
        paintMousePos = new Vector2((message.x - 0.5f) * xScale, -(message.y - 0.5f) * yScale);
    }

    public void DefineCursor(string id)
    {
        userID = id;
    }
}
