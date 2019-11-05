using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// Method represents a method of an API interface.
    /// </summary>
    public sealed partial class Method : IMessage<Method> {
        private static readonly MessageParser<Method> _parser = new MessageParser<Method>(() => new Method());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<Method> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.ApiReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Method() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Method(Method other) : this() {
            name_ = other.name_;
            requestTypeUrl_ = other.requestTypeUrl_;
            requestStreaming_ = other.requestStreaming_;
            responseTypeUrl_ = other.responseTypeUrl_;
            responseStreaming_ = other.responseStreaming_;
            options_ = other.options_.Clone();
            syntax_ = other.syntax_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Method Clone() {
            return new Method(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;
        private string name_ = "";
        /// <summary>
        /// The simple name of this method.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name {
            get { return name_; }
            set {
                name_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "request_type_url" field.</summary>
        public const int RequestTypeUrlFieldNumber = 2;
        private string requestTypeUrl_ = "";
        /// <summary>
        /// A URL of the input message type.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string RequestTypeUrl {
            get { return requestTypeUrl_; }
            set {
                requestTypeUrl_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "request_streaming" field.</summary>
        public const int RequestStreamingFieldNumber = 3;
        private bool requestStreaming_;
        /// <summary>
        /// If true, the request is streamed.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool RequestStreaming {
            get { return requestStreaming_; }
            set {
                requestStreaming_ = value;
            }
        }

        /// <summary>Field number for the "response_type_url" field.</summary>
        public const int ResponseTypeUrlFieldNumber = 4;
        private string responseTypeUrl_ = "";
        /// <summary>
        /// The URL of the output message type.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string ResponseTypeUrl {
            get { return responseTypeUrl_; }
            set {
                responseTypeUrl_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "response_streaming" field.</summary>
        public const int ResponseStreamingFieldNumber = 5;
        private bool responseStreaming_;
        /// <summary>
        /// If true, the response is streamed.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool ResponseStreaming {
            get { return responseStreaming_; }
            set {
                responseStreaming_ = value;
            }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 6;
        private static readonly FieldCodec<global::Google.Protobuf.WellKnownTypes.Option> _repeated_options_codec
            = FieldCodec.ForMessage(50, global::Google.Protobuf.WellKnownTypes.Option.Parser);
        private readonly RepeatedField<global::Google.Protobuf.WellKnownTypes.Option> options_ = new RepeatedField<global::Google.Protobuf.WellKnownTypes.Option>();
        /// <summary>
        /// Any metadata attached to the method.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.WellKnownTypes.Option> Options {
            get { return options_; }
        }

        /// <summary>Field number for the "syntax" field.</summary>
        public const int SyntaxFieldNumber = 7;
        private global::Google.Protobuf.WellKnownTypes.Syntax syntax_ = 0;
        /// <summary>
        /// The source syntax of this method.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Syntax Syntax {
            get { return syntax_; }
            set {
                syntax_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as Method);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Method other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if (RequestTypeUrl != other.RequestTypeUrl) return false;
            if (RequestStreaming != other.RequestStreaming) return false;
            if (ResponseTypeUrl != other.ResponseTypeUrl) return false;
            if (ResponseStreaming != other.ResponseStreaming) return false;
            if(!options_.Equals(other.options_)) return false;
            if (Syntax != other.Syntax) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (RequestTypeUrl.Length != 0) hash ^= RequestTypeUrl.GetHashCode();
            if (RequestStreaming != false) hash ^= RequestStreaming.GetHashCode();
            if (ResponseTypeUrl.Length != 0) hash ^= ResponseTypeUrl.GetHashCode();
            if (ResponseStreaming != false) hash ^= ResponseStreaming.GetHashCode();
            hash ^= options_.GetHashCode();
            if (Syntax != 0) hash ^= Syntax.GetHashCode();
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
            if (RequestTypeUrl.Length != 0) {
                output.WriteRawTag(18);
                output.WriteString(RequestTypeUrl);
            }
            if (RequestStreaming != false) {
                output.WriteRawTag(24);
                output.WriteBool(RequestStreaming);
            }
            if (ResponseTypeUrl.Length != 0) {
                output.WriteRawTag(34);
                output.WriteString(ResponseTypeUrl);
            }
            if (ResponseStreaming != false) {
                output.WriteRawTag(40);
                output.WriteBool(ResponseStreaming);
            }
            options_.WriteTo(output, _repeated_options_codec);
            if (Syntax != 0) {
                output.WriteRawTag(56);
                output.WriteEnum((int) Syntax);
            }
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
            if (RequestTypeUrl.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(RequestTypeUrl);
            }
            if (RequestStreaming != false) {
                size += 1 + 1;
            }
            if (ResponseTypeUrl.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(ResponseTypeUrl);
            }
            if (ResponseStreaming != false) {
                size += 1 + 1;
            }
            size += options_.CalculateSize(_repeated_options_codec);
            if (Syntax != 0) {
                size += 1 + CodedOutputStream.ComputeEnumSize((int) Syntax);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Method other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.RequestTypeUrl.Length != 0) {
                RequestTypeUrl = other.RequestTypeUrl;
            }
            if (other.RequestStreaming != false) {
                RequestStreaming = other.RequestStreaming;
            }
            if (other.ResponseTypeUrl.Length != 0) {
                ResponseTypeUrl = other.ResponseTypeUrl;
            }
            if (other.ResponseStreaming != false) {
                ResponseStreaming = other.ResponseStreaming;
            }
            options_.Add(other.options_);
            if (other.Syntax != 0) {
                Syntax = other.Syntax;
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
                        Name = input.ReadString();
                        break;
                    }
                    case 18: {
                        RequestTypeUrl = input.ReadString();
                        break;
                    }
                    case 24: {
                        RequestStreaming = input.ReadBool();
                        break;
                    }
                    case 34: {
                        ResponseTypeUrl = input.ReadString();
                        break;
                    }
                    case 40: {
                        ResponseStreaming = input.ReadBool();
                        break;
                    }
                    case 50: {
                        options_.AddEntriesFrom(input, _repeated_options_codec);
                        break;
                    }
                    case 56: {
                        syntax_ = (global::Google.Protobuf.WellKnownTypes.Syntax) input.ReadEnum();
                        break;
                    }
                }
            }
        }

    }
}