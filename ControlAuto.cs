using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Text;
using System.Threading.Tasks;
using SerialComm;

namespace ControlAuto
{
    public class ControlAuto
    {
        int bodyCalibration = 187;
        int shoulderCalibration = 311;
        int elbowCalibration = 330;
        int wristCalibration = 15;
        int palmCalibration = 60;
        int gripperCalibration = 125;

        double bodyAngleValue;
        double shoulderAngleValue;
        double elbowAngleValue;
        double wristAngleValue;
        double palmAngleValue;
        double gripperRightAngleValue;
        double gripperLeftAngleValue;

        double lastBodyAngleValue;
        double lastShoulderAngleValue;
        double lastElbowAngleValue;
        double lastWristAngleValue;
        double lastPalmAngleValue;
        double lastGripperRightAngleValue;
        double lastGripperLeftAngleValue;

        bool isT0Active = true;
        bool isT1Active = false;

        public void Execute(Transform[] objectChildren, SerialPort port, Sender sender)
      {
            Transform body = objectChildren[2];
            Transform shoulder = objectChildren[5];
            Transform elbow = objectChildren[7];
            Transform wrist = objectChildren[9];
            Transform palm = objectChildren[11];
            Transform gripperRight = objectChildren[12];
            Transform gripperLeft = objectChildren[15];

            bodyAngleValue = Math.Floor(body.localRotation.y * bodyCalibration);
            shoulderAngleValue = Math.Floor(shoulder.localRotation.x * shoulderCalibration);
            elbowAngleValue = Math.Floor(elbow.localRotation.x * elbowCalibration);
            wristAngleValue = Math.Floor(wrist.localRotation.y * wristCalibration);
            palmAngleValue = Math.Floor(palm.localRotation.x * palmCalibration);
            gripperRightAngleValue = Math.Floor(gripperRight.localRotation.z * gripperCalibration);
            gripperLeftAngleValue = Math.Floor(gripperLeft.localRotation.z * gripperCalibration);
            

            if (bodyAngleValue != lastBodyAngleValue)
            {
                sender.SendGCode(port, $"G0 X" + bodyAngleValue);
            }
            if(shoulderAngleValue != lastShoulderAngleValue) 
            {
                sender.SendGCode(port, $"G0 Y" + shoulderAngleValue);
            }

            if (elbowAngleValue != lastElbowAngleValue)
            {
                sender.SendGCode(port, $"G0 Z" + elbowAngleValue);
            }

            if (wristAngleValue !=  lastWristAngleValue)
            {
                if (!isT0Active)
                {
                    sender.SendGCode(port, $"T0");
                    isT0Active = true;
                    isT1Active = false;
                }
                sender.SendGCode(port, $"G0 E" +  wristAngleValue);
            }

            if (palmAngleValue != lastPalmAngleValue)
            {
                if (!isT1Active)
                {
                    sender.SendGCode(port, $"T1");
                    isT1Active = true;
                    isT0Active = false;
                }
                sender.SendGCode(port, $"G0 E" +  palmAngleValue);
            }

            if(gripperRightAngleValue != lastGripperRightAngleValue) 
            {
                if (gripperRightAngleValue > 0 && gripperRightAngleValue < 150)
                {
                    sender.SendGCode(port, $"M280 P0 S" + gripperRightAngleValue);
                }
                //Debug.Log(gripperRightAngleValue);
            }
            /*
            if (gripperLeftAngleValue != lastGripperLeftAngleValue)
            {
                sender.SendGCode(port, $"M280 P0 S" + gripperLeftAngleValue);
            }
            */
            lastBodyAngleValue = bodyAngleValue;
            lastShoulderAngleValue = shoulderAngleValue;
            lastElbowAngleValue = elbowAngleValue;
            lastWristAngleValue = wristAngleValue;
            lastPalmAngleValue = palmAngleValue;
            lastGripperRightAngleValue = gripperRightAngleValue;
            lastGripperLeftAngleValue = gripperLeftAngleValue;
        }
    }
}
