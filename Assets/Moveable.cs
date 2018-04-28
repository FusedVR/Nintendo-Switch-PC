using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {
    const float SPEED = 10f;
    Joycon j = null;

    public void StartMove(Joycon controller) {
        j = controller;
    }

    public void StopMove() {
        j = null;
    }

    void Update() {
        if (j != null) {
            j.SetRumble(160, 320, 0.3f, 200);

            if (j.GetButton(Joycon.Button.DPAD_UP)) {
                transform.position += (Vector3.forward * SPEED * Time.deltaTime);
            }

            if (j.GetButton(Joycon.Button.DPAD_DOWN)) {
                transform.position += (Vector3.back * SPEED * Time.deltaTime);
            }

            if (j.GetButton(Joycon.Button.DPAD_LEFT)) {
                transform.position += (Vector3.left * SPEED * Time.deltaTime);
            }

            if (j.GetButton(Joycon.Button.DPAD_RIGHT)) {
                transform.position += (Vector3.right * SPEED * Time.deltaTime);
            }
        }
    }
}
