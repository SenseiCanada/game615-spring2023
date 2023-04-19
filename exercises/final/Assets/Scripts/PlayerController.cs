using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    public float jumpForce;
    public float rotateSpeed = 5f;
    public float moveSpeed = 1f;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        jumpForce = 1000f;
        GameObject gmObj = GameObject.Find("GameManager");
        gm = gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //tank controls
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);
        
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && gm.jumpCharge > 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0);
            playerRB.AddForce(Vector3.up * jumpForce);
            //how to add force slightly at an angle?
            gm.jumpCharge -= 1;
            Debug.Log(gm.jumpCharge);
        }

        //drop
        if (Input.GetMouseButtonDown(0) && playerRB.velocity.y > 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, -0.1f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jumpPower"))
        {
            Debug.Log("Wee!");
            gm.jumpCharge += 1;
            Destroy(other.gameObject);
        }
    }
}   
