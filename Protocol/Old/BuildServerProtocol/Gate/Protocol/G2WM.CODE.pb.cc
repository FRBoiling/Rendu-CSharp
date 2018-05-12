// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: Gate/Protocol/G2WM.CODE.proto

#include "Gate/Protocol/G2WM.CODE.pb.h"

#include <algorithm>

#include <google/protobuf/stubs/common.h>
#include <google/protobuf/stubs/port.h>
#include <google/protobuf/stubs/once.h>
#include <google/protobuf/io/coded_stream.h>
#include <google/protobuf/wire_format_lite_inl.h>
#include <google/protobuf/descriptor.h>
#include <google/protobuf/generated_message_reflection.h>
#include <google/protobuf/reflection_ops.h>
#include <google/protobuf/wire_format.h>
// This is a temporary google only hack
#ifdef GOOGLE_PROTOBUF_ENFORCE_UNIQUENESS
#include "third_party/protobuf/version.h"
#endif
// @@protoc_insertion_point(includes)
namespace Protocol {
namespace Gate {
namespace G2WM {
class MSG_G2WM_HeartbeatDefaultTypeInternal {
 public:
  ::google::protobuf::internal::ExplicitlyConstructed<MSG_G2WM_Heartbeat>
      _instance;
} _MSG_G2WM_Heartbeat_default_instance_;
class MSG_G2WM_CreateRoleIdDefaultTypeInternal {
 public:
  ::google::protobuf::internal::ExplicitlyConstructed<MSG_G2WM_CreateRoleId>
      _instance;
} _MSG_G2WM_CreateRoleId_default_instance_;
}  // namespace G2WM
}  // namespace Gate
}  // namespace Protocol
namespace protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto {
void InitDefaultsMSG_G2WM_HeartbeatImpl() {
  GOOGLE_PROTOBUF_VERIFY_VERSION;

#ifdef GOOGLE_PROTOBUF_ENFORCE_UNIQUENESS
  ::google::protobuf::internal::InitProtobufDefaultsForceUnique();
#else
  ::google::protobuf::internal::InitProtobufDefaults();
#endif  // GOOGLE_PROTOBUF_ENFORCE_UNIQUENESS
  {
    void* ptr = &::Protocol::Gate::G2WM::_MSG_G2WM_Heartbeat_default_instance_;
    new (ptr) ::Protocol::Gate::G2WM::MSG_G2WM_Heartbeat();
    ::google::protobuf::internal::OnShutdownDestroyMessage(ptr);
  }
  ::Protocol::Gate::G2WM::MSG_G2WM_Heartbeat::InitAsDefaultInstance();
}

void InitDefaultsMSG_G2WM_Heartbeat() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &InitDefaultsMSG_G2WM_HeartbeatImpl);
}

void InitDefaultsMSG_G2WM_CreateRoleIdImpl() {
  GOOGLE_PROTOBUF_VERIFY_VERSION;

#ifdef GOOGLE_PROTOBUF_ENFORCE_UNIQUENESS
  ::google::protobuf::internal::InitProtobufDefaultsForceUnique();
#else
  ::google::protobuf::internal::InitProtobufDefaults();
#endif  // GOOGLE_PROTOBUF_ENFORCE_UNIQUENESS
  {
    void* ptr = &::Protocol::Gate::G2WM::_MSG_G2WM_CreateRoleId_default_instance_;
    new (ptr) ::Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId();
    ::google::protobuf::internal::OnShutdownDestroyMessage(ptr);
  }
  ::Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId::InitAsDefaultInstance();
}

void InitDefaultsMSG_G2WM_CreateRoleId() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &InitDefaultsMSG_G2WM_CreateRoleIdImpl);
}

::google::protobuf::Metadata file_level_metadata[2];

