using System.Collections;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class TestConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM6", 115200); // Increased baud rate for better performance
    private Thread serialThread;       // Thread for reading data from Arduino
    private bool isRunning = true;     // Flag to control the thread
    private string buffer = "";        // Buffer to store incoming serial data
    private object bufferLock = new object(); // Lock object to prevent race conditions

    public string receivedData;        // Latest processed data (for debugging)

    // Your components for controlling crane and hook
    CraneTurning craneTurn;
    DroppingHook hookMove;
    Hookview cameraMove;

    private void Start()
    {
        // Open the serial port
        data_stream.Open();

        // Find references to your crane and hook objects
        craneTurn = GameObject.Find("Crane_Cabin").GetComponent<CraneTurning>();
        hookMove = GameObject.Find("Crane_Hook").GetComponent<DroppingHook>();
        cameraMove = GameObject.Find("DownView").GetComponent<Hookview>();

        // Start the thread for reading serial data
        serialThread = new Thread(ReadSerialData);
        serialThread.Start();
    }

    // Thread method to read data from the serial port
    private void ReadSerialData()
    {
        while (isRunning)
        {
            try
            {
                if (data_stream.IsOpen)
                {
                    // Read available data from the serial port
                    string newData = data_stream.ReadExisting();

                    // If there is new data, append it to the buffer
                    if (!string.IsNullOrEmpty(newData))
                    {
                        lock (bufferLock) // Lock the buffer to prevent data race conditions
                        {
                            buffer += newData;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading serial data: " + e.Message);
            }
        }
    }

    // Process incoming data each frame
    private void Update()
    {
        // Lock and process the buffer
        lock (bufferLock)
        {
            if (!string.IsNullOrEmpty(buffer))
            {
                // Process the buffered data for complete commands
                ProcessReceivedData();
            }
        }
    }

    // This method processes the received data
    private void ProcessReceivedData()
    {
        // Keep processing while we have complete commands (ending with \n)
        while (buffer.Contains("\n"))
        {
            // Find the newline character
            int newlineIndex = buffer.IndexOf("\n");

            // Extract the full command from the buffer (before the newline)
            string command = buffer.Substring(0, newlineIndex).Trim();

            // Remove the processed command from the buffer
            buffer = buffer.Substring(newlineIndex + 1);

            // Process the command based on its content
            if (command.Contains("Direction: RIGHT"))
            {
                craneTurn.goingRight = true;
            }
            else if (command.Contains("Direction: LEFT"))
            {
                craneTurn.goingLeft = true;
            }
            else if (command.Contains("Direction: UP"))
            {
                hookMove.goingForward = true;
            }
            else if (command.Contains("Direction: DOWN"))
            {
                hookMove.goingBackward = true;
            }
            else if (command.Contains("Crane: DOWN"))
            {
                hookMove.goingDown = true;
            }
            else if (command.Contains("Crane: UP"))
            {
                hookMove.goingUp = true;
            }
            else if (command.Contains("STOP"))
            {
                hookMove.goingBackward = false;
                hookMove.goingForward = false;
                hookMove.goingUp = false;
                hookMove.goingDown = false;
                craneTurn.goingLeft = false;
                craneTurn.goingRight = false;

            }

            // For debugging purposes, store the last command
            receivedData = command;
        }
    }

    // Clean up and stop the thread when the game is closed
    private void OnDestroy()
    {
        isRunning = false;

        // Wait for the thread to finish
        if (serialThread != null && serialThread.IsAlive)
        {
            serialThread.Join();
        }

        // Close the serial port
        if (data_stream.IsOpen)
        {
            data_stream.Close();
        }
    }
}