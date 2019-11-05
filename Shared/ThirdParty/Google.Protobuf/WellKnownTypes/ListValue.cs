using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// `ListValue` is a wrapper around a repeated field of values.
    ///
    /// The JSON representation for `ListValue` is JSON array.
    /// </summary>
    public sealed partial class ListValue : IMessage<ListValue> {
        private static readonly MessageParser<ListValue> _parser = new MessageParser<ListValue>(() => new ListValue());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<ListValue> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.StructReflection.Descriptor.MessageTypes[2]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ListValue() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ListValue(ListValue other) : this() {
            values_ = other.values_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ListValue Clone() {
            return new ListValue(this);
        }

        /// <summary>Field number for the "values" field.</summary>
        public const int ValuesFieldNumber = 1;
        private static readonly FieldCodec<global::Google.Protobuf.WellKnownTypes.Value> _repeated_values_codec
            = FieldCodec.ForMessage(10, global::Google.Protobuf.WellKnownTypes.Value.Parser);
        private readonly RepeatedField<global::Google.Protobuf.WellKnownTypes.Value> values_ = new RepeatedField<global::Google.Protobuf.WellKnownTypes.Value>();
        /// <summary>
        /// Repeated field of dynamically typed values.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.WellKnownTypes.Value> Values {
            get { return values_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as ListValue);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ListValue other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if(!values_.Equals(other.values_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            hash ^= values_.GetHashCode();
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
            values_.WriteTo(output, _repeated_values_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            size += values_.CalculateSize(_repeated_values_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ListValue other) {
            if (other == null) {
                return;
            }
            values_.Add(other.values_);
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
                        values_.AddEntriesFrom(input, _repeated_values_codec);
                        break;
                    }
                }
            }
        }

    }
}