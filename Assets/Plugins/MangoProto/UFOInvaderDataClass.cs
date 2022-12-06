﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFOInvader_Data
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Source_ID_Data")]
    public partial class Source_ID_Data : global::ProtoBuf.IExtensible
    {
        public Source_ID_Data() { }

        private uint _id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public uint id
        {
            get { return _id; }
            set { _id = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Source_ID_State_Data")]
    public partial class Source_ID_State_Data : global::ProtoBuf.IExtensible
    {
        public Source_ID_State_Data() { }

        private uint _id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public uint id
        {
            get { return _id; }
            set { _id = value; }
        }
        private uint _state;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public uint state
        {
            get { return _state; }
            set { _state = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Source_ID_Bool_Data")]
    public partial class Source_ID_Bool_Data : global::ProtoBuf.IExtensible
    {
        public Source_ID_Bool_Data() { }

        private uint _id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public uint id
        {
            get { return _id; }
            set { _id = value; }
        }
        private bool _state;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"state", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public bool state
        {
            get { return _state; }
            set { _state = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"UFO_Info")]
    public partial class UFO_Info : global::ProtoBuf.IExtensible
    {
        public UFO_Info() { }

        private int _Id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _name;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _spawnTimes;
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"spawnTimes", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int spawnTimes
        {
            get { return _spawnTimes; }
            set { _spawnTimes = value; }
        }
        private int _type;
        [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name = @"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        private int _attackSpeed;
        [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name = @"attackSpeed", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int attackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }
        private float _attackInterval;
        [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name = @"attackInterval", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float attackInterval
        {
            get { return _attackInterval; }
            set { _attackInterval = value; }
        }
        private int _damage;
        [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name = @"damage", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        private float _moveSpeed;
        [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name = @"moveSpeed", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float moveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }
        private int _hp;
        [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name = @"hp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        private int _score;
        [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name = @"score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int score
        {
            get { return _score; }
            set { _score = value; }
        }
        private int _dispearedTime;
        [global::ProtoBuf.ProtoMember(11, IsRequired = true, Name = @"dispearedTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int dispearedTime
        {
            get { return _dispearedTime; }
            set { _dispearedTime = value; }
        }
        private float _attackDistance;
        [global::ProtoBuf.ProtoMember(12, IsRequired = true, Name = @"attackDistance", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float attackDistance
        {
            get { return _attackDistance; }
            set { _attackDistance = value; }
        }
        private int _itemType;
        [global::ProtoBuf.ProtoMember(13, IsRequired = true, Name = @"itemType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int itemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }
        private int _subItemType;
        [global::ProtoBuf.ProtoMember(14, IsRequired = true, Name = @"subItemType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int subItemType
        {
            get { return _subItemType; }
            set { _subItemType = value; }
        }
        private int _quantity;
        [global::ProtoBuf.ProtoMember(15, IsRequired = true, Name = @"quantity", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        private float _startX;
        [global::ProtoBuf.ProtoMember(16, IsRequired = true, Name = @"startX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float startX
        {
            get { return _startX; }
            set { _startX = value; }
        }
        private float _startY;
        [global::ProtoBuf.ProtoMember(17, IsRequired = true, Name = @"startY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float startY
        {
            get { return _startY; }
            set { _startY = value; }
        }
        private float _startZ;
        [global::ProtoBuf.ProtoMember(18, IsRequired = true, Name = @"startZ", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float startZ
        {
            get { return _startZ; }
            set { _startZ = value; }
        }
        private int _playerId;
        [global::ProtoBuf.ProtoMember(19, IsRequired = true, Name = @"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        private float _faceX;
        [global::ProtoBuf.ProtoMember(20, IsRequired = true, Name = @"faceX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float faceX
        {
            get { return _faceX; }
            set { _faceX = value; }
        }
        private float _faceY;
        [global::ProtoBuf.ProtoMember(21, IsRequired = true, Name = @"faceY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float faceY
        {
            get { return _faceY; }
            set { _faceY = value; }
        }
        private float _faceZ;
        [global::ProtoBuf.ProtoMember(22, IsRequired = true, Name = @"faceZ", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float faceZ
        {
            get { return _faceZ; }
            set { _faceZ = value; }
        }
        private int _desId;
        [global::ProtoBuf.ProtoMember(23, IsRequired = true, Name = @"desId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int desId
        {
            get { return _desId; }
            set { _desId = value; }
        }
        private float _accSpeed;
        [global::ProtoBuf.ProtoMember(24, IsRequired = true, Name = @"accSpeed", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public float accSpeed
        {
            get { return _accSpeed; }
            set { _accSpeed = value; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"SpawnUFO_MSG")]
    public partial class SpawnUFO_MSG : global::ProtoBuf.IExtensible
    {
        public SpawnUFO_MSG() { }

        private UFO_Info _ufoInfo;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"ufoInfo", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public UFO_Info ufoInfo
        {
            get { return _ufoInfo; }
            set { _ufoInfo = value; }
        }
        private int _spawnPoint;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"spawnPoint", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int spawnPoint
        {
            get { return _spawnPoint; }
            set { _spawnPoint = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Damage_Info")]
    public partial class Damage_Info : global::ProtoBuf.IExtensible
    {
        public Damage_Info() { }

        private int _Id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _damage;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"damage", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        private int _gunType;
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"gunType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int gunType
        {
            get { return _gunType; }
            set { _gunType = value; }
        }
        private int _playerId;
        [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name = @"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"UFODie_Info")]
    public partial class UFODie_Info : global::ProtoBuf.IExtensible
    {
        public UFODie_Info() { }

        private int _Id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _playerId;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        private int _gunType;
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"gunType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int gunType
        {
            get { return _gunType; }
            set { _gunType = value; }
        }
        private int _itemType;
        [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name = @"itemType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int itemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }
        private int _subItemType;
        [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name = @"subItemType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int subItemType
        {
            get { return _subItemType; }
            set { _subItemType = value; }
        }
        private int _quantity;
        [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name = @"quantity", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"PlayerDamage_Info")]
    public partial class PlayerDamage_Info : global::ProtoBuf.IExtensible
    {
        public PlayerDamage_Info() { }

        private int _playerId;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        private int _damage;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"damage", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        private int _ufoId;
        [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name = @"ufoId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int zombieId
        {
            get { return _ufoId; }
            set { _ufoId = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"SpawnUFONum")]
    public partial class SpawnUFONum : global::ProtoBuf.IExtensible
    {
        public SpawnUFONum() { }

        private int _waves;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"waves", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int waves
        {
            get { return _waves; }
            set { _waves = value; }
        }
        private int _num;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"num", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int num
        {
            get { return _num; }
            set { _num = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

}