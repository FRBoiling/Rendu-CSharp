using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes a complete .proto file.
    /// </summary>
    internal sealed partial class FileDescriptorProto : IMessage<FileDescriptorProto> {
        private static readonly MessageParser<FileDescriptorProto> _parser = new MessageParser<FileDescriptorProto>(() => new FileDescriptorProto());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<FileDescriptorProto> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileDescriptorProto() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileDescriptorProto(FileDescriptorProto other) : this() {
            name_ = other.name_;
            package_ = other.package_;
            dependency_ = other.dependency_.Clone();
            publicDependency_ = other.publicDependency_.Clone();
            weakDependency_ = other.weakDependency_.Clone();
            messageType_ = other.messageType_.Clone();
            enumType_ = other.enumType_.Clone();
            service_ = other.service_.Clone();
            extension_ = other.extension_.Clone();
            options_ = other.options_ != null ? other.options_.Clone() : null;
            sourceCodeInfo_ = other.sourceCodeInfo_ != null ? other.sourceCodeInfo_.Clone() : null;
            syntax_ = other.syntax_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileDescriptorProto Clone() {
            return new FileDescriptorProto(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;
        private string name_ = "";
        /// <summary>
        /// file name, relative to root of source tree
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name {
            get { return name_; }
            set {
                name_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "package" field.</summary>
        public const int PackageFieldNumber = 2;
        private string package_ = "";
        /// <summary>
        /// e.g. "foo", "foo.bar", etc.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Package {
            get { return package_; }
            set {
                package_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "dependency" field.</summary>
        public const int DependencyFieldNumber = 3;
        private static readonly FieldCodec<string> _repeated_dependency_codec
            = FieldCodec.ForString(26);
        private readonly RepeatedField<string> dependency_ = new RepeatedField<string>();
        /// <summary>
        /// Names of files imported by this file.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<string> Dependency {
            get { return dependency_; }
        }

        /// <summary>Field number for the "public_dependency" field.</summary>
        public const int PublicDependencyFieldNumber = 10;
        private static readonly FieldCodec<int> _repeated_publicDependency_codec
            = FieldCodec.ForInt32(80);
        private readonly RepeatedField<int> publicDependency_ = new RepeatedField<int>();
        /// <summary>
        /// Indexes of the public imported files in the dependency list above.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<int> PublicDependency {
            get { return publicDependency_; }
        }

        /// <summary>Field number for the "weak_dependency" field.</summary>
        public const int WeakDependencyFieldNumber = 11;
        private static readonly FieldCodec<int> _repeated_weakDependency_codec
            = FieldCodec.ForInt32(88);
        private readonly RepeatedField<int> weakDependency_ = new RepeatedField<int>();
        /// <summary>
        /// Indexes of the weak imported files in the dependency list.
        /// For Google-internal migration only. Do not use.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<int> WeakDependency {
            get { return weakDependency_; }
        }

        /// <summary>Field number for the "message_type" field.</summary>
        public const int MessageTypeFieldNumber = 4;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.DescriptorProto> _repeated_messageType_codec
            = FieldCodec.ForMessage(34, global::Google.Protobuf.Reflection.DescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto> messageType_ = new RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto>();
        /// <summary>
        /// All top-level definitions in this file.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.DescriptorProto> MessageType {
            get { return messageType_; }
        }

        /// <summary>Field number for the "enum_type" field.</summary>
        public const int EnumTypeFieldNumber = 5;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.EnumDescriptorProto> _repeated_enumType_codec
            = FieldCodec.ForMessage(42, global::Google.Protobuf.Reflection.EnumDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto> enumType_ = new RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.EnumDescriptorProto> EnumType {
            get { return enumType_; }
        }

        /// <summary>Field number for the "service" field.</summary>
        public const int ServiceFieldNumber = 6;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.ServiceDescriptorProto> _repeated_service_codec
            = FieldCodec.ForMessage(50, global::Google.Protobuf.Reflection.ServiceDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.ServiceDescriptorProto> service_ = new RepeatedField<global::Google.Protobuf.Reflection.ServiceDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.ServiceDescriptorProto> Service {
            get { return service_; }
        }

        /// <summary>Field number for the "extension" field.</summary>
        public const int ExtensionFieldNumber = 7;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.FieldDescriptorProto> _repeated_extension_codec
            = FieldCodec.ForMessage(58, global::Google.Protobuf.Reflection.FieldDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto> extension_ = new RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.FieldDescriptorProto> Extension {
            get { return extension_; }
        }

        /// <summary>Field number for the "options" field.</summary>
        public const int OptionsFieldNumber = 8;
        private global::Google.Protobuf.Reflection.FileOptions options_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.FileOptions Options {
            get { return options_; }
            set {
                options_ = value;
            }
        }

        /// <summary>Field number for the "source_code_info" field.</summary>
        public const int SourceCodeInfoFieldNumber = 9;
        private global::Google.Protobuf.Reflection.SourceCodeInfo sourceCodeInfo_;
        /// <summary>
        /// This field contains optional information about the original source code.
        /// You may safely remove this entire field without harming runtime
        /// functionality of the descriptors -- the information is needed only by
        /// development tools.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.SourceCodeInfo SourceCodeInfo {
            get { return sourceCodeInfo_; }
            set {
                sourceCodeInfo_ = value;
            }
        }

        /// <summary>Field number for the "syntax" field.</summary>
        public const int SyntaxFieldNumber = 12;
        private string syntax_ = "";
        /// <summary>
        /// The syntax of the proto file.
        /// The supported values are "proto2" and "proto3".
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Syntax {
            get { return syntax_; }
            set {
                syntax_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as FileDescriptorProto);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(FileDescriptorProto other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if (Package != other.Package) return false;
            if(!dependency_.Equals(other.dependency_)) return false;
            if(!publicDependency_.Equals(other.publicDependency_)) return false;
            if(!weakDependency_.Equals(other.weakDependency_)) return false;
            if(!messageType_.Equals(other.messageType_)) return false;
            if(!enumType_.Equals(other.enumType_)) return false;
            if(!service_.Equals(other.service_)) return false;
            if(!extension_.Equals(other.extension_)) return false;
            if (!object.Equals(Options, other.Options)) return false;
            if (!object.Equals(SourceCodeInfo, other.SourceCodeInfo)) return false;
            if (Syntax != other.Syntax) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (Package.Length != 0) hash ^= Package.GetHashCode();
            hash ^= dependency_.GetHashCode();
            hash ^= publicDependency_.GetHashCode();
            hash ^= weakDependency_.GetHashCode();
            hash ^= messageType_.GetHashCode();
            hash ^= enumType_.GetHashCode();
            hash ^= service_.GetHashCode();
            hash ^= extension_.GetHashCode();
            if (options_ != null) hash ^= Options.GetHashCode();
            if (sourceCodeInfo_ != null) hash ^= SourceCodeInfo.GetHashCode();
            if (Syntax.Length != 0) hash ^= Syntax.GetHashCode();
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
            if (Package.Length != 0) {
                output.WriteRawTag(18);
                output.WriteString(Package);
            }
            dependency_.WriteTo(output, _repeated_dependency_codec);
            messageType_.WriteTo(output, _repeated_messageType_codec);
            enumType_.WriteTo(output, _repeated_enumType_codec);
            service_.WriteTo(output, _repeated_service_codec);
            extension_.WriteTo(output, _repeated_extension_codec);
            if (options_ != null) {
                output.WriteRawTag(66);
                output.WriteMessage(Options);
            }
            if (sourceCodeInfo_ != null) {
                output.WriteRawTag(74);
                output.WriteMessage(SourceCodeInfo);
            }
            publicDependency_.WriteTo(output, _repeated_publicDependency_codec);
            weakDependency_.WriteTo(output, _repeated_weakDependency_codec);
            if (Syntax.Length != 0) {
                output.WriteRawTag(98);
                output.WriteString(Syntax);
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
            if (Package.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Package);
            }
            size += dependency_.CalculateSize(_repeated_dependency_codec);
            size += publicDependency_.CalculateSize(_repeated_publicDependency_codec);
            size += weakDependency_.CalculateSize(_repeated_weakDependency_codec);
            size += messageType_.CalculateSize(_repeated_messageType_codec);
            size += enumType_.CalculateSize(_repeated_enumType_codec);
            size += service_.CalculateSize(_repeated_service_codec);
            size += extension_.CalculateSize(_repeated_extension_codec);
            if (options_ != null) {
                size += 1 + CodedOutputStream.ComputeMessageSize(Options);
            }
            if (sourceCodeInfo_ != null) {
                size += 1 + CodedOutputStream.ComputeMessageSize(SourceCodeInfo);
            }
            if (Syntax.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Syntax);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(FileDescriptorProto other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.Package.Length != 0) {
                Package = other.Package;
            }
            dependency_.Add(other.dependency_);
            publicDependency_.Add(other.publicDependency_);
            weakDependency_.Add(other.weakDependency_);
            messageType_.Add(other.messageType_);
            enumType_.Add(other.enumType_);
            service_.Add(other.service_);
            extension_.Add(other.extension_);
            if (other.options_ != null) {
                if (options_ == null) {
                    options_ = new global::Google.Protobuf.Reflection.FileOptions();
                }
                Options.MergeFrom(other.Options);
            }
            if (other.sourceCodeInfo_ != null) {
                if (sourceCodeInfo_ == null) {
                    sourceCodeInfo_ = new global::Google.Protobuf.Reflection.SourceCodeInfo();
                }
                SourceCodeInfo.MergeFrom(other.SourceCodeInfo);
            }
            if (other.Syntax.Length != 0) {
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
                        Package = input.ReadString();
                        break;
                    }
                    case 26: {
                        dependency_.AddEntriesFrom(input, _repeated_dependency_codec);
                        break;
                    }
                    case 34: {
                        messageType_.AddEntriesFrom(input, _repeated_messageType_codec);
                        break;
                    }
                    case 42: {
                        enumType_.AddEntriesFrom(input, _repeated_enumType_codec);
                        break;
                    }
                    case 50: {
                        service_.AddEntriesFrom(input, _repeated_service_codec);
                        break;
                    }
                    case 58: {
                        extension_.AddEntriesFrom(input, _repeated_extension_codec);
                        break;
                    }
                    case 66: {
                        if (options_ == null) {
                            options_ = new global::Google.Protobuf.Reflection.FileOptions();
                        }
                        input.ReadMessage(options_);
                        break;
                    }
                    case 74: {
                        if (sourceCodeInfo_ == null) {
                            sourceCodeInfo_ = new global::Google.Protobuf.Reflection.SourceCodeInfo();
                        }
                        input.ReadMessage(sourceCodeInfo_);
                        break;
                    }
                    case 82:
                    case 80: {
                        publicDependency_.AddEntriesFrom(input, _repeated_publicDependency_codec);
                        break;
                    }
                    case 90:
                    case 88: {
                        weakDependency_.AddEntriesFrom(input, _repeated_weakDependency_codec);
                        break;
                    }
                    case 98: {
                        Syntax = input.ReadString();
                        break;
                    }
                }
            }
        }

    }
}