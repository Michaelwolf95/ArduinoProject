using System;
using System.Threading;
using CommandMessenger;
using CommandMessenger.Transport.Serial;
using UnityEngine;
using System.Collections;
using UnityEditor;


 
namespace SR_mono_ui
{

    //[InitializeOnLoad]
    public class SandR_mono //: MonoBehaviour
    {
        enum Command
        {
            Button1,
            Button2,
        }


        public bool RunLoop { get; set; }
        private SerialTransport _serialTransport;
        private CmdMessenger _cmdMessenger;
        private int _count;
        public int test;

        public string _stringArg;


        // static SandR_mono()
        //{ }

        // Use this for initialization
        public void Start()
        {



            // Create Serial Port transport object
            // Note that for some boards (e.g. Sparkfun Pro Micro) DtrEnable may need to be true.
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = "COM9", BaudRate = 115200, DtrEnable = false } // object initializer
            };

            // Initialize the command messenger with the Serial Port transport layer
            // Set if it is communicating with a 16- or 32-bit Arduino board
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();

            // Start listening
            var Button1 = _cmdMessenger.Connect();
            if (!Button1)
            {
                Debug.Log("No connection could be made");
                return;
            }
        }



        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Button1, OnButton1);
            _cmdMessenger.Attach((int)Command.Button2, OnButton2);
        }

        void OnUnknownCommand(ReceivedCommand arguments)
        {
            Debug.Log("Command without attached callback received");
        }



        void OnButton2(ReceivedCommand arguments)
        {
            Debug.Log("Arduino Button2 ");
            //test = arguments.ReadInt32Arg();
            //Debug.Log(test);

            //var cmd_return = new SendCommand((int)Command.SetLed);

           // _cmdMessenger.SendCommand(cmd_return);



        }



        void OnButton1(ReceivedCommand arguments)
        {
            //Thread.Sleep(1000);
            Debug.Log("Arduino Button1: ");
          //  test = arguments.ReadInt32Arg();
           // Debug.Log(test);

           // var cmd_return = new SendCommand((int)Command.SetLed);

           // _cmdMessenger.SendCommand(cmd_return);

        }

        public int GetArguments()
        {
            return test;
        }

        // Update is called once per frame

        static void Update()
        {

        }



    }

}







