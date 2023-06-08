# StructuralDesignPatternsDemo

A project developed to show the Creational Design Patters i learned at Uni.

## 🔃 Proxy

The Proxy Pattern is used to create a layer of abstraction between the code and the TransmitterProxy class. Instead of directly creating an instance of the TransmitterProxy and directly calling the methods, an instance of a SenderProxy is created and this object is responsible for instantiating an instance of TransmitterProxy and calling the appropriate methods. This allows for a layer of abstraction that simplifies the implementation of changes to the TransmitterProxy class code, as the SenderProxy class can be changed without needing to modify the controller class in any way.

Code example for Proxy Pattern:

```c#
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
```

## 🔗 Facade 

The Facade pattern is used in the SerialcommFacade class to encapsulate the complexity of the underlying code into a simplified interface. Instead of having to write a lot of code for sending and receiving serial commands, the Facade provides a few methods which abstract the underlying code and can be used to send and receive commands. This reduces the code complexity and increases readability which makes it easier to debug any code related to serial communication.

Code example for Facade Pattern:

```c#
public class SerialcommFacade
{
    public string Command {get; set;}
    public SerialPort Port {get; set;}

    public void SendCommand(string command)
    {
        Command = command;
        Port.Write(command);
    }

    public string ReceiveCommand()
    {
        Port.ReadTimeout = 1000;
        string data = Port.ReadLine();
        if (data.Contains("%"))
        {
            SendCommand(command);
            return data;
        }
        return null;
    }
}
```
## Authors

- [@itsmemarius](https://www.github.com/itsmemarius)