const ::google::protobuf::uint32 TableStruct::offsets[] GOOGLE_PROTOBUF_ATTRIBUTE_SECTION_VARIABLE(protodesc_cold) = {
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(::Protocol::Gate::G2WM::MSG_G2WM_Heartbeat, _has_bits_),
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(::Protocol::Gate::G2WM::MSG_G2WM_Heartbeat, _internal_metadata_),
  ~0u,  // no _extensions_
  ~0u,  // no _oneof_case_
  ~0u,  // no _weak_field_map_
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(::Protocol::Gate::G2WM::MSG_G2WM_Heartbeat, uid_),
  0,
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(::Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId, _has_bits_),
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(::Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId, _internal_metadata_),
  ~0u,  // no _extensions_
  ~0u,  // no _oneof_case_
  ~0u,  // no _weak_field_map_
  GOOGLE_PROTOBUF_GENERATED_MESSAGE_FIELD_OFFSET(::Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId, username_),
  0,
};
static const ::google::protobuf::internal::MigrationSchema schemas[] GOOGLE_PROTOBUF_ATTRIBUTE_SECTION_VARIABLE(protodesc_cold) = {
  { 0, 6, sizeof(::Protocol::Gate::G2WM::MSG_G2WM_Heartbeat)},
  { 7, 13, sizeof(::Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId)},
};

static ::google::protobuf::Message const * const file_default_instances[] = {
  reinterpret_cast<const ::google::protobuf::Message*>(&::Protocol::Gate::G2WM::_MSG_G2WM_Heartbeat_default_instance_),
  reinterpret_cast<const ::google::protobuf::Message*>(&::Protocol::Gate::G2WM::_MSG_G2WM_CreateRoleId_default_instance_),
};

void protobuf_AssignDescriptors() {
  AddDescriptors();
  ::google::protobuf::MessageFactory* factory = NULL;
  AssignDescriptors(
      "Gate/Protocol/G2WM.CODE.proto", schemas, file_default_instances, TableStruct::offsets, factory,
      file_level_metadata, NULL, NULL);
}

void protobuf_AssignDescriptorsOnce() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &protobuf_AssignDescriptors);
}

void protobuf_RegisterTypes(const ::std::string&) GOOGLE_PROTOBUF_ATTRIBUTE_COLD;
void protobuf_RegisterTypes(const ::std::string&) {
  protobuf_AssignDescriptorsOnce();
  ::google::protobuf::internal::RegisterAllTypes(file_level_metadata, 2);
}

void AddDescriptorsImpl() {
  InitDefaults();
  static const char descriptor[] GOOGLE_PROTOBUF_ATTRIBUTE_SECTION_VARIABLE(protodesc_cold) = {
      "\n\035Gate/Protocol/G2WM.CODE.proto\022\022Protoco"
      "l.Gate.G2WM\"!\n\022MSG_G2WM_Heartbeat\022\013\n\003UId"
      "\030\001 \002(\005\")\n\025MSG_G2WM_CreateRoleId\022\020\n\010Usern"
      "ame\030\001 \002(\t"
  };
  ::google::protobuf::DescriptorPool::InternalAddGeneratedFile(
      descriptor, 129);
  ::google::protobuf::MessageFactory::InternalRegisterGeneratedFile(
    "Gate/Protocol/G2WM.CODE.proto", &protobuf_RegisterTypes);
}

