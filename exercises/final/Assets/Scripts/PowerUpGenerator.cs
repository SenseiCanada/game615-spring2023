using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject JPPrefab;
    public float coilTight = 5;
    public float coilHeight = 10;
    

    

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 90; i++) 
        {
            GameObject jumpPower = Instantiate(JPPrefab, transform.position, Quaternion.identity);
            transform.Rotate(0, 10f, 0);
            transform.Translate(transform.forward * coilTight);
            transform.Translate(transform.up * coilHeight);

            //Vector3 JPPos = transform.position;
            // JPPos.x = JPPos.x + i;
            //JPPos.y = JPPos.y + i;

            //JPPrefab.transform.Rotate(0, 1f, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
