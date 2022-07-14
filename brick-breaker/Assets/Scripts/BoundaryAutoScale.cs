using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryAutoScale : MonoBehaviour
{
    enum positions { Left, Right, Top, Bottom };
    [SerializeField] positions position;

    // Start is called before the first frame update
    void Start()
    {
        reposition();
    }

    private void reposition()
    {
        switch (position)
        {
            case positions.Left:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0));
                transform.localScale = new Vector3(0.01f, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y * 2, 1);
                break;
            case positions.Right:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0));
                transform.localScale = new Vector3(0.01f, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y * 2, 1);
                break;
            case positions.Top:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0));
                transform.localScale = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x * 2, 0.01f, 1);
                break;
            default:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0));
                transform.localScale = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x * 2, 0.01f, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        reposition();
    }
}
