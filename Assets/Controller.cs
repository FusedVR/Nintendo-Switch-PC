using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private Joycon j;
    Moveable currMove = null;

    void Start() {
        j = JoyconManager.Instance.j[0];
        if (j == null) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        gameObject.transform.rotation = Quaternion.Euler(90, 0, 0) * j.GetVector(); //switch coordinate systems

        if (j.GetButtonDown(Joycon.Button.SHOULDER_1)) { //reset
            // GetStick returns a 2-element vector with x/y joystick components
            Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

            // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
            j.Recenter();
        }

        if (j.GetButtonDown(Joycon.Button.SHOULDER_2)) { //capture
            if(currMove != null) {
                currMove.StopMove();
                currMove = null;
            } else {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                    Moveable move = hit.transform.GetComponent<Moveable>();
                    if (move != null) {
                        move.StartMove(j);
                        currMove = move;
                    }
                }
            }
        }
    }
}
