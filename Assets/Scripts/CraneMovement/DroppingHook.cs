using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingHook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //up&down
        if (Input.GetButton("Fire3"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 00000000000.1f/ 20, gameObject.transform.position.z);
        }

        if (Input.GetButton("Fire4"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 000000000000.1f / 20, gameObject.transform.position.z);
        }

        if(gameObject.transform.position.y > 22)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 22f, gameObject.transform.position.z);
        }


        //Over the crane
        if (Input.GetButton("Fire5"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 00000000000.1f / 20, gameObject.transform.position.y , gameObject.transform.position.z);
        }

        if (Input.GetButton("Fire6"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 000000000000.1f / 20, gameObject.transform.position.y , gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x > 1)
        {
            gameObject.transform.position = new Vector3( 1f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x > 2)
        {
            gameObject.transform.position = new Vector3(2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}