void AddDescriptors() {
  static GOOGLE_PROTOBUF_DECLARE_ONCE(once);
  ::google::protobuf::GoogleOnceInit(&once, &AddDescriptorsImpl);
}
// Force AddDescriptors() to be called at dynamic initialization time.
struct StaticDescriptorInitializer {
  StaticDescriptorInitializer() {
    AddDescriptors();
  }
} static_descriptor_initializer;
}  // namespace protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto
namespace Protocol {
namespace Gate {
namespace G2WM {

// ===================================================================

void MSG_G2WM_Heartbeat::InitAsDefaultInstance() {
}
#if !defined(_MSC_VER) || _MSC_VER >= 1900
const int MSG_G2WM_Heartbeat::kUIdFieldNumber;
#endif  // !defined(_MSC_VER) || _MSC_VER >= 1900

MSG_G2WM_Heartbeat::MSG_G2WM_Heartbeat()
  : ::google::protobuf::Message(), _internal_metadata_(NULL) {
  if (GOOGLE_PREDICT_TRUE(this != internal_default_instance())) {
    ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::InitDefaultsMSG_G2WM_Heartbeat();
  }
  SharedCtor();
  // @@protoc_insertion_point(constructor:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
}
MSG_G2WM_Heartbeat::MSG_G2WM_Heartbeat(const MSG_G2WM_Heartbeat& from)
  : ::google::protobuf::Message(),
      _internal_metadata_(NULL),
      _has_bits_(from._has_bits_),
      _cached_size_(0) {
  _internal_metadata_.MergeFrom(from._internal_metadata_);
  uid_ = from.uid_;
  // @@protoc_insertion_point(copy_constructor:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
}

void MSG_G2WM_Heartbeat::SharedCtor() {
  _cached_size_ = 0;
  uid_ = 0;
}

MSG_G2WM_Heartbeat::~MSG_G2WM_Heartbeat() {
  // @@protoc_insertion_point(destructor:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  SharedDtor();
}

void MSG_G2WM_Heartbeat::SharedDtor() {
}

void MSG_G2WM_Heartbeat::SetCachedSize(int size) const {
  GOOGLE_SAFE_CONCURRENT_WRITES_BEGIN();
  _cached_size_ = size;
  GOOGLE_SAFE_CONCURRENT_WRITES_END();
}
const ::google::protobuf::Descriptor* MSG_G2WM_Heartbeat::descriptor() {
  ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::protobuf_AssignDescriptorsOnce();
  return ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::file_level_metadata[kIndexInFileMessages].descriptor;
}

const MSG_G2WM_Heartbeat& MSG_G2WM_Heartbeat::default_instance() {
  ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::InitDefaultsMSG_G2WM_Heartbeat();
  return *internal_default_instance();
}

MSG_G2WM_Heartbeat* MSG_G2WM_Heartbeat::New(::google::protobuf::Arena* arena) const {
  MSG_G2WM_Heartbeat* n = new MSG_G2WM_Heartbeat;
  if (arena != NULL) {
    arena->Own(n);
  }
  return n;
}

void MSG_G2WM_Heartbeat::Clear() {
// @@protoc_insertion_point(message_clear_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  ::google::protobuf::uint32 cached_has_bits = 0;
  // Prevent compiler warnings about cached_has_bits being unused
  (void) cached_has_bits;

  uid_ = 0;
  _has_bits_.Clear();
  _internal_metadata_.Clear();
}

bool MSG_G2WM_Heartbeat::MergePartialFromCodedStream(
    ::google::protobuf::io::CodedInputStream* input) {
#define DO_(EXPRESSION) if (!GOOGLE_PREDICT_TRUE(EXPRESSION)) goto failure
  ::google::protobuf::uint32 tag;
  // @@protoc_insertion_point(parse_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  for (;;) {
    ::std::pair< ::google::protobuf::uint32, bool> p = input->ReadTagWithCutoffNoLastTag(127u);
    tag = p.first;
    if (!p.second) goto handle_unusual;
    switch (::google::protobuf::internal::WireFormatLite::GetTagFieldNumber(tag)) {
      // required int32 UId = 1;
      case 1: {
        if (static_cast< ::google::protobuf::uint8>(tag) ==
            static_cast< ::google::protobuf::uint8>(8u /* 8 & 0xFF */)) {
          set_has_uid();
          DO_((::google::protobuf::internal::WireFormatLite::ReadPrimitive<
                   ::google::protobuf::int32, ::google::protobuf::internal::WireFormatLite::TYPE_INT32>(
                 input, &uid_)));
        } else {
          goto handle_unusual;
        }
        break;
      }

      default: {
      handle_unusual:
        if (tag == 0) {
          goto success;
        }
        DO_(::google::protobuf::internal::WireFormat::SkipField(
              input, tag, _internal_metadata_.mutable_unknown_fields()));
        break;
      }
    }
  }
success:
  // @@protoc_insertion_point(parse_success:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  return true;
failure:
  // @@protoc_insertion_point(parse_failure:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  return false;
#undef DO_
}

void MSG_G2WM_Heartbeat::SerializeWithCachedSizes(
    ::google::protobuf::io::CodedOutputStream* output) const {
  // @@protoc_insertion_point(serialize_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  ::google::protobuf::uint32 cached_has_bits = 0;
  (void) cached_has_bits;

  cached_has_bits = _has_bits_[0];
  // required int32 UId = 1;
  if (cached_has_bits & 0x00000001u) {
    ::google::protobuf::internal::WireFormatLite::WriteInt32(1, this->uid(), output);
  }

  if (_internal_metadata_.have_unknown_fields()) {
    ::google::protobuf::internal::WireFormat::SerializeUnknownFields(
        _internal_metadata_.unknown_fields(), output);
  }
  // @@protoc_insertion_point(serialize_end:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
}

::google::protobuf::uint8* MSG_G2WM_Heartbeat::InternalSerializeWithCachedSizesToArray(
    bool deterministic, ::google::protobuf::uint8* target) const {
  (void)deterministic; // Unused
  // @@protoc_insertion_point(serialize_to_array_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  ::google::protobuf::uint32 cached_has_bits = 0;
  (void) cached_has_bits;

  cached_has_bits = _has_bits_[0];
  // required int32 UId = 1;
  if (cached_has_bits & 0x00000001u) {
    target = ::google::protobuf::internal::WireFormatLite::WriteInt32ToArray(1, this->uid(), target);
  }

  if (_internal_metadata_.have_unknown_fields()) {
    target = ::google::protobuf::internal::WireFormat::SerializeUnknownFieldsToArray(
        _internal_metadata_.unknown_fields(), target);
  }
  // @@protoc_insertion_point(serialize_to_array_end:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  return target;
}

size_t MSG_G2WM_Heartbeat::ByteSizeLong() const {
// @@protoc_insertion_point(message_byte_size_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  size_t total_size = 0;

  if (_internal_metadata_.have_unknown_fields()) {
    total_size +=
      ::google::protobuf::internal::WireFormat::ComputeUnknownFieldsSize(
        _internal_metadata_.unknown_fields());
  }
  // required int32 UId = 1;
  if (has_uid()) {
    total_size += 1 +
      ::google::protobuf::internal::WireFormatLite::Int32Size(
        this->uid());
  }
  int cached_size = ::google::protobuf::internal::ToCachedSize(total_size);
  GOOGLE_SAFE_CONCURRENT_WRITES_BEGIN();
  _cached_size_ = cached_size;
  GOOGLE_SAFE_CONCURRENT_WRITES_END();
  return total_size;
}

void MSG_G2WM_Heartbeat::MergeFrom(const ::google::protobuf::Message& from) {
// @@protoc_insertion_point(generalized_merge_from_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  GOOGLE_DCHECK_NE(&from, this);
  const MSG_G2WM_Heartbeat* source =
      ::google::protobuf::internal::DynamicCastToGenerated<const MSG_G2WM_Heartbeat>(
          &from);
  if (source == NULL) {
  // @@protoc_insertion_point(generalized_merge_from_cast_fail:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
    ::google::protobuf::internal::ReflectionOps::Merge(from, this);
  } else {
  // @@protoc_insertion_point(generalized_merge_from_cast_success:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
    MergeFrom(*source);
  }
}

void MSG_G2WM_Heartbeat::MergeFrom(const MSG_G2WM_Heartbeat& from) {
// @@protoc_insertion_point(class_specific_merge_from_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  GOOGLE_DCHECK_NE(&from, this);
  _internal_metadata_.MergeFrom(from._internal_metadata_);
  ::google::protobuf::uint32 cached_has_bits = 0;
  (void) cached_has_bits;

  if (from.has_uid()) {
    set_uid(from.uid());
  }
}

void MSG_G2WM_Heartbeat::CopyFrom(const ::google::protobuf::Message& from) {
// @@protoc_insertion_point(generalized_copy_from_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  if (&from == this) return;
  Clear();
  MergeFrom(from);
}

void MSG_G2WM_Heartbeat::CopyFrom(const MSG_G2WM_Heartbeat& from) {
// @@protoc_insertion_point(class_specific_copy_from_start:Protocol.Gate.G2WM.MSG_G2WM_Heartbeat)
  if (&from == this) return;
  Clear();
  MergeFrom(from);
}

bool MSG_G2WM_Heartbeat::IsInitialized() const {
  if ((_has_bits_[0] & 0x00000001) != 0x00000001) return false;
  return true;
}

void MSG_G2WM_Heartbeat::Swap(MSG_G2WM_Heartbeat* other) {
  if (other == this) return;
  InternalSwap(other);
}
void MSG_G2WM_Heartbeat::InternalSwap(MSG_G2WM_Heartbeat* other) {
  using std::swap;
  swap(uid_, other->uid_);
  swap(_has_bits_[0], other->_has_bits_[0]);
  _internal_metadata_.Swap(&other->_internal_metadata_);
  swap(_cached_size_, other->_cached_size_);
}

::google::protobuf::Metadata MSG_G2WM_Heartbeat::GetMetadata() const {
  protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::protobuf_AssignDescriptorsOnce();
  return ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::file_level_metadata[kIndexInFileMessages];
}


// ===================================================================

void MSG_G2WM_CreateRoleId::InitAsDefaultInstance() {
}
#if !defined(_MSC_VER) || _MSC_VER >= 1900
const int MSG_G2WM_CreateRoleId::kUsernameFieldNumber;
#endif  // !defined(_MSC_VER) || _MSC_VER >= 1900

MSG_G2WM_CreateRoleId::MSG_G2WM_CreateRoleId()
  : ::google::protobuf::Message(), _internal_metadata_(NULL) {
  if (GOOGLE_PREDICT_TRUE(this != internal_default_instance())) {
    ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::InitDefaultsMSG_G2WM_CreateRoleId();
  }
  SharedCtor();
  // @@protoc_insertion_point(constructor:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
}
MSG_G2WM_CreateRoleId::MSG_G2WM_CreateRoleId(const MSG_G2WM_CreateRoleId& from)
  : ::google::protobuf::Message(),
      _internal_metadata_(NULL),
      _has_bits_(from._has_bits_),
      _cached_size_(0) {
  _internal_metadata_.MergeFrom(from._internal_metadata_);
  username_.UnsafeSetDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
  if (from.has_username()) {
    username_.AssignWithDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), from.username_);
  }
  // @@protoc_insertion_point(copy_constructor:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
}

