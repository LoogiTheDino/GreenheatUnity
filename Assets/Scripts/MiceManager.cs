using System.Collections.Generic;
using UnityEngine;

public class MiceManager : MonoBehaviour
{
    public GameObject mousePrefab;
    //Canvas canvas;

    [SerializeField]
    List<string> userID;
    public List<GameObject> cursors;
    ObjectDirectory dir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir = GetComponent<ObjectDirectory>();
        //canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        GreenHeatEventManager.OnGreenHeatHover += CreateCursor;

        if (userID.Count > cursors.Count)
        {
            cursors.Add(Instantiate(mousePrefab));
            cursors[cursors.Count - 1].GetComponent<CursorScript>().DefineCursor(userID[userID.Count - 1], GetComponent<Canvas>());
            cursors[cursors.Count - 1].transform.SetParent(gameObject.transform);

            dir.AddTip(cursors[cursors.Count - 1].GetComponent<CursorScript>().GetTip());
        }
    }

    public void CreateCursor(GreenHeatMessage message)
    {
        if (!userID.Contains(message.id)) userID.Add(message.id);
    }
}
