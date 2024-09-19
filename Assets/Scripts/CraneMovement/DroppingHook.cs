using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingHook : MonoBehaviour
{
    public Transform Front;
    public Transform Back;

    public float CraneHeight;
    public float Groundlevel;
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

        if(gameObject.transform.position.y > CraneHeight)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, CraneHeight, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.y < Groundlevel)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, Groundlevel, gameObject.transform.position.z);
        }


        //Over the crane
        if (Input.GetButton("Fire5"))
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Front.position , 5 * Time.deltaTime);
           
         
        }

        if (Input.GetButton("Fire6"))
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Back.position, 5 * Time.deltaTime);



        }

       
    }
}

