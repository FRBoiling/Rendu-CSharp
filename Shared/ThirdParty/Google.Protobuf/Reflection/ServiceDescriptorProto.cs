using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes a service.
    /// </summary>
    internal sealed partial class ServiceDescriptorProto : IMessage<ServiceDescriptorProto> {
        private static readonly MessageParser<ServiceDescriptorProto> _parser = new MessageParser<ServiceDescriptorProto>(() => new ServiceDescriptorProto());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<ServiceDescriptorProto> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[8]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ServiceDescriptorProto() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ServiceDescriptorProto(ServiceDescriptorProto other) : this() {
            name_ = other.name_;
            method_ = other.method_.Clone();
            options_ = other.options_ != null ? other.options_.Clone() : null;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ServiceDescriptorProto Clone() {
            return new ServiceDescriptorProto(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;
        private string name_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name {
            get { return name_; }
            set {
                name_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "method" field.</summary>
        public const int MethodFieldNumber = 2;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.MethodDescriptorProto> _repeated_method_codec
            = FieldCodec.ForMessage(18, global::Google.Protobuf.Reflection.MethodDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.MethodDescriptorProto> method_ = new RepeatedField<global::Google.Protobuf.Reflection.MethodDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.MethodDescriptorProto> Method {
            get { return method_; }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 3;
        private global::Google.Protobuf.Reflection.ServiceOptions options_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.ServiceOptions Options {
            get { return options_; }
            set {
                options_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as ServiceDescriptorProto);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ServiceDescriptorProto other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if(!method_.Equals(other.method_)) return false;
            if (!object.Equals(Options, other.Options)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            hash ^= method_.GetHashCode();
            if (options_ != null) hash ^= Options.GetHashCode();
            if (_unknownFields != null) {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
            return JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(CodedOutputStream output) {
            if (Name.Length != 0) {
                output.WriteRawTag(10);
                output.WriteString(Name);
            }
            method_.WriteTo(output, _repeated_method_codec);
            if (options_ != null) {
                output.WriteRawTag(26);
                output.WriteMessage(Options);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (Name.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Name);
            }
            size += method_.CalculateSize(_repeated_method_codec);
            if (options_ != null) {
                size += 1 + CodedOutputStream.ComputeMessageSize(Options);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ServiceDescriptorProto other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            method_.Add(other.method_);
            if (other.options_ != null) {
                if (options_ == null) {
                    options_ = new global::Google.Protobuf.Reflection.ServiceOptions();
                }
                Options.MergeFrom(other.Options);
            }
            _unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(CodedInputStream input) {
            uint tag;
            while ((tag = input.ReadTag()) != 0) {
                switch(tag) {
                    default:
                        _unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 10: {
                        Name = input.ReadString();
                        break;
                    }
                    case 18: {
                        method_.AddEntriesFrom(input, _repeated_method_codec);
                        break;
                    }
                    case 26: {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.ServiceOptions();
                        }
                        input.ReadMessage(options_);
                        break;
                    }
                }
            }
        }

    }
}