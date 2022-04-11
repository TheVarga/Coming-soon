using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public UnityAction action;
    public void Action() {

        action.Invoke();
    }
    
}
