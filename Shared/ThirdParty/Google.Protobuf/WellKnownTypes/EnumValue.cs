using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// Enum value definition.
    /// </summary>
    public sealed partial class EnumValue : IMessage<EnumValue> {
        private static readonly MessageParser<EnumValue> _parser = new MessageParser<EnumValue>(() => new EnumValue());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<EnumValue> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.TypeReflection.Descriptor.MessageTypes[3]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumValue() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumValue(EnumValue other) : this() {
            name_ = other.name_;
            number_ = other.number_;
            options_ = other.options_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumValue Clone() {
            return new EnumValue(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;
        private string name_ = "";
        /// <summary>
        /// Enum value name.
        /// </summary>
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
        /// <summary>
        /// Enum value number.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Number {
            get { return number_; }
            set {
                number_ = value;
            }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 3;
        private static readonly FieldCodec<global::Google.Protobuf.WellKnownTypes.Option> _repeated_options_codec
            = FieldCodec.ForMessage(26, global::Google.Protobuf.WellKnownTypes.Option.Parser);
        private readonly RepeatedField<global::Google.Protobuf.WellKnownTypes.Option> options_ = new RepeatedField<global::Google.Protobuf.WellKnownTypes.Option>();
        /// <summary>
        /// Protocol buffer options.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.WellKnownTypes.Option> Options {
            get { return options_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as EnumValue);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(EnumValue other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if (Number != other.Number) return false;
            if(!options_.Equals(other.options_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (Number != 0) hash ^= Number.GetHashCode();
            hash ^= options_.GetHashCode();
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
            options_.WriteTo(output, _repeated_options_codec);
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
            size += options_.CalculateSize(_repeated_options_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(EnumValue other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.Number != 0) {
                Number = other.Number;
            }
            options_.Add(other.options_);
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
                        options_.AddEntriesFrom(input, _repeated_options_codec);
                        break;
                    }
                }
            }
        }

    }
}