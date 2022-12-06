

using System;
using Google.Protobuf;
using NewProto;

namespace network
{
    public class Block
    {
        public int rIndex , wIndex;

        public byte[] data;

        public Block(int size){
            data=new byte[size];
        }

        public Block(byte[] data)
        {
            this.data = data;
        }

        //重置位置
        public int capacity()
        {
            return data.Length;
        }

        //重置位置
        public void resetWriter()                      //重置到起始位置
        {
            wIndex = 0;
        }
        public void setWriterPosition(int pos)     //指定写入位置
        {
            wIndex = pos;
        }
        public int writerPosition()
        {
            return wIndex;
        }
        public int writerRemaining()
        {
            return data.Length - wIndex;
        }

        //顺序写入
        public void writeBoolean(bool value)
        {
            writeByte(value == true ? (byte)1 : 0);
        }
        public void writeByte(byte value)
        {
            data[wIndex++] = (byte)value;
        }
        public void writeByte(int value)
        {
            data[wIndex++] = (byte)(value);
        }
        public void writeChar(char value)
        {
            writeShort((short)value);
        }
        public void writeShort(short value)
        {
            data[wIndex++] = (byte)value;
            data[wIndex++] = (byte)(value >> 8);
        }
        public void writeShort(int value)
        {
            data[wIndex++] = (byte)value;
            data[wIndex++] = (byte)(value >> 8);
        }
        public void writeCompactShort(short value)
        {
            if (Math.Abs(value) > byte.MaxValue)
            {
                writeByte(byte.MinValue);
                writeShort(value);
            }
            else
            {
                writeByte((byte)value);
            }
        }
        public void writeUnsignedShort(int value)
        {
            writeShort(value);
        }
        public void writeInt(int value)
        {
            data[wIndex++] = (byte)value;
            data[wIndex++] = (byte)((value >> 8));
            data[wIndex++] = (byte)((value >> 16));
            data[wIndex++] = (byte)((value >> 24));
        }

        public void writeProto(IMessage value)
        {
            data = NetUtilcs.Serialize(value);
        }

        public  byte[] getData()
        {
            return data;
        }

        public void writeVaryInt(int value)
        {
            long unsignedValue = value & 0xffffffffL;
            for (;;)
            {
                int cur = (int)unsignedValue & 0x7F;
                unsignedValue >>= 7;
                if (unsignedValue == 0)
                {
                    writeByte(cur);
                    break;
                }
                else
                {
                    writeByte(cur | 0x80);
                }
            }
        }
        public void writeCompactInt(int value)
        {
            if (Math.Abs(value) > short.MaxValue)
            {
                writeShort(short.MinValue);
                writeInt(value);
            }
            else
            {
                writeShort((short)value);
            }
        }
        public void writeLong(long value)
        {
            data[wIndex++] = (byte)value;
            data[wIndex++] = (byte)((value >> 8));
            data[wIndex++] = (byte)((value >> 16));
            data[wIndex++] = (byte)((value >> 24));
            data[wIndex++] = (byte)((value >> 32));
            data[wIndex++] = (byte)((value >> 40));
            data[wIndex++] = (byte)((value >> 48));
            data[wIndex++] = (byte)((value >> 56));
        }
        public void writeFloat(float value)
        {
            int a = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
            writeInt(a);
        }
        public void writeDouble(double value)
        {
            long t=BitConverter.DoubleToInt64Bits(value);
            writeLong(t);
        }
        public void writeString(string value)
        {
            char[] c= value.ToCharArray();
            writeCharArray(c);
        }

        public void writeDate(DateTime time)
        {
            long javaTime = (time.Ticks- 621355968000000000L) / 10000 - 8 * 3600 * 1000 ;
            writeLong(javaTime);
        }

        public void writeBooleanArray(bool[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i = 0; i < len; ++i)
            {
                writeBoolean(value[i]);
            }
        }
        public void writeByteArray(byte[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i=0;i<len;++i)
            {
                data[wIndex + i] = (byte)value[i];
            }
            wIndex += len;
        }

