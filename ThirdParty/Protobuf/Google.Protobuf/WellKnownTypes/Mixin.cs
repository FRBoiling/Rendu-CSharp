using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// Declares an API Interface to be included in this interface. The including
    /// interface must redeclare all the methods from the included interface, but
    /// documentation and options are inherited as follows:
    ///
    /// - If after comment and whitespace stripping, the documentation
    ///   string of the redeclared method is empty, it will be inherited
    ///   from the original method.
    ///
    /// - Each annotation belonging to the service config (http,
    ///   visibility) which is not set in the redeclared method will be
    ///   inherited.
    ///
    /// - If an http annotation is inherited, the path pattern will be
    ///   modified as follows. Any version prefix will be replaced by the
    ///   version of the including interface plus the [root][] path if
    ///   specified.
    ///
    /// Example of a simple mixin:
    ///
    ///     package google.acl.v1;
    ///     service AccessControl {
    ///       // Get the underlying ACL object.
    ///       rpc GetAcl(GetAclRequest) returns (Acl) {
    ///         option (google.api.http).get = "/v1/{resource=**}:getAcl";
    ///       }
    ///     }
    ///
    ///     package google.storage.v2;
    ///     service Storage {
    ///       rpc GetAcl(GetAclRequest) returns (Acl);
    ///
    ///       // Get a data record.
    ///       rpc GetData(GetDataRequest) returns (Data) {
    ///         option (google.api.http).get = "/v2/{resource=**}";
    ///       }
    ///     }
    ///
    /// Example of a mixin configuration:
    ///
    ///     apis:
    ///     - name: google.storage.v2.Storage
    ///       mixins:
    ///       - name: google.acl.v1.AccessControl
    ///
    /// The mixin construct implies that all methods in `AccessControl` are
    /// also declared with same name and request/response types in
    /// `Storage`. A documentation generator or annotation processor will
    /// see the effective `Storage.GetAcl` method after inherting
    /// documentation and annotations as follows:
    ///
    ///     service Storage {
    ///       // Get the underlying ACL object.
    ///       rpc GetAcl(GetAclRequest) returns (Acl) {
    ///         option (google.api.http).get = "/v2/{resource=**}:getAcl";
    ///       }
    ///       ...
    ///     }
    ///
    /// Note how the version in the path pattern changed from `v1` to `v2`.
    ///
    /// If the `root` field in the mixin is specified, it should be a
    /// relative path under which inherited HTTP paths are placed. Example:
    ///
    ///     apis:
    ///     - name: google.storage.v2.Storage
    ///       mixins:
    ///       - name: google.acl.v1.AccessControl
    ///         root: acls
    ///
    /// This implies the following inherited HTTP annotation:
    ///
    ///     service Storage {
    ///       // Get the underlying ACL object.
    ///       rpc GetAcl(GetAclRequest) returns (Acl) {
    ///         option (google.api.http).get = "/v2/acls/{resource=**}:getAcl";
    ///       }
    ///       ...
    ///     }
    /// </summary>
    public sealed partial class Mixin : IMessage<Mixin> {
        private static readonly MessageParser<Mixin> _parser = new MessageParser<Mixin>(() => new Mixin());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<Mixin> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.ApiReflection.Descriptor.MessageTypes[2]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Mixin() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Mixin(Mixin other) : this() {
            name_ = other.name_;
            root_ = other.root_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Mixin Clone() {
            return new Mixin(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;
        private string name_ = "";
        /// <summary>
        /// The fully qualified name of the interface which is included.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name {
            get { return name_; }
            set {
                name_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "root" field.</summary>
        public const int RootFieldNumber = 2;
        private string root_ = "";
        /// <summary>
        /// If non-empty specifies a path under which inherited HTTP paths
        /// are rooted.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Root {
            get { return root_; }
            set {
                root_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as Mixin);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Mixin other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Name != other.Name) return false;
            if (Root != other.Root) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (Root.Length != 0) hash ^= Root.GetHashCode();
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
            if (Root.Length != 0) {
                output.WriteRawTag(18);
                output.WriteString(Root);
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
            if (Root.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Root);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Mixin other) {
            if (other == null) {
                return;
            }
            if (other.Name.Length != 0) {
                Name = other.Name;
            }
            if (other.Root.Length != 0) {
                Root = other.Root;
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
                        Root = input.ReadString();
                        break;
                    }
                }
            }
        }

    }
}