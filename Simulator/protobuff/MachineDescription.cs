// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: MachineDescription.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LlsfMsgs {

  /// <summary>Holder for reflection information generated from MachineDescription.proto</summary>
  public static partial class MachineDescriptionReflection {

    #region Descriptor
    /// <summary>File descriptor for MachineDescription.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MachineDescriptionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhNYWNoaW5lRGVzY3JpcHRpb24ucHJvdG8SCWxsc2ZfbXNncyIpCgZTU1Ns",
            "b3QSCQoBeBgBIAIoDRIJCgF5GAIgAigNEgkKAXoYAyACKA0qLAoKTGlnaHRD",
            "b2xvchIHCgNSRUQQABIKCgZZRUxMT1cQARIJCgVHUkVFThACKigKCkxpZ2h0",
            "U3RhdGUSBwoDT0ZGEAASBgoCT04QARIJCgVCTElOSxACKh8KBFNTT3ASCQoF",
            "U1RPUkUQARIMCghSRVRSSUVWRRACKicKBENTT3ASEAoMUkVUUklFVkVfQ0FQ",
            "EAESDQoJTU9VTlRfQ0FQEAJCOwofb3JnLnJvYm9jdXBfbG9naXN0aWNzLmxs",
            "c2ZfbXNnc0IYTWFjaGluZURlc2NyaXB0aW9uUHJvdG9z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::LlsfMsgs.LightColor), typeof(global::LlsfMsgs.LightState), typeof(global::LlsfMsgs.SSOp), typeof(global::LlsfMsgs.CSOp), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LlsfMsgs.SSSlot), global::LlsfMsgs.SSSlot.Parser, new[]{ "X", "Y", "Z" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum LightColor {
    [pbr::OriginalName("RED")] Red = 0,
    [pbr::OriginalName("YELLOW")] Yellow = 1,
    [pbr::OriginalName("GREEN")] Green = 2,
  }

  public enum LightState {
    [pbr::OriginalName("OFF")] Off = 0,
    [pbr::OriginalName("ON")] On = 1,
    [pbr::OriginalName("BLINK")] Blink = 2,
  }

  public enum SSOp {
    [pbr::OriginalName("STORE")] Store = 1,
    [pbr::OriginalName("RETRIEVE")] Retrieve = 2,
  }

  public enum CSOp {
    [pbr::OriginalName("RETRIEVE_CAP")] RetrieveCap = 1,
    [pbr::OriginalName("MOUNT_CAP")] MountCap = 2,
  }

  #endregion

  #region Messages
  public sealed partial class SSSlot : pb::IMessage<SSSlot> {
    private static readonly pb::MessageParser<SSSlot> _parser = new pb::MessageParser<SSSlot>(() => new SSSlot());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SSSlot> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LlsfMsgs.MachineDescriptionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SSSlot() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SSSlot(SSSlot other) : this() {
      _hasBits0 = other._hasBits0;
      x_ = other.x_;
      y_ = other.y_;
      z_ = other.z_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SSSlot Clone() {
      return new SSSlot(this);
    }

    /// <summary>Field number for the "x" field.</summary>
    public const int XFieldNumber = 1;
    private readonly static uint XDefaultValue = 0;

    private uint x_;
    /// <summary>
    /// Ordering is a right hand coordinate system, starting at the left bottom front corner
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint X {
      get { if ((_hasBits0 & 1) != 0) { return x_; } else { return XDefaultValue; } }
      set {
        _hasBits0 |= 1;
        x_ = value;
      }
    }
    /// <summary>Gets whether the "x" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasX {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "x" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearX() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "y" field.</summary>
    public const int YFieldNumber = 2;
    private readonly static uint YDefaultValue = 0;

    private uint y_;
    /// <summary>
    /// [0-4] width;  the place on the shelf
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Y {
      get { if ((_hasBits0 & 2) != 0) { return y_; } else { return YDefaultValue; } }
      set {
        _hasBits0 |= 2;
        y_ = value;
      }
    }
    /// <summary>Gets whether the "y" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasY {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "y" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearY() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "z" field.</summary>
    public const int ZFieldNumber = 3;
    private readonly static uint ZDefaultValue = 0;

    private uint z_;
    /// <summary>
    /// [0-1] depth;  the front or back row of the shelf
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Z {
      get { if ((_hasBits0 & 4) != 0) { return z_; } else { return ZDefaultValue; } }
      set {
        _hasBits0 |= 4;
        z_ = value;
      }
    }
    /// <summary>Gets whether the "z" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasZ {
      get { return (_hasBits0 & 4) != 0; }
    }
    /// <summary>Clears the value of the "z" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearZ() {
      _hasBits0 &= ~4;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SSSlot);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SSSlot other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (X != other.X) return false;
      if (Y != other.Y) return false;
      if (Z != other.Z) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (HasX) hash ^= X.GetHashCode();
      if (HasY) hash ^= Y.GetHashCode();
      if (HasZ) hash ^= Z.GetHashCode();
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
      if (HasX) {
        output.WriteRawTag(8);
        output.WriteUInt32(X);
      }
      if (HasY) {
        output.WriteRawTag(16);
        output.WriteUInt32(Y);
      }
      if (HasZ) {
        output.WriteRawTag(24);
        output.WriteUInt32(Z);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HasX) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(X);
      }
      if (HasY) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Y);
      }
      if (HasZ) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Z);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SSSlot other) {
      if (other == null) {
        return;
      }
      if (other.HasX) {
        X = other.X;
      }
      if (other.HasY) {
        Y = other.Y;
      }
      if (other.HasZ) {
        Z = other.Z;
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
          case 8: {
            X = input.ReadUInt32();
            break;
          }
          case 16: {
            Y = input.ReadUInt32();
            break;
          }
          case 24: {
            Z = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
