namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes a value within an enum.
    /// </summary>
    internal sealed partial class EnumValueDescriptorProto : IMessage<EnumValueDescriptorProto> {
        private static readonly MessageParser<EnumValueDescriptorProto> _parser = new MessageParser<EnumValueDescriptorProto>(() => new EnumValueDescriptorProto());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<EnumValueDescriptorProto> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[7]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumValueDescriptorProto() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumValueDescriptorProto(EnumValueDescriptorProto other) : this() {
            name_ = other.name_;
            number_ = other.number_;
            options_ = other.options_ != null ? other.options_.Clone() : null;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumValueDescriptorProto Clone() {
            return new EnumValueDescriptorProto(this);
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

        /// <summary>Field number for the "number" field.</summary>
        public const int NumberFieldNumber = 2;
        private int number_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Number {
            get { return number_; }
            set {
                number_ = value;
            }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 3;
        private global::Google.Protobuf.Reflection.EnumValueOptions options_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.EnumValueOptions Options {
            get { return options_; }
            set {
                options_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as EnumValueDescriptorProto);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(EnumValueDescriptorProto other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if (Number != other.Number) return false;
            if (!object.Equals(Options, other.Options)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (Number != 0) hash ^= Number.GetHashCode();
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
            if (Number != 0) {
                output.WriteRawTag(16);
                output.WriteInt32(Number);
            }
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
            if (Number != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(Number);
            }
            if (options_ != null) {
                size += 1 + CodedOutputStream.ComputeMessageSize(Options);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(EnumValueDescriptorProto other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.Number != 0) {
                Number = other.Number;
            }
            if (other.options_ != null) {
                if (options_ == null) {
                    options_ = new global::Google.Protobuf.Reflection.EnumValueOptions();
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
                    case 16: {
                        Number = input.ReadInt32();
                        break;
                    }
                    case 26: {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.EnumValueOptions();
                        }
                        input.ReadMessage(options_);
                        break;
                    }
                }
            }
        }

    }
}