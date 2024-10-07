using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingHook : MonoBehaviour
{
    public Transform Front;
    public Transform Back;

    public float CraneHeight;
    public float Groundlevel;

    public bool goingForward;
    public bool goingBackward;

    public bool goingUp;
    public bool goingDown;

    void Update()
    {
        //up&down
        if (goingUp)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 00000000000.1f/ 20, gameObject.transform.position.z);
        }

        if (goingDown)
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
        if (goingForward)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Front.position , 5 * Time.deltaTime);
           
         
        }

        if (goingBackward)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Back.position, 5 * Time.deltaTime);



        }

       
    }
}

