using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleImpact : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "beet" || col.gameObject.name == "Pole")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            rb.useGravity= true;
        }
    }
}
