using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
        }
        
    }
}
//asset sources: 
//beet - Beet by Poly by Google [CC-BY] via Poly Pizza
//carrot - Carrot by Poly by Google [CC-BY] via Poly Pizza
// steak - Steak by Poly by Google [CC-BY] via Poly Pizza
