using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookview : MonoBehaviour
{
    public Transform hookReference;  // Position to move towards

    void Update()
    {
        gameObject.transform.position = hookReference.transform.position;
    }
}
