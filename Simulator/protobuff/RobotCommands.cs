// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: RobotCommands.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LlsfMsgs {

  /// <summary>Holder for reflection information generated from RobotCommands.proto</summary>
  public static partial class RobotCommandsReflection {

    #region Descriptor
    /// <summary>File descriptor for RobotCommands.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RobotCommandsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNSb2JvdENvbW1hbmRzLnByb3RvEglsbHNmX21zZ3MaClRlYW0ucHJvdG8i",
            "jQEKE1NldFJvYm90TWFpbnRlbmFuY2USFAoMcm9ib3RfbnVtYmVyGAEgAigN",
            "EhMKC21haW50ZW5hbmNlGAMgAigIEiMKCnRlYW1fY29sb3IYBCACKA4yDy5s",
            "bHNmX21zZ3MuVGVhbSImCghDb21wVHlwZRIMCgdDT01QX0lEENAPEgwKCE1T",
            "R19UWVBFEFtCNgofb3JnLnJvYm9jdXBfbG9naXN0aWNzLmxsc2ZfbXNnc0IT",
            "Um9ib3RDb21tYW5kc1Byb3Rvcw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::LlsfMsgs.TeamReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LlsfMsgs.SetRobotMaintenance), global::LlsfMsgs.SetRobotMaintenance.Parser, new[]{ "RobotNumber", "Maintenance", "TeamColor" }, null, new[]{ typeof(global::LlsfMsgs.SetRobotMaintenance.Types.CompType) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Set a robot's maintenance state
  /// </summary>
  public sealed partial class SetRobotMaintenance : pb::IMessage<SetRobotMaintenance>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SetRobotMaintenance> _parser = new pb::MessageParser<SetRobotMaintenance>(() => new SetRobotMaintenance());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SetRobotMaintenance> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LlsfMsgs.RobotCommandsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SetRobotMaintenance() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SetRobotMaintenance(SetRobotMaintenance other) : this() {
      _hasBits0 = other._hasBits0;
      robotNumber_ = other.robotNumber_;
      maintenance_ = other.maintenance_;
      teamColor_ = other.teamColor_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SetRobotMaintenance Clone() {
      return new SetRobotMaintenance(this);
    }

    /// <summary>Field number for the "robot_number" field.</summary>
    public const int RobotNumberFieldNumber = 1;
    private readonly static uint RobotNumberDefaultValue = 0;

    private uint robotNumber_;
    /// <summary>
    /// Number of robot to set state
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint RobotNumber {
      get { if ((_hasBits0 & 1) != 0) { return robotNumber_; } else { return RobotNumberDefaultValue; } }
      set {
        _hasBits0 |= 1;
        robotNumber_ = value;
      }
    }
    /// <summary>Gets whether the "robot_number" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasRobotNumber {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "robot_number" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearRobotNumber() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "maintenance" field.</summary>
    public const int MaintenanceFieldNumber = 3;
    private readonly static bool MaintenanceDefaultValue = false;

    private bool maintenance_;
    /// <summary>
    /// True to activate maintenance,
    /// false to bring back robot
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Maintenance {
      get { if ((_hasBits0 & 2) != 0) { return maintenance_; } else { return MaintenanceDefaultValue; } }
      set {
        _hasBits0 |= 2;
        maintenance_ = value;
      }
    }
    /// <summary>Gets whether the "maintenance" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasMaintenance {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "maintenance" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearMaintenance() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "team_color" field.</summary>
    public const int TeamColorFieldNumber = 4;
    private readonly static global::LlsfMsgs.Team TeamColorDefaultValue = global::LlsfMsgs.Team.Cyan;

    private global::LlsfMsgs.Team teamColor_;
    /// <summary>
    /// Team the robot belongs to
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::LlsfMsgs.Team TeamColor {
      get { if ((_hasBits0 & 4) != 0) { return teamColor_; } else { return TeamColorDefaultValue; } }
      set {
        _hasBits0 |= 4;
        teamColor_ = value;
      }
    }
    /// <summary>Gets whether the "team_color" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasTeamColor {
      get { return (_hasBits0 & 4) != 0; }
    }
    /// <summary>Clears the value of the "team_color" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearTeamColor() {
      _hasBits0 &= ~4;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as SetRobotMaintenance);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SetRobotMaintenance other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RobotNumber != other.RobotNumber) return false;
      if (Maintenance != other.Maintenance) return false;
      if (TeamColor != other.TeamColor) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasRobotNumber) hash ^= RobotNumber.GetHashCode();
      if (HasMaintenance) hash ^= Maintenance.GetHashCode();
      if (HasTeamColor) hash ^= TeamColor.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasRobotNumber) {
        output.WriteRawTag(8);
        output.WriteUInt32(RobotNumber);
      }
      if (HasMaintenance) {
        output.WriteRawTag(24);
        output.WriteBool(Maintenance);
      }
      if (HasTeamColor) {
        output.WriteRawTag(32);
        output.WriteEnum((int) TeamColor);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasRobotNumber) {
        output.WriteRawTag(8);
        output.WriteUInt32(RobotNumber);
      }
      if (HasMaintenance) {
        output.WriteRawTag(24);
        output.WriteBool(Maintenance);
      }
      if (HasTeamColor) {
        output.WriteRawTag(32);
        output.WriteEnum((int) TeamColor);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasRobotNumber) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(RobotNumber);
      }
      if (HasMaintenance) {
        size += 1 + 1;
      }
      if (HasTeamColor) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) TeamColor);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SetRobotMaintenance other) {
      if (other == null) {
        return;
      }
      if (other.HasRobotNumber) {
        RobotNumber = other.RobotNumber;
      }
      if (other.HasMaintenance) {
        Maintenance = other.Maintenance;
      }
      if (other.HasTeamColor) {
        TeamColor = other.TeamColor;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RobotNumber = input.ReadUInt32();
            break;
          }
          case 24: {
            Maintenance = input.ReadBool();
            break;
          }
          case 32: {
            TeamColor = (global::LlsfMsgs.Team) input.ReadEnum();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            RobotNumber = input.ReadUInt32();
            break;
          }
          case 24: {
            Maintenance = input.ReadBool();
            break;
          }
          case 32: {
            TeamColor = (global::LlsfMsgs.Team) input.ReadEnum();
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the SetRobotMaintenance message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Types {
      public enum CompType {
        [pbr::OriginalName("COMP_ID")] CompId = 2000,
        [pbr::OriginalName("MSG_TYPE")] MsgType = 91,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
