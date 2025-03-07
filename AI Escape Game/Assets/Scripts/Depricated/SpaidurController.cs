using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaidurController : MonoBehaviour
{
    public float speed;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = -transform.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            direction *= -1;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Die");
        }
    }
}
