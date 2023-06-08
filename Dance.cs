using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Text;
using System.Threading.Tasks;
using SerialComm;
using System.Threading;

namespace Dance
{
    public class Dance
    {
        public async void Execute(SerialPort port, Sender sender)
        {
            sender.SendGCode(port, $"T1");
            await Task.Delay(100);

            sender.SendGCode(port, $"G0 Y-100 Z250 E-10");   // se apleaca
            await Task.Delay(11800);

            sender.SendGCode(port, $"M280 P0 S0");          // deschide servo
            await Task.Delay(500);

            sender.SendGCode(port, $"G0 Y-50");           // se ridica un pic
            await Task.Delay(3000);

            //sender.SendGCode(port, $"G0 E-10");             // se indoaie incheietura sa apce paharul 35
            //await Task.Delay(1000);

            sender.SendGCode(port, $"M280 P0 S50");        //inchide servo
            await Task.Delay(500);

            //sender.SendGCode(port, $"G0 E-30");            // se dezloaie
            //await Task.Delay(500);


            sender.SendGCode(port, $"G0 X100 Y-25 Z200");
            await Task.Delay(3500);


            sender.SendGCode(port, $"G0 X200 Y-50 Z250");
            await Task.Delay(8000);

            sender.SendGCode(port, $"M280 P0 S0");          // deschide servo
            await Task.Delay(500);

            sender.SendGCode(port, $"G0 X0 Y0 Z0 E0");
            await Task.Delay(500);


            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S0");        //inchide servo
            await Task.Delay(450);

            sender.SendGCode(port, $"M280 P0 S115");        //inchide servo
            await Task.Delay(450);

        }

    }
}

