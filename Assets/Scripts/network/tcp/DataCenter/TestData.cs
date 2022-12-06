namespace network.tcp.DataCenter
{
    public class TestTcpData : Request 
    {
      
            public int version= 100;
            public int id = 98;
            public int name =99;
            public string url ="SSSSSSSSSSSSSSSSAAAASSDASDASDASDAS";
            public int ids =222;

            public override string getCmd() {
                return "Accunt:TestTcpData";
            }

            public override byte getClsID() {
                return (byte)100;
            }

            public override byte getMethodID() {
                return (byte)3;
            }

            public override int getBinLength() {
                return   Serializer.IntLength + Serializer.IntLength+
                         Serializer.IntLength +  Serializer.length(url)+ Serializer.IntLength;
            }

            public override void writeBin(Block _block) {
                _block.writeInt(version);
                _block.writeInt(id);
                _block.writeInt(name);
                _block.writeString(url);
                _block.writeInt(ids);
            }
      
    }
}