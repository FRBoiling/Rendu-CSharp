using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// The protocol compiler can output a FileDescriptorSet containing the .proto
    /// files it parses.
    /// </summary>
    internal sealed partial class FileDescriptorSet : IMessage<FileDescriptorSet> {
        private static readonly MessageParser<FileDescriptorSet> _parser = new MessageParser<FileDescriptorSet>(() => new FileDescriptorSet());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<FileDescriptorSet> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileDescriptorSet() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileDescriptorSet(FileDescriptorSet other) : this() {
            file_ = other.file_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileDescriptorSet Clone() {
            return new FileDescriptorSet(this);
        }

        /// <summary>Field number for the "file" field.</summary>
        public const int FileFieldNumber = 1;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.FileDescriptorProto> _repeated_file_codec
            = FieldCodec.ForMessage(10, global::Google.Protobuf.Reflection.FileDescriptorProto.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.FileDescriptorProto> file_ = new RepeatedField<global::Google.Protobuf.Reflection.FileDescriptorProto>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.FileDescriptorProto> File {
            get { return file_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as FileDescriptorSet);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(FileDescriptorSet other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if(!file_.Equals(other.file_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            hash ^= file_.GetHashCode();
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
            file_.WriteTo(output, _repeated_file_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            size += file_.CalculateSize(_repeated_file_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(FileDescriptorSet other) {
            if (other == null) {
                return;
            }
            file_.Add(other.file_);
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
                        file_.AddEntriesFrom(input, _repeated_file_codec);
                        break;
                    }
                }
            }
        }

    }
}