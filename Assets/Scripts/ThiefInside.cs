using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefInside : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm.On();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.Off();
    }
}
