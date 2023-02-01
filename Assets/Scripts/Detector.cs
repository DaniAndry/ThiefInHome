using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool isInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        _alarm.Breaker(isInside);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        _alarm.Breaker(isInside);
    }
}
