#ifndef Protocol_Client_C2G_h
#define Protocol_Client_C2G_h

namespace Protocol { namespace Client { namespace C2G {
class MSG_C2G_Heartbeat;
class MSG_C2G_GetEncryptKey;
class MSG_C2G_Login;
class MSG_C2G_CreateRole;
} } }

const uint32 engine::id<Protocol::Client::C2G::MSG_C2G_Heartbeat>::value = 0xF200001;
const uint32 engine::id<Protocol::Client::C2G::MSG_C2G_GetEncryptKey>::value = 0xF200010;
const uint32 engine::id<Protocol::Client::C2G::MSG_C2G_Login>::value = 0xF200101;
const uint32 engine::id<Protocol::Client::C2G::MSG_C2G_CreateRole>::value = 0xF200102;

#endif