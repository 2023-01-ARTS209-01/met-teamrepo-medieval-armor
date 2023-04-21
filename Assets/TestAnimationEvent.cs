// This C# function can be called by an Animation Event
using UnityEngine;
using System.Collections;


public class TestAnimationEvent : MonoBehaviour
{
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
}