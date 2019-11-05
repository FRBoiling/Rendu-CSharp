using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// A message representing a option the parser does not recognize. This only
    /// appears in options protos created by the compiler::Parser class.
    /// DescriptorPool resolves these when building Descriptor objects. Therefore,
    /// options protos in descriptor objects (e.g. returned by Descriptor::options(),
    /// or produced by Descriptor::CopyTo()) will never have UninterpretedOptions
    /// in them.
    /// </summary>
    internal sealed partial class UninterpretedOption : IMessage<UninterpretedOption> {
        private static readonly MessageParser<UninterpretedOption> _parser = new MessageParser<UninterpretedOption>(() => new UninterpretedOption());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<UninterpretedOption> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[18]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public UninterpretedOption() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public UninterpretedOption(UninterpretedOption other) : this() {
            name_ = other.name_.Clone();
            identifierValue_ = other.identifierValue_;
            positiveIntValue_ = other.positiveIntValue_;
            negativeIntValue_ = other.negativeIntValue_;
            doubleValue_ = other.doubleValue_;
            stringValue_ = other.stringValue_;
            aggregateValue_ = other.aggregateValue_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public UninterpretedOption Clone() {
            return new UninterpretedOption(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 2;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.UninterpretedOption.Types.NamePart> _repeated_name_codec
            = FieldCodec.ForMessage(18, global::Google.Protobuf.Reflection.UninterpretedOption.Types.NamePart.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption.Types.NamePart> name_ = new RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption.Types.NamePart>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption.Types.NamePart> Name {
            get { return name_; }
        }

        /// <summary>Field number for the "identifier_value" field.</summary>
        public const int IdentifierValueFieldNumber = 3;
        private string identifierValue_ = "";
        /// <summary>
        /// The value of the uninterpreted option, in whatever type the tokenizer
        /// identified it as during parsing. Exactly one of these should be set.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string IdentifierValue {
            get { return identifierValue_; }
            set {
                identifierValue_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "positive_int_value" field.</summary>
        public const int PositiveIntValueFieldNumber = 4;
        private ulong positiveIntValue_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ulong PositiveIntValue {
            get { return positiveIntValue_; }
            set {
                positiveIntValue_ = value;
            }
        }

        /// <summary>Field number for the "negative_int_value" field.</summary>
        public const int NegativeIntValueFieldNumber = 5;
        private long negativeIntValue_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public long NegativeIntValue {
            get { return negativeIntValue_; }
            set {
                negativeIntValue_ = value;
            }
        }

        /// <summary>Field number for the "double_value" field.</summary>
        public const int DoubleValueFieldNumber = 6;
        private double doubleValue_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public double DoubleValue {
            get { return doubleValue_; }
            set {
                doubleValue_ = value;
            }
        }

        /// <summary>Field number for the "string_value" field.</summary>
        public const int StringValueFieldNumber = 7;
        private ByteString stringValue_ = ByteString.Empty;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ByteString StringValue {
            get { return stringValue_; }
            set {
                stringValue_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "aggregate_value" field.</summary>
        public const int AggregateValueFieldNumber = 8;
        private string aggregateValue_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string AggregateValue {
            get { return aggregateValue_; }
            set {
                aggregateValue_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as UninterpretedOption);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(UninterpretedOption other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if(!name_.Equals(other.name_)) return false;
            if (IdentifierValue != other.IdentifierValue) return false;
            if (PositiveIntValue != other.PositiveIntValue) return false;
            if (NegativeIntValue != other.NegativeIntValue) return false;
            if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DoubleValue, other.DoubleValue)) return false;
            if (StringValue != other.StringValue) return false;
            if (AggregateValue != other.AggregateValue) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            hash ^= name_.GetHashCode();
            if (IdentifierValue.Length != 0) hash ^= IdentifierValue.GetHashCode();
            if (PositiveIntValue != 0UL) hash ^= PositiveIntValue.GetHashCode();
            if (NegativeIntValue != 0L) hash ^= NegativeIntValue.GetHashCode();
            if (DoubleValue != 0D) hash ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DoubleValue);
            if (StringValue.Length != 0) hash ^= StringValue.GetHashCode();
            if (AggregateValue.Length != 0) hash ^= AggregateValue.GetHashCode();
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
            name_.WriteTo(output, _repeated_name_codec);
            if (IdentifierValue.Length != 0) {
                output.WriteRawTag(26);
                output.WriteString(IdentifierValue);
            }
            if (PositiveIntValue != 0UL) {
                output.WriteRawTag(32);
                output.WriteUInt64(PositiveIntValue);
            }
            if (NegativeIntValue != 0L) {
                output.WriteRawTag(40);
                output.WriteInt64(NegativeIntValue);
            }
            if (DoubleValue != 0D) {
                output.WriteRawTag(49);
                output.WriteDouble(DoubleValue);
            }
            if (StringValue.Length != 0) {
                output.WriteRawTag(58);
                output.WriteBytes(StringValue);
            }
            if (AggregateValue.Length != 0) {
                output.WriteRawTag(66);
                output.WriteString(AggregateValue);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            size += name_.CalculateSize(_repeated_name_codec);
            if (IdentifierValue.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(IdentifierValue);
            }
            if (PositiveIntValue != 0UL) {
                size += 1 + CodedOutputStream.ComputeUInt64Size(PositiveIntValue);
            }
            if (NegativeIntValue != 0L) {
                size += 1 + CodedOutputStream.ComputeInt64Size(NegativeIntValue);
            }
            if (DoubleValue != 0D) {
                size += 1 + 8;
            }
            if (StringValue.Length != 0) {
                size += 1 + CodedOutputStream.ComputeBytesSize(StringValue);
            }
            if (AggregateValue.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(AggregateValue);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(UninterpretedOption other) {
            if (other == null) {
                return;
            }
            name_.Add(other.name_);
            if (other.IdentifierValue.Length != 0) {
                IdentifierValue = other.IdentifierValue;
            }
            if (other.PositiveIntValue != 0UL) {
                PositiveIntValue = other.PositiveIntValue;
            }
            if (other.NegativeIntValue != 0L) {
                NegativeIntValue = other.NegativeIntValue;
            }
            if (other.DoubleValue != 0D) {
                DoubleValue = other.DoubleValue;
            }
            if (other.StringValue.Length != 0) {
                StringValue = other.StringValue;
            }
            if (other.AggregateValue.Length != 0) {
                AggregateValue = other.AggregateValue;
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
                    case 18: {
                        name_.AddEntriesFrom(input, _repeated_name_codec);
                        break;
                    }
                    case 26: {
                        IdentifierValue = input.ReadString();
                        break;
                    }
                    case 32: {
                        PositiveIntValue = input.ReadUInt64();
                        break;
                    }
                    case 40: {
                        NegativeIntValue = input.ReadInt64();
                        break;
                    }
                    case 49: {
                        DoubleValue = input.ReadDouble();
                        break;
                    }
                    case 58: {
                        StringValue = input.ReadBytes();
                        break;
                    }
                    case 66: {
                        AggregateValue = input.ReadString();
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the UninterpretedOption message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            /// <summary>
            /// The name of the uninterpreted option.  Each string represents a segment in
            /// a dot-separated name.  is_extension is true iff a segment represents an
            /// extension (denoted with parentheses in options specs in .proto files).
            /// E.g.,{ ["foo", false], ["bar.baz", true], ["qux", false] } represents
            /// "foo.(bar.baz).qux".
            /// </summary>
            internal sealed partial class NamePart : IMessage<NamePart> {
                private static readonly MessageParser<NamePart> _parser = new MessageParser<NamePart>(() => new NamePart());
                private UnknownFieldSet _unknownFields;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageParser<NamePart> Parser { get { return _parser; } }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageDescriptor Descriptor {
                    get { return global::Google.Protobuf.Reflection.UninterpretedOption.Descriptor.NestedTypes[0]; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                MessageDescriptor IMessage.Descriptor {
                    get { return Descriptor; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public NamePart() {
                    OnConstruction();
                }

                partial void OnConstruction();

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public NamePart(NamePart other) : this() {
                    namePart_ = other.namePart_;
                    isExtension_ = other.isExtension_;
                    _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public NamePart Clone() {
                    return new NamePart(this);
                }

                /// <summary>Field number for the "name_part" field.</summary>
                public const int NamePart_FieldNumber = 1;
                private string namePart_ = "";
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public string NamePart_ {
                    get { return namePart_; }
                    set {
                        namePart_ = ProtoPreconditions.CheckNotNull(value, "value");
                    }
                }

                /// <summary>Field number for the "is_extension" field.</summary>
                public const int IsExtensionFieldNumber = 2;
                private bool isExtension_;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool IsExtension {
                    get { return isExtension_; }
                    set {
                        isExtension_ = value;
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override bool Equals(object other) {
                    return Equals(other as NamePart);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool Equals(NamePart other) {
                    if (ReferenceEquals(other, null)) {
                        return false;
                    }
                    if (ReferenceEquals(other, this)) {
                        return true;
                    }
                    if (NamePart_ != other.NamePart_) return false;
                    if (IsExtension != other.IsExtension) return false;
                    return Equals(_unknownFields, other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override int GetHashCode() {
                    int hash = 1;
                    if (NamePart_.Length != 0) hash ^= NamePart_.GetHashCode();
                    if (IsExtension != false) hash ^= IsExtension.GetHashCode();
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
                    if (NamePart_.Length != 0) {
                        output.WriteRawTag(10);
                        output.WriteString(NamePart_);
                    }
                    if (IsExtension != false) {
                        output.WriteRawTag(16);
                        output.WriteBool(IsExtension);
                    }
                    if (_unknownFields != null) {
                        _unknownFields.WriteTo(output);
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int CalculateSize() {
                    int size = 0;
                    if (NamePart_.Length != 0) {
                        size += 1 + CodedOutputStream.ComputeStringSize(NamePart_);
                    }
                    if (IsExtension != false) {
                        size += 1 + 1;
                    }
                    if (_unknownFields != null) {
                        size += _unknownFields.CalculateSize();
                    }
                    return size;
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public void MergeFrom(NamePart other) {
                    if (other == null) {
                        return;
                    }
                    if (other.NamePart_.Length != 0) {
                        NamePart_ = other.NamePart_;
                    }
                    if (other.IsExtension != false) {
                        IsExtension = other.IsExtension;
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
                                NamePart_ = input.ReadString();
                                break;
                            }
                            case 16: {
                                IsExtension = input.ReadBool();
                                break;
                            }
                        }
                    }
                }

            }

        }
        #endregion

    }
}