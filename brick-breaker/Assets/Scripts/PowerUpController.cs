using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] LevelController levelController;

    [SerializeField] float wideDurationMax = 10.0f;
    [SerializeField] float wideDuration = 0.0f;
    [SerializeField] GameObject paddle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wideDuration -= Time.deltaTime;
        if (wideDuration <= 0)
        {
            removeWide();
        }
    }

    public void spawnPowerUp(PowerUps powerUp, Transform transform)
    {
        GameObject powerUpInstance = Instantiate(powerUpPrefab, transform);
        powerUpInstance.transform.SetParent(null);
        powerUpInstance.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        powerUpInstance.GetComponent<PowerUpBehavior>().setPowerUp(powerUp);
    }

    public void Multi()
    {
        for (int i = 0; i < 3; i++)
        {
            levelController.spawnBall();
        }
    }

    public void Wide()
    {
        paddle.transform.localScale = new Vector3(0.225f, 0.1f, 1);
        wideDuration = wideDurationMax;
    }

    void removeWide()
    {
        paddle.transform.localScale = new Vector3(0.15f, 0.1f, 1);
    }
}
