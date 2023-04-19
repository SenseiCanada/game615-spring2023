using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int jumpCharge;

    public TMP_Text JCText;

    // Start is called before the first frame update
    void Start()
    {
       jumpCharge = 10;
       

    }

    // Update is called once per frame
    void Update()
    {
        JCText.text = jumpCharge.ToString();
    }

   
}
