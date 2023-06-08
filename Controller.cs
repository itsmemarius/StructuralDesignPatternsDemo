using System.Collections;
using System.IO.Ports;
using SerialComm;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private static Controller instance = null;
    public static Controller Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Controller();
            }
            return instance;
        }

    }
    //SerialPort portUSB = new SerialPort("/dev/cu.usbserial-AO008WED", 115200);
    SenderProxy proxy;
    Transform[] objectChildren;

    float BodyX;
    float ShoulderX;
    float ElbowX;
    float WristY;
    float PalmX;
    float GripperX;

    Vector3 BodyRotation;
    Vector3 ShoulderRotation;
    Vector3 ElbowRotation;
    Vector3 WristRotation;
    Vector3 PalmRotation;

    float RotateSpeed = 1;
    int childrenCount;
    GameObject Body;
    GameObject Shoulder;
    GameObject Elbow;
    GameObject Wrist;
    GameObject Palm;
    GameObject Gripper;

    bool valueChanged = false;

    void Start()
    {
        GameObject go = new GameObject();
        //proxy = new TransmitterProxy(portUSB);
        //proxy.Open();

        childrenCount = transform.childCount;

        //ender.SendGCode(port, $"b'0'\nb'\\x10'\nb'\x14'");
        //sender.SendGCode(port, $"G07 VP=50\r\n");

        float countTime = 1;
        StartCoroutine(SerialCommDelay(countTime));

        Body = GameObject.FindGameObjectWithTag("Body");
        Shoulder = GameObject.FindGameObjectWithTag("Shoulder");
        Elbow = GameObject.FindGameObjectWithTag("Elbow");
        Wrist = GameObject.FindGameObjectWithTag("Wrist");
        Palm = GameObject.FindGameObjectWithTag("Palm");
        Gripper = GameObject.FindGameObjectWithTag("Gripper");

        BodyRotation = Body.transform.eulerAngles;
        ShoulderRotation = Shoulder.transform.eulerAngles;
        ElbowRotation = Elbow.transform.eulerAngles;
        WristRotation = Wrist.transform.eulerAngles;
        PalmRotation = Palm.transform.eulerAngles;

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            BodyX = Body.transform.eulerAngles.y - BodyRotation.y;

            if (BodyX < 0)
            {
                BodyX += 360;
            }

            Body.transform.Rotate(0, 0, 1);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            BodyX = Body.transform.eulerAngles.y - BodyRotation.y;

            if (BodyX < 0)
            {
                BodyX += 360;
            }

            Body.transform.Rotate(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Shoulder.transform.Rotate(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Shoulder.transform.Rotate(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Elbow.transform.Rotate(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Elbow.transform.Rotate(1, 0, 0);

        }


    }

    IEnumerator SerialCommDelay(float countTime)
    {
        while (true)

        {
            yield return new WaitForSeconds(countTime);

            //Debug.Log($"G00 J1=0 J2=0 J3={delta} J4=40 J5=0 J6=0\r\n");
            Debug.Log($"G00 J1={BodyX} J2={Shoulder.transform.eulerAngles.x} J3={Elbow.transform.eulerAngles.x} J4={WristY} J5={PalmX} J6=0\r\n");
            //port.DiscardOutBuffer();
            //sender.ReceiveGCode(port);
            //proxy.SendGCode($"G00 J1={BodyX} J2={Shoulder.transform.eulerAngles.x} J3={Elbow.transform.eulerAngles.x} J4={WristY} J5={PalmX} J6=0\r\n");
            //proxy.ReceiveGCode();
        }
    }
    public class SenderProxy
    {
        private Sender sender;
        public SerialPort port;

        public SenderProxy(SerialPort port)
        {
            this.port = port;
            this.sender = new Sender();
        }

        public void SendGCode(string gcode)
        {
            sender.SendGCode(port, gcode);
        }

        public void ReceiveGCode()
        {
            sender.ReceiveGCode(port);
        }
        public void Open()
        {
            port.Open();
        }
    }

}