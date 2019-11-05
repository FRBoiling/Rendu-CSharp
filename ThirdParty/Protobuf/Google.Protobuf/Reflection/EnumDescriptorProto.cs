using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes an enum type.
    /// </summary>
    internal sealed partial class EnumDescriptorProto : IMessage<EnumDescriptorProto> {
        private static readonly MessageParser<EnumDescriptorProto> _parser = new MessageParser<EnumDescriptorProto>(() => new EnumDescriptorProto());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<EnumDescriptorProto> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[6]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumDescriptorProto() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumDescriptorProto(EnumDescriptorProto other) : this() {
            name_ = other.name_;
            value_ = other.value_.Clone();
            options_ = other.options_ != null ? other.options_.Clone() : null;
            reservedRange_ = other.reservedRange_.Clone();
            reservedName_ = other.reservedName_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumDescriptorProto Clone() {
            return new EnumDescriptorProto(this);
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

        /// <summary>Field number for the "value" field.</summary>
        public const int ValueFieldNumber = 2;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.EnumValueDescriptorProto> _repeated_value_codec
            = FieldCodec.ForMessage(18, global::Google.Protobuf.Reflection.EnumValueDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.EnumValueDescriptorProto> value_ = new RepeatedField<global::Google.Protobuf.Reflection.EnumValueDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.EnumValueDescriptorProto> Value {
            get { return value_; }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 3;
        private global::Google.Protobuf.Reflection.EnumOptions options_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.EnumOptions Options {
            get { return options_; }
            set {
                options_ = value;
            }
        }

        /// <summary>Field number for the "reserved_range" field.</summary>
        public const int ReservedRangeFieldNumber = 4;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.EnumDescriptorProto.Types.EnumReservedRange> _repeated_reservedRange_codec
            = FieldCodec.ForMessage(34, global::Google.Protobuf.Reflection.EnumDescriptorProto.Types.EnumReservedRange.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto.Types.EnumReservedRange> reservedRange_ = new RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto.Types.EnumReservedRange>();
        /// <summary>
        /// Range of reserved numeric values. Reserved numeric values may not be used
        /// by enum values in the same enum declaration. Reserved ranges may not
        /// overlap.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto.Types.EnumReservedRange> ReservedRange {
            get { return reservedRange_; }
        }

        /// <summary>Field number for the "reserved_name" field.</summary>
        public const int ReservedNameFieldNumber = 5;
        private static readonly FieldCodec<string> _repeated_reservedName_codec
            = FieldCodec.ForString(42);
        private readonly RepeatedField<string> reservedName_ = new RepeatedField<string>();
        /// <summary>
        /// Reserved enum value names, which may not be reused. A given name may only
        /// be reserved once.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<string> ReservedName {
            get { return reservedName_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as EnumDescriptorProto);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(EnumDescriptorProto other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if(!value_.Equals(other.value_)) return false;
            if (!object.Equals(Options, other.Options)) return false;
            if(!reservedRange_.Equals(other.reservedRange_)) return false;
            if(!reservedName_.Equals(other.reservedName_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            hash ^= value_.GetHashCode();
            if (options_ != null) hash ^= Options.GetHashCode();
            hash ^= reservedRange_.GetHashCode();
            hash ^= reservedName_.GetHashCode();
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
            value_.WriteTo(output, _repeated_value_codec);
            if (options_ != null) {
                output.WriteRawTag(26);
                output.WriteMessage(Options);
            }
            reservedRange_.WriteTo(output, _repeated_reservedRange_codec);
            reservedName_.WriteTo(output, _repeated_reservedName_codec);
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
            size += value_.CalculateSize(_repeated_value_codec);
            if (options_ != null) {
                size += 1 + CodedOutputStream.ComputeMessageSize(Options);
            }
            size += reservedRange_.CalculateSize(_repeated_reservedRange_codec);
            size += reservedName_.CalculateSize(_repeated_reservedName_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(EnumDescriptorProto other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            value_.Add(other.value_);
            if (other.options_ != null) {
                if (options_ == null) {
                    options_ = new global::Google.Protobuf.Reflection.EnumOptions();
                }
                Options.MergeFrom(other.Options);
            }
            reservedRange_.Add(other.reservedRange_);
            reservedName_.Add(other.reservedName_);
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
                        value_.AddEntriesFrom(input, _repeated_value_codec);
                        break;
                    }
                    case 26: {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.EnumOptions();
                        }
                        input.ReadMessage(options_);
                        break;
                    }
                    case 34: {
                        reservedRange_.AddEntriesFrom(input, _repeated_reservedRange_codec);
                        break;
                    }
                    case 42: {
                        reservedName_.AddEntriesFrom(input, _repeated_reservedName_codec);
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the EnumDescriptorProto message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            /// <summary>
            /// Range of reserved numeric values. Reserved values may not be used by
            /// entries in the same enum. Reserved ranges may not overlap.
            ///
            /// Note that this is distinct from DescriptorProto.ReservedRange in that it
            /// is inclusive such that it can appropriately represent the entire int32
            /// domain.
            /// </summary>
            internal sealed partial class EnumReservedRange : IMessage<EnumReservedRange> {
                private static readonly MessageParser<EnumReservedRange> _parser = new MessageParser<EnumReservedRange>(() => new EnumReservedRange());
                private UnknownFieldSet _unknownFields;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageParser<EnumReservedRange> Parser { get { return _parser; } }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageDescriptor Descriptor {
                    get { return global::Google.Protobuf.Reflection.EnumDescriptorProto.Descriptor.NestedTypes[0]; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                MessageDescriptor IMessage.Descriptor {
                    get { return Descriptor; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public EnumReservedRange() {
                    OnConstruction();
                }

                partial void OnConstruction();

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public EnumReservedRange(EnumReservedRange other) : this() {
                    start_ = other.start_;
                    end_ = other.end_;
                    _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public EnumReservedRange Clone() {
                    return new EnumReservedRange(this);
                }

                /// <summary>Field number for the "start" field.</summary>
                public const int StartFieldNumber = 1;
                private int start_;
                /// <summary>
                /// Inclusive.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int Start {
                    get { return start_; }
                    set {
                        start_ = value;
                    }
                }

                /// <summary>Field number for the "end" field.</summary>
                public const int EndFieldNumber = 2;
                private int end_;
                /// <summary>
                /// Inclusive.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int End {
                    get { return end_; }
                    set {
                        end_ = value;
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override bool Equals(object other) {
                    return Equals(other as EnumReservedRange);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool Equals(EnumReservedRange other) {
                    if (ReferenceEquals(other, null)) {
                        return false;
                    }
                    if (ReferenceEquals(other, this)) {
                        return true;
                    }
                    if (Start != other.Start) return false;
                    if (End != other.End) return false;
                    return Equals(_unknownFields, other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override int GetHashCode() {
                    int hash = 1;
                    if (Start != 0) hash ^= Start.GetHashCode();
                    if (End != 0) hash ^= End.GetHashCode();
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
                    if (Start != 0) {
                        output.WriteRawTag(8);
                        output.WriteInt32(Start);
                    }
                    if (End != 0) {
                        output.WriteRawTag(16);
                        output.WriteInt32(End);
                    }
                    if (_unknownFields != null) {
                        _unknownFields.WriteTo(output);
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int CalculateSize() {
                    int size = 0;
                    if (Start != 0) {
                        size += 1 + CodedOutputStream.ComputeInt32Size(Start);
                    }
                    if (End != 0) {
                        size += 1 + CodedOutputStream.ComputeInt32Size(End);
                    }
                    if (_unknownFields != null) {
                        size += _unknownFields.CalculateSize();
                    }
                    return size;
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public void MergeFrom(EnumReservedRange other) {
                    if (other == null) {
                        return;
                    }
                    if (other.Start != 0) {
                        Start = other.Start;
                    }
                    if (other.End != 0) {
                        End = other.End;
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
                                Start = input.ReadInt32();
                                break;
                            }
                            case 16: {
                                End = input.ReadInt32();
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