void MSG_G2WM_CreateRoleId::SharedCtor() {
  _cached_size_ = 0;
  username_.UnsafeSetDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
}

MSG_G2WM_CreateRoleId::~MSG_G2WM_CreateRoleId() {
  // @@protoc_insertion_point(destructor:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  SharedDtor();
}

void MSG_G2WM_CreateRoleId::SharedDtor() {
  username_.DestroyNoArena(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
}

void MSG_G2WM_CreateRoleId::SetCachedSize(int size) const {
  GOOGLE_SAFE_CONCURRENT_WRITES_BEGIN();
  _cached_size_ = size;
  GOOGLE_SAFE_CONCURRENT_WRITES_END();
}
const ::google::protobuf::Descriptor* MSG_G2WM_CreateRoleId::descriptor() {
  ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::protobuf_AssignDescriptorsOnce();
  return ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::file_level_metadata[kIndexInFileMessages].descriptor;
}

const MSG_G2WM_CreateRoleId& MSG_G2WM_CreateRoleId::default_instance() {
  ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::InitDefaultsMSG_G2WM_CreateRoleId();
  return *internal_default_instance();
}

MSG_G2WM_CreateRoleId* MSG_G2WM_CreateRoleId::New(::google::protobuf::Arena* arena) const {
  MSG_G2WM_CreateRoleId* n = new MSG_G2WM_CreateRoleId;
  if (arena != NULL) {
    arena->Own(n);
  }
  return n;
}

void MSG_G2WM_CreateRoleId::Clear() {
// @@protoc_insertion_point(message_clear_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  ::google::protobuf::uint32 cached_has_bits = 0;
  // Prevent compiler warnings about cached_has_bits being unused
  (void) cached_has_bits;

  cached_has_bits = _has_bits_[0];
  if (cached_has_bits & 0x00000001u) {
    GOOGLE_DCHECK(!username_.IsDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited()));
    (*username_.UnsafeRawStringPointer())->clear();
  }
  _has_bits_.Clear();
  _internal_metadata_.Clear();
}

