using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class KTVChooseRequest : Request {
        public string songId;

        public int resourceType;

        public string songName;

        public string originalSinger;

        public int singer;

        public string singerName;

        public override string getCmd() {
            return "KTV:Choose";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)11;
        }

        public override int getBinLength() {
            return   HallSerializer.length(songId) + Serializer.IntLength + HallSerializer.length(songName) + HallSerializer.length(originalSinger) + Serializer.IntLength + HallSerializer.length(singerName) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(songId);
            _block.writeInt(resourceType);
            _block.writeString(songName);
            _block.writeString(originalSinger);
            _block.writeInt(singer);
            _block.writeString(singerName);
        }
    }
}

