using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// `Value` represents a dynamically typed value which can be either
    /// null, a number, a string, a boolean, a recursive struct value, or a
    /// list of values. A producer of value is expected to set one of that
    /// variants, absence of any variant indicates an error.
    ///
    /// The JSON representation for `Value` is JSON value.
    /// </summary>
    public sealed partial class Value : IMessage<Value> {
        private static readonly MessageParser<Value> _parser = new MessageParser<Value>(() => new Value());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<Value> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.StructReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Value() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Value(Value other) : this() {
            switch (other.KindCase) {
                case KindOneofCase.NullValue:
                    NullValue = other.NullValue;
                    break;
                case KindOneofCase.NumberValue:
                    NumberValue = other.NumberValue;
                    break;
                case KindOneofCase.StringValue:
                    StringValue = other.StringValue;
                    break;
                case KindOneofCase.BoolValue:
                    BoolValue = other.BoolValue;
                    break;
                case KindOneofCase.StructValue:
                    StructValue = other.StructValue.Clone();
                    break;
                case KindOneofCase.ListValue:
                    ListValue = other.ListValue.Clone();
                    break;
            }

            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Value Clone() {
            return new Value(this);
        }

        /// <summary>Field number for the "null_value" field.</summary>
        public const int NullValueFieldNumber = 1;
        /// <summary>
        /// Represents a null value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.NullValue NullValue {
            get { return kindCase_ == KindOneofCase.NullValue ? (global::Google.Protobuf.WellKnownTypes.NullValue) kind_ : 0; }
            set {
                kind_ = value;
                kindCase_ = KindOneofCase.NullValue;
            }
        }

        /// <summary>Field number for the "number_value" field.</summary>
        public const int NumberValueFieldNumber = 2;
        /// <summary>
        /// Represents a double value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public double NumberValue {
            get { return kindCase_ == KindOneofCase.NumberValue ? (double) kind_ : 0D; }
            set {
                kind_ = value;
                kindCase_ = KindOneofCase.NumberValue;
            }
        }

        /// <summary>Field number for the "string_value" field.</summary>
        public const int StringValueFieldNumber = 3;
        /// <summary>
        /// Represents a string value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string StringValue {
            get { return kindCase_ == KindOneofCase.StringValue ? (string) kind_ : ""; }
            set {
                kind_ = ProtoPreconditions.CheckNotNull(value, "value");
                kindCase_ = KindOneofCase.StringValue;
            }
        }

        /// <summary>Field number for the "bool_value" field.</summary>
        public const int BoolValueFieldNumber = 4;
        /// <summary>
        /// Represents a boolean value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool BoolValue {
            get { return kindCase_ == KindOneofCase.BoolValue ? (bool) kind_ : false; }
            set {
                kind_ = value;
                kindCase_ = KindOneofCase.BoolValue;
            }
        }

        /// <summary>Field number for the "struct_value" field.</summary>
        public const int StructValueFieldNumber = 5;
        /// <summary>
        /// Represents a structured value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Struct StructValue {
            get { return kindCase_ == KindOneofCase.StructValue ? (global::Google.Protobuf.WellKnownTypes.Struct) kind_ : null; }
            set {
                kind_ = value;
                kindCase_ = value == null ? KindOneofCase.None : KindOneofCase.StructValue;
            }
        }

        /// <summary>Field number for the "list_value" field.</summary>
        public const int ListValueFieldNumber = 6;
        /// <summary>
        /// Represents a repeated `Value`.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.ListValue ListValue {
            get { return kindCase_ == KindOneofCase.ListValue ? (global::Google.Protobuf.WellKnownTypes.ListValue) kind_ : null; }
            set {
                kind_ = value;
                kindCase_ = value == null ? KindOneofCase.None : KindOneofCase.ListValue;
            }
        }

        private object kind_;
        /// <summary>Enum of possible cases for the "kind" oneof.</summary>
        public enum KindOneofCase {
            None = 0,
            NullValue = 1,
            NumberValue = 2,
            StringValue = 3,
            BoolValue = 4,
            StructValue = 5,
            ListValue = 6,
        }
        private KindOneofCase kindCase_ = KindOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public KindOneofCase KindCase {
            get { return kindCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearKind() {
            kindCase_ = KindOneofCase.None;
            kind_ = null;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as Value);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Value other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (NullValue != other.NullValue) return false;
            if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(NumberValue, other.NumberValue)) return false;
            if (StringValue != other.StringValue) return false;
            if (BoolValue != other.BoolValue) return false;
            if (!object.Equals(StructValue, other.StructValue)) return false;
            if (!object.Equals(ListValue, other.ListValue)) return false;
            if (KindCase != other.KindCase) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (kindCase_ == KindOneofCase.NullValue) hash ^= NullValue.GetHashCode();
            if (kindCase_ == KindOneofCase.NumberValue) hash ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(NumberValue);
            if (kindCase_ == KindOneofCase.StringValue) hash ^= StringValue.GetHashCode();
            if (kindCase_ == KindOneofCase.BoolValue) hash ^= BoolValue.GetHashCode();
            if (kindCase_ == KindOneofCase.StructValue) hash ^= StructValue.GetHashCode();
            if (kindCase_ == KindOneofCase.ListValue) hash ^= ListValue.GetHashCode();
            hash ^= (int) kindCase_;
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
            if (kindCase_ == KindOneofCase.NullValue) {
                output.WriteRawTag(8);
                output.WriteEnum((int) NullValue);
            }
            if (kindCase_ == KindOneofCase.NumberValue) {
                output.WriteRawTag(17);
                output.WriteDouble(NumberValue);
            }
            if (kindCase_ == KindOneofCase.StringValue) {
                output.WriteRawTag(26);
                output.WriteString(StringValue);
            }
            if (kindCase_ == KindOneofCase.BoolValue) {
                output.WriteRawTag(32);
                output.WriteBool(BoolValue);
            }
            if (kindCase_ == KindOneofCase.StructValue) {
                output.WriteRawTag(42);
                output.WriteMessage(StructValue);
            }
            if (kindCase_ == KindOneofCase.ListValue) {
                output.WriteRawTag(50);
                output.WriteMessage(ListValue);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (kindCase_ == KindOneofCase.NullValue) {
                size += 1 + CodedOutputStream.ComputeEnumSize((int) NullValue);
            }
            if (kindCase_ == KindOneofCase.NumberValue) {
                size += 1 + 8;
            }
            if (kindCase_ == KindOneofCase.StringValue) {
                size += 1 + CodedOutputStream.ComputeStringSize(StringValue);
            }
            if (kindCase_ == KindOneofCase.BoolValue) {
                size += 1 + 1;
            }
            if (kindCase_ == KindOneofCase.StructValue) {
                size += 1 + CodedOutputStream.ComputeMessageSize(StructValue);
            }
            if (kindCase_ == KindOneofCase.ListValue) {
                size += 1 + CodedOutputStream.ComputeMessageSize(ListValue);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Value other) {
            if (other == null) {
                return;
            }
            switch (other.KindCase) {
                case KindOneofCase.NullValue:
                    NullValue = other.NullValue;
                    break;
                case KindOneofCase.NumberValue:
                    NumberValue = other.NumberValue;
                    break;
                case KindOneofCase.StringValue:
                    StringValue = other.StringValue;
                    break;
                case KindOneofCase.BoolValue:
                    BoolValue = other.BoolValue;
                    break;
                case KindOneofCase.StructValue:
                    if (StructValue == null) {
                        StructValue = new global::Google.Protobuf.WellKnownTypes.Struct();
                    }
                    StructValue.MergeFrom(other.StructValue);
                    break;
                case KindOneofCase.ListValue:
                    if (ListValue == null) {
                        ListValue = new global::Google.Protobuf.WellKnownTypes.ListValue();
                    }
                    ListValue.MergeFrom(other.ListValue);
                    break;
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
                    case 8: {
                        kind_ = input.ReadEnum();
                        kindCase_ = KindOneofCase.NullValue;
                        break;
                    }
                    case 17: {
                        NumberValue = input.ReadDouble();
                        break;
                    }
                    case 26: {
                        StringValue = input.ReadString();
                        break;
                    }
                    case 32: {
                        BoolValue = input.ReadBool();
                        break;
                    }
                    case 42: {
                        global::Google.Protobuf.WellKnownTypes.Struct subBuilder = new global::Google.Protobuf.WellKnownTypes.Struct();
                        if (kindCase_ == KindOneofCase.StructValue) {
                            subBuilder.MergeFrom(StructValue);
                        }
                        input.ReadMessage(subBuilder);
                        StructValue = subBuilder;
                        break;
                    }
                    case 50: {
                        global::Google.Protobuf.WellKnownTypes.ListValue subBuilder = new global::Google.Protobuf.WellKnownTypes.ListValue();
                        if (kindCase_ == KindOneofCase.ListValue) {
                            subBuilder.MergeFrom(ListValue);
                        }
                        input.ReadMessage(subBuilder);
                        ListValue = subBuilder;
                        break;
                    }
                }
            }
        }

    }
}