using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using network.entity;

namespace network
{
    public class RoomProperty
    {
        public static PropertyValue setBoolValue(int index, bool value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            if (value)
            {
                pv.properties = new byte[]{1};
            }
            else
            {
                pv.properties = new byte[]{0};
            }
            return pv;
        }

        public static bool getBoolValue(PropertyValue value)
        {
            if (value.properties[0] == 1)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public static PropertyValue setByteValue(int index, byte value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;
            pv.properties = new byte[] { value };
            return pv;
        }

        public static byte getByteValue(PropertyValue value)
        {
            return value.properties[0];
        }

        public static PropertyValue setShortValue(int index, short value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            pv.index = (byte)index;

            byte[] data = new byte[2];
            data[0] = (byte)value;
            data[1] = (byte)((value >> 8));

            pv.properties = data;
            return pv;
        }

        public static short getShortValue(PropertyValue value)
        {
            byte[] data = value.properties;
            return (short)((data[0] & 0xff)
              + ((data[1] & 0xff) << 8));
        }


        public static PropertyValue setIntValue(int index,int value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            byte[] data = new byte[4];
            data[0] = (byte)value;
            data[1] = (byte)((value >> 8));
            data[2] = (byte)((value >> 16));
            data[3] = (byte)((value >> 24));

            pv.properties = data;
            return pv;
        }

        public static int getIntValue(PropertyValue value)
        {
            byte[] data = value.properties;
            return (data[0]&0xff)
              + ((data[1] & 0xff) << 8)
              + ((data[2] & 0xff) << 16)
              + ((data[3] & 0xff) << 24)
            ;
        }


        public static PropertyValue setLongValue(int index, long value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            byte[] data = new byte[8];
            data[0] = (byte)value;
            data[1] = (byte)((value >> 8));
            data[2] = (byte)((value >> 16));
            data[3] = (byte)((value >> 24));
            data[4] = (byte)((value >> 32));
            data[5] = (byte)((value >> 40));
            data[6] = (byte)((value >> 48));
            data[7] = (byte)((value >> 56));
            pv.properties = data;
            return pv;
        }

        public static long getLongValue(PropertyValue value)
        {
            byte[] data = value.properties;
            return (long)(data[0] & 0xff)
              + ((long)(data[1] & 0xff) << 8)
              + ((long)(data[2] & 0xff) << 16)
              + ((long)(data[3] & 0xff) << 24)
              + ((long)(data[4] & 0xff) << 32)
              + ((long)(data[5] & 0xff) << 40)
              + ((long)(data[6] & 0xff) << 48)
              + ((long)(data[7] & 0xff) << 56)
            ;
        }


        public static PropertyValue setFloatValue(int index, float value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            int a = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

            byte[] data = new byte[4];

            data[0] = (byte)a;
            data[1] = (byte)((a >> 8));
            data[2] = (byte)((a >> 16));
            data[3] = (byte)((a >> 24));

            pv.properties = data;
            return pv;
        }

        public static float  getFloatValue(PropertyValue value)
        {
            byte[] data = value.properties;
            int i= (data[0] & 0xff)
              + ((data[1] & 0xff) << 8)
              + ((data[2] & 0xff) << 16)
              + ((data[3] & 0xff) << 24)
            ;

            return BitConverter.ToSingle(BitConverter.GetBytes(i), 0);
        }


        public static PropertyValue setDateValue(int index, DateTime value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            long javaTime = (value.Ticks - 621355968000000000L) / 10000 - 8 * 3600 * 1000;
            pv.properties = long2Array(javaTime);
            return pv;
        }

        public static DateTime getDateValue(PropertyValue value)
        {
            byte[] data = value.properties;
            long time = ((long)(data[0] & 0xff)) +
           ((long)(data[1] & 0xff) << 8)  |
           ((long)(data[2] & 0xff) << 16) |
           ((long)(data[3] & 0xff) << 24) |
           ((long)(data[4] & 0xff) << 32) |
           ((long)(data[5] & 0xff) << 40) |
           ((long)(data[6] & 0xff) << 48) |
           ((long)(data[7]&0xff) << 56)
           ;

            long milli = time + 8 * 3600 * 1000;
            long ticks = (milli * 10000) + 621355968000000000L;

            return new DateTime(ticks);
        }


        public static byte[] long2Array(long value)
        {
            byte[] data = new byte[8];
            data[0] = (byte)value;
            data[1] = (byte)((value >> 8));
            data[2] = (byte)((value >> 16));
            data[3] = (byte)((value >> 24));
            data[4] = (byte)((value >> 32));
            data[5] = (byte)((value >> 40));
            data[6] = (byte)((value >> 48));
            data[7] = (byte)((value >> 56));
            return data;
        }

        public static void writeFloat(byte[] data,int offset,float value)
        {
            int a = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

            data[offset] = (byte)a;
            data[offset + 1] = (byte)((a >> 8));
            data[offset + 2] = (byte)((a >> 16));
            data[offset + 3] = (byte)((a >> 24));
    
        }


        public static float readFloat(byte[] data, int offset)
        {

            int i = (data[offset] & 0xff)
              + ((data[offset + 1] & 0xff) << 8)
              + ((data[offset + 2] & 0xff) << 16)
              + ((data[offset + 3] & 0xff) << 24)
            ;

            return BitConverter.ToSingle(BitConverter.GetBytes(i), 0);


        }


        public static PropertyValue setStringValue(int index, string value)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            if (value != null)
            {
                char[] c = value.ToCharArray();
                byte[] data = new byte[c.Length<<1];
                for (int i=0;i<c.Length;++i)
                {
                    data[i<<1] = (byte)c[i];
                    data[(i << 1)+1] = (byte)(c[i] >> 8);

                }
                pv.properties = data;
            }

            return pv;
        }

