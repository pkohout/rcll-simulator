// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: LogMessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LlsfLogMsgs {

  /// <summary>Holder for reflection information generated from LogMessage.proto</summary>
  public static partial class LogMessageReflection {

    #region Descriptor
    /// <summary>File descriptor for LogMessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LogMessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBMb2dNZXNzYWdlLnByb3RvEg1sbHNmX2xvZ19tc2dzIpwCCgpMb2dNZXNz",
            "YWdlEg4KBnRzX3NlYxgBIAIoAxIPCgd0c19uc2VjGAIgAigDEjUKCWxvZ19s",
            "ZXZlbBgDIAIoDjIiLmxsc2ZfbG9nX21zZ3MuTG9nTWVzc2FnZS5Mb2dMZXZl",
            "bBIRCgljb21wb25lbnQYBCACKAkSDwoHbWVzc2FnZRgFIAIoCRIbCgxpc19l",
            "eGNlcHRpb24YBiABKAg6BWZhbHNlIiYKCENvbXBUeXBlEgwKB0NPTVBfSUQQ",
            "0w8SDAoITVNHX1RZUEUQASJNCghMb2dMZXZlbBIMCghMTF9ERUJVRxAAEgsK",
            "B0xMX0lORk8QARILCgdMTF9XQVJOEAISDAoITExfRVJST1IQBBILCgdMTF9O",
            "T05FEAg="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LlsfLogMsgs.LogMessage), global::LlsfLogMsgs.LogMessage.Parser, new[]{ "TsSec", "TsNsec", "LogLevel", "Component", "Message", "IsException" }, null, new[]{ typeof(global::LlsfLogMsgs.LogMessage.Types.CompType), typeof(global::LlsfLogMsgs.LogMessage.Types.LogLevel) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class LogMessage : pb::IMessage<LogMessage> {
    private static readonly pb::MessageParser<LogMessage> _parser = new pb::MessageParser<LogMessage>(() => new LogMessage());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LogMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LlsfLogMsgs.LogMessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogMessage(LogMessage other) : this() {
      _hasBits0 = other._hasBits0;
      tsSec_ = other.tsSec_;
      tsNsec_ = other.tsNsec_;
      logLevel_ = other.logLevel_;
      component_ = other.component_;
      message_ = other.message_;
      isException_ = other.isException_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogMessage Clone() {
      return new LogMessage(this);
    }

    /// <summary>Field number for the "ts_sec" field.</summary>
    public const int TsSecFieldNumber = 1;
    private readonly static long TsSecDefaultValue = 0L;

    private long tsSec_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long TsSec {
      get { if ((_hasBits0 & 1) != 0) { return tsSec_; } else { return TsSecDefaultValue; } }
      set {
        _hasBits0 |= 1;
        tsSec_ = value;
      }
    }
    /// <summary>Gets whether the "ts_sec" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasTsSec {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "ts_sec" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearTsSec() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "ts_nsec" field.</summary>
    public const int TsNsecFieldNumber = 2;
    private readonly static long TsNsecDefaultValue = 0L;

    private long tsNsec_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long TsNsec {
      get { if ((_hasBits0 & 2) != 0) { return tsNsec_; } else { return TsNsecDefaultValue; } }
      set {
        _hasBits0 |= 2;
        tsNsec_ = value;
      }
    }
    /// <summary>Gets whether the "ts_nsec" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasTsNsec {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "ts_nsec" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearTsNsec() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "log_level" field.</summary>
    public const int LogLevelFieldNumber = 3;
    private readonly static global::LlsfLogMsgs.LogMessage.Types.LogLevel LogLevelDefaultValue = global::LlsfLogMsgs.LogMessage.Types.LogLevel.LlDebug;

    private global::LlsfLogMsgs.LogMessage.Types.LogLevel logLevel_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::LlsfLogMsgs.LogMessage.Types.LogLevel LogLevel {
      get { if ((_hasBits0 & 4) != 0) { return logLevel_; } else { return LogLevelDefaultValue; } }
      set {
        _hasBits0 |= 4;
        logLevel_ = value;
      }
    }
    /// <summary>Gets whether the "log_level" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasLogLevel {
      get { return (_hasBits0 & 4) != 0; }
    }
    /// <summary>Clears the value of the "log_level" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearLogLevel() {
      _hasBits0 &= ~4;
    }

    /// <summary>Field number for the "component" field.</summary>
    public const int ComponentFieldNumber = 4;
    private readonly static string ComponentDefaultValue = "";

    private string component_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Component {
      get { return component_ ?? ComponentDefaultValue; }
      set {
        component_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "component" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasComponent {
      get { return component_ != null; }
    }
    /// <summary>Clears the value of the "component" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearComponent() {
      component_ = null;
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 5;
    private readonly static string MessageDefaultValue = "";

    private string message_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_ ?? MessageDefaultValue; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "message" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasMessage {
      get { return message_ != null; }
    }
    /// <summary>Clears the value of the "message" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearMessage() {
      message_ = null;
    }

    /// <summary>Field number for the "is_exception" field.</summary>
    public const int IsExceptionFieldNumber = 6;
    private readonly static bool IsExceptionDefaultValue = false;

    private bool isException_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsException {
      get { if ((_hasBits0 & 8) != 0) { return isException_; } else { return IsExceptionDefaultValue; } }
      set {
        _hasBits0 |= 8;
        isException_ = value;
      }
    }
    /// <summary>Gets whether the "is_exception" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasIsException {
      get { return (_hasBits0 & 8) != 0; }
    }
    /// <summary>Clears the value of the "is_exception" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearIsException() {
      _hasBits0 &= ~8;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LogMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LogMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TsSec != other.TsSec) return false;
      if (TsNsec != other.TsNsec) return false;
      if (LogLevel != other.LogLevel) return false;
      if (Component != other.Component) return false;
      if (Message != other.Message) return false;
      if (IsException != other.IsException) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (HasTsSec) hash ^= TsSec.GetHashCode();
      if (HasTsNsec) hash ^= TsNsec.GetHashCode();
      if (HasLogLevel) hash ^= LogLevel.GetHashCode();
      if (HasComponent) hash ^= Component.GetHashCode();
      if (HasMessage) hash ^= Message.GetHashCode();
      if (HasIsException) hash ^= IsException.GetHashCode();
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
      if (HasTsSec) {
        output.WriteRawTag(8);
        output.WriteInt64(TsSec);
      }
      if (HasTsNsec) {
        output.WriteRawTag(16);
        output.WriteInt64(TsNsec);
      }
      if (HasLogLevel) {
        output.WriteRawTag(24);
        output.WriteEnum((int) LogLevel);
      }
      if (HasComponent) {
        output.WriteRawTag(34);
        output.WriteString(Component);
      }
      if (HasMessage) {
        output.WriteRawTag(42);
        output.WriteString(Message);
      }
      if (HasIsException) {
        output.WriteRawTag(48);
        output.WriteBool(IsException);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HasTsSec) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(TsSec);
      }
      if (HasTsNsec) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(TsNsec);
      }
      if (HasLogLevel) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) LogLevel);
      }
      if (HasComponent) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Component);
      }
      if (HasMessage) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (HasIsException) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LogMessage other) {
      if (other == null) {
        return;
      }
      if (other.HasTsSec) {
        TsSec = other.TsSec;
      }
      if (other.HasTsNsec) {
        TsNsec = other.TsNsec;
      }
      if (other.HasLogLevel) {
        LogLevel = other.LogLevel;
      }
      if (other.HasComponent) {
        Component = other.Component;
      }
      if (other.HasMessage) {
        Message = other.Message;
      }
      if (other.HasIsException) {
        IsException = other.IsException;
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
            TsSec = input.ReadInt64();
            break;
          }
          case 16: {
            TsNsec = input.ReadInt64();
            break;
          }
          case 24: {
            LogLevel = (global::LlsfLogMsgs.LogMessage.Types.LogLevel) input.ReadEnum();
            break;
          }
          case 34: {
            Component = input.ReadString();
            break;
          }
          case 42: {
            Message = input.ReadString();
            break;
          }
          case 48: {
            IsException = input.ReadBool();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the LogMessage message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum CompType {
        [pbr::OriginalName("COMP_ID")] CompId = 2003,
        [pbr::OriginalName("MSG_TYPE")] MsgType = 1,
      }

      public enum LogLevel {
        [pbr::OriginalName("LL_DEBUG")] LlDebug = 0,
        [pbr::OriginalName("LL_INFO")] LlInfo = 1,
        [pbr::OriginalName("LL_WARN")] LlWarn = 2,
        [pbr::OriginalName("LL_ERROR")] LlError = 4,
        [pbr::OriginalName("LL_NONE")] LlNone = 8,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