bool MSG_G2WM_CreateRoleId::MergePartialFromCodedStream(
    ::google::protobuf::io::CodedInputStream* input) {
#define DO_(EXPRESSION) if (!GOOGLE_PREDICT_TRUE(EXPRESSION)) goto failure
  ::google::protobuf::uint32 tag;
  // @@protoc_insertion_point(parse_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  for (;;) {
    ::std::pair< ::google::protobuf::uint32, bool> p = input->ReadTagWithCutoffNoLastTag(127u);
    tag = p.first;
    if (!p.second) goto handle_unusual;
    switch (::google::protobuf::internal::WireFormatLite::GetTagFieldNumber(tag)) {
      // required string Username = 1;
      case 1: {
        if (static_cast< ::google::protobuf::uint8>(tag) ==
            static_cast< ::google::protobuf::uint8>(10u /* 10 & 0xFF */)) {
          DO_(::google::protobuf::internal::WireFormatLite::ReadString(
                input, this->mutable_username()));
          ::google::protobuf::internal::WireFormat::VerifyUTF8StringNamedField(
            this->username().data(), static_cast<int>(this->username().length()),
            ::google::protobuf::internal::WireFormat::PARSE,
            "Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId.Username");
        } else {
          goto handle_unusual;
        }
        break;
      }

      default: {
      handle_unusual:
        if (tag == 0) {
          goto success;
        }
        DO_(::google::protobuf::internal::WireFormat::SkipField(
              input, tag, _internal_metadata_.mutable_unknown_fields()));
        break;
      }
    }
  }
