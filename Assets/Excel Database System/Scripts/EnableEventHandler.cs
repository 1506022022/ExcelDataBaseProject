using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableEventHandler : MonoBehaviour
{
    public UnityEvent m_EnableEventHandler, m_DisableEventHandler;
    private void OnEnable()
    {
        m_EnableEventHandler.Invoke();
    }
    private void OnDisable()
    {
        m_DisableEventHandler.Invoke();
    }

}
