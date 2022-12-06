using System;
using UnityEngine;


public class CreateConnectionAsyncArgs : EventArgs
{
    public bool ConnectionOk { get; private set; }

    public CreateConnectionAsyncArgs(bool connnectionOk)
    {
        this.ConnectionOk = connnectionOk;
        Debug.Log("ConnectionOk");
    }
}

