using UnityEngine;
using System.Collections;
using SendAndReceive;

public class ArduinoEventManager : MonoBehaviour
{
    public delegate void button1_Action();
    public static event button1_Action OnPressed;
    private SendAndReceive.SendAndReceive SR_Object;

    public delegate void _update();
    public static event _update ardUpdate;

    // Use this for initialization
    void Start ()
    {
        SR_Object = new SendAndReceive.SendAndReceive(); 
    }
	
	// Update is called once per frame
	void Update ()
    {
	    //if(SR_Object.GetArguments() == "1") //If Argument is _____
        if(Input.GetButtonDown("Fire1"))
        {
            if (OnPressed != null)
            {
                OnPressed();
            }
        }
	}
}
