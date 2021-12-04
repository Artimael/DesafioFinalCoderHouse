using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private UnityEvent onSwitchPush;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Prueba");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Desactivar");
            onSwitchPush?.Invoke();
        }
    }
}