success:
  // @@protoc_insertion_point(parse_success:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  return true;
failure:
  // @@protoc_insertion_point(parse_failure:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  return false;
#undef DO_
}

void MSG_G2WM_CreateRoleId::SerializeWithCachedSizes(
    ::google::protobuf::io::CodedOutputStream* output) const {
  // @@protoc_insertion_point(serialize_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  ::google::protobuf::uint32 cached_has_bits = 0;
  (void) cached_has_bits;

  cached_has_bits = _has_bits_[0];
  // required string Username = 1;
  if (cached_has_bits & 0x00000001u) {
    ::google::protobuf::internal::WireFormat::VerifyUTF8StringNamedField(
      this->username().data(), static_cast<int>(this->username().length()),
      ::google::protobuf::internal::WireFormat::SERIALIZE,
      "Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId.Username");
    ::google::protobuf::internal::WireFormatLite::WriteStringMaybeAliased(
      1, this->username(), output);
  }

  if (_internal_metadata_.have_unknown_fields()) {
    ::google::protobuf::internal::WireFormat::SerializeUnknownFields(
        _internal_metadata_.unknown_fields(), output);
  }
  // @@protoc_insertion_point(serialize_end:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
}

::google::protobuf::uint8* MSG_G2WM_CreateRoleId::InternalSerializeWithCachedSizesToArray(
    bool deterministic, ::google::protobuf::uint8* target) const {
  (void)deterministic; // Unused
  // @@protoc_insertion_point(serialize_to_array_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  ::google::protobuf::uint32 cached_has_bits = 0;
  (void) cached_has_bits;

  cached_has_bits = _has_bits_[0];
  // required string Username = 1;
  if (cached_has_bits & 0x00000001u) {
    ::google::protobuf::internal::WireFormat::VerifyUTF8StringNamedField(
      this->username().data(), static_cast<int>(this->username().length()),
      ::google::protobuf::internal::WireFormat::SERIALIZE,
      "Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId.Username");
    target =
      ::google::protobuf::internal::WireFormatLite::WriteStringToArray(
        1, this->username(), target);
  }

  if (_internal_metadata_.have_unknown_fields()) {
    target = ::google::protobuf::internal::WireFormat::SerializeUnknownFieldsToArray(
        _internal_metadata_.unknown_fields(), target);
  }
  // @@protoc_insertion_point(serialize_to_array_end:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  return target;
}

