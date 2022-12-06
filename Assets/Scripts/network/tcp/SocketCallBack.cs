using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class SocketCallBack
{
    public delegate void Callback(byte[] data);
    public event Callback callback;

    public void SendMessage(byte[] data){
        if (callback != null)
        {
            callback(data);
        }
    }
}
