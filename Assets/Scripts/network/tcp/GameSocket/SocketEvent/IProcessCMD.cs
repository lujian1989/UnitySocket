using System;

public abstract class IProcessCMD
{
    public abstract void IncomingData(byte[] data, int actualSize);
}