        public static string getStringValue(PropertyValue value)
        {
            byte[] data = value.properties;
            char[] array = new char[data.Length>>1];

            for (int i = 0; i < data.Length; i+=2)
            {
                array[i >> 1] = (char)((data[i]&0xff) + ((data[i+1]&0xff) << 8));
            }

            if (array != null)
                return new string(array);

            return null;
        }

        public static PropertyValue setVectorValue(int index, float[] value)
        {
            return setVectorValue(index, value[0], value[1], value[2]);
        }

        public static PropertyValue setVectorValue(int index, float x, float y, float z)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;

            byte[] data = new byte[12];
            writeFloat(data, 0, x);
            writeFloat(data, 4, y);
            writeFloat(data, 8, z);

            pv.properties = data;
            return pv;
        }

        public static PropertyValue setByteArrayValue(int index, byte[] data)
        {
            PropertyValue pv = new PropertyValue();
            pv.index = (byte)index;
            pv.properties = data;
            return pv;
        }

        public static byte[] getByteArrayValue(PropertyValue value)
        {
            return value.properties;
        }

        public static float[] getVectorValue(PropertyValue value)
        {
            byte[] data = value.properties;

            float[] result = new float[3];
            result[0] = readFloat(data, 0);
            result[1] = readFloat(data, 4);
            result[2] = readFloat(data, 8);

            return result;
        }


        // public static PropertyValue setProtoValue<T>(int index, T value)
        // {
        //     PropertyValue pv = new PropertyValue();
        //     pv.index = (byte)index;
        //
        //     byte[] data = ProtoBufUtils.ProtobufSerialize<T>(value);
        //     pv.setProperties(data);
        //     return pv;
        // }
        //
        //
        // public static T getProtoValue<T>(PropertyValue value)
        // {
        //     byte[] data = value.properties;
        //
        //     T p = ProtoBufUtils.Deserialize<T>(data);
        //
        //     return p;
        // }





    }
}
