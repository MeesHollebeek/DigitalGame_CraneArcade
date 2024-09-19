using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookview : MonoBehaviour
{
    public Transform Front;
    public Transform Back;

    void Update()
    {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 22.472f, gameObject.transform.position.z);

        //Over the crane
        if (Input.GetButton("Fire5"))
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Front.position, 5 * Time.deltaTime);


        }

        if (Input.GetButton("Fire6"))
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Back.position, 5 * Time.deltaTime);



        }


    }
}
