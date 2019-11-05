using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes a message type.
    /// </summary>
    internal sealed partial class DescriptorProto : IMessage<DescriptorProto> {
        private static readonly MessageParser<DescriptorProto> _parser = new MessageParser<DescriptorProto>(() => new DescriptorProto());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<DescriptorProto> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[2]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public DescriptorProto() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public DescriptorProto(DescriptorProto other) : this() {
            name_ = other.name_;
            field_ = other.field_.Clone();
            extension_ = other.extension_.Clone();
            nestedType_ = other.nestedType_.Clone();
            enumType_ = other.enumType_.Clone();
            extensionRange_ = other.extensionRange_.Clone();
            oneofDecl_ = other.oneofDecl_.Clone();
            options_ = other.options_ != null ? other.options_.Clone() : null;
            reservedRange_ = other.reservedRange_.Clone();
            reservedName_ = other.reservedName_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public DescriptorProto Clone() {
            return new DescriptorProto(this);
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

        /// <summary>Field number for the "field" field.</summary>
        public const int FieldFieldNumber = 2;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.FieldDescriptorProto> _repeated_field_codec
            = FieldCodec.ForMessage(18, global::Google.Protobuf.Reflection.FieldDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto> field_ = new RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto> Field {
            get { return field_; }
        }

        /// <summary>Field number for the "extension" field.</summary>
        public const int ExtensionFieldNumber = 6;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.FieldDescriptorProto> _repeated_extension_codec
            = FieldCodec.ForMessage(50, global::Google.Protobuf.Reflection.FieldDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto> extension_ = new RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto> Extension {
            get { return extension_; }
        }

        /// <summary>Field number for the "nested_type" field.</summary>
        public const int NestedTypeFieldNumber = 3;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.DescriptorProto> _repeated_nestedType_codec
            = FieldCodec.ForMessage(26, global::Google.Protobuf.Reflection.DescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto> nestedType_ = new RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto> NestedType {
            get { return nestedType_; }
        }

        /// <summary>Field number for the "enum_type" field.</summary>
        public const int EnumTypeFieldNumber = 4;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.EnumDescriptorProto> _repeated_enumType_codec
            = FieldCodec.ForMessage(34, global::Google.Protobuf.Reflection.EnumDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto> enumType_ = new RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto> EnumType {
            get { return enumType_; }
        }

        /// <summary>Field number for the "extension_range" field.</summary>
        public const int ExtensionRangeFieldNumber = 5;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.DescriptorProto.Types.ExtensionRange> _repeated_extensionRange_codec
            = FieldCodec.ForMessage(42, global::Google.Protobuf.Reflection.DescriptorProto.Types.ExtensionRange.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto.Types.ExtensionRange> extensionRange_ = new RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto.Types.ExtensionRange>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto.Types.ExtensionRange> ExtensionRange {
            get { return extensionRange_; }
        }

        /// <summary>Field number for the "oneof_decl" field.</summary>
        public const int OneofDeclFieldNumber = 8;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.OneofDescriptorProto> _repeated_oneofDecl_codec
            = FieldCodec.ForMessage(66, global::Google.Protobuf.Reflection.OneofDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.OneofDescriptorProto> oneofDecl_ = new RepeatedField<global::Google.Protobuf.Reflection.OneofDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.OneofDescriptorProto> OneofDecl {
            get { return oneofDecl_; }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 7;
        private global::Google.Protobuf.Reflection.MessageOptions options_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.MessageOptions Options {
            get { return options_; }
            set {
                options_ = value;
            }
        }

        /// <summary>Field number for the "reserved_range" field.</summary>
        public const int ReservedRangeFieldNumber = 9;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.DescriptorProto.Types.ReservedRange> _repeated_reservedRange_codec
            = FieldCodec.ForMessage(74, global::Google.Protobuf.Reflection.DescriptorProto.Types.ReservedRange.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto.Types.ReservedRange> reservedRange_ = new RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto.Types.ReservedRange>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto.Types.ReservedRange> ReservedRange {
            get { return reservedRange_; }
        }

        /// <summary>Field number for the "reserved_name" field.</summary>
        public const int ReservedNameFieldNumber = 10;
        private static readonly FieldCodec<string> _repeated_reservedName_codec
            = FieldCodec.ForString(82);
        private readonly RepeatedField<string> reservedName_ = new RepeatedField<string>();
        /// <summary>
        /// Reserved field names, which may not be used by fields in the same message.
        /// A given name may only be reserved once.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<string> ReservedName {
            get { return reservedName_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as DescriptorProto);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(DescriptorProto other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if(!field_.Equals(other.field_)) return false;
            if(!extension_.Equals(other.extension_)) return false;
            if(!nestedType_.Equals(other.nestedType_)) return false;
            if(!enumType_.Equals(other.enumType_)) return false;
            if(!extensionRange_.Equals(other.extensionRange_)) return false;
            if(!oneofDecl_.Equals(other.oneofDecl_)) return false;
            if (!object.Equals(Options, other.Options)) return false;
            if(!reservedRange_.Equals(other.reservedRange_)) return false;
            if(!reservedName_.Equals(other.reservedName_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            hash ^= field_.GetHashCode();
            hash ^= extension_.GetHashCode();
            hash ^= nestedType_.GetHashCode();
            hash ^= enumType_.GetHashCode();
            hash ^= extensionRange_.GetHashCode();
            hash ^= oneofDecl_.GetHashCode();
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
            field_.WriteTo(output, _repeated_field_codec);
            nestedType_.WriteTo(output, _repeated_nestedType_codec);
            enumType_.WriteTo(output, _repeated_enumType_codec);
            extensionRange_.WriteTo(output, _repeated_extensionRange_codec);
            extension_.WriteTo(output, _repeated_extension_codec);
            if (options_ != null) {
                output.WriteRawTag(58);
                output.WriteMessage(Options);
            }
            oneofDecl_.WriteTo(output, _repeated_oneofDecl_codec);
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
            size += field_.CalculateSize(_repeated_field_codec);
            size += extension_.CalculateSize(_repeated_extension_codec);
            size += nestedType_.CalculateSize(_repeated_nestedType_codec);
            size += enumType_.CalculateSize(_repeated_enumType_codec);
            size += extensionRange_.CalculateSize(_repeated_extensionRange_codec);
            size += oneofDecl_.CalculateSize(_repeated_oneofDecl_codec);
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
        public void MergeFrom(DescriptorProto other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            field_.Add(other.field_);
            extension_.Add(other.extension_);
            nestedType_.Add(other.nestedType_);
            enumType_.Add(other.enumType_);
            extensionRange_.Add(other.extensionRange_);
            oneofDecl_.Add(other.oneofDecl_);
            if (other.options_ != null) {
                if (options_ == null) {
                    options_ = new global::Google.Protobuf.Reflection.MessageOptions();
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
                        field_.AddEntriesFrom(input, _repeated_field_codec);
                        break;
                    }
                    case 26: {
                        nestedType_.AddEntriesFrom(input, _repeated_nestedType_codec);
                        break;
                    }
                    case 34: {
                        enumType_.AddEntriesFrom(input, _repeated_enumType_codec);
                        break;
                    }
                    case 42: {
                        extensionRange_.AddEntriesFrom(input, _repeated_extensionRange_codec);
                        break;
                    }
                    case 50: {
                        extension_.AddEntriesFrom(input, _repeated_extension_codec);
                        break;
                    }
                    case 58: {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.MessageOptions();
                        }
                        input.ReadMessage(options_);
                        break;
                    }
                    case 66: {
                        oneofDecl_.AddEntriesFrom(input, _repeated_oneofDecl_codec);
                        break;
                    }
                    case 74: {
                        reservedRange_.AddEntriesFrom(input, _repeated_reservedRange_codec);
                        break;
                    }
                    case 82: {
                        reservedName_.AddEntriesFrom(input, _repeated_reservedName_codec);
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the DescriptorProto message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            internal sealed partial class ExtensionRange : IMessage<ExtensionRange> {
                private static readonly MessageParser<ExtensionRange> _parser = new MessageParser<ExtensionRange>(() => new ExtensionRange());
                private UnknownFieldSet _unknownFields;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageParser<ExtensionRange> Parser { get { return _parser; } }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageDescriptor Descriptor {
                    get { return global::Google.Protobuf.Reflection.DescriptorProto.Descriptor.NestedTypes[0]; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                MessageDescriptor IMessage.Descriptor {
                    get { return Descriptor; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public ExtensionRange() {
                    OnConstruction();
                }

                partial void OnConstruction();

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public ExtensionRange(ExtensionRange other) : this() {
                    start_ = other.start_;
                    end_ = other.end_;
                    options_ = other.options_ != null ? other.options_.Clone() : null;
                    _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public ExtensionRange Clone() {
                    return new ExtensionRange(this);
                }

                /// <summary>Field number for the "start" field.</summary>
                public const int StartFieldNumber = 1;
                private int start_;
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
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int End {
                    get { return end_; }
                    set {
                        end_ = value;
                    }
                }

                /// <summary>Field number for the "options" field.</summary>
                public const int OptionsFieldNumber = 3;
                private global::Google.Protobuf.Reflection.ExtensionRangeOptions options_;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public global::Google.Protobuf.Reflection.ExtensionRangeOptions Options {
                    get { return options_; }
                    set {
                        options_ = value;
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override bool Equals(object other) {
                    return Equals(other as ExtensionRange);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool Equals(ExtensionRange other) {
                    if (ReferenceEquals(other, null)) {
                        return false;
                    }
                    if (ReferenceEquals(other, this)) {
                        return true;
                    }
                    if (Start != other.Start) return false;
                    if (End != other.End) return false;
                    if (!object.Equals(Options, other.Options)) return false;
                    return Equals(_unknownFields, other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override int GetHashCode() {
                    int hash = 1;
                    if (Start != 0) hash ^= Start.GetHashCode();
                    if (End != 0) hash ^= End.GetHashCode();
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
                    if (Start != 0) {
                        output.WriteRawTag(8);
                        output.WriteInt32(Start);
                    }
                    if (End != 0) {
                        output.WriteRawTag(16);
                        output.WriteInt32(End);
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
                    if (Start != 0) {
                        size += 1 + CodedOutputStream.ComputeInt32Size(Start);
                    }
                    if (End != 0) {
                        size += 1 + CodedOutputStream.ComputeInt32Size(End);
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
                public void MergeFrom(ExtensionRange other) {
                    if (other == null) {
                        return;
                    }
                    if (other.Start != 0) {
                        Start = other.Start;
                    }
                    if (other.End != 0) {
                        End = other.End;
                    }
                    if (other.options_ != null) {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.ExtensionRangeOptions();
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
                            case 8: {
                                Start = input.ReadInt32();
                                break;
                            }
                            case 16: {
                                End = input.ReadInt32();
                                break;
                            }
                            case 26: {
                                if (options_ == null) {
                                    options_ = new global::Google.Protobuf.Reflection.ExtensionRangeOptions();
                                }
                                input.ReadMessage(options_);
                                break;
                            }
                        }
                    }
                }

            }

            /// <summary>
            /// Range of reserved tag numbers. Reserved tag numbers may not be used by
            /// fields or extension ranges in the same message. Reserved ranges may
            /// not overlap.
            /// </summary>
            internal sealed partial class ReservedRange : IMessage<ReservedRange> {
                private static readonly MessageParser<ReservedRange> _parser = new MessageParser<ReservedRange>(() => new ReservedRange());
                private UnknownFieldSet _unknownFields;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageParser<ReservedRange> Parser { get { return _parser; } }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageDescriptor Descriptor {
                    get { return global::Google.Protobuf.Reflection.DescriptorProto.Descriptor.NestedTypes[1]; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                MessageDescriptor IMessage.Descriptor {
                    get { return Descriptor; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public ReservedRange() {
                    OnConstruction();
                }

                partial void OnConstruction();

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public ReservedRange(ReservedRange other) : this() {
                    start_ = other.start_;
                    end_ = other.end_;
                    _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public ReservedRange Clone() {
                    return new ReservedRange(this);
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
                /// Exclusive.
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
                    return Equals(other as ReservedRange);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool Equals(ReservedRange other) {
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
                public void MergeFrom(ReservedRange other) {
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