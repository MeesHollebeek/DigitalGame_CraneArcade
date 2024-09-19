using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingMovepoints : MonoBehaviour
{
    public Transform Hook;
  

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Hook.position.y, gameObject.transform.position.z);
    }
}
