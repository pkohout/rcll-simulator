// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: NewPuck.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GazsimMsgs {

  /// <summary>Holder for reflection information generated from NewPuck.proto</summary>
  public static partial class NewPuckReflection {

    #region Descriptor
    /// <summary>File descriptor for NewPuck.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NewPuckReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg1OZXdQdWNrLnByb3RvEgtnYXpzaW1fbXNncyIvCgdOZXdQdWNrEhEKCXB1",
            "Y2tfbmFtZRgBIAIoCRIRCglncHNfdG9waWMYAiABKAk="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GazsimMsgs.NewPuck), global::GazsimMsgs.NewPuck.Parser, new[]{ "PuckName", "GpsTopic" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NewPuck : pb::IMessage<NewPuck> {
    private static readonly pb::MessageParser<NewPuck> _parser = new pb::MessageParser<NewPuck>(() => new NewPuck());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NewPuck> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GazsimMsgs.NewPuckReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NewPuck() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NewPuck(NewPuck other) : this() {
      puckName_ = other.puckName_;
      gpsTopic_ = other.gpsTopic_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NewPuck Clone() {
      return new NewPuck(this);
    }

    /// <summary>Field number for the "puck_name" field.</summary>
    public const int PuckNameFieldNumber = 1;
    private readonly static string PuckNameDefaultValue = "";

    private string puckName_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PuckName {
      get { return puckName_ ?? PuckNameDefaultValue; }
      set {
        puckName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "puck_name" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasPuckName {
      get { return puckName_ != null; }
    }
    /// <summary>Clears the value of the "puck_name" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearPuckName() {
      puckName_ = null;
    }

    /// <summary>Field number for the "gps_topic" field.</summary>
    public const int GpsTopicFieldNumber = 2;
    private readonly static string GpsTopicDefaultValue = "";

    private string gpsTopic_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string GpsTopic {
      get { return gpsTopic_ ?? GpsTopicDefaultValue; }
      set {
        gpsTopic_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "gps_topic" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasGpsTopic {
      get { return gpsTopic_ != null; }
    }
    /// <summary>Clears the value of the "gps_topic" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearGpsTopic() {
      gpsTopic_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NewPuck);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NewPuck other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (PuckName != other.PuckName) return false;
      if (GpsTopic != other.GpsTopic) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (HasPuckName) hash ^= PuckName.GetHashCode();
      if (HasGpsTopic) hash ^= GpsTopic.GetHashCode();
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
      if (HasPuckName) {
        output.WriteRawTag(10);
        output.WriteString(PuckName);
      }
      if (HasGpsTopic) {
        output.WriteRawTag(18);
        output.WriteString(GpsTopic);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HasPuckName) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PuckName);
      }
      if (HasGpsTopic) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(GpsTopic);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NewPuck other) {
      if (other == null) {
        return;
      }
      if (other.HasPuckName) {
        PuckName = other.PuckName;
      }
      if (other.HasGpsTopic) {
        GpsTopic = other.GpsTopic;
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
          case 10: {
            PuckName = input.ReadString();
            break;
          }
          case 18: {
            GpsTopic = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
