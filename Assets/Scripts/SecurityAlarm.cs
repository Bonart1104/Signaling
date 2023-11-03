using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class SecurityAlarm : MonoBehaviour
{
    private bool _isWorkAlarm;
    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Intruder>(out Intruder intruder))
        {
            _isWorkAlarm = true;
            _alarm.Activate(_isWorkAlarm);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent<Intruder>(out Intruder intruder))
        {
            _isWorkAlarm = false;
            _alarm.Activate(_isWorkAlarm);
        }
    }
}
