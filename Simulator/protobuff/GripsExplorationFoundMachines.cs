// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GripsExplorationFoundMachines.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LlsfMsgs {

  /// <summary>Holder for reflection information generated from GripsExplorationFoundMachines.proto</summary>
  public static partial class GripsExplorationFoundMachinesReflection {

    #region Descriptor
    /// <summary>File descriptor for GripsExplorationFoundMachines.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GripsExplorationFoundMachinesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiNHcmlwc0V4cGxvcmF0aW9uRm91bmRNYWNoaW5lcy5wcm90bxIJbGxzZl9t",
            "c2dzGhhSb2JvdE1hY2hpbmVSZXBvcnQucHJvdG8ikAEKHUdyaXBzRXhwbG9y",
            "YXRpb25Gb3VuZE1hY2hpbmVzEjQKCG1hY2hpbmVzGAIgAygLMiIubGxzZl9t",
            "c2dzLlJvYm90TWFjaGluZVJlcG9ydEVudHJ5EhAKCHJvYm90X2lkGAMgAigN",
            "IicKCENvbXBUeXBlEgwKB0NPTVBfSUQQiCcSDQoITVNHX1RZUEUQ+QNCRgof",
            "b3JnLnJvYm9jdXBfbG9naXN0aWNzLmxsc2ZfbXNnc0IjR3JpcHNFeHBsb3Jh",
            "dGlvbkZvdW5kTWFjaGluZXNQcm90b3M="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::LlsfMsgs.RobotMachineReportReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LlsfMsgs.GripsExplorationFoundMachines), global::LlsfMsgs.GripsExplorationFoundMachines.Parser, new[]{ "Machines", "RobotId" }, null, new[]{ typeof(global::LlsfMsgs.GripsExplorationFoundMachines.Types.CompType) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GripsExplorationFoundMachines : pb::IMessage<GripsExplorationFoundMachines> {
    private static readonly pb::MessageParser<GripsExplorationFoundMachines> _parser = new pb::MessageParser<GripsExplorationFoundMachines>(() => new GripsExplorationFoundMachines());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GripsExplorationFoundMachines> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LlsfMsgs.GripsExplorationFoundMachinesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GripsExplorationFoundMachines() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GripsExplorationFoundMachines(GripsExplorationFoundMachines other) : this() {
      _hasBits0 = other._hasBits0;
      machines_ = other.machines_.Clone();
      robotId_ = other.robotId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GripsExplorationFoundMachines Clone() {
      return new GripsExplorationFoundMachines(this);
    }

    /// <summary>Field number for the "machines" field.</summary>
    public const int MachinesFieldNumber = 2;
    private static readonly pb::FieldCodec<global::LlsfMsgs.RobotMachineReportEntry> _repeated_machines_codec
        = pb::FieldCodec.ForMessage(18, global::LlsfMsgs.RobotMachineReportEntry.Parser);
    private readonly pbc::RepeatedField<global::LlsfMsgs.RobotMachineReportEntry> machines_ = new pbc::RepeatedField<global::LlsfMsgs.RobotMachineReportEntry>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::LlsfMsgs.RobotMachineReportEntry> Machines {
      get { return machines_; }
    }

    /// <summary>Field number for the "robot_id" field.</summary>
    public const int RobotIdFieldNumber = 3;
    private readonly static uint RobotIdDefaultValue = 0;

    private uint robotId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint RobotId {
      get { if ((_hasBits0 & 1) != 0) { return robotId_; } else { return RobotIdDefaultValue; } }
      set {
        _hasBits0 |= 1;
        robotId_ = value;
      }
    }
    /// <summary>Gets whether the "robot_id" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasRobotId {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "robot_id" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearRobotId() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GripsExplorationFoundMachines);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GripsExplorationFoundMachines other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!machines_.Equals(other.machines_)) return false;
      if (RobotId != other.RobotId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= machines_.GetHashCode();
      if (HasRobotId) hash ^= RobotId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      machines_.WriteTo(output, _repeated_machines_codec);
      if (HasRobotId) {
        output.WriteRawTag(24);
        output.WriteUInt32(RobotId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += machines_.CalculateSize(_repeated_machines_codec);
      if (HasRobotId) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(RobotId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GripsExplorationFoundMachines other) {
      if (other == null) {
        return;
      }
      machines_.Add(other.machines_);
      if (other.HasRobotId) {
        RobotId = other.RobotId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 18: {
            machines_.AddEntriesFrom(input, _repeated_machines_codec);
            break;
          }
          case 24: {
            RobotId = input.ReadUInt32();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the GripsExplorationFoundMachines message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum CompType {
        [pbr::OriginalName("COMP_ID")] CompId = 5000,
        [pbr::OriginalName("MSG_TYPE")] MsgType = 505,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
