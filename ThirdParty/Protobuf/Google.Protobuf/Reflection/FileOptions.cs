using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
    internal sealed partial class FileOptions : IMessage<FileOptions> {
        private static readonly MessageParser<FileOptions> _parser = new MessageParser<FileOptions>(() => new FileOptions());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<FileOptions> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor.MessageTypes[10]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        internal CustomOptions CustomOptions{ get; private set; } = CustomOptions.Empty;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileOptions() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileOptions(FileOptions other) : this() {
            javaPackage_ = other.javaPackage_;
            javaOuterClassname_ = other.javaOuterClassname_;
            javaMultipleFiles_ = other.javaMultipleFiles_;
            javaGenerateEqualsAndHash_ = other.javaGenerateEqualsAndHash_;
            javaStringCheckUtf8_ = other.javaStringCheckUtf8_;
            optimizeFor_ = other.optimizeFor_;
            goPackage_ = other.goPackage_;
            ccGenericServices_ = other.ccGenericServices_;
            javaGenericServices_ = other.javaGenericServices_;
            pyGenericServices_ = other.pyGenericServices_;
            phpGenericServices_ = other.phpGenericServices_;
            deprecated_ = other.deprecated_;
            ccEnableArenas_ = other.ccEnableArenas_;
            objcClassPrefix_ = other.objcClassPrefix_;
            csharpNamespace_ = other.csharpNamespace_;
            swiftPrefix_ = other.swiftPrefix_;
            phpClassPrefix_ = other.phpClassPrefix_;
            phpNamespace_ = other.phpNamespace_;
            phpMetadataNamespace_ = other.phpMetadataNamespace_;
            rubyPackage_ = other.rubyPackage_;
            uninterpretedOption_ = other.uninterpretedOption_.Clone();
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public FileOptions Clone() {
            return new FileOptions(this);
        }

        /// <summary>Field number for the "java_package" field.</summary>
        public const int JavaPackageFieldNumber = 1;
        private string javaPackage_ = "";
        /// <summary>
        /// Sets the Java package where classes generated from this .proto will be
        /// placed.  By default, the proto package is used, but this is often
        /// inappropriate because proto packages do not normally start with backwards
        /// domain names.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string JavaPackage {
            get { return javaPackage_; }
            set {
                javaPackage_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "java_outer_classname" field.</summary>
        public const int JavaOuterClassnameFieldNumber = 8;
        private string javaOuterClassname_ = "";
        /// <summary>
        /// If set, all the classes from the .proto file are wrapped in a single
        /// outer class with the given name.  This applies to both Proto1
        /// (equivalent to the old "--one_java_file" option) and Proto2 (where
        /// a .proto always translates to a single class, but you may want to
        /// explicitly choose the class name).
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string JavaOuterClassname {
            get { return javaOuterClassname_; }
            set {
                javaOuterClassname_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "java_multiple_files" field.</summary>
        public const int JavaMultipleFilesFieldNumber = 10;
        private bool javaMultipleFiles_;
        /// <summary>
        /// If set true, then the Java code generator will generate a separate .java
        /// file for each top-level message, enum, and service defined in the .proto
        /// file.  Thus, these types will *not* be nested inside the outer class
        /// named by java_outer_classname.  However, the outer class will still be
        /// generated to contain the file's getDescriptor() method as well as any
        /// top-level extensions defined in the file.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool JavaMultipleFiles {
            get { return javaMultipleFiles_; }
            set {
                javaMultipleFiles_ = value;
            }
        }

        /// <summary>Field number for the "java_generate_equals_and_hash" field.</summary>
        public const int JavaGenerateEqualsAndHashFieldNumber = 20;
        private bool javaGenerateEqualsAndHash_;
        /// <summary>
        /// This option does nothing.
        /// </summary>
        [global::System.ObsoleteAttribute]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool JavaGenerateEqualsAndHash {
            get { return javaGenerateEqualsAndHash_; }
            set {
                javaGenerateEqualsAndHash_ = value;
            }
        }

        /// <summary>Field number for the "java_string_check_utf8" field.</summary>
        public const int JavaStringCheckUtf8FieldNumber = 27;
        private bool javaStringCheckUtf8_;
        /// <summary>
        /// If set true, then the Java2 code generator will generate code that
        /// throws an exception whenever an attempt is made to assign a non-UTF-8
        /// byte sequence to a string field.
        /// MessageBuilder reflection will do the same.
        /// However, an extension field still accepts non-UTF-8 byte sequences.
        /// This option has no effect on when used with the lite runtime.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool JavaStringCheckUtf8 {
            get { return javaStringCheckUtf8_; }
            set {
                javaStringCheckUtf8_ = value;
            }
        }

        /// <summary>Field number for the "optimize_for" field.</summary>
        public const int OptimizeForFieldNumber = 9;
        private global::Google.Protobuf.Reflection.FileOptions.Types.OptimizeMode optimizeFor_ = 0;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Reflection.FileOptions.Types.OptimizeMode OptimizeFor {
            get { return optimizeFor_; }
            set {
                optimizeFor_ = value;
            }
        }

        /// <summary>Field number for the "go_package" field.</summary>
        public const int GoPackageFieldNumber = 11;
        private string goPackage_ = "";
        /// <summary>
        /// Sets the Go package where structs generated from this .proto will be
        /// placed. If omitted, the Go package will be derived from the following:
        ///   - The basename of the package import path, if provided.
        ///   - Otherwise, the package statement in the .proto file, if present.
        ///   - Otherwise, the basename of the .proto file, without extension.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string GoPackage {
            get { return goPackage_; }
            set {
                goPackage_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "cc_generic_services" field.</summary>
        public const int CcGenericServicesFieldNumber = 16;
        private bool ccGenericServices_;
        /// <summary>
        /// Should generic services be generated in each language?  "Generic" services
        /// are not specific to any particular RPC system.  They are generated by the
        /// main code generators in each language (without additional plugins).
        /// Generic services were the only kind of service generation supported by
        /// early versions of google.protobuf.
        ///
        /// Generic services are now considered deprecated in favor of using plugins
        /// that generate code specific to your particular RPC system.  Therefore,
        /// these default to false.  Old code which depends on generic services should
        /// explicitly set them to true.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool CcGenericServices {
            get { return ccGenericServices_; }
            set {
                ccGenericServices_ = value;
            }
        }

        /// <summary>Field number for the "java_generic_services" field.</summary>
        public const int JavaGenericServicesFieldNumber = 17;
        private bool javaGenericServices_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool JavaGenericServices {
            get { return javaGenericServices_; }
            set {
                javaGenericServices_ = value;
            }
        }

        /// <summary>Field number for the "py_generic_services" field.</summary>
        public const int PyGenericServicesFieldNumber = 18;
        private bool pyGenericServices_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool PyGenericServices {
            get { return pyGenericServices_; }
            set {
                pyGenericServices_ = value;
            }
        }

        /// <summary>Field number for the "php_generic_services" field.</summary>
        public const int PhpGenericServicesFieldNumber = 42;
        private bool phpGenericServices_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool PhpGenericServices {
            get { return phpGenericServices_; }
            set {
                phpGenericServices_ = value;
            }
        }

        /// <summary>Field number for the "deprecated" field.</summary>
        public const int DeprecatedFieldNumber = 23;
        private bool deprecated_;
        /// <summary>
        /// Is this file deprecated?
        /// Depending on the target platform, this can emit Deprecated annotations
        /// for everything in the file, or it will be completely ignored; in the very
        /// least, this is a formalization for deprecating files.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Deprecated {
            get { return deprecated_; }
            set {
                deprecated_ = value;
            }
        }

        /// <summary>Field number for the "cc_enable_arenas" field.</summary>
        public const int CcEnableArenasFieldNumber = 31;
        private bool ccEnableArenas_;
        /// <summary>
        /// Enables the use of arenas for the proto messages in this file. This applies
        /// only to generated classes for C++.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool CcEnableArenas {
            get { return ccEnableArenas_; }
            set {
                ccEnableArenas_ = value;
            }
        }

        /// <summary>Field number for the "objc_class_prefix" field.</summary>
        public const int ObjcClassPrefixFieldNumber = 36;
        private string objcClassPrefix_ = "";
        /// <summary>
        /// Sets the objective c class prefix which is prepended to all objective c
        /// generated classes from this .proto. There is no default.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string ObjcClassPrefix {
            get { return objcClassPrefix_; }
            set {
                objcClassPrefix_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "csharp_namespace" field.</summary>
        public const int CsharpNamespaceFieldNumber = 37;
        private string csharpNamespace_ = "";
        /// <summary>
        /// Namespace for generated classes; defaults to the package.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string CsharpNamespace {
            get { return csharpNamespace_; }
            set {
                csharpNamespace_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "swift_prefix" field.</summary>
        public const int SwiftPrefixFieldNumber = 39;
        private string swiftPrefix_ = "";
        /// <summary>
        /// By default Swift generators will take the proto package and CamelCase it
        /// replacing '.' with underscore and use that to prefix the types/symbols
        /// defined. When this options is provided, they will use this value instead
        /// to prefix the types/symbols defined.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string SwiftPrefix {
            get { return swiftPrefix_; }
            set {
                swiftPrefix_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "php_class_prefix" field.</summary>
        public const int PhpClassPrefixFieldNumber = 40;
        private string phpClassPrefix_ = "";
        /// <summary>
        /// Sets the php class prefix which is prepended to all php generated classes
        /// from this .proto. Default is empty.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string PhpClassPrefix {
            get { return phpClassPrefix_; }
            set {
                phpClassPrefix_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "php_namespace" field.</summary>
        public const int PhpNamespaceFieldNumber = 41;
        private string phpNamespace_ = "";
        /// <summary>
        /// Use this option to change the namespace of php generated classes. Default
        /// is empty. When this option is empty, the package name will be used for
        /// determining the namespace.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string PhpNamespace {
            get { return phpNamespace_; }
            set {
                phpNamespace_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "php_metadata_namespace" field.</summary>
        public const int PhpMetadataNamespaceFieldNumber = 44;
        private string phpMetadataNamespace_ = "";
        /// <summary>
        /// Use this option to change the namespace of php generated metadata classes.
        /// Default is empty. When this option is empty, the proto file name will be used
        /// for determining the namespace.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string PhpMetadataNamespace {
            get { return phpMetadataNamespace_; }
            set {
                phpMetadataNamespace_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "ruby_package" field.</summary>
        public const int RubyPackageFieldNumber = 45;
        private string rubyPackage_ = "";
        /// <summary>
        /// Use this option to change the package of ruby generated classes. Default
        /// is empty. When this option is not set, the package name will be used for
        /// determining the ruby package.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string RubyPackage {
            get { return rubyPackage_; }
            set {
                rubyPackage_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "uninterpreted_option" field.</summary>
        public const int UninterpretedOptionFieldNumber = 999;
        private static readonly FieldCodec<global::Google.Protobuf.Reflection.UninterpretedOption> _repeated_uninterpretedOption_codec
            = FieldCodec.ForMessage(7994, global::Google.Protobuf.Reflection.UninterpretedOption.Parser);
        private readonly RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption> uninterpretedOption_ = new RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption>();
        /// <summary>
        /// The parser stores options it doesn't recognize here.
        /// See the documentation for the "Options" section above.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RepeatedField<global::Google.Protobuf.Reflection.UninterpretedOption> UninterpretedOption {
            get { return uninterpretedOption_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as FileOptions);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(FileOptions other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (JavaPackage != other.JavaPackage) return false;
            if (JavaOuterClassname != other.JavaOuterClassname) return false;
            if (JavaMultipleFiles != other.JavaMultipleFiles) return false;
            if (JavaGenerateEqualsAndHash != other.JavaGenerateEqualsAndHash) return false;
            if (JavaStringCheckUtf8 != other.JavaStringCheckUtf8) return false;
            if (OptimizeFor != other.OptimizeFor) return false;
            if (GoPackage != other.GoPackage) return false;
            if (CcGenericServices != other.CcGenericServices) return false;
            if (JavaGenericServices != other.JavaGenericServices) return false;
            if (PyGenericServices != other.PyGenericServices) return false;
            if (PhpGenericServices != other.PhpGenericServices) return false;
            if (Deprecated != other.Deprecated) return false;
            if (CcEnableArenas != other.CcEnableArenas) return false;
            if (ObjcClassPrefix != other.ObjcClassPrefix) return false;
            if (CsharpNamespace != other.CsharpNamespace) return false;
            if (SwiftPrefix != other.SwiftPrefix) return false;
            if (PhpClassPrefix != other.PhpClassPrefix) return false;
            if (PhpNamespace != other.PhpNamespace) return false;
            if (PhpMetadataNamespace != other.PhpMetadataNamespace) return false;
            if (RubyPackage != other.RubyPackage) return false;
            if(!uninterpretedOption_.Equals(other.uninterpretedOption_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (JavaPackage.Length != 0) hash ^= JavaPackage.GetHashCode();
            if (JavaOuterClassname.Length != 0) hash ^= JavaOuterClassname.GetHashCode();
            if (JavaMultipleFiles != false) hash ^= JavaMultipleFiles.GetHashCode();
            if (JavaGenerateEqualsAndHash != false) hash ^= JavaGenerateEqualsAndHash.GetHashCode();
            if (JavaStringCheckUtf8 != false) hash ^= JavaStringCheckUtf8.GetHashCode();
            if (OptimizeFor != 0) hash ^= OptimizeFor.GetHashCode();
            if (GoPackage.Length != 0) hash ^= GoPackage.GetHashCode();
            if (CcGenericServices != false) hash ^= CcGenericServices.GetHashCode();
            if (JavaGenericServices != false) hash ^= JavaGenericServices.GetHashCode();
            if (PyGenericServices != false) hash ^= PyGenericServices.GetHashCode();
            if (PhpGenericServices != false) hash ^= PhpGenericServices.GetHashCode();
            if (Deprecated != false) hash ^= Deprecated.GetHashCode();
            if (CcEnableArenas != false) hash ^= CcEnableArenas.GetHashCode();
            if (ObjcClassPrefix.Length != 0) hash ^= ObjcClassPrefix.GetHashCode();
            if (CsharpNamespace.Length != 0) hash ^= CsharpNamespace.GetHashCode();
            if (SwiftPrefix.Length != 0) hash ^= SwiftPrefix.GetHashCode();
            if (PhpClassPrefix.Length != 0) hash ^= PhpClassPrefix.GetHashCode();
            if (PhpNamespace.Length != 0) hash ^= PhpNamespace.GetHashCode();
            if (PhpMetadataNamespace.Length != 0) hash ^= PhpMetadataNamespace.GetHashCode();
            if (RubyPackage.Length != 0) hash ^= RubyPackage.GetHashCode();
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
            if (JavaPackage.Length != 0) {
                output.WriteRawTag(10);
                output.WriteString(JavaPackage);
            }
            if (JavaOuterClassname.Length != 0) {
                output.WriteRawTag(66);
                output.WriteString(JavaOuterClassname);
            }
            if (OptimizeFor != 0) {
                output.WriteRawTag(72);
                output.WriteEnum((int) OptimizeFor);
            }
            if (JavaMultipleFiles != false) {
                output.WriteRawTag(80);
                output.WriteBool(JavaMultipleFiles);
            }
            if (GoPackage.Length != 0) {
                output.WriteRawTag(90);
                output.WriteString(GoPackage);
            }
            if (CcGenericServices != false) {
                output.WriteRawTag(128, 1);
                output.WriteBool(CcGenericServices);
            }
            if (JavaGenericServices != false) {
                output.WriteRawTag(136, 1);
                output.WriteBool(JavaGenericServices);
            }
            if (PyGenericServices != false) {
                output.WriteRawTag(144, 1);
                output.WriteBool(PyGenericServices);
            }
            if (JavaGenerateEqualsAndHash != false) {
                output.WriteRawTag(160, 1);
                output.WriteBool(JavaGenerateEqualsAndHash);
            }
            if (Deprecated != false) {
                output.WriteRawTag(184, 1);
                output.WriteBool(Deprecated);
            }
            if (JavaStringCheckUtf8 != false) {
                output.WriteRawTag(216, 1);
                output.WriteBool(JavaStringCheckUtf8);
            }
            if (CcEnableArenas != false) {
                output.WriteRawTag(248, 1);
                output.WriteBool(CcEnableArenas);
            }
            if (ObjcClassPrefix.Length != 0) {
                output.WriteRawTag(162, 2);
                output.WriteString(ObjcClassPrefix);
            }
            if (CsharpNamespace.Length != 0) {
                output.WriteRawTag(170, 2);
                output.WriteString(CsharpNamespace);
            }
            if (SwiftPrefix.Length != 0) {
                output.WriteRawTag(186, 2);
                output.WriteString(SwiftPrefix);
            }
            if (PhpClassPrefix.Length != 0) {
                output.WriteRawTag(194, 2);
                output.WriteString(PhpClassPrefix);
            }
            if (PhpNamespace.Length != 0) {
                output.WriteRawTag(202, 2);
                output.WriteString(PhpNamespace);
            }
            if (PhpGenericServices != false) {
                output.WriteRawTag(208, 2);
                output.WriteBool(PhpGenericServices);
            }
            if (PhpMetadataNamespace.Length != 0) {
                output.WriteRawTag(226, 2);
                output.WriteString(PhpMetadataNamespace);
            }
            if (RubyPackage.Length != 0) {
                output.WriteRawTag(234, 2);
                output.WriteString(RubyPackage);
            }
            uninterpretedOption_.WriteTo(output, _repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (JavaPackage.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(JavaPackage);
            }
            if (JavaOuterClassname.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(JavaOuterClassname);
            }
            if (JavaMultipleFiles != false) {
                size += 1 + 1;
            }
            if (JavaGenerateEqualsAndHash != false) {
                size += 2 + 1;
            }
            if (JavaStringCheckUtf8 != false) {
                size += 2 + 1;
            }
            if (OptimizeFor != 0) {
                size += 1 + CodedOutputStream.ComputeEnumSize((int) OptimizeFor);
            }
            if (GoPackage.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(GoPackage);
            }
            if (CcGenericServices != false) {
                size += 2 + 1;
            }
            if (JavaGenericServices != false) {
                size += 2 + 1;
            }
            if (PyGenericServices != false) {
                size += 2 + 1;
            }
            if (PhpGenericServices != false) {
                size += 2 + 1;
            }
            if (Deprecated != false) {
                size += 2 + 1;
            }
            if (CcEnableArenas != false) {
                size += 2 + 1;
            }
            if (ObjcClassPrefix.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(ObjcClassPrefix);
            }
            if (CsharpNamespace.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(CsharpNamespace);
            }
            if (SwiftPrefix.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(SwiftPrefix);
            }
            if (PhpClassPrefix.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(PhpClassPrefix);
            }
            if (PhpNamespace.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(PhpNamespace);
            }
            if (PhpMetadataNamespace.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(PhpMetadataNamespace);
            }
            if (RubyPackage.Length != 0) {
                size += 2 + CodedOutputStream.ComputeStringSize(RubyPackage);
            }
            size += uninterpretedOption_.CalculateSize(_repeated_uninterpretedOption_codec);
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(FileOptions other) {
            if (other == null) {
                return;
            }
            if (other.JavaPackage.Length != 0) {
                JavaPackage = other.JavaPackage;
            }
            if (other.JavaOuterClassname.Length != 0) {
                JavaOuterClassname = other.JavaOuterClassname;
            }
            if (other.JavaMultipleFiles != false) {
                JavaMultipleFiles = other.JavaMultipleFiles;
            }
            if (other.JavaGenerateEqualsAndHash != false) {
                JavaGenerateEqualsAndHash = other.JavaGenerateEqualsAndHash;
            }
            if (other.JavaStringCheckUtf8 != false) {
                JavaStringCheckUtf8 = other.JavaStringCheckUtf8;
            }
            if (other.OptimizeFor != 0) {
                OptimizeFor = other.OptimizeFor;
            }
            if (other.GoPackage.Length != 0) {
                GoPackage = other.GoPackage;
            }
            if (other.CcGenericServices != false) {
                CcGenericServices = other.CcGenericServices;
            }
            if (other.JavaGenericServices != false) {
                JavaGenericServices = other.JavaGenericServices;
            }
            if (other.PyGenericServices != false) {
                PyGenericServices = other.PyGenericServices;
            }
            if (other.PhpGenericServices != false) {
                PhpGenericServices = other.PhpGenericServices;
            }
            if (other.Deprecated != false) {
                Deprecated = other.Deprecated;
            }
            if (other.CcEnableArenas != false) {
                CcEnableArenas = other.CcEnableArenas;
            }
            if (other.ObjcClassPrefix.Length != 0) {
                ObjcClassPrefix = other.ObjcClassPrefix;
            }
            if (other.CsharpNamespace.Length != 0) {
                CsharpNamespace = other.CsharpNamespace;
            }
            if (other.SwiftPrefix.Length != 0) {
                SwiftPrefix = other.SwiftPrefix;
            }
            if (other.PhpClassPrefix.Length != 0) {
                PhpClassPrefix = other.PhpClassPrefix;
            }
            if (other.PhpNamespace.Length != 0) {
                PhpNamespace = other.PhpNamespace;
            }
            if (other.PhpMetadataNamespace.Length != 0) {
                PhpMetadataNamespace = other.PhpMetadataNamespace;
            }
            if (other.RubyPackage.Length != 0) {
                RubyPackage = other.RubyPackage;
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
                    case 10: {
                        JavaPackage = input.ReadString();
                        break;
                    }
                    case 66: {
                        JavaOuterClassname = input.ReadString();
                        break;
                    }
                    case 72: {
                        optimizeFor_ = (global::Google.Protobuf.Reflection.FileOptions.Types.OptimizeMode) input.ReadEnum();
                        break;
                    }
                    case 80: {
                        JavaMultipleFiles = input.ReadBool();
                        break;
                    }
                    case 90: {
                        GoPackage = input.ReadString();
                        break;
                    }
                    case 128: {
                        CcGenericServices = input.ReadBool();
                        break;
                    }
                    case 136: {
                        JavaGenericServices = input.ReadBool();
                        break;
                    }
                    case 144: {
                        PyGenericServices = input.ReadBool();
                        break;
                    }
                    case 160: {
                        JavaGenerateEqualsAndHash = input.ReadBool();
                        break;
                    }
                    case 184: {
                        Deprecated = input.ReadBool();
                        break;
                    }
                    case 216: {
                        JavaStringCheckUtf8 = input.ReadBool();
                        break;
                    }
                    case 248: {
                        CcEnableArenas = input.ReadBool();
                        break;
                    }
                    case 290: {
                        ObjcClassPrefix = input.ReadString();
                        break;
                    }
                    case 298: {
                        CsharpNamespace = input.ReadString();
                        break;
                    }
                    case 314: {
                        SwiftPrefix = input.ReadString();
                        break;
                    }
                    case 322: {
                        PhpClassPrefix = input.ReadString();
                        break;
                    }
                    case 330: {
                        PhpNamespace = input.ReadString();
                        break;
                    }
                    case 336: {
                        PhpGenericServices = input.ReadBool();
                        break;
                    }
                    case 354: {
                        PhpMetadataNamespace = input.ReadString();
                        break;
                    }
                    case 362: {
                        RubyPackage = input.ReadString();
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
        /// <summary>Container for nested types declared in the FileOptions message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types {
            /// <summary>
            /// Generated classes can be optimized for speed or code size.
            /// </summary>
            internal enum OptimizeMode {
                /// <summary>
                /// Generate complete code for parsing, serialization,
                /// </summary>
                [OriginalName("SPEED")] Speed = 1,
                /// <summary>
                /// etc.
                /// </summary>
                [OriginalName("CODE_SIZE")] CodeSize = 2,
                /// <summary>
                /// Generate code using MessageLite and the lite runtime.
                /// </summary>
                [OriginalName("LITE_RUNTIME")] LiteRuntime = 3,
            }

        }
        #endregion

    }
}