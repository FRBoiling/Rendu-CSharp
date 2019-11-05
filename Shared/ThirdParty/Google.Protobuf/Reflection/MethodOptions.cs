using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    internal sealed partial class MethodOptions : IMessage<MethodOptions> {
        private static readonly MessageParser<MethodOptions> _parser = new MessageParser<MethodOptions>(() => new MethodOptions());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<MethodOptions> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[17]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        internal CustomOptions CustomOptions{ get; private set; } = CustomOptions.Empty;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MethodOptions() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MethodOptions(MethodOptions other) : this() {
            deprecated_ = other.deprecated_;
            idempotencyLevel_ = other.idempotencyLevel_;
            uninterpretedOption_ = other.uninterpretedOption_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MethodOptions Clone() {
            return new MethodOptions(this);
        }

        /// <summary>Field number for the "deprecated" field.</summary>
        public const int DeprecatedFieldNumber = 33;
        private bool deprecated_;
        /// <summary>
        /// Is this method deprecated?
        /// Depending on the target platform, this can emit Deprecated annotations
        /// for the method, or it will be completely ignored; in the very least,
        /// this is a formalization for deprecating methods.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Deprecated {
            get { return deprecated_; }
            set {
                deprecated_ = value;
            }
        }

        /// <summary>Field number for the "idempotency_level" field.</summary>
        public const int IdempotencyLevelFieldNumber = 34;
        private global::Google.Protobuf.Reflection.MethodOptions.Types.IdempotencyLevel idempotencyLevel_ = 0;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.MethodOptions.Types.IdempotencyLevel IdempotencyLevel {
            get { return idempotencyLevel_; }
            set {
                idempotencyLevel_ = value;
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
            return Equals(other as MethodOptions);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(MethodOptions other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Deprecated != other.Deprecated) return false;
            if (IdempotencyLevel != other.IdempotencyLevel) return false;
            if(!uninterpretedOption_.Equals(other.uninterpretedOption_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Deprecated != false) hash ^= Deprecated.GetHashCode();
            if (IdempotencyLevel != 0) hash ^= IdempotencyLevel.GetHashCode();
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
            if (Deprecated != false) {
                output.WriteRawTag(136, 2);
                output.WriteBool(Deprecated);
            }
            if (IdempotencyLevel != 0) {
                output.WriteRawTag(144, 2);
                output.WriteEnum((int) IdempotencyLevel);
            }
            uninterpretedOption_.WriteTo(output, _repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (Deprecated != false) {
                size += 2 + 1;
            }
            if (IdempotencyLevel != 0) {
                size += 2 + CodedOutputStream.ComputeEnumSize((int) IdempotencyLevel);
            }
            size += uninterpretedOption_.CalculateSize(_repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(MethodOptions other) {
            if (other == null) {
                return;
            }
            if (other.Deprecated != false) {
                Deprecated = other.Deprecated;
            }
            if (other.IdempotencyLevel != 0) {
                IdempotencyLevel = other.IdempotencyLevel;
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
                    case 264: {
                        Deprecated = input.ReadBool();
                        break;
                    }
                    case 272: {
                        idempotencyLevel_ = (global::Google.Protobuf.Reflection.MethodOptions.Types.IdempotencyLevel) input.ReadEnum();
                        break;
                    }
                    case 7994: {
                        uninterpretedOption_.AddEntriesFrom(input, _repeated_uninterpretedOption_codec);
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the MethodOptions message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            /// <summary>
            /// Is this method side-effect-free (or safe in HTTP parlance), or idempotent,
            /// or neither? HTTP based RPC implementation may choose GET verb for safe
            /// methods, and PUT verb for idempotent methods instead of the default POST.
            /// </summary>
            internal enum IdempotencyLevel {
                [OriginalName("IDEMPOTENCY_UNKNOWN")] IdempotencyUnknown = 0,
                /// <summary>
                /// implies idempotent
                /// </summary>
                [OriginalName("NO_SIDE_EFFECTS")] NoSideEffects = 1,
                /// <summary>
                /// idempotent, but may have side effects
                /// </summary>
                [OriginalName("IDEMPOTENT")] Idempotent = 2,
            }

        }
        #endregion

    }
}