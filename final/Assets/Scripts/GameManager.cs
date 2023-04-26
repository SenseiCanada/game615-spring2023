using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int jumpCharge;

    public TMP_Text JCText;
    public TMP_Text rotateHint;

    public Animator startAnimator;

    PlayerController playerController;
    
    public GameObject pcObj;

    public Rigidbody playerRB;

    bool gameStart = false;
 

    // Start is called before the first frame update
    void Start()
    {

        playerController = pcObj.GetComponent<PlayerController>();
        playerRB = pcObj.GetComponent<Rigidbody>();
        jumpCharge = 10;

    }

    // Update is called once per frame
    void Update()
    {
        JCText.text = "bounce charges " + jumpCharge.ToString();

        Debug.Log(Time.timeSinceLevelLoad.ToString());

        if (Time.timeSinceLevelLoad >= 1.5f && gameStart == false)
        {
            StartLaunch();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("YouWin");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void StartLaunch()
    {
        rotateHint.gameObject.SetActive(false);
        playerRB.AddForce(0, 0, 1000);
        playerRB.useGravity = true;
        gameStart = true;
    }


}
