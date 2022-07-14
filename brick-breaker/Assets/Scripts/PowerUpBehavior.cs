using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public PowerUps PowerUp { get; set; }
    [SerializeField] Sprite[] sprites;
    [SerializeField] float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed);
    }

    public void setPowerUp(PowerUps powerUp)
    {
        PowerUp = powerUp;
        try
        {
            Debug.Log((int)powerUp - 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)powerUp - 1];
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }
}
