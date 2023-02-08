// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: NavigationChallenge.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LlsfMsgs {

  /// <summary>Holder for reflection information generated from NavigationChallenge.proto</summary>
  public static partial class NavigationChallengeReflection {

    #region Descriptor
    /// <summary>File descriptor for NavigationChallenge.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NavigationChallengeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlOYXZpZ2F0aW9uQ2hhbGxlbmdlLnByb3RvEglsbHNmX21zZ3MaClRlYW0u",
            "cHJvdG8aClpvbmUucHJvdG8ieQoFUm91dGUSCgoCaWQYASACKA0SHgoFcm91",
            "dGUYAiADKA4yDy5sbHNmX21zZ3MuWm9uZRIgCgdyZWFjaGVkGAMgAygOMg8u",
            "bGxzZl9tc2dzLlpvbmUSIgoJcmVtYWluaW5nGAQgAygOMg8ubGxzZl9tc2dz",
            "LlpvbmUiggEKEE5hdmlnYXRpb25Sb3V0ZXMSIwoKdGVhbV9jb2xvchgBIAIo",
            "DjIPLmxsc2ZfbXNncy5UZWFtEiAKBnJvdXRlcxgFIAMoCzIQLmxsc2ZfbXNn",
            "cy5Sb3V0ZSInCghDb21wVHlwZRIMCgdDT01QX0lEENAPEg0KCE1TR19UWVBF",
            "EPoBQjwKH29yZy5yb2JvY3VwX2xvZ2lzdGljcy5sbHNmX21zZ3NCGU5hdmln",
            "YXRpb25DaGFsbGVuZ2VQcm90b3M="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::LlsfMsgs.TeamReflection.Descriptor, global::LlsfMsgs.ZoneReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LlsfMsgs.Route), global::LlsfMsgs.Route.Parser, new[]{ "Id", "Route_", "Reached", "Remaining" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::LlsfMsgs.NavigationRoutes), global::LlsfMsgs.NavigationRoutes.Parser, new[]{ "TeamColor", "Routes" }, null, new[]{ typeof(global::LlsfMsgs.NavigationRoutes.Types.CompType) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Route : pb::IMessage<Route>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Route> _parser = new pb::MessageParser<Route>(() => new Route());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Route> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LlsfMsgs.NavigationChallengeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Route() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Route(Route other) : this() {
      _hasBits0 = other._hasBits0;
      id_ = other.id_;
      route_ = other.route_.Clone();
      reached_ = other.reached_.Clone();
      remaining_ = other.remaining_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Route Clone() {
      return new Route(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private readonly static uint IdDefaultValue = 0;

    private uint id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Id {
      get { if ((_hasBits0 & 1) != 0) { return id_; } else { return IdDefaultValue; } }
      set {
        _hasBits0 |= 1;
        id_ = value;
      }
    }
    /// <summary>Gets whether the "id" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasId {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "id" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearId() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "route" field.</summary>
    public const int Route_FieldNumber = 2;
    private static readonly pb::FieldCodec<global::LlsfMsgs.Zone> _repeated_route_codec
        = pb::FieldCodec.ForEnum(16, x => (int) x, x => (global::LlsfMsgs.Zone) x);
    private readonly pbc::RepeatedField<global::LlsfMsgs.Zone> route_ = new pbc::RepeatedField<global::LlsfMsgs.Zone>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::LlsfMsgs.Zone> Route_ {
      get { return route_; }
    }

    /// <summary>Field number for the "reached" field.</summary>
    public const int ReachedFieldNumber = 3;
    private static readonly pb::FieldCodec<global::LlsfMsgs.Zone> _repeated_reached_codec
        = pb::FieldCodec.ForEnum(24, x => (int) x, x => (global::LlsfMsgs.Zone) x);
    private readonly pbc::RepeatedField<global::LlsfMsgs.Zone> reached_ = new pbc::RepeatedField<global::LlsfMsgs.Zone>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::LlsfMsgs.Zone> Reached {
      get { return reached_; }
    }

    /// <summary>Field number for the "remaining" field.</summary>
    public const int RemainingFieldNumber = 4;
    private static readonly pb::FieldCodec<global::LlsfMsgs.Zone> _repeated_remaining_codec
        = pb::FieldCodec.ForEnum(32, x => (int) x, x => (global::LlsfMsgs.Zone) x);
    private readonly pbc::RepeatedField<global::LlsfMsgs.Zone> remaining_ = new pbc::RepeatedField<global::LlsfMsgs.Zone>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::LlsfMsgs.Zone> Remaining {
      get { return remaining_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Route);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Route other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if(!route_.Equals(other.route_)) return false;
      if(!reached_.Equals(other.reached_)) return false;
      if(!remaining_.Equals(other.remaining_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasId) hash ^= Id.GetHashCode();
      hash ^= route_.GetHashCode();
      hash ^= reached_.GetHashCode();
      hash ^= remaining_.GetHashCode();
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
      if (HasId) {
        output.WriteRawTag(8);
        output.WriteUInt32(Id);
      }
      route_.WriteTo(output, _repeated_route_codec);
      reached_.WriteTo(output, _repeated_reached_codec);
      remaining_.WriteTo(output, _repeated_remaining_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasId) {
        output.WriteRawTag(8);
        output.WriteUInt32(Id);
      }
      route_.WriteTo(ref output, _repeated_route_codec);
      reached_.WriteTo(ref output, _repeated_reached_codec);
      remaining_.WriteTo(ref output, _repeated_remaining_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasId) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
      }
      size += route_.CalculateSize(_repeated_route_codec);
      size += reached_.CalculateSize(_repeated_reached_codec);
      size += remaining_.CalculateSize(_repeated_remaining_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Route other) {
      if (other == null) {
        return;
      }
      if (other.HasId) {
        Id = other.Id;
      }
      route_.Add(other.route_);
      reached_.Add(other.reached_);
      remaining_.Add(other.remaining_);
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
            Id = input.ReadUInt32();
            break;
          }
          case 18:
          case 16: {
            route_.AddEntriesFrom(input, _repeated_route_codec);
            break;
          }
          case 26:
          case 24: {
            reached_.AddEntriesFrom(input, _repeated_reached_codec);
            break;
          }
          case 34:
          case 32: {
            remaining_.AddEntriesFrom(input, _repeated_remaining_codec);
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
            Id = input.ReadUInt32();
            break;
          }
          case 18:
          case 16: {
            route_.AddEntriesFrom(ref input, _repeated_route_codec);
            break;
          }
          case 26:
          case 24: {
            reached_.AddEntriesFrom(ref input, _repeated_reached_codec);
            break;
          }
          case 34:
          case 32: {
            remaining_.AddEntriesFrom(ref input, _repeated_remaining_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class NavigationRoutes : pb::IMessage<NavigationRoutes>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<NavigationRoutes> _parser = new pb::MessageParser<NavigationRoutes>(() => new NavigationRoutes());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NavigationRoutes> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LlsfMsgs.NavigationChallengeReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NavigationRoutes() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NavigationRoutes(NavigationRoutes other) : this() {
      _hasBits0 = other._hasBits0;
      teamColor_ = other.teamColor_;
      routes_ = other.routes_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NavigationRoutes Clone() {
      return new NavigationRoutes(this);
    }

    /// <summary>Field number for the "team_color" field.</summary>
    public const int TeamColorFieldNumber = 1;
    private readonly static global::LlsfMsgs.Team TeamColorDefaultValue = global::LlsfMsgs.Team.Cyan;

    private global::LlsfMsgs.Team teamColor_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::LlsfMsgs.Team TeamColor {
      get { if ((_hasBits0 & 1) != 0) { return teamColor_; } else { return TeamColorDefaultValue; } }
      set {
        _hasBits0 |= 1;
        teamColor_ = value;
      }
    }
    /// <summary>Gets whether the "team_color" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasTeamColor {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "team_color" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearTeamColor() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "routes" field.</summary>
    public const int RoutesFieldNumber = 5;
    private static readonly pb::FieldCodec<global::LlsfMsgs.Route> _repeated_routes_codec
        = pb::FieldCodec.ForMessage(42, global::LlsfMsgs.Route.Parser);
    private readonly pbc::RepeatedField<global::LlsfMsgs.Route> routes_ = new pbc::RepeatedField<global::LlsfMsgs.Route>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::LlsfMsgs.Route> Routes {
      get { return routes_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as NavigationRoutes);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NavigationRoutes other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TeamColor != other.TeamColor) return false;
      if(!routes_.Equals(other.routes_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasTeamColor) hash ^= TeamColor.GetHashCode();
      hash ^= routes_.GetHashCode();
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
      if (HasTeamColor) {
        output.WriteRawTag(8);
        output.WriteEnum((int) TeamColor);
      }
      routes_.WriteTo(output, _repeated_routes_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasTeamColor) {
        output.WriteRawTag(8);
        output.WriteEnum((int) TeamColor);
      }
      routes_.WriteTo(ref output, _repeated_routes_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasTeamColor) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) TeamColor);
      }
      size += routes_.CalculateSize(_repeated_routes_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NavigationRoutes other) {
      if (other == null) {
        return;
      }
      if (other.HasTeamColor) {
        TeamColor = other.TeamColor;
      }
      routes_.Add(other.routes_);
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
            TeamColor = (global::LlsfMsgs.Team) input.ReadEnum();
            break;
          }
          case 42: {
            routes_.AddEntriesFrom(input, _repeated_routes_codec);
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
            TeamColor = (global::LlsfMsgs.Team) input.ReadEnum();
            break;
          }
          case 42: {
            routes_.AddEntriesFrom(ref input, _repeated_routes_codec);
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the NavigationRoutes message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Types {
      public enum CompType {
        [pbr::OriginalName("COMP_ID")] CompId = 2000,
        [pbr::OriginalName("MSG_TYPE")] MsgType = 250,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