        public void writeBlock(Block value)
        {
            if (value == null) return;
            int writeSize = writerRemaining();
            int readSize = value.readerRemaining();
            int minSize = writeSize > readSize ? readSize : writeSize;
           
            for (int i=0;i<minSize;++i)
            {
                data[wIndex++] = value.data[value.rIndex++];
            }
            
        }
        

        public void writeCharArray(char[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i = 0; i < len; ++i)
            {
                writeChar(value[i]);
            }
        }
        public void writeShortArray(short[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i = 0; i < len; ++i)
            {
                writeShort(value[i]);
            }
        }
        public void writeIntArray(int[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i = 0; i < len; ++i)
            {
                writeInt(value[i]);
            }
        }
        public void writeLongArray(long[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i = 0; i < len; ++i)
            {
                writeLong(value[i]);
            }
        }
        public void writeFloatArray(float[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i = 0; i < len; ++i)
            {
                writeFloat(value[i]);
            }
        }
        public void writeDoubleArray(double[] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);
            for (int i=0;i<len;++i)
            {
                writeDouble(value[i]);
            }
        }
        public void writeStringArray(string[] str)
        {
            if (str == null)
            {
                writeShort(-1);
                return;
            }

            int len = str.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeString(str[i]);
            }
        }

        public void writeBooleanArray_D(bool[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeBooleanArray(value[i]);
            }
        }
        public void writeByteArray_D(byte[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeByteArray(value[i]);
            }
        }
        public void writeCharArray_D(char[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeCharArray(value[i]);
            }
        }
        public void writeShortArray_D(short[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeShortArray(value[i]);
            }
        }
        public void writeIntArray_D(int[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeIntArray(value[i]);
            }
        }
        public void writeLongArray_D(long[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeLongArray(value[i]);
            }
        }
        public void writeFloatArray_D(float[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeFloatArray(value[i]);
            }
        }
        public void writeDoubleArray_D(double[][] value)
        {
            if (value == null)
            {
                writeShort(-1);
                return;
            }

            int len = value.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeDoubleArray(value[i]);
            }
        }
        public void writeStringArray_D(string[][] str)
        {
            if (str == null)
            {
                writeShort(-1);
                return;
            }

            int len = str.Length;
            writeShort(len);

            for (int i = 0; i < len; ++i)
            {
                writeStringArray(str[i]);
            }
        }

        //随机写入
        public void writeBoolean(int offset, bool value)
        {
            setWriterPosition(offset);
            writeBoolean(value);
        }
        public void writeByte(int offset, byte value)
        {
            setWriterPosition(offset);
            writeByte(value);
        }
        public void writeByte(int offset, int value)
        {
            setWriterPosition(offset);
            writeByte(value);
        }
        public void writeChar(int offset, char value)
        {
            setWriterPosition(offset);
            writeChar(value);
        }

        public void writeShort(int offset, short value)
        {
            setWriterPosition(offset);
            writeShort(value);
        }
        public void writeShort(int offset, int value)
        {
            setWriterPosition(offset);
            writeShort(value);
        }
        public void writeUnsignedShort(int offset, int value)
        {
            setWriterPosition(offset);
            writeUnsignedShort(value);
        }
        public void writeCompactShort(int offset, short value)
        {
            setWriterPosition(offset);
            writeCompactShort(value);
        }
        public void writeInt(int offset, int value)
        {
            setWriterPosition(offset);
            writeInt(value);
        }
        public void writeVaryInt(int offset, int value)
        {
            setWriterPosition(offset);
            writeInt(value);
        }
        public void writeCompactInt(int offset, int value)
        {
            setWriterPosition(offset);
            writeCompactInt(value);
        }
        public void writeLong(int offset, long value)
        {
            setWriterPosition(offset);
            writeLong(value);
        }
        public void writeFloat(int offset, float value)
        {
            setWriterPosition(offset);
            writeFloat(value);
        }
        public void writeDouble(int offset, double value)
        {
            setWriterPosition(offset);
            writeDouble(value);
        }
        public void writeString(int offset, string value)
        {
            setWriterPosition(offset);
            writeString(value);
        }
        public void writeDate(int offset, DateTime value)
        {
            setWriterPosition(offset);
            writeDate(value);
        }

        public void writeBooleanArray(int offset, bool[] value)
        {
            setWriterPosition(offset);
            writeBooleanArray(value);
        }
        public void writeByteArray(int offset, byte[] value)
        {
            setWriterPosition(offset);
            writeByteArray(value);
        }
        public void writeCharArray(int offset, char[] value)
        {
            setWriterPosition(offset);
            writeCharArray(value);
        }
        public void writeShortArray(int offset, short[] value)
        {
            setWriterPosition(offset);
            writeShortArray(value);
        }
        public void writeIntArray(int offset, int[] value)
        {
            setWriterPosition(offset);
            writeIntArray(value);
        }
        public void writeLongArray(int offset, long[] value)
        {
            setWriterPosition(offset);
            writeLongArray(value);
        }
        public void writeFloatArray(int offset, float[] value)
        {
            setWriterPosition(offset);
            writeFloatArray(value);
        }
        public void writeDoubleArray(int offset, double[] value)
        {
            setWriterPosition(offset);
            writeDoubleArray(value);
        }
        public void writeStringArray(int offset, string[] value)
        {
            setWriterPosition(offset);
            writeStringArray(value);
        }

        public void writeBooleanArray_D(int offset, bool[][] value)
        {
            setWriterPosition(offset);
            writeBooleanArray_D(value);
        }
        public void writeByteArray_D(int offset, byte[][] value)
        {
            setWriterPosition(offset);
            writeByteArray_D(value);
        }
        public void writeCharArray_D(int offset, char[][] value)
        {
            setWriterPosition(offset);
            writeCharArray_D(value);
        }
        public void writeShortArray_D(int offset, short[][] value)
        {
            setWriterPosition(offset);
            writeShortArray_D(value);
        }
        public void writeIntArray_D(int offset, int[][] value)
        {
            setWriterPosition(offset);
            writeIntArray_D(value);
        }
        public void writeLongArray_D(int offset, long[][] value)
        {
            setWriterPosition(offset);
            writeLongArray_D(value);
        }
        public void writeFloatArray_D(int offset, float[][] value)
        {
            setWriterPosition(offset);
            writeFloatArray_D(value);
        }
        public void writeDoubleArray_D(int offset, double[][] value)
        {
            setWriterPosition(offset);
            writeDoubleArray_D(value);
        }
        public void writeStringArray_D(int offset, string[][] value)
        {
            setWriterPosition(offset);
            writeStringArray_D(value);
        }



        public void resetReader()                      //重置到起始位置
        {
            rIndex = 0;
        }
        public void setReaderPosition(int pos)    //指定读取位置
        {
            rIndex = pos;
        }

        public void readSkips(int pos)    //指定读取位置
        {
            rIndex += pos;
        }

        public void writeSkips(int pos)    //指定读取位置
        {
            wIndex += pos;
        }

        public int readerPosition()
        {
            return rIndex;
        }
        public int readerRemaining()
        {
            return wIndex - rIndex;
        }

        //顺序读取
        public int readUnsignedShort()
        {
            return readShort() & 0xFFFF;
        }
        public short readCompactShort()
        {
            byte firstByte = readByte();
            if (firstByte == byte.MinValue)
            {
                return readShort();
            }
            else
            {
                return firstByte;
            }
        }
        public int readCompactInt()
        {
            short firstShort = readShort();
            if (firstShort == short.MinValue)
            {
                return readInt();
            }
            else
            {
                return firstShort;
            }
        }
        public int readVaryInt()
        {
            long result = 0;
            int i = 0;
            for (;;)
            {
                byte b = readByte();
                result |= (b & 0x7FL) << i;

                if (b < 0)
                {
                    i += 7;
                }
                else
                {
                    return (int)result;
                }
            }
        }

        public bool readBoolean()
        {
            return data[rIndex++] == 0 ? false : true;
        }
        public byte readByte()
        {
            return (byte)data[rIndex++];
        }
        public char readChar()
        {
            return (char)readShort();
        }
        public short readShort()
        {
            return (short)((data[rIndex++])  + ((data[rIndex++]) << 8));
        }
        public int readInt()
        {
            return
                (data[rIndex++])
              + ((data[rIndex++]) << 8)
              + ((data[rIndex++]) << 16)
              + ((data[rIndex++]) << 24)
                ;
        }
        public long readLong()
        {

            return     ((data[rIndex++]) << 0) +
                       ((data[rIndex++]) << 8) +
                       ((data[rIndex++]) << 16) +
                       ((long)(data[rIndex++]) << 24) +
                       ((long)(data[rIndex++]) << 32) +
                       ((long)(data[rIndex++]) << 40) +
                       ((long)(data[rIndex++]) << 48) +
                       ((long)data[rIndex++] << 56)
                       ;
        }
        public float readFloat()
        {
            int i = readInt();
            return BitConverter.ToSingle(BitConverter.GetBytes(i),0);
        }
        public double readDouble()
        {
            long l = readLong();
            return BitConverter.Int64BitsToDouble(l);
        }
        public string readString()
        {
            char[] data = readCharArray();
            if (data != null)
                return new string(data);
            return null;
        }


        public DateTime readDate()
        {
            long time = readLong();
            long milli = time + 8 * 3600 * 1000;
            long ticks = (milli * 10000) + 621355968000000000L;

            return new DateTime(ticks);
        }

        public bool[] readBooleanArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            bool[] array = new bool[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readBoolean();
            }

            return array;
        }
        
        public byte[] readArray(int len)
        {
            if (len == -1)
            {
                return null;
            }

            byte[] array = new byte[len];

            for (int i = 0; i < len; ++i)
            {
                array[i] = (byte)data[rIndex + i];
            }

            rIndex += len;

            return array;
        }
        
        public byte[] readByteArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            byte[] array = new byte[len];

            for (int i = 0; i < len; ++i)
            {
                array[i] = (byte)data[rIndex + i];
            }

            rIndex += len;

            return array;
        }
        public char[] readCharArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            char[] array = new char[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readChar();
            }

            return array;
        }
        public short[] readShortArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            short[] array = new short[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readShort();
            }

            return array;
        }
        public int[] readIntArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            int[] array = new int[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readInt();
            }

            return array;
        }
        public long[] readLongArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            long[] array = new long[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readLong();
            }

            return array;
        }
        public float[] readFloatArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            float[] array = new float[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readFloat();
            }

            return array;
        }
        public double[] readDoubleArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            double[] array = new double[len];
            for (int i=0;i<len;++i)
            {
                array[i] = readDouble();
            }

            return array;
       }

        public string[] readStringArray()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            string[] array = new string[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readString();
            }

            return array;
        }

        public bool[][] readBooleanArray_D()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            bool[][] array = new bool[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readBooleanArray();
            }

            return array;
        }
        public byte[][] readByteArray_D()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            byte[][] array = new byte[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readByteArray();
            }

            return array;
        }
        public char[][] readCharArray_D()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            char[][] array = new char[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readCharArray();
            }

            return array;
        }
        public short[][] readShortArray_D()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            short[][] array = new short[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readShortArray();
            }

            return array;
        }
        public int[][] readIntArray_D()
        {
            short len = readShort();
            if (len == -1)
            {
                return null;
            }

            int[][] array = new int[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readIntArray();
            }

            return array;
        }
        public long[][] readLongArray_D()
        {
            int len = readShort();
            if (len == -1)
            {
                return null;
            }

            long[][] array = new long[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readLongArray();
            }

            return array;
        }
        public float[][] readFloatArray_D()
        {
            int len = readShort();
            if (len == -1)
            {
                return null;
            }

            float[][] array = new float[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readFloatArray();
            }

            return array;
        }
        public double[][] readDoubleArray_D()
        {
            int len = readShort();
            if (len == -1)
            {
                return null;
            }

            double[][] array = new double[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readDoubleArray();
            }

            return array;
        }
        public string[][] readStringArray_D()
        {
            int len = readShort();
            if (len == -1)
            {
                return null;
            }

            string[][] array = new string[len][];
            for (int i = 0; i < len; ++i)
            {
                array[i] = readStringArray();
            }

            return array;
        }

        //随机读取
        public int readUnsignedShort(int offset)
        {
            setReaderPosition(offset);
            return readUnsignedShort();
        }
        public short readCompactShort(int offset)
        {
            setReaderPosition(offset);
            return readCompactShort();
        }
        public int readCompactInt(int offset)
        {
            setReaderPosition(offset);
            return readCompactInt();
        }
        public int readVaryInt(int offset)
        {
            setReaderPosition(offset);
            return readVaryInt();
        }

        public bool readBoolean(int offset)
        {
            setReaderPosition(offset);
            return readBoolean();
        }
        public byte readByte(int offset)
        {
            setReaderPosition(offset);
            return readByte();
        }
        public char readChar(int offset)
        {
            setReaderPosition(offset);
            return readChar();
        }
        public short readShort(int offset)
        {
            setReaderPosition(offset);
            return readShort();
        }
        public int readInt(int offset)
        {
            setReaderPosition(offset);
            return readInt();
        }
        public long readLong(int offset)
        {
            setReaderPosition(offset);
            return readLong();
        }
        public float readFloat(int offset)
        {
            setReaderPosition(offset);
            return readFloat();
        }
        public double readDouble(int offset)
        {
            setReaderPosition(offset);
            return readDouble();
        }
        public string readString(int offset)
        {
            setReaderPosition(offset);
            return readString();
        }
        public DateTime readDate(int offset)
        {
            setReaderPosition(offset);
            return readDate();
        }

        public bool[] readBooleanArray(int offset)
        {
            setReaderPosition(offset);
            return readBooleanArray();
        }
        public byte[] readByteArray(int offset)
        {
            setReaderPosition(offset);
            return readByteArray();
        }
        public char[] readCharArray(int offset)
        {
            setReaderPosition(offset);
            return readCharArray();
        }
        public short[] readShortArray(int offset)
        {
            setReaderPosition(offset);
            return readShortArray();
        }
        public int[] readIntArray(int offset)
        {
            setReaderPosition(offset);
            return readIntArray();
        }
        public long[] readLongArray(int offset)
        {
            setReaderPosition(offset);
            return readLongArray();
        }
        public float[] readFloatArray(int offset)
        {
            setReaderPosition(offset);
            return readFloatArray();
        }

        public double[] readDoubleArray(int offset)
        {
            setReaderPosition(offset);
            return readDoubleArray();
        }
        public string[] readStringArray(int offset)
        {
            setReaderPosition(offset);
            return readStringArray();
        }

        public bool[][] readBooleanArray_D(int offset)
        {
            setReaderPosition(offset);
            return readBooleanArray_D();
        }
        public byte[][] readByteArray_D(int offset)
        {
            setReaderPosition(offset);
            return readByteArray_D();
        }
        public char[][] readCharArray_D(int offset)
        {
            setReaderPosition(offset);
            return readCharArray_D();
        }
        public short[][] readShortArray_D(int offset)
        {
            setReaderPosition(offset);
            return readShortArray_D();
        }
        public int[][] readIntArray_D(int offset)
        {
            setReaderPosition(offset);
            return readIntArray_D();
        }
        public long[][] readLongArray_D(int offset)
        {
            setReaderPosition(offset);
            return readLongArray_D();
        }
        public float[][] readFloatArray_D(int offset)
        {
            setReaderPosition(offset);
            return readFloatArray_D();
        }
        public double[][] readDoubleArray_D(int offset)
        {
            setReaderPosition(offset);
            return readDoubleArray_D();
        }
        public string[][] readStringArray_D(int offset)
        {
            setReaderPosition(offset);
            return readStringArray_D();
        }
        public void writeRealByteArray(byte[] value)
        {
            if (value == null)
            {
                return;
            }
            int len = value.Length;
            for (int i=0;i<len;++i)
            {
                data[wIndex + i] = (byte)value[i];
            }
            wIndex += len;
        }
        public byte[] readRealByteArray()
        {
            int len = data.Length;
            if (len == -1)
            {
                return null;
            }
            byte[] array = new byte[len];
            for (int i = 0; i < len; ++i)
            {
                array[i] = (byte)data[rIndex + i];
            }
            rIndex += len;
            return array;
        }
    }
}
