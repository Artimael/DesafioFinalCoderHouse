using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private UnityEvent onSwitchPush;
    
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Evento de presionar switch ");
            onSwitchPush?.Invoke();
        }
    }


}
