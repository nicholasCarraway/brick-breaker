using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] Color[] colors;
    [SerializeField] PowerUps powerUp;

    [SerializeField] LevelController levelController;
    [SerializeField] PowerUpController powerUpController;

    private void Start()
    {
        try
        {
            gameObject.GetComponent<SpriteRenderer>().color = colors[health - 1];
        }
        catch(System.Exception e) 
        {
            Debug.LogException(e);
            Debug.LogError("Attempted to start with a brick with invalid health.");
            Destroy(gameObject);
        }
    }

    public void onHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            levelController.SendMessage("onHit");

            if (!powerUp.Equals(PowerUps.None))
            {
                powerUpController.spawnPowerUp(powerUp, transform);
            }

            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = colors[health - 1];
        }
    }
}
