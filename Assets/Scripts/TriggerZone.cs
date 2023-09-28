using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Dude>(out Dude dude))
        {
            _enter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Dude>(out Dude dude))
        {
            _exit?.Invoke();
        }
    }
}
