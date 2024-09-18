using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTurning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
           gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + 000.1f, gameObject.transform.eulerAngles.z);
        }

        if (Input.GetButton("Fire2"))
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - 000.1f, gameObject.transform.eulerAngles.z);
        }

    }
}
