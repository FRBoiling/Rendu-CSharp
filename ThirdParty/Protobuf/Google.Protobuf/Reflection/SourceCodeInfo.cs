using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Encapsulates information about the original source file from which a
    /// FileDescriptorProto was generated.
    /// </summary>
    internal sealed partial class SourceCodeInfo : IMessage<SourceCodeInfo> {
        private static readonly MessageParser<SourceCodeInfo> _parser = new MessageParser<SourceCodeInfo>(() => new SourceCodeInfo());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<SourceCodeInfo> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[19]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SourceCodeInfo() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SourceCodeInfo(SourceCodeInfo other) : this() {
            location_ = other.location_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SourceCodeInfo Clone() {
            return new SourceCodeInfo(this);
        }

        /// <summary>Field number for the "location" field.</summary>
        public const int LocationFieldNumber = 1;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.SourceCodeInfo.Types.Location> _repeated_location_codec
            = FieldCodec.ForMessage(10, global::Google.Protobuf.Reflection.SourceCodeInfo.Types.Location.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.SourceCodeInfo.Types.Location> location_ = new RepeatedField<global::Google.Protobuf.Reflection.SourceCodeInfo.Types.Location>();
        /// <summary>
        /// A Location identifies a piece of source code in a .proto file which
        /// corresponds to a particular definition.  This information is intended
        /// to be useful to IDEs, code indexers, documentation generators, and similar
        /// tools.
        ///
        /// For example, say we have a file like:
        ///   message Foo {
        ///     optional string foo = 1;
        ///   }
        /// Let's look at just the field definition:
        ///   optional string foo = 1;
        ///   ^       ^^     ^^  ^  ^^^
        ///   a       bc     de  f  ghi
        /// We have the following locations:
        ///   span   path               represents
        ///   [a,i)  [ 4, 0, 2, 0 ]     The whole field definition.
        ///   [a,b)  [ 4, 0, 2, 0, 4 ]  The label (optional).
        ///   [c,d)  [ 4, 0, 2, 0, 5 ]  The type (string).
        ///   [e,f)  [ 4, 0, 2, 0, 1 ]  The name (foo).
        ///   [g,h)  [ 4, 0, 2, 0, 3 ]  The number (1).
        ///
        /// Notes:
        /// - A location may refer to a repeated field itself (i.e. not to any
        ///   particular index within it).  This is used whenever a set of elements are
        ///   logically enclosed in a single code segment.  For example, an entire
        ///   extend block (possibly containing multiple extension definitions) will
        ///   have an outer location whose path refers to the "extensions" repeated
        ///   field without an index.
        /// - Multiple locations may have the same path.  This happens when a single
        ///   logical declaration is spread out across multiple places.  The most
        ///   obvious example is the "extend" block again -- there may be multiple
        ///   extend blocks in the same scope, each of which will have the same path.
        /// - A location's span is not always a subset of its parent's span.  For
        ///   example, the "extendee" of an extension declaration appears at the
        ///   beginning of the "extend" block and is shared by all extensions within
        ///   the block.
        /// - Just because a location's span is a subset of some other location's span
        ///   does not mean that it is a descendent.  For example, a "group" defines
        ///   both a type and a field in a single declaration.  Thus, the locations
        ///   corresponding to the type and field and their components will overlap.
        /// - Code which tries to interpret locations should probably be designed to
        ///   ignore those that it doesn't understand, as more types of locations could
        ///   be recorded in the future.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.SourceCodeInfo.Types.Location> Location {
            get { return location_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as SourceCodeInfo);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(SourceCodeInfo other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if(!location_.Equals(other.location_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            hash ^= location_.GetHashCode();
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
            location_.WriteTo(output, _repeated_location_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            size += location_.CalculateSize(_repeated_location_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(SourceCodeInfo other) {
            if (other == null) {
                return;
            }
            location_.Add(other.location_);
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
                        location_.AddEntriesFrom(input, _repeated_location_codec);
                        break;
                    }
                }
            }
        }

        #region Nested types
        /// <summary>Container for nested types declared in the SourceCodeInfo message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            internal sealed partial class Location : IMessage<Location> {
                private static readonly MessageParser<Location> _parser = new MessageParser<Location>(() => new Location());
                private UnknownFieldSet _unknownFields;
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageParser<Location> Parser { get { return _parser; } }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public static MessageDescriptor Descriptor {
                    get { return global::Google.Protobuf.Reflection.SourceCodeInfo.Descriptor.NestedTypes[0]; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                MessageDescriptor IMessage.Descriptor {
                    get { return Descriptor; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public Location() {
                    OnConstruction();
                }

                partial void OnConstruction();

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public Location(Location other) : this() {
                    path_ = other.path_.Clone();
                    span_ = other.span_.Clone();
                    leadingComments_ = other.leadingComments_;
                    trailingComments_ = other.trailingComments_;
                    leadingDetachedComments_ = other.leadingDetachedComments_.Clone();
                    _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public Location Clone() {
                    return new Location(this);
                }

                /// <summary>Field number for the "path" field.</summary>
                public const int PathFieldNumber = 1;
                private static readonly FieldCodec<int> _repeated_path_codec
                    = FieldCodec.ForInt32(10);
                private readonly RepeatedField<int> path_ = new RepeatedField<int>();
                /// <summary>
                /// Identifies which part of the FileDescriptorProto was defined at this
                /// location.
                ///
                /// Each element is a field number or an index.  They form a path from
                /// the root FileDescriptorProto to the place where the definition.  For
                /// example, this path:
                ///   [ 4, 3, 2, 7, 1 ]
                /// refers to:
                ///   file.message_type(3)  // 4, 3
                ///       .field(7)         // 2, 7
                ///       .name()           // 1
                /// This is because FileDescriptorProto.message_type has field number 4:
                ///   repeated DescriptorProto message_type = 4;
                /// and DescriptorProto.field has field number 2:
                ///   repeated FieldDescriptorProto field = 2;
                /// and FieldDescriptorProto.name has field number 1:
                ///   optional string name = 1;
                ///
                /// Thus, the above path gives the location of a field name.  If we removed
                /// the last element:
                ///   [ 4, 3, 2, 7 ]
                /// this path refers to the whole field declaration (from the beginning
                /// of the label to the terminating semicolon).
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public RepeatedField<int> Path {
                    get { return path_; }
                }

                /// <summary>Field number for the "span" field.</summary>
                public const int SpanFieldNumber = 2;
                private static readonly FieldCodec<int> _repeated_span_codec
                    = FieldCodec.ForInt32(18);
                private readonly RepeatedField<int> span_ = new RepeatedField<int>();
                /// <summary>
                /// Always has exactly three or four elements: start line, start column,
                /// end line (optional, otherwise assumed same as start line), end column.
                /// These are packed into a single field for efficiency.  Note that line
                /// and column numbers are zero-based -- typically you will want to add
                /// 1 to each before displaying to a user.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public RepeatedField<int> Span {
                    get { return span_; }
                }

                /// <summary>Field number for the "leading_comments" field.</summary>
                public const int LeadingCommentsFieldNumber = 3;
                private string leadingComments_ = "";
                /// <summary>
                /// If this SourceCodeInfo represents a complete declaration, these are any
                /// comments appearing before and after the declaration which appear to be
                /// attached to the declaration.
                ///
                /// A series of line comments appearing on consecutive lines, with no other
                /// tokens appearing on those lines, will be treated as a single comment.
                ///
                /// leading_detached_comments will keep paragraphs of comments that appear
                /// before (but not connected to) the current element. Each paragraph,
                /// separated by empty lines, will be one comment element in the repeated
                /// field.
                ///
                /// Only the comment content is provided; comment markers (e.g. //) are
                /// stripped out.  For block comments, leading whitespace and an asterisk
                /// will be stripped from the beginning of each line other than the first.
                /// Newlines are included in the output.
                ///
                /// Examples:
                ///
                ///   optional int32 foo = 1;  // Comment attached to foo.
                ///   // Comment attached to bar.
                ///   optional int32 bar = 2;
                ///
                ///   optional string baz = 3;
                ///   // Comment attached to baz.
                ///   // Another line attached to baz.
                ///
                ///   // Comment attached to qux.
                ///   //
                ///   // Another line attached to qux.
                ///   optional double qux = 4;
                ///
                ///   // Detached comment for corge. This is not leading or trailing comments
                ///   // to qux or corge because there are blank lines separating it from
                ///   // both.
                ///
                ///   // Detached comment for corge paragraph 2.
                ///
                ///   optional string corge = 5;
                ///   /* Block comment attached
                ///    * to corge.  Leading asterisks
                ///    * will be removed. */
                ///   /* Block comment attached to
                ///    * grault. */
                ///   optional int32 grault = 6;
                ///
                ///   // ignored detached comments.
                /// </summary>
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public string LeadingComments {
                    get { return leadingComments_; }
                    set {
                        leadingComments_ = ProtoPreconditions.CheckNotNull(value, "value");
                    }
                }

                /// <summary>Field number for the "trailing_comments" field.</summary>
                public const int TrailingCommentsFieldNumber = 4;
                private string trailingComments_ = "";
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public string TrailingComments {
                    get { return trailingComments_; }
                    set {
                        trailingComments_ = ProtoPreconditions.CheckNotNull(value, "value");
                    }
                }

                /// <summary>Field number for the "leading_detached_comments" field.</summary>
                public const int LeadingDetachedCommentsFieldNumber = 6;
                private static readonly FieldCodec<string> _repeated_leadingDetachedComments_codec
                    = FieldCodec.ForString(50);
                private readonly RepeatedField<string> leadingDetachedComments_ = new RepeatedField<string>();
                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public RepeatedField<string> LeadingDetachedComments {
                    get { return leadingDetachedComments_; }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override bool Equals(object other) {
                    return Equals(other as Location);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public bool Equals(Location other) {
                    if (ReferenceEquals(other, null)) {
                        return false;
                    }
                    if (ReferenceEquals(other, this)) {
                        return true;
                    }
                    if(!path_.Equals(other.path_)) return false;
                    if(!span_.Equals(other.span_)) return false;
                    if (LeadingComments != other.LeadingComments) return false;
                    if (TrailingComments != other.TrailingComments) return false;
                    if(!leadingDetachedComments_.Equals(other.leadingDetachedComments_)) return false;
                    return Equals(_unknownFields, other._unknownFields);
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public override int GetHashCode() {
                    int hash = 1;
                    hash ^= path_.GetHashCode();
                    hash ^= span_.GetHashCode();
                    if (LeadingComments.Length != 0) hash ^= LeadingComments.GetHashCode();
                    if (TrailingComments.Length != 0) hash ^= TrailingComments.GetHashCode();
                    hash ^= leadingDetachedComments_.GetHashCode();
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
                    span_.WriteTo(output, _repeated_span_codec);
                    if (LeadingComments.Length != 0) {
                        output.WriteRawTag(26);
                        output.WriteString(LeadingComments);
                    }
                    if (TrailingComments.Length != 0) {
                        output.WriteRawTag(34);
                        output.WriteString(TrailingComments);
                    }
                    leadingDetachedComments_.WriteTo(output, _repeated_leadingDetachedComments_codec);
                    if (_unknownFields != null) {
                        _unknownFields.WriteTo(output);
                    }
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public int CalculateSize() {
                    int size = 0;
                    size += path_.CalculateSize(_repeated_path_codec);
                    size += span_.CalculateSize(_repeated_span_codec);
                    if (LeadingComments.Length != 0) {
                        size += 1 + CodedOutputStream.ComputeStringSize(LeadingComments);
                    }
                    if (TrailingComments.Length != 0) {
                        size += 1 + CodedOutputStream.ComputeStringSize(TrailingComments);
                    }
                    size += leadingDetachedComments_.CalculateSize(_repeated_leadingDetachedComments_codec);
                    if (_unknownFields != null) {
                        size += _unknownFields.CalculateSize();
                    }
                    return size;
                }

                [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
                public void MergeFrom(Location other) {
                    if (other == null) {
                        return;
                    }
                    path_.Add(other.path_);
                    span_.Add(other.span_);
                    if (other.LeadingComments.Length != 0) {
                        LeadingComments = other.LeadingComments;
                    }
                    if (other.TrailingComments.Length != 0) {
                        TrailingComments = other.TrailingComments;
                    }
                    leadingDetachedComments_.Add(other.leadingDetachedComments_);
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
                            case 18:
                            case 16: {
                                span_.AddEntriesFrom(input, _repeated_span_codec);
                                break;
                            }
                            case 26: {
                                LeadingComments = input.ReadString();
                                break;
                            }
                            case 34: {
                                TrailingComments = input.ReadString();
                                break;
                            }
                            case 50: {
                                leadingDetachedComments_.AddEntriesFrom(input, _repeated_leadingDetachedComments_codec);
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