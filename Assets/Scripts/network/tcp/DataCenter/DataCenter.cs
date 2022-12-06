using UnityEngine;
using System.Collections;
public class DataCenter {

    static private PacketBuilder _packetBuilder = null;
    static public PacketBuilder PacketBuilder {
        get {
            if ( _packetBuilder == null ) {
                _packetBuilder = new PacketBuilder();
            }
            return _packetBuilder;
        }
    }


    static private PacketParser _packetParser = null;
    static public PacketParser PacketParser {
        get {
            if ( _packetParser == null ) {
                _packetParser = new PacketParser();
            }
            return _packetParser;
        }
    }

    static private PacketProcesser _packetProcesser = null;
    static public PacketProcesser packetProcesser {
        get {
            if ( _packetProcesser == null ) {
                _packetProcesser = new PacketProcesser();
            }
            return _packetProcesser;
        }
    }
}
