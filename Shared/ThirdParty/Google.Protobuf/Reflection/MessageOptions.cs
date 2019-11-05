using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    internal sealed partial class MessageOptions : IMessage<MessageOptions> {
        private static readonly MessageParser<MessageOptions> _parser = new MessageParser<MessageOptions>(() => new MessageOptions());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<MessageOptions> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[11]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        internal CustomOptions CustomOptions{ get; private set; } = CustomOptions.Empty;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MessageOptions() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MessageOptions(MessageOptions other) : this() {
            messageSetWireFormat_ = other.messageSetWireFormat_;
            noStandardDescriptorAccessor_ = other.noStandardDescriptorAccessor_;
            deprecated_ = other.deprecated_;
            mapEntry_ = other.mapEntry_;
            uninterpretedOption_ = other.uninterpretedOption_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MessageOptions Clone() {
            return new MessageOptions(this);
        }

        /// <summary>Field number for the "message_set_wire_format" field.</summary>
        public const int MessageSetWireFormatFieldNumber = 1;
        private bool messageSetWireFormat_;
        /// <summary>
        /// Set true to use the old proto1 MessageSet wire format for extensions.
        /// This is provided for backwards-compatibility with the MessageSet wire
        /// format.  You should not use this for any other reason:  It's less
        /// efficient, has fewer features, and is more complicated.
        ///
        /// The message must be defined exactly as follows:
        ///   message Foo {
        ///     option message_set_wire_format = true;
        ///     extensions 4 to max;
        ///   }
        /// Note that the message cannot have any defined fields; MessageSets only
        /// have extensions.
        ///
        /// All extensions of your type must be singular messages; e.g. they cannot
        /// be int32s, enums, or repeated messages.
        ///
        /// Because this is an option, the above two restrictions are not enforced by
        /// the protocol compiler.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool MessageSetWireFormat {
            get { return messageSetWireFormat_; }
            set {
                messageSetWireFormat_ = value;
            }
        }

        /// <summary>Field number for the "no_standard_descriptor_accessor" field.</summary>
        public const int NoStandardDescriptorAccessorFieldNumber = 2;
        private bool noStandardDescriptorAccessor_;
        /// <summary>
        /// Disables the generation of the standard "descriptor()" accessor, which can
        /// conflict with a field of the same name.  This is meant to make migration
        /// from proto1 easier; new code should avoid fields named "descriptor".
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool NoStandardDescriptorAccessor {
            get { return noStandardDescriptorAccessor_; }
            set {
                noStandardDescriptorAccessor_ = value;
            }
        }

        /// <summary>Field number for the "deprecated" field.</summary>
        public const int DeprecatedFieldNumber = 3;
        private bool deprecated_;
        /// <summary>
        /// Is this message deprecated?
        /// Depending on the target platform, this can emit Deprecated annotations
        /// for the message, or it will be completely ignored; in the very least,
        /// this is a formalization for deprecating messages.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Deprecated {
            get { return deprecated_; }
            set {
                deprecated_ = value;
            }
        }

        /// <summary>Field number for the "map_entry" field.</summary>
        public const int MapEntryFieldNumber = 7;
        private bool mapEntry_;
        /// <summary>
        /// Whether the message is an automatically generated map entry type for the
        /// maps field.
        ///
        /// For maps fields:
        ///     map&lt;KeyType, ValueType> map_field = 1;
        /// The parsed descriptor looks like:
        ///     message MapFieldEntry {
        ///         option map_entry = true;
        ///         optional KeyType key = 1;
        ///         optional ValueType value = 2;
        ///     }
        ///     repeated MapFieldEntry map_field = 1;
        ///
        /// Implementations may choose not to generate the map_entry=true message, but
        /// use a native map in the target language to hold the keys and values.
        /// The reflection APIs in such implementions still need to work as
        /// if the field is a repeated message field.
        ///
        /// NOTE: Do not set the option in .proto files. Always use the maps syntax
        /// instead. The option should only be implicitly set by the proto compiler
        /// parser.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool MapEntry {
            get { return mapEntry_; }
            set {
                mapEntry_ = value;
            }
        }

        /// <summary>Field number for the "uninterpreted_option" field.</summary>
        public const int UninterpretedOptionFieldNumber = 999;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.UninterpretedOption> _repeated_uninterpretedOption_codec
            = FieldCodec.ForMessage(7994, global::Google.Protobuf.Reflection.UninterpretedOption.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption> uninterpretedOption_ = new RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption>();
        /// <summary>
        /// The parser stores options it doesn't recognize here. See above.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption> UninterpretedOption {
            get { return uninterpretedOption_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as MessageOptions);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(MessageOptions other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (MessageSetWireFormat != other.MessageSetWireFormat) return false;
            if (NoStandardDescriptorAccessor != other.NoStandardDescriptorAccessor) return false;
            if (Deprecated != other.Deprecated) return false;
            if (MapEntry != other.MapEntry) return false;
            if(!uninterpretedOption_.Equals(other.uninterpretedOption_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (MessageSetWireFormat != false) hash ^= MessageSetWireFormat.GetHashCode();
            if (NoStandardDescriptorAccessor != false) hash ^= NoStandardDescriptorAccessor.GetHashCode();
            if (Deprecated != false) hash ^= Deprecated.GetHashCode();
            if (MapEntry != false) hash ^= MapEntry.GetHashCode();
            hash ^= uninterpretedOption_.GetHashCode();
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
            if (MessageSetWireFormat != false) {
                output.WriteRawTag(8);
                output.WriteBool(MessageSetWireFormat);
            }
            if (NoStandardDescriptorAccessor != false) {
                output.WriteRawTag(16);
                output.WriteBool(NoStandardDescriptorAccessor);
            }
            if (Deprecated != false) {
                output.WriteRawTag(24);
                output.WriteBool(Deprecated);
            }
            if (MapEntry != false) {
                output.WriteRawTag(56);
                output.WriteBool(MapEntry);
            }
            uninterpretedOption_.WriteTo(output, _repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (MessageSetWireFormat != false) {
                size += 1 + 1;
            }
            if (NoStandardDescriptorAccessor != false) {
                size += 1 + 1;
            }
            if (Deprecated != false) {
                size += 1 + 1;
            }
            if (MapEntry != false) {
                size += 1 + 1;
            }
            size += uninterpretedOption_.CalculateSize(_repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(MessageOptions other) {
            if (other == null) {
                return;
            }
            if (other.MessageSetWireFormat != false) {
                MessageSetWireFormat = other.MessageSetWireFormat;
            }
            if (other.NoStandardDescriptorAccessor != false) {
                NoStandardDescriptorAccessor = other.NoStandardDescriptorAccessor;
            }
            if (other.Deprecated != false) {
                Deprecated = other.Deprecated;
            }
            if (other.MapEntry != false) {
                MapEntry = other.MapEntry;
            }
            uninterpretedOption_.Add(other.uninterpretedOption_);
            _unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(CodedInputStream input) {
            uint tag;
            while ((tag = input.ReadTag()) != 0) {
                switch(tag) {
                    default:
                        CustomOptions = CustomOptions.ReadOrSkipUnknownField(input);
                        break;
                    case 8: {
                        MessageSetWireFormat = input.ReadBool();
                        break;
                    }
                    case 16: {
                        NoStandardDescriptorAccessor = input.ReadBool();
                        break;
                    }
                    case 24: {
                        Deprecated = input.ReadBool();
                        break;
                    }
                    case 56: {
                        MapEntry = input.ReadBool();
                        break;
                    }
                    case 7994: {
                        uninterpretedOption_.AddEntriesFrom(input, _repeated_uninterpretedOption_codec);
                        break;
                    }
                }
            }
        }

    }
}