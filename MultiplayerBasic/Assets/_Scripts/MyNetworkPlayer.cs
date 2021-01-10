using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text displayNameText = null;
    [SerializeField] private Renderer displayColourRender = null;



    [SyncVar(hook = nameof(HandleDisplayNameUpdate))]
    [SerializeField]
    private string displayName = "Missing Name";

    [SyncVar(hook = nameof(HandleDisplayColourUpdate))]
    [SerializeField]
    private Color displayColour = Color.black;

    #region Server
    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColour(Color newDisplayColour)
    {

        displayColour = newDisplayColour;
    }
    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        if (newDisplayName.Length<2 || newDisplayName.Length>20){return;}

        RpcLogNewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }
    #endregion
    #region Client
    private void HandleDisplayNameUpdate(string oldName, string newName)
    {
        displayNameText.text = newName;
    }

    private void HandleDisplayColourUpdate(Color oldColour, Color newColour)
    {
        displayColourRender.material.SetColor("_BaseColor", newColour);
    }
    [ContextMenu("Set MyName")]
    private void SetMyName()
    {
        CmdSetDisplayName("My New Name");
    }

    [ClientRpc]
    private void RpcLogNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }

    #endregion

}