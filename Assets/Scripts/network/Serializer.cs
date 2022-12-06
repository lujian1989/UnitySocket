using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace network
{
    public class Serializer
    {
        public const int BooleanLength = 1;
        public const int ByteLength = 1;
        public const int ShortLength = 2;
        public const int CharLength = 2;
        public const int IntLength = 4;
        public const int LongLength = 8;
        public const int FloatLength = 4;
        public const int DoubleLength = 8;
        public const int DateLength = 8;

        public const string BooleanLengthName = "BooleanLength";
        public const string ByteLengthName = "ByteLength";
        public const string ShortLengthName = "ShortLength";
        public const string CharLengthName = "CharLength";
        public const string IntLengthName = "IntLength";
        public const string LongLengthName = "LongLength";
        public const string FloatLengthName = "FloatLength";
        public const string DoubleLengthName = "DoubleLength";
        public const string DateLengthName = "DateLength";

        public static int length(IMessage proto)
        {
            if (proto == null)
            {
                return 2;
            }

            return 2 + (proto.CalculateSize() << 1);
        }

        
        
        public static int length(string str)
        {
            if (str == null)
            {
                return 2;
            }

            return 2 + (str.Length << 1);
        }

        public static int length(string[] strs)
        {
            if (strs == null)
            {
                return 2;
            }

            int count = 2;
            foreach (string str in strs)
            {
                count += length(str);
            }

            return count;
        }

        public static int length(string[][] strs)
        {
            if (strs == null)
            {
                return 2;
            }

            int count = 2;
            foreach (string[] str in strs)
            {
                count += length(str);
            }

            return count;
        }

        public static int length(byte[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length);
        }

        public static int length(byte[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (byte[] value in values)
            {
                count += length(value);
            }

            return count;
        }

        public static int length(bool[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length);
        }


        public static int length(bool[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (bool[] value in values)
            {
                count += length(value);
            }

            return count;
        }

        public static int length(short[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length << 1);
        }


        public static int length(short[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (short[] value in values)
            {
                count += length(value);
            }

            return count;
        }

        public static int length(char[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length << 1);
        }

        public static int length(char[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (char[] value in values)
            {
                count += length(value);
            }

            return count;
        }


        public static int length(int[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length << 2);
        }

        public static int length(int[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (int[] value in values)
            {
                count += length(value);
            }

            return count;
        }

        public static int length(long[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length << 3);
        }


        public static int length(long[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (long[] value in values)
            {
                count += length(value);
            }

            return count;
        }

        public static int length(float[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length << 2);
        }


        public static int length(float[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (float[] value in values)
            {
                count += length(value);
            }

            return count;
        }

        public static int length(double[] value)
        {
            if (value == null)
            {
                return 2;
            }

            return 2 + (value.Length << 3);
        }

        public static int length(double[][] values)
        {
            if (values == null)
            {
                return 2;
            }

            int count = 2;
            foreach (double[] value in values)
            {
                count += length(value);
            }

            return count;
        }
    }
}
