using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    internal sealed partial class EnumOptions : IMessage<EnumOptions> {
        private static readonly MessageParser<EnumOptions> _parser = new MessageParser<EnumOptions>(() => new EnumOptions());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<EnumOptions> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[14]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        internal CustomOptions CustomOptions{ get; private set; } = CustomOptions.Empty;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumOptions() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumOptions(EnumOptions other) : this() {
            allowAlias_ = other.allowAlias_;
            deprecated_ = other.deprecated_;
            uninterpretedOption_ = other.uninterpretedOption_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public EnumOptions Clone() {
            return new EnumOptions(this);
        }

        /// <summary>Field number for the "allow_alias" field.</summary>
        public const int AllowAliasFieldNumber = 2;
        private bool allowAlias_;
        /// <summary>
        /// Set this option to true to allow mapping different tag names to the same
        /// value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool AllowAlias {
            get { return allowAlias_; }
            set {
                allowAlias_ = value;
            }
        }

        /// <summary>Field number for the "deprecated" field.</summary>
        public const int DeprecatedFieldNumber = 3;
        private bool deprecated_;
        /// <summary>
        /// Is this enum deprecated?
        /// Depending on the target platform, this can emit Deprecated annotations
        /// for the enum, or it will be completely ignored; in the very least, this
        /// is a formalization for deprecating enums.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Deprecated {
            get { return deprecated_; }
            set {
                deprecated_ = value;
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
            return Equals(other as EnumOptions);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(EnumOptions other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (AllowAlias != other.AllowAlias) return false;
            if (Deprecated != other.Deprecated) return false;
            if(!uninterpretedOption_.Equals(other.uninterpretedOption_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (AllowAlias != false) hash ^= AllowAlias.GetHashCode();
            if (Deprecated != false) hash ^= Deprecated.GetHashCode();
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
            if (AllowAlias != false) {
                output.WriteRawTag(16);
                output.WriteBool(AllowAlias);
            }
            if (Deprecated != false) {
                output.WriteRawTag(24);
                output.WriteBool(Deprecated);
            }
            uninterpretedOption_.WriteTo(output, _repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (AllowAlias != false) {
                size += 1 + 1;
            }
            if (Deprecated != false) {
                size += 1 + 1;
            }
            size += uninterpretedOption_.CalculateSize(_repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(EnumOptions other) {
            if (other == null) {
                return;
            }
            if (other.AllowAlias != false) {
                AllowAlias = other.AllowAlias;
            }
            if (other.Deprecated != false) {
                Deprecated = other.Deprecated;
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
                    case 16: {
                        AllowAlias = input.ReadBool();
                        break;
                    }
                    case 24: {
                        Deprecated = input.ReadBool();
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