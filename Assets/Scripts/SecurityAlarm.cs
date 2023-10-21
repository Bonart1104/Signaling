using UnityEngine;

public class SecurityAlarm : MonoBehaviour
{
    private bool isWorkAlarm;
    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isWorkAlarm = true;
        _alarm.TurnOn(isWorkAlarm);
    }

    private void OnCollisionExit(Collision collision)
    {
        isWorkAlarm = false;
        _alarm.TurnOn(false);
    }
}
