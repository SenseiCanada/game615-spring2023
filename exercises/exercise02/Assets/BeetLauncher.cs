using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeetLauncher : MonoBehaviour
{
    public float launchForce = 100;
    public Rigidbody rb;

    float rotateSpeed = 0.1f;
    float lastRotate = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time - lastRotate > 1f)
        {
            rotateSpeed = rotateSpeed * -1;
            lastRotate = Time.time;
        }
        gameObject.transform.Rotate(0, rotateSpeed, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            rb.AddForce(gameObject.transform.forward * launchForce);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.name == "Pole" )
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
}
