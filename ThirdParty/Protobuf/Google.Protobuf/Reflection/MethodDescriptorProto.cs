namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes a method of a service.
    /// </summary>
    internal sealed partial class MethodDescriptorProto : IMessage<MethodDescriptorProto> {
        private static readonly MessageParser<MethodDescriptorProto> _parser = new MessageParser<MethodDescriptorProto>(() => new MethodDescriptorProto());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<MethodDescriptorProto> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[9]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MethodDescriptorProto() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MethodDescriptorProto(MethodDescriptorProto other) : this() {
            name_ = other.name_;
            inputType_ = other.inputType_;
            outputType_ = other.outputType_;
            options_ = other.options_ != null ? other.options_.Clone() : null;
            clientStreaming_ = other.clientStreaming_;
            serverStreaming_ = other.serverStreaming_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MethodDescriptorProto Clone() {
            return new MethodDescriptorProto(this);
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

        /// <summary>Field number for the "input_type" field.</summary>
        public const int InputTypeFieldNumber = 2;
        private string inputType_ = "";
        /// <summary>
        /// Input and output type names.  These are resolved in the same way as
        /// FieldDescriptorProto.type_name, but must refer to a message type.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string InputType {
            get { return inputType_; }
            set {
                inputType_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "output_type" field.</summary>
        public const int OutputTypeFieldNumber = 3;
        private string outputType_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string OutputType {
            get { return outputType_; }
            set {
                outputType_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 4;
        private global::Google.Protobuf.Reflection.MethodOptions options_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.MethodOptions Options {
            get { return options_; }
            set {
                options_ = value;
            }
        }

        /// <summary>Field number for the "client_streaming" field.</summary>
        public const int ClientStreamingFieldNumber = 5;
        private bool clientStreaming_;
        /// <summary>
        /// Identifies if client streams multiple client messages
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool ClientStreaming {
            get { return clientStreaming_; }
            set {
                clientStreaming_ = value;
            }
        }

        /// <summary>Field number for the "server_streaming" field.</summary>
        public const int ServerStreamingFieldNumber = 6;
        private bool serverStreaming_;
        /// <summary>
        /// Identifies if server streams multiple server messages
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool ServerStreaming {
            get { return serverStreaming_; }
            set {
                serverStreaming_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as MethodDescriptorProto);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(MethodDescriptorProto other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if (InputType != other.InputType) return false;
            if (OutputType != other.OutputType) return false;
            if (!object.Equals(Options, other.Options)) return false;
            if (ClientStreaming != other.ClientStreaming) return false;
            if (ServerStreaming != other.ServerStreaming) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (InputType.Length != 0) hash ^= InputType.GetHashCode();
            if (OutputType.Length != 0) hash ^= OutputType.GetHashCode();
            if (options_ != null) hash ^= Options.GetHashCode();
            if (ClientStreaming != false) hash ^= ClientStreaming.GetHashCode();
            if (ServerStreaming != false) hash ^= ServerStreaming.GetHashCode();
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
            if (InputType.Length != 0) {
                output.WriteRawTag(18);
                output.WriteString(InputType);
            }
            if (OutputType.Length != 0) {
                output.WriteRawTag(26);
                output.WriteString(OutputType);
            }
            if (options_ != null) {
                output.WriteRawTag(34);
                output.WriteMessage(Options);
            }
            if (ClientStreaming != false) {
                output.WriteRawTag(40);
                output.WriteBool(ClientStreaming);
            }
            if (ServerStreaming != false) {
                output.WriteRawTag(48);
                output.WriteBool(ServerStreaming);
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
            if (InputType.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(InputType);
            }
            if (OutputType.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(OutputType);
            }
            if (options_ != null) {
                size += 1 + CodedOutputStream.ComputeMessageSize(Options);
            }
            if (ClientStreaming != false) {
                size += 1 + 1;
            }
            if (ServerStreaming != false) {
                size += 1 + 1;
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(MethodDescriptorProto other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.InputType.Length != 0) {
                InputType = other.InputType;
            }
            if (other.OutputType.Length != 0) {
                OutputType = other.OutputType;
            }
            if (other.options_ != null) {
                if (options_ == null) {
                    options_ = new global::Google.Protobuf.Reflection.MethodOptions();
                }
                Options.MergeFrom(other.Options);
            }
            if (other.ClientStreaming != false) {
                ClientStreaming = other.ClientStreaming;
            }
            if (other.ServerStreaming != false) {
                ServerStreaming = other.ServerStreaming;
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
                        InputType = input.ReadString();
                        break;
                    }
                    case 26: {
                        OutputType = input.ReadString();
                        break;
                    }
                    case 34: {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.MethodOptions();
                        }
                        input.ReadMessage(options_);
                        break;
                    }
                    case 40: {
                        ClientStreaming = input.ReadBool();
                        break;
                    }
                    case 48: {
                        ServerStreaming = input.ReadBool();
                        break;
                    }
                }
            }
        }

    }
}