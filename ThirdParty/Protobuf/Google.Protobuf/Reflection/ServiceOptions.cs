using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    internal sealed partial class ServiceOptions : IMessage<ServiceOptions> {
        private static readonly MessageParser<ServiceOptions> _parser = new MessageParser<ServiceOptions>(() => new ServiceOptions());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<ServiceOptions> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[16]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        internal CustomOptions CustomOptions{ get; private set; } = CustomOptions.Empty;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ServiceOptions() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ServiceOptions(ServiceOptions other) : this() {
            deprecated_ = other.deprecated_;
            uninterpretedOption_ = other.uninterpretedOption_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ServiceOptions Clone() {
            return new ServiceOptions(this);
        }

        /// <summary>Field number for the "deprecated" field.</summary>
        public const int DeprecatedFieldNumber = 33;
        private bool deprecated_;
        /// <summary>
        /// Is this service deprecated?
        /// Depending on the target platform, this can emit Deprecated annotations
        /// for the service, or it will be completely ignored; in the very least,
        /// this is a formalization for deprecating services.
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
            return Equals(other as ServiceOptions);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ServiceOptions other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Deprecated != other.Deprecated) return false;
            if(!uninterpretedOption_.Equals(other.uninterpretedOption_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
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
            if (Deprecated != false) {
                output.WriteRawTag(136, 2);
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
            if (Deprecated != false) {
                size += 2 + 1;
            }
            size += uninterpretedOption_.CalculateSize(_repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ServiceOptions other) {
            if (other == null) {
                return;
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
                    case 264: {
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