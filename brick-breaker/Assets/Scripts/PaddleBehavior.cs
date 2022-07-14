using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] PowerUpController powerUpController;

    float yPosition;

    // Start is called before the first frame update
    void Start()
    {
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 touchPosition = getTouch();

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (touchPosition != Vector3.zero)
        {
            transform.position = new Vector2(touchPosition.x, yPosition);
        }
    }

    Vector3 getTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                return Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            }
        }

        return Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Power Up"))
        {
            powerUpController.SendMessage(collision.gameObject.GetComponent<PowerUpBehavior>().PowerUp.ToString());
            Destroy(collision.gameObject);
        }
    }
}
