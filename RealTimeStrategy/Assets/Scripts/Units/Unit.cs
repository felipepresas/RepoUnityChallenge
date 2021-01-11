using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class Unit : NetworkBehaviour
{
    [SerializeField] private UnityEvent OnSelected = null;
    [SerializeField] private UnityEvent OnDeselected = null;

    #region Client
    [Client]
    public void Select()
    {
        if (!hasAuthority){return;}
        OnSelected?.Invoke();
    }
    [Client]
    public void Deselect()
    {
        if (!hasAuthority){return;}
        OnDeselected?.Invoke();
    }
    #endregion
}