using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// Wrapper message for `string`.
    ///
    /// The JSON representation for `StringValue` is JSON string.
    /// </summary>
    public sealed partial class StringValue : IMessage<StringValue> {
        private static readonly MessageParser<StringValue> _parser = new MessageParser<StringValue>(() => new StringValue());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<StringValue> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor.MessageTypes[7]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StringValue() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StringValue(StringValue other) : this() {
            value_ = other.value_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StringValue Clone() {
            return new StringValue(this);
        }

        /// <summary>Field number for the "value" field.</summary>
        public const int ValueFieldNumber = 1;
        private string value_ = "";
        /// <summary>
        /// The string value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Value {
            get { return value_; }
            set {
                value_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as StringValue);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(StringValue other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Value != other.Value) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Value.Length != 0) hash ^= Value.GetHashCode();
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
            if (Value.Length != 0) {
                output.WriteRawTag(10);
                output.WriteString(Value);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (Value.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Value);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(StringValue other) {
            if (other == null) {
                return;
            }
            if (other.Value.Length != 0) {
                Value = other.Value;
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
                        Value = input.ReadString();
                        break;
                    }
                }
            }
        }

    }
}