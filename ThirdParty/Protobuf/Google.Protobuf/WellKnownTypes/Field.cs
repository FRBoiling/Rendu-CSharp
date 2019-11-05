using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// A single field of a message type.
    /// </summary>
    public sealed partial class Field : IMessage<Field> {
        private static readonly MessageParser<Field> _parser = new MessageParser<Field>(() => new Field());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<Field> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.TypeReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Field() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Field(Field other) : this() {
            kind_ = other.kind_;
            cardinality_ = other.cardinality_;
            number_ = other.number_;
            name_ = other.name_;
            typeUrl_ = other.typeUrl_;
            oneofIndex_ = other.oneofIndex_;
            packed_ = other.packed_;
            options_ = other.options_.Clone();
            jsonName_ = other.jsonName_;
            defaultValue_ = other.defaultValue_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Field Clone() {
            return new Field(this);
        }

        /// <summary>Field number for the "kind" field.</summary>
        public const int KindFieldNumber = 1;
        private global::Google.Protobuf.WellKnownTypes.Field.Types.Kind kind_ = 0;
        /// <summary>
        /// The field type.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Field.Types.Kind Kind {
            get { return kind_; }
            set {
                kind_ = value;
            }
        }

        /// <summary>Field number for the "cardinality" field.</summary>
        public const int CardinalityFieldNumber = 2;
        private global::Google.Protobuf.WellKnownTypes.Field.Types.Cardinality cardinality_ = 0;
        /// <summary>
        /// The field cardinality.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Field.Types.Cardinality Cardinality {
            get { return cardinality_; }
            set {
                cardinality_ = value;
            }
        }

        /// <summary>Field number for the "number" field.</summary>
        public const int NumberFieldNumber = 3;
        private int number_;
        /// <summary>
        /// The field number.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Number {
            get { return number_; }
            set {
                number_ = value;
            }
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 4;
        private string name_ = "";
        /// <summary>
        /// The field name.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name {
            get { return name_; }
            set {
                name_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "type_url" field.</summary>
        public const int TypeUrlFieldNumber = 6;
        private string typeUrl_ = "";
        /// <summary>
        /// The field type URL, without the scheme, for message or enumeration
        /// types. Example: `"type.googleapis.com/google.protobuf.Timestamp"`.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string TypeUrl {
            get { return typeUrl_; }
            set {
                typeUrl_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "oneof_index" field.</summary>
        public const int OneofIndexFieldNumber = 7;
        private int oneofIndex_;
        /// <summary>
        /// The index of the field type in `Type.oneofs`, for message or enumeration
        /// types. The first type has index 1; zero means the type is not in the list.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int OneofIndex {
            get { return oneofIndex_; }
            set {
                oneofIndex_ = value;
            }
        }

        /// <summary>Field number for the "packed" field.</summary>
        public const int PackedFieldNumber = 8;
        private bool packed_;
        /// <summary>
        /// Whether to use alternative packed wire representation.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Packed {
            get { return packed_; }
            set {
                packed_ = value;
            }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 9;
        private static readonly FieldCodec<global::Google.Protobuf.WellKnownTypes.Option> _repeated_options_codec
            = FieldCodec.ForMessage(74, global::Google.Protobuf.WellKnownTypes.Option.Parser);
        private readonly RepeatedField<global::Google.Protobuf.WellKnownTypes.Option> options_ = new RepeatedField<global::Google.Protobuf.WellKnownTypes.Option>();
        /// <summary>
        /// The protocol buffer options.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.WellKnownTypes.Option> Options {
            get { return options_; }
        }

        /// <summary>Field number for the "json_name" field.</summary>
        public const int JsonNameFieldNumber = 10;
        private string jsonName_ = "";
        /// <summary>
        /// The field JSON name.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string JsonName {
            get { return jsonName_; }
            set {
                jsonName_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "default_value" field.</summary>
        public const int DefaultValueFieldNumber = 11;
        private string defaultValue_ = "";
        /// <summary>
        /// The string value of the default value of this field. Proto2 syntax only.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string DefaultValue {
            get { return defaultValue_; }
            set {
                defaultValue_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as Field);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Field other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Kind != other.Kind) return false;
            if (Cardinality != other.Cardinality) return false;
            if (Number != other.Number) return false;
            if (Name != other.Name) return false;
            if (TypeUrl != other.TypeUrl) return false;
            if (OneofIndex != other.OneofIndex) return false;
            if (Packed != other.Packed) return false;
            if(!options_.Equals(other.options_)) return false;
            if (JsonName != other.JsonName) return false;
            if (DefaultValue != other.DefaultValue) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Kind != 0) hash ^= Kind.GetHashCode();
            if (Cardinality != 0) hash ^= Cardinality.GetHashCode();
            if (Number != 0) hash ^= Number.GetHashCode();
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (TypeUrl.Length != 0) hash ^= TypeUrl.GetHashCode();
            if (OneofIndex != 0) hash ^= OneofIndex.GetHashCode();
            if (Packed != false) hash ^= Packed.GetHashCode();
            hash ^= options_.GetHashCode();
            if (JsonName.Length != 0) hash ^= JsonName.GetHashCode();
            if (DefaultValue.Length != 0) hash ^= DefaultValue.GetHashCode();
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
            if (Kind != 0) {
                output.WriteRawTag(8);
                output.WriteEnum((int) Kind);
            }
            if (Cardinality != 0) {
                output.WriteRawTag(16);
                output.WriteEnum((int) Cardinality);
            }
            if (Number != 0) {
                output.WriteRawTag(24);
                output.WriteInt32(Number);
            }
            if (Name.Length != 0) {
                output.WriteRawTag(34);
                output.WriteString(Name);
            }
            if (TypeUrl.Length != 0) {
                output.WriteRawTag(50);
                output.WriteString(TypeUrl);
            }
            if (OneofIndex != 0) {
                output.WriteRawTag(56);
                output.WriteInt32(OneofIndex);
            }
            if (Packed != false) {
                output.WriteRawTag(64);
                output.WriteBool(Packed);
            }
            options_.WriteTo(output, _repeated_options_codec);
            if (JsonName.Length != 0) {
                output.WriteRawTag(82);
                output.WriteString(JsonName);
            }
            if (DefaultValue.Length != 0) {
                output.WriteRawTag(90);
                output.WriteString(DefaultValue);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (Kind != 0) {
                size += 1 + CodedOutputStream.ComputeEnumSize((int) Kind);
            }
            if (Cardinality != 0) {
                size += 1 + CodedOutputStream.ComputeEnumSize((int) Cardinality);
            }
            if (Number != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(Number);
            }
            if (Name.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Name);
            }
            if (TypeUrl.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(TypeUrl);
            }
            if (OneofIndex != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(OneofIndex);
            }
            if (Packed != false) {
                size += 1 + 1;
            }
            size += options_.CalculateSize(_repeated_options_codec);
            if (JsonName.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(JsonName);
            }
            if (DefaultValue.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(DefaultValue);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Field other) {
            if (other == null) {
                return;
            }
            if (other.Kind != 0) {
                Kind = other.Kind;
            }
            if (other.Cardinality != 0) {
                Cardinality = other.Cardinality;
            }
            if (other.Number != 0) {
                Number = other.Number;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.TypeUrl.Length != 0) {
                TypeUrl = other.TypeUrl;
            }
            if (other.OneofIndex != 0) {
                OneofIndex = other.OneofIndex;
            }
            if (other.Packed != false) {
                Packed = other.Packed;
            }
            options_.Add(other.options_);
            if (other.JsonName.Length != 0) {
                JsonName = other.JsonName;
            }
            if (other.DefaultValue.Length != 0) {
                DefaultValue = other.DefaultValue;
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
                        kind_ = (global::Google.Protobuf.WellKnownTypes.Field.Types.Kind) input.ReadEnum();
                        break;
                    }
                    case 16: {
                        cardinality_ = (global::Google.Protobuf.WellKnownTypes.Field.Types.Cardinality) input.ReadEnum();
                        break;
                    }
                    case 24: {
                        Number = input.ReadInt32();
                        break;
                    }
                    case 34: {
                        Name = input.ReadString();
                        break;
                    }
                    case 50: {
                        TypeUrl = input.ReadString();
                        break;
                    }
                    case 56: {
                        OneofIndex = input.ReadInt32();
                        break;
                    }
                    case 64: {
                        Packed = input.ReadBool();
                        break;
                    }
                    case 74: {
                        options_.AddEntriesFrom(input, _repeated_options_codec);
                        break;
                    }
                    case 82: {
                        JsonName = input.ReadString();
                        break;
                    }
                    case 90: {
                        DefaultValue = input.ReadString();
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the Field message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            /// <summary>
            /// Basic field types.
            /// </summary>
            public enum Kind {
                /// <summary>
                /// Field type unknown.
                /// </summary>
                [OriginalName("TYPE_UNKNOWN")] TypeUnknown = 0,
                /// <summary>
                /// Field type double.
                /// </summary>
                [OriginalName("TYPE_DOUBLE")] TypeDouble = 1,
                /// <summary>
                /// Field type float.
                /// </summary>
                [OriginalName("TYPE_FLOAT")] TypeFloat = 2,
                /// <summary>
                /// Field type int64.
                /// </summary>
                [OriginalName("TYPE_INT64")] TypeInt64 = 3,
                /// <summary>
                /// Field type uint64.
                /// </summary>
                [OriginalName("TYPE_UINT64")] TypeUint64 = 4,
                /// <summary>
                /// Field type int32.
                /// </summary>
                [OriginalName("TYPE_INT32")] TypeInt32 = 5,
                /// <summary>
                /// Field type fixed64.
                /// </summary>
                [OriginalName("TYPE_FIXED64")] TypeFixed64 = 6,
                /// <summary>
                /// Field type fixed32.
                /// </summary>
                [OriginalName("TYPE_FIXED32")] TypeFixed32 = 7,
                /// <summary>
                /// Field type bool.
                /// </summary>
                [OriginalName("TYPE_BOOL")] TypeBool = 8,
                /// <summary>
                /// Field type string.
                /// </summary>
                [OriginalName("TYPE_STRING")] TypeString = 9,
                /// <summary>
                /// Field type group. Proto2 syntax only, and deprecated.
                /// </summary>
                [OriginalName("TYPE_GROUP")] TypeGroup = 10,
                /// <summary>
                /// Field type message.
                /// </summary>
                [OriginalName("TYPE_MESSAGE")] TypeMessage = 11,
                /// <summary>
                /// Field type bytes.
                /// </summary>
                [OriginalName("TYPE_BYTES")] TypeBytes = 12,
                /// <summary>
                /// Field type uint32.
                /// </summary>
                [OriginalName("TYPE_UINT32")] TypeUint32 = 13,
                /// <summary>
                /// Field type enum.
                /// </summary>
                [OriginalName("TYPE_ENUM")] TypeEnum = 14,
                /// <summary>
                /// Field type sfixed32.
                /// </summary>
                [OriginalName("TYPE_SFIXED32")] TypeSfixed32 = 15,
                /// <summary>
                /// Field type sfixed64.
                /// </summary>
                [OriginalName("TYPE_SFIXED64")] TypeSfixed64 = 16,
                /// <summary>
                /// Field type sint32.
                /// </summary>
                [OriginalName("TYPE_SINT32")] TypeSint32 = 17,
                /// <summary>
                /// Field type sint64.
                /// </summary>
                [OriginalName("TYPE_SINT64")] TypeSint64 = 18,
            }

            /// <summary>
            /// Whether a field is optional, required, or repeated.
            /// </summary>
            public enum Cardinality {
                /// <summary>
                /// For fields with unknown cardinality.
                /// </summary>
                [OriginalName("CARDINALITY_UNKNOWN")] Unknown = 0,
                /// <summary>
                /// For optional fields.
                /// </summary>
                [OriginalName("CARDINALITY_OPTIONAL")] Optional = 1,
                /// <summary>
                /// For required fields. Proto2 syntax only.
                /// </summary>
                [OriginalName("CARDINALITY_REQUIRED")] Required = 2,
                /// <summary>
                /// For repeated fields.
                /// </summary>
                [OriginalName("CARDINALITY_REPEATED")] Repeated = 3,
            }

        }
        #endregion

    }
}