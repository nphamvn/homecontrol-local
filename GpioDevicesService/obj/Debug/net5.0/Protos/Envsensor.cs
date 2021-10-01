// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/envsensor.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GpioDevicesService {

  /// <summary>Holder for reflection information generated from Protos/envsensor.proto</summary>
  public static partial class EnvsensorReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/envsensor.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static EnvsensorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZQcm90b3MvZW52c2Vuc29yLnByb3RvEgVncmVldBobZ29vZ2xlL3Byb3Rv",
            "YnVmL2VtcHR5LnByb3RvIkMKC1NlbnNvclJlcGx5EhMKC3RlbXBlcmF0dXJl",
            "GAEgASgBEhEKCWh1bWluZGl0eRgCIAEoARIMCgR0aW1lGAMgASgJMlAKEUVu",
            "dmlyb25tZW50U2Vuc29yEjsKDUdldFNlbnNvckRhdGESFi5nb29nbGUucHJv",
            "dG9idWYuRW1wdHkaEi5ncmVldC5TZW5zb3JSZXBseUIVqgISR3Bpb0Rldmlj",
            "ZXNTZXJ2aWNlYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GpioDevicesService.SensorReply), global::GpioDevicesService.SensorReply.Parser, new[]{ "Temperature", "Humindity", "Time" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The response message containing the brightness.
  /// </summary>
  public sealed partial class SensorReply : pb::IMessage<SensorReply>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SensorReply> _parser = new pb::MessageParser<SensorReply>(() => new SensorReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SensorReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GpioDevicesService.EnvsensorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SensorReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SensorReply(SensorReply other) : this() {
      temperature_ = other.temperature_;
      humindity_ = other.humindity_;
      time_ = other.time_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SensorReply Clone() {
      return new SensorReply(this);
    }

    /// <summary>Field number for the "temperature" field.</summary>
    public const int TemperatureFieldNumber = 1;
    private double temperature_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Temperature {
      get { return temperature_; }
      set {
        temperature_ = value;
      }
    }

    /// <summary>Field number for the "humindity" field.</summary>
    public const int HumindityFieldNumber = 2;
    private double humindity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Humindity {
      get { return humindity_; }
      set {
        humindity_ = value;
      }
    }

    /// <summary>Field number for the "time" field.</summary>
    public const int TimeFieldNumber = 3;
    private string time_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Time {
      get { return time_; }
      set {
        time_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SensorReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SensorReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Temperature, other.Temperature)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Humindity, other.Humindity)) return false;
      if (Time != other.Time) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Temperature != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Temperature);
      if (Humindity != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Humindity);
      if (Time.Length != 0) hash ^= Time.GetHashCode();
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
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Temperature != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Temperature);
      }
      if (Humindity != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Humindity);
      }
      if (Time.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Time);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Temperature != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Temperature);
      }
      if (Humindity != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Humindity);
      }
      if (Time.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Time);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Temperature != 0D) {
        size += 1 + 8;
      }
      if (Humindity != 0D) {
        size += 1 + 8;
      }
      if (Time.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Time);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SensorReply other) {
      if (other == null) {
        return;
      }
      if (other.Temperature != 0D) {
        Temperature = other.Temperature;
      }
      if (other.Humindity != 0D) {
        Humindity = other.Humindity;
      }
      if (other.Time.Length != 0) {
        Time = other.Time;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
          case 9: {
            Temperature = input.ReadDouble();
            break;
          }
          case 17: {
            Humindity = input.ReadDouble();
            break;
          }
          case 26: {
            Time = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 9: {
            Temperature = input.ReadDouble();
            break;
          }
          case 17: {
            Humindity = input.ReadDouble();
            break;
          }
          case 26: {
            Time = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code