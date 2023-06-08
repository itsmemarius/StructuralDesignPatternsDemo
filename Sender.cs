using System;
using System.Collections;
using System.IO.Ports;
using SerialComm;
using UnityEngine;



namespace SerialComm
{


    public class Snapshoturi
    {
        public string Command { get; set; }

        public void SaveregisterSnapshot(string command)
        {
            Command = command;
        }
    }

    public class Sender : MonoBehaviour
    {
        public Snapshoturi inregistreazaSnap;

        public void SendGCode(SerialPort port, string command)
        {

            //port.Write(command);
            inregistreazaSnap.SaveregisterSnapshot(command);
            Debug.Log($"Trimitem pe {port} : {command}");
        }

        public void ReceiveGCode(SerialPort port)
        {
            //port.ReadTimeout = 1000;

            try
            {
                // Citim datele
                string data = ("%");
                if (data.Contains("%"))
                {
                    Debug.Log("Command Done");
                    SendGCode(port, inregistreazaSnap.Command);
                }

            }
            catch (TimeoutException)
            {
                // Handle timeout exception
                Debug.Log("Error: Timeout while waiting for data");
            }

            Debug.Log(port.ReadLine());

        }


        public IEnumerator SerialReadDelay(SerialPort port)
        {
            String receivedData = port.ReadLine();
            yield return receivedData;

        }
    }


}