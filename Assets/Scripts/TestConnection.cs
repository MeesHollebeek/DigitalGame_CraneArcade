using System.Collections;
using UnityEngine;
using System.IO.Ports;

public class TestConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM6", 9600); // Arduino is connected to COM6, with 9600 baud rate
    public string receivedstring;

    CraneTurning craneTurn;
    DroppingHook hookMove;
    Hookview cameraMove;

    private void Start()
    {
        data_stream.Open(); // Initiate the Serial stream
        craneTurn = GameObject.Find("PivotPoint").GetComponent<CraneTurning>();
        hookMove = GameObject.Find("Hook").GetComponent<DroppingHook>();
        cameraMove = GameObject.Find("DownView").GetComponent<Hookview>();
    }

    private void Update()
    {
        receivedstring = data_stream.ReadLine();
        
        if(receivedstring == "Direction: RIGHT")
        {
            craneTurn.goingRight = true;
        }
        else
        {
            craneTurn.goingRight = false;
        }
       
        if(receivedstring == "Direction: LEFT")
        {
            craneTurn.goingLeft = true;
        }
        else
        {
            craneTurn.goingLeft = false;
        }

        if (receivedstring == "Direction: UP")
        {
            hookMove.goingForward = true;
            cameraMove.moveForward = true;
        }
        else
        {
            hookMove.goingForward = false;
            cameraMove.moveForward = false;
        }

        if (receivedstring == "Direction: DOWN")
        {
            hookMove.goingBackward = true;
            cameraMove.moveBackward = true;
        }
        else
        {
            hookMove.goingBackward = false;
            cameraMove.moveBackward = false;
        }
        
        if (receivedstring == "Crane: DOWN")
        {
            hookMove.goingDown = true;
        }
        else
        {
            hookMove.goingDown = false;
        }

        if (receivedstring == "Crane: UP")
        {
            hookMove.goingUp = true;
        }
        else
        {
            hookMove.goingUp = false;
        }
    }
}
