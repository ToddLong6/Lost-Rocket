using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        //Switch Statement are a Conditional like If/Else Statement
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Im Not dead"); 
                break;
            case "Finish":
                Debug.Log("I WON!!"); 
                break;
            case "Fuel":
                Debug.Log("I can still fly"); 
                break;
            default:
                Debug.Log("Im Dead");
                break;
        }
    }
}
