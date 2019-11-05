using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Describes the relationship between generated code and its original source
    /// file. A GeneratedCodeInfo message is associated with only one generated
    /// source file, but may contain references to different source .proto files.
    /// </summary>
    internal sealed partial class GeneratedCodeInfo : IMessage<GeneratedCodeInfo> {
        private static readonly MessageParser<GeneratedCodeInfo> _parser = new MessageParser<GeneratedCodeInfo>(() => new GeneratedCodeInfo());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<GeneratedCodeInfo> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[20]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public GeneratedCodeInfo() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public GeneratedCodeInfo(GeneratedCodeInfo other) : this() {
            annotation_ = other.annotation_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public GeneratedCodeInfo Clone() {
            return new GeneratedCodeInfo(this);
        }

        /// <summary>Field number for the "annotation" field.</summary>
        public const int AnnotationFieldNumber = 1;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.GeneratedCodeInfo.Types.Annotation> _repeated_annotation_codec
            = FieldCodec.ForMessage(10, global::Google.Protobuf.Reflection.GeneratedCodeInfo.Types.Annotation.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.GeneratedCodeInfo.Types.Annotation> annotation_ = new RepeatedField<global::Google.Protobuf.Reflection.GeneratedCodeInfo.Types.Annotation>();
        /// <summary>
        /// An Annotation connects some span of text in generated code to an element
        /// of its generating .proto file.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.GeneratedCodeInfo.Types.Annotation> Annotation {
            get { return annotation_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as GeneratedCodeInfo);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(GeneratedCodeInfo other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if(!annotation_.Equals(other.annotation_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            hash ^= annotation_.GetHashCode();
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
            annotation_.WriteTo(output, _repeated_annotation_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            size += annotation_.CalculateSize(_repeated_annotation_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(GeneratedCodeInfo other) {
            if (other == null) {
                return;
            }
            annotation_.Add(other.annotation_);
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
                        annotation_.AddEntriesFrom(input, _repeated_annotation_codec);
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the GeneratedCodeInfo message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            internal sealed partial class Annotation : IMessage<Annotation> {
                private static readonly MessageParser<Annotation> _parser = new MessageParser<Annotation>(() => new Annotation());
                private UnknownFieldSet _unknownFields;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageParser<Annotation> Parser { get { return _parser; } }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageDescriptor Descriptor {
                    get { return global::Google.Protobuf.Reflection.GeneratedCodeInfo.Descriptor.NestedTypes[0]; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                MessageDescriptor IMessage.Descriptor {
                    get { return Descriptor; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public Annotation() {
                    OnConstruction();
                }

                partial void OnConstruction();

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public Annotation(Annotation other) : this() {
                    path_ = other.path_.Clone();
                    sourceFile_ = other.sourceFile_;
                    begin_ = other.begin_;
                    end_ = other.end_;
                    _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public Annotation Clone() {
                    return new Annotation(this);
                }

                /// <summary>Field number for the "path" field.</summary>
                public const int PathFieldNumber = 1;
                private static readonly FieldCodec<int> _repeated_path_codec
                    = FieldCodec.ForInt32(10);
                private readonly RepeatedField<int> path_ = new RepeatedField<int>();
                /// <summary>
                /// Identifies the element in the original source .proto file. This field
                /// is formatted the same as SourceCodeInfo.Location.path.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public RepeatedField<int> Path {
                    get { return path_; }
                }

                /// <summary>Field number for the "source_file" field.</summary>
                public const int SourceFileFieldNumber = 2;
                private string sourceFile_ = "";
                /// <summary>
                /// Identifies the filesystem path to the original source .proto.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public string SourceFile {
                    get { return sourceFile_; }
                    set {
                        sourceFile_ = ProtoPreconditions.CheckNotNull(value, "value");
                    }
                }

                /// <summary>Field number for the "begin" field.</summary>
                public const int BeginFieldNumber = 3;
                private int begin_;
                /// <summary>
                /// Identifies the starting offset in bytes in the generated code
                /// that relates to the identified object.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int Begin {
                    get { return begin_; }
                    set {
                        begin_ = value;
                    }
                }

                /// <summary>Field number for the "end" field.</summary>
                public const int EndFieldNumber = 4;
                private int end_;
                /// <summary>
                /// Identifies the ending offset in bytes in the generated code that
                /// relates to the identified offset. The end offset should be one past
                /// the last relevant byte (so the length of the text = end - begin).
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
                    return Equals(other as Annotation);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool Equals(Annotation other) {
                    if (ReferenceEquals(other, null)) {
                        return false;
                    }
                    if (ReferenceEquals(other, this)) {
                        return true;
                    }
                    if(!path_.Equals(other.path_)) return false;
                    if (SourceFile != other.SourceFile) return false;
                    if (Begin != other.Begin) return false;
                    if (End != other.End) return false;
                    return Equals(_unknownFields, other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override int GetHashCode() {
                    int hash = 1;
                    hash ^= path_.GetHashCode();
                    if (SourceFile.Length != 0) hash ^= SourceFile.GetHashCode();
                    if (Begin != 0) hash ^= Begin.GetHashCode();
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
                    path_.WriteTo(output, _repeated_path_codec);
                    if (SourceFile.Length != 0) {
                        output.WriteRawTag(18);
                        output.WriteString(SourceFile);
                    }
                    if (Begin != 0) {
                        output.WriteRawTag(24);
                        output.WriteInt32(Begin);
                    }
                    if (End != 0) {
                        output.WriteRawTag(32);
                        output.WriteInt32(End);
                    }
                    if (_unknownFields != null) {
                        _unknownFields.WriteTo(output);
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int CalculateSize() {
                    int size = 0;
                    size += path_.CalculateSize(_repeated_path_codec);
                    if (SourceFile.Length != 0) {
                        size += 1 + CodedOutputStream.ComputeStringSize(SourceFile);
                    }
                    if (Begin != 0) {
                        size += 1 + CodedOutputStream.ComputeInt32Size(Begin);
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
                public void MergeFrom(Annotation other) {
                    if (other == null) {
                        return;
                    }
                    path_.Add(other.path_);
                    if (other.SourceFile.Length != 0) {
                        SourceFile = other.SourceFile;
                    }
                    if (other.Begin != 0) {
                        Begin = other.Begin;
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
                            case 10:
                            case 8: {
                                path_.AddEntriesFrom(input, _repeated_path_codec);
                                break;
                            }
                            case 18: {
                                SourceFile = input.ReadString();
                                break;
                            }
                            case 24: {
                                Begin = input.ReadInt32();
                                break;
                            }
                            case 32: {
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