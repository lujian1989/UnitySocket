using UnityEngine;
using System.Collections;
public class PacketCenter {

    private static PacketBuilder _packetBuilder = null;
    public static PacketBuilder PacketBuilder {
        get {
            if ( _packetBuilder == null ) {
                _packetBuilder = new PacketBuilder();
            }
            return _packetBuilder;
        }
    }


    private static PacketParser _packetParser = null;
    public static PacketParser PacketParser {
        get {
            if ( _packetParser == null ) {
                _packetParser = new PacketParser();
            }
            return _packetParser;
        }
    }

    private static PacketProcesser _packetProcesser = null;
    public static PacketProcesser packetProcesser {
        get {
            if ( _packetProcesser == null ) {
                _packetProcesser = new PacketProcesser();
            }
            return _packetProcesser;
        }
    }
}
