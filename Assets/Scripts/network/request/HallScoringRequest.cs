using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallScoringRequest : Request {
        public ScoringInfo scoringInfo;

        public override string getCmd() {
            return "Hall:Scoring";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)15;
        }

        public override int getBinLength() {
            return   HallSerializer.getScoringInfoLength(scoringInfo) ;
        }

        public override void writeBin(Block _block) {
            HallSerializer.writeScoringInfo(_block,scoringInfo);
        }
    }
}

