using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    private int jumpcon;
    private float timer;

    private void Start()
    {
        jumpcon = 2;
        timer = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if (timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }
        var auxVel = rb.velocity;
        auxVel.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = auxVel;


        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && jumpcon > 0)
        {
            var aux = rb.velocity;
            aux.y = 0;
            rb.velocity = aux;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpcon--;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            CameraMovement.instance.Perder();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Door"))
        {
            CameraMovement.instance.Ganaste();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            Destroy(other.gameObject);
            CameraMovement.instance.Points(5);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            jumpcon = 2;
        }
    }
}
