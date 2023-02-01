using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isInside = true;
        _alarm.Control(isInside);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bool isInside = false;
        _alarm.Control(isInside);
    }
}
