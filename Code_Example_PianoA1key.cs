using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class A1 : MonoBehaviour
{
    // LS-up-left/RS-up-left/D-up-left + RT + X

    public GameObject A1_Pad;

    private int Lock = 0; // "Turbo" pushing prevention

    private bool Act_1; // LS
    private bool Act_2; // RS
    private bool Act_3; // D-Pad
    private bool Act_4; // RT
    private bool Act_5; // X

    private void Update()
    {
        if ((Input.GetAxis("Left Stick Y") < -0.5) && (Input.GetAxis("Left Stick Y") >= -1) 
            && (Input.GetAxis("Left Stick X") < -0.5) && (Input.GetAxis("Left Stick X") >= -1))
            Act_1 = true;
        else Act_1 = false;

        if ((Input.GetAxis("Right Stick Y") < -0.5) && (Input.GetAxis("Right Stick Y") >= -1) 
            && (Input.GetAxis("Right Stick X") < -0.5) && (Input.GetAxis("Right Stick X") >= -1))
            Act_2 = true;
        else Act_2 = false;

        if ((Input.GetAxis("D-Pad Y") > 0.5) && (Input.GetAxis("D-Pad Y") <= 1) 
            && (Input.GetAxis("D-Pad X") < -0.5) && (Input.GetAxis("D-Pad X") >= -1))
            Act_3 = true;
        else Act_3 = false;

        if ((Input.GetAxis("RT") > 0.5) && (Input.GetAxis("RT") <= 1))
            Act_4 = true;
        else Act_4 = false;

        if (Input.GetKey(KeyCode.JoystickButton2))
            Act_5 = true;
        else Act_5 = false;

        if (Lock == 0)
        {
            if ((Act_1 && Act_4 && Act_5) == true) // LS-up-left + RT + X
            {
                SND(); Lock = 1;
            }

            if ((Act_2 && Act_4 && Act_5) == true) // RS-up-left + RT + X
            {
                SND(); Lock = 2;
            }

            if ((Act_3 && Act_4 && Act_5) == true) // D-up-left + RT + X
            {
                SND(); Lock = 3;
            }
        }

        if (Lock > 0)
        {
            if (Act_1 && Act_4 == false) Lock = 0;
            if (Act_2 && Act_4 == false) Lock = 0;
            if (Act_3 && Act_4 == false) Lock = 0;
            if (Act_1 && Act_5 == false) Lock = 0;
            if (Act_2 && Act_5 == false) Lock = 0;
            if (Act_3 && Act_5 == false) Lock = 0;
            if ((Lock == 1) && (Act_1 == false)) Lock = 0;
            if ((Lock == 2) && (Act_2 == false)) Lock = 0;
            if ((Lock == 3) && (Act_3 == false)) Lock = 0;
        }
    }

    private void SND()
    {
        A1_Pad.GetComponent<AudioSource>().volume = 1f;
        A1_Pad.GetComponent<AudioSource>().Play();
    }
}