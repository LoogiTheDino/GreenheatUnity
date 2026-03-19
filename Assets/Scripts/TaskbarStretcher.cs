using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskbarStretcher : MonoBehaviour
{
    Resolution res;
    // Start is called before the first frame update
    void Start()
    {
        res = Screen.currentResolution;
        gameObject.transform.localScale = new Vector3(res.width, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (res.width != Screen.currentResolution.width || res.height != Screen.currentResolution.height)
        {
            res = Screen.currentResolution;
            gameObject.transform.localScale = new Vector3(res.width, 1, 1);
        }


    }
}
