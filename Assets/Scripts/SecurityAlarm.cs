using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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
        if (collision.collider.TryGetComponent<Intruder>(out Intruder intruder))
        {
            isWorkAlarm = true;
            _alarm.TurnOn(isWorkAlarm);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent<Intruder>(out Intruder intruder))
        {
            isWorkAlarm = false;
            _alarm.TurnOn(isWorkAlarm);
        }
    }
}
