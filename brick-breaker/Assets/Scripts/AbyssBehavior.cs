using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssBehavior : MonoBehaviour
{
    [SerializeField] LevelController levelController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            levelController.SendMessage("onAbyss");
        }
        Destroy(collision.gameObject);
    }
}
