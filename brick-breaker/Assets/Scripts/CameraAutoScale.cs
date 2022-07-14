using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScale : MonoBehaviour
{
    float aspectRatio = -1;
    readonly float targetAspectRatio = 1080.0f / 2340.0f;
    [SerializeField] GameObject coreAnchor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (aspectRatio < 0)
        {
            aspectRatio = (float)Screen.width / Screen.height;
            //gameObject.GetComponent<Camera>().orthographicSize = targetAspectRatio / aspectRatio * 5.0f;
            // let's scale the game objects instead of the camera
            float scaleFactor = aspectRatio / targetAspectRatio;
            coreAnchor.transform.localScale = new Vector3(scaleFactor, scaleFactor);
            coreAnchor.transform.position = new Vector3(0, (aspectRatio - targetAspectRatio) * 5.0f, 0);
        }
    }
}
