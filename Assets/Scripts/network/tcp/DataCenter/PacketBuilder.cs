using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using ComponentAce.Compression.Libs.zlib;
using Google.Protobuf;
using network;
using NewProto;


public enum NET_CMD_TYPE
{
    OLD = 0,
    PB = 1,
    JSON = 2,
    COUSTOM = 3,
}

public class PacketBuilder
{
    private int size = 0;
    private byte type;
    private byte end;
    private byte compress;
    private int privateKey;
    private byte clsID;
    private byte methodID;
    private byte[] body;


    /// <summary>
    /// 打包消息数据
    /// </summary>
    /// <param name="msgObject"></param>
    /// <returns>打包后的二进制流</returns>
    public byte[] Build(object msgObject, byte type = (byte)NET_CMD_TYPE.OLD, bool isEncryption = true)
    {
        int len = 0;
        byte[] packet = null;
        if (msgObject == null)
        {
            Debug.LogError("Error: protobuf class and name can not be null!");
            return null;
        }
        DataCenter.packetProcesser.privateKey++;
        Debug.Log("privateKey" + DataCenter.packetProcesser.privateKey);
        Request req = msgObject as Request;
        if (req != null)
        {
            this.type = type;
            clsID = req.getClsID();
            methodID = req.getMethodID();
            end = req.end();
            compress = req.isCompress();
            Debug.Log("Build end:" + end + " compress:" + compress);

            Block block = new Block(req.getBinLength());
            req.writeBin(block);

            len = 9 + req.getBinLength();
            packet = new byte[len + 4];
            int writeIndex = 0;
            WriteInt32(ref packet, ref writeIndex, len);
            WriteByte(ref packet, ref writeIndex, type);
            WriteByte(ref packet, ref writeIndex, end);
            WriteByte(ref packet, ref writeIndex, compress);
            WriteInt32(ref packet, ref writeIndex, DataCenter.packetProcesser.privateKey);
            WriteByte(ref packet, ref writeIndex, clsID);
            WriteByte(ref packet, ref writeIndex, methodID);
            //body = block.getData();
            WriteBytes(ref packet, ref writeIndex, block.getData(), block.getData().Length);
            Debug.LogError("=====实际发送包加密前=====:" + isEncryption);
            NetUtilcs.DebugBytes(packet);
            if (isEncryption)
            {
                packet = NetUtilcs.EncryptionBytes(packet,
                    DataCenter.packetProcesser.PublicKey == 0 ? len : DataCenter.packetProcesser.PublicKey);
            }
            Debug.LogError("=====实际发送包=====");
            NetUtilcs.DebugBytes(packet);
        }
        return packet;
    }


    private void WriteUInt16(ref byte[] packet, ref int writeIndex, ushort num)
    {
        byte[] tmp = BitConverter.GetBytes(num);
        Array.Copy(tmp, 0, packet, writeIndex, 2);
        writeIndex += 2;
    }

    private void WriteInt32(ref byte[] packet, ref int writeIndex, int num)
    {
        byte[] tmp = BitConverter.GetBytes(num);
        Array.Reverse(tmp);
        Array.Copy(tmp, 0, packet, writeIndex, 4);

        writeIndex += 4;
    }

    private void WriteBytes(ref byte[] packet, ref int writeIndex, byte[] data, int len)
    {
        Array.Copy(data, 0, packet, writeIndex, len);
        writeIndex += len;
    }

    private void WriteByte(ref byte[] packet, ref int writeIndex, byte data)
    {
        var bytesNew = new byte[1];
        bytesNew[0] = data;
        Array.Copy(bytesNew, 0, packet, writeIndex, 1);
        writeIndex += 1;
    }
}