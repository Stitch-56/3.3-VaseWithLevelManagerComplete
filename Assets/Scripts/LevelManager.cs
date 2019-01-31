using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    // Create a public static LevelManager variable that will be set by the Unity Engine (in the Awake function below)
    // to point to the one and only LevelManager object in the Scene. This variable can then be used by any script that
    // needs to to access the one and only LevelManager object by going LevelManager.instance.
    public static LevelManager instance;

    // The SwitchController
    public SwitchController theSwitch;

    // The VaseController
    public GameObject theVase;

    [Header("Configurable properties")]
    [Tooltip("The force applied to the vase")]
    public Vector2 vasePushForce;

	// Variables to store the state of various game objects in the scene
    [Header("Useful debug info")]
	public bool switchEnabled = false;
	public bool switchOn = false;
	public bool vaseOnLedge = true;

    private void Awake()
    {
        instance = this;
    }

    // This function will get called when the Player presses the spacebar (have a look at the InputManager
    // script that I have attached to the Hero GameObject). You are going to have to write the code that
    // goes into this function that will (a) if the switch is enabled will turn it on if it is off and
    // push the Vase off the ledge and (b) if the switch is enabled will turn it off if it is on.
    public void flipTheSwitch() {
		if (switchEnabled == true) {

			if (switchOn == false) {
				theSwitch.turnOn ();
				switchOn = true;

                pushVase();
			} else {
				theSwitch.turnOff ();
				switchOn = false;
			}

		}
	}

    // The following two functions get called by the SwitchController object when the Hero enters the 
    // trigger box of the Switch

	public void onSwitchTriggerEnter(Collider2D other) {

        // Just to demonstrate how we can use the LevelManager to "control" what happens in the Level, I
        // am only allowing the switch to be enabled by the Hero (by walking into the trigger box of the
        // Switch) once 5 seconds have elapsed since the start of the game. The Time.fixedTime property 
        // contains the number of seconds have elapsed since the start of the game. 
        //
        // In a "real game" this if statement might be something like "if the Hero has collected the
        // potion" then enable the switch.
        if (Time.fixedTime > 5.0f)
        {
            switchEnabled = true;
        }
	}

	public void onSwitchTriggerExit(Collider2D other) {
		switchEnabled = false;
	}

    private void pushVase()
    {
        // Make the vase fall
        if (vaseOnLedge == true)
        {
            Rigidbody2D theVasesRB = theVase.GetComponent<Rigidbody2D>();
            theVasesRB.AddForce(vasePushForce, ForceMode2D.Impulse);
            vaseOnLedge = false;
        }
    }
}
