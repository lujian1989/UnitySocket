using System;
using System.Linq;
using NewProto;
using UnityEngine;

public class TCPCMDProcess : IProcessCMD
{
    private const int packetMaxLength = 65535;
    private SocketCallBack mCallback;

    private int writeIndex = 0;
    private byte[] buffer;

    public TCPCMDProcess(SocketCallBack Callback)
    {
        this.buffer = new byte[packetMaxLength];
        this.mCallback = Callback;
    }

    /*
    override public void IncomingData(byte[] data, int actualSize)
    {
        if (this.writeIndex + actualSize >= packetMaxLength)
        {
            throw new Exception("Buffer Overflow!");
        }
        Array.Copy(data, 0, this.buffer, this.writeIndex, actualSize);
        this.writeIndex += actualSize;
        while (this.writeIndex >= Demo.packetLength)
        {
            byte[] bytes = new byte[Demo.packetLength];
            Array.Copy(this.buffer, 0, bytes, 0, Demo.packetLength);
            this.mCallback.SendMessage(bytes);
            this.writeIndex = 0;
        }
    }
    */

    override public void IncomingData( byte[] data, int actualSize ) {
        if( this.writeIndex + actualSize  >=  packetMaxLength ) {
            Debug.LogError("Buffer Overflow:actualSize"+actualSize+" data.Length:"+data.Length+" writeIndex:"+writeIndex);
            throw new Exception( "Buffer Overflow!" );
        }
        Array.Copy( data, 0, this.buffer, this.writeIndex, actualSize );
        this.writeIndex += actualSize;

        if( writeIndex < 4 ) {
            return;
        }
        byte[] lenByte = new byte[4];
        Array.Copy( this.buffer, 0, lenByte, 0, 4 );
        Array.Reverse(lenByte);
        int len = (int)BitConverter.ToInt32(lenByte, 0);
        len += 4;
        if (len <= 0 || len > this.writeIndex ) {
            Debug.LogError("等下一个组包：len:"+len+" writeIndex:"+writeIndex+" actualSize:"+actualSize);
            return;
        }
        Debug.Log( "writeIndex: " + writeIndex + "    len: " + len + "    " + data.Length + "------");
        while ( this.writeIndex >= 4 && this.writeIndex >= len ) {
            Debug.Log( "begin parse "+buffer.Length);
            byte[] result = new byte[len];
            Array.Copy( this.buffer, 0, result, 0, len);
            NetUtilcs.DebugBytes2(buffer);
            this.mCallback.SendMessage( result );
            bool isWait = false;
            if (writeIndex -len < 4 )
            {
                isWait = true;
                Debug.LogError("余下字节不可构成长度:"+(writeIndex -len));
                //return;
            }
            
            this.buffer = Remove( this.buffer, ref this.writeIndex, len );
            
            //len = BitConverter.ToUInt16( this.buffer, 0 );
            Debug.LogError("解析后:"+buffer.Length);
            NetUtilcs.DebugBytes2(buffer);

            if (isWait)
            {
                return;
            }
            Array.Copy( this.buffer, 0, lenByte, 0, 4 );
            Array.Reverse(lenByte);
            len = (int)BitConverter.ToInt32(lenByte, 0);
            Debug.LogError("下一个len:"+len);
            if (len <= 0 || len > writeIndex - 4) {
                Debug.LogError("长度不够等下一个:"+len);
                return;
            } 
            len += 4;
            Debug.Log( "writeIndex: " + writeIndex + "    len: " + len + "    " + data.Length + "------In While");
        }

    }


    private byte[] Remove( byte[] data, ref int writeIndex, int len )
    {
        byte[] newBuffer = new byte[packetMaxLength];
        Array.Copy( data, len, newBuffer, 0, writeIndex   - len );
        writeIndex -= len;
        Debug.Log("Remove----writeIndex:"+writeIndex+" len:"+len);
        return newBuffer;
    }
}
