using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject JPPrefab;
    public float coilTight = 5;
    public float coilHeight = 5;
    public float rotateSpeed;

    public GameObject powerParent1;

    public GameObject powerParent2;
    

    

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 90; i++) 
        {
            GameObject jumpPower = Instantiate(JPPrefab, transform.position, Quaternion.identity);
            transform.Rotate(0, 10f, 0);
            transform.Translate(transform.forward * coilTight);
            transform.Translate(transform.up * coilHeight);

            jumpPower.transform.SetParent(powerParent1.transform);

        }
        rotateSpeed = 10f;
        gameObject.transform.position = new Vector3(0, 0, -10f);

        for (int i = 0; i < 90; i++)
        {
            GameObject jumpPower = Instantiate(JPPrefab, transform.position, Quaternion.identity);
            transform.Rotate(0, -10f, 0);
            transform.Translate(-transform.forward * coilTight);
            transform.Translate(transform.up * coilHeight);

            jumpPower.transform.SetParent(powerParent2.transform);

        }
        rotateSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        powerParent1.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        powerParent2.transform.Rotate(0, rotateSpeed *-5f * Time.deltaTime, 0);
    }
}