size_t MSG_G2WM_CreateRoleId::ByteSizeLong() const {
// @@protoc_insertion_point(message_byte_size_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  size_t total_size = 0;

  if (_internal_metadata_.have_unknown_fields()) {
    total_size +=
      ::google::protobuf::internal::WireFormat::ComputeUnknownFieldsSize(
        _internal_metadata_.unknown_fields());
  }
  // required string Username = 1;
  if (has_username()) {
    total_size += 1 +
      ::google::protobuf::internal::WireFormatLite::StringSize(
        this->username());
  }
  int cached_size = ::google::protobuf::internal::ToCachedSize(total_size);
  GOOGLE_SAFE_CONCURRENT_WRITES_BEGIN();
  _cached_size_ = cached_size;
  GOOGLE_SAFE_CONCURRENT_WRITES_END();
  return total_size;
}

void MSG_G2WM_CreateRoleId::MergeFrom(const ::google::protobuf::Message& from) {
// @@protoc_insertion_point(generalized_merge_from_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  GOOGLE_DCHECK_NE(&from, this);
  const MSG_G2WM_CreateRoleId* source =
      ::google::protobuf::internal::DynamicCastToGenerated<const MSG_G2WM_CreateRoleId>(
          &from);
  if (source == NULL) {
  // @@protoc_insertion_point(generalized_merge_from_cast_fail:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
    ::google::protobuf::internal::ReflectionOps::Merge(from, this);
  } else {
  // @@protoc_insertion_point(generalized_merge_from_cast_success:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
    MergeFrom(*source);
  }
}

void MSG_G2WM_CreateRoleId::MergeFrom(const MSG_G2WM_CreateRoleId& from) {
// @@protoc_insertion_point(class_specific_merge_from_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  GOOGLE_DCHECK_NE(&from, this);
  _internal_metadata_.MergeFrom(from._internal_metadata_);
  ::google::protobuf::uint32 cached_has_bits = 0;
  (void) cached_has_bits;

  if (from.has_username()) {
    set_has_username();
    username_.AssignWithDefault(&::google::protobuf::internal::GetEmptyStringAlreadyInited(), from.username_);
  }
}

void MSG_G2WM_CreateRoleId::CopyFrom(const ::google::protobuf::Message& from) {
// @@protoc_insertion_point(generalized_copy_from_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  if (&from == this) return;
  Clear();
  MergeFrom(from);
}

void MSG_G2WM_CreateRoleId::CopyFrom(const MSG_G2WM_CreateRoleId& from) {
// @@protoc_insertion_point(class_specific_copy_from_start:Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId)
  if (&from == this) return;
  Clear();
  MergeFrom(from);
}

bool MSG_G2WM_CreateRoleId::IsInitialized() const {
  if ((_has_bits_[0] & 0x00000001) != 0x00000001) return false;
  return true;
}

void MSG_G2WM_CreateRoleId::Swap(MSG_G2WM_CreateRoleId* other) {
  if (other == this) return;
  InternalSwap(other);
}
void MSG_G2WM_CreateRoleId::InternalSwap(MSG_G2WM_CreateRoleId* other) {
  using std::swap;
  username_.Swap(&other->username_);
  swap(_has_bits_[0], other->_has_bits_[0]);
  _internal_metadata_.Swap(&other->_internal_metadata_);
  swap(_cached_size_, other->_cached_size_);
}

::google::protobuf::Metadata MSG_G2WM_CreateRoleId::GetMetadata() const {
  protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::protobuf_AssignDescriptorsOnce();
  return ::protobuf_Gate_2fProtocol_2fG2WM_2eCODE_2eproto::file_level_metadata[kIndexInFileMessages];
}


// @@protoc_insertion_point(namespace_scope)
}  // namespace G2WM
}  // namespace Gate
}  // namespace Protocol

// @@protoc_insertion_point(global_scope)