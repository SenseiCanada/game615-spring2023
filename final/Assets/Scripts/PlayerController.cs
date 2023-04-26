using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Rigidbody playerRB;
    public float jumpForce;
    public float rotateSpeed = 5f;
    public float moveSpeed = 1f;
    public float groundDistance;
    public bool controlsEnabled = false;

    GameManager gm;
    public Animator menuAnimator;
    public Animator warnAnimator;
    
    
    public GameObject mainCamera;
    public GameObject ground;

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
        groundDistance = Vector3.Distance(gameObject.transform.position, ground.transform.position);
        
        
        //tank controls attempt 1
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        gameObject.transform.Translate(transform.forward * vAxis * moveSpeed * Time.deltaTime, Space.World);
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);
        
        if (groundDistance <= 60f || controlsEnabled == true)
        {
            controlsEnabled = true;
            menuAnimator.SetBool("powerUnlocked", true);
            enableControls();
        }
        if (groundDistance <= 60f)
        {
            warnAnimator.SetBool("needWarning", true);
        }
        else
        {
            warnAnimator.SetBool("needWarning", false);
        }
        
        
        

    }

    void enableControls()
    {
        

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && gm.jumpCharge > 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0);
            playerRB.AddForce(Vector3.up * jumpForce);
            gm.jumpCharge -= 1;
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
            gm.jumpCharge += 1;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("towerTop"))
        {
            gm.LoadScene();
        }

        if (other.CompareTag("ground"))
        {
            gm.LoadGameOver();
        }

        if (other.CompareTag("wall"))
        {
            playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
        }
    }
}   
