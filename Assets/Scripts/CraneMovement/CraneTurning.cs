using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTurning : MonoBehaviour
{
    public bool goingRight;
    public bool goingLeft;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        goingRight = false;
        goingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight == true)
        {
           gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + speed, gameObject.transform.eulerAngles.z);
        }

        if (goingLeft == true)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - speed, gameObject.transform.eulerAngles.z);
        }

    }
}
