using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallStartVoteRequest : Request {
        public VoteInfo voteInfo;

        public override string getCmd() {
            return "Hall:StartVote";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override int getBinLength() {
            return   HallSerializer.getVoteInfoLength(voteInfo) ;
        }

        public override void writeBin(Block _block) {
            HallSerializer.writeVoteInfo(_block,voteInfo);
        }
    }
}

