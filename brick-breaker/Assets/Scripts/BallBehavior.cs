using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody2D rigidBody;
    int damage = 1;

    [Tooltip("Setting this too high can cause unpredictable behavior.")]
    [SerializeField] float courseCorrectionThreshold = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        float angle = Random.Range(45.0f, 135.0f);
        AddForceAngled(200.0f, angle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if other is a brick
        if (collision.gameObject.CompareTag("Brick"))
        {
            // call the damage method on brick
            collision.gameObject.SendMessage("onHit", damage);
        }
    }

    private void OnCollisionExit2D()
    {
        courseCorrection();
    }

    void AddForceAngled(float force, float angle) 
    {
        float xComponent = Mathf.Cos(angle * Mathf.PI / 180.0f) * force;
        float yComponent = Mathf.Sin(angle * Mathf.PI / 180.0f) * force;

        rigidBody.AddForce(new Vector3(xComponent, yComponent, 0));
    }

    void courseCorrection()
    {
        // if the ball manages to get stuck bouncing in a straigth line give it a nudge in a random direction
        if (trajectoryTooFlat())
        {
            float angle = Random.Range(0.0f, 360.0f);
            AddForceAngled(50.0f, angle);
        }
    }

    bool trajectoryTooFlat()
    {
        return (rigidBody.velocity.y <= courseCorrectionThreshold && rigidBody.velocity.y >= -courseCorrectionThreshold) || (rigidBody.velocity.x <= courseCorrectionThreshold && rigidBody.velocity.x >= -courseCorrectionThreshold);
    }
}
