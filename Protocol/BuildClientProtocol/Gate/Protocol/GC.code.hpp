#ifndef Protocol_Gate_G2C_h
#define Protocol_Gate_G2C_h

namespace Protocol { namespace Gate { namespace G2C {
class MSG_G2C_Heartbeat;
class MSG_G2C_EncryptKey;
class MSG_G2C_Login;
class MSG_G2C_CreateRole;
class Role_BaseInfo;
class Role_Model;
class Role_Info;
} } }

const uint32 engine::id<Protocol::Gate::G2C::MSG_G2C_Heartbeat>::value = 0x2F00001;
const uint32 engine::id<Protocol::Gate::G2C::MSG_G2C_EncryptKey>::value = 0x2F00010;
const uint32 engine::id<Protocol::Gate::G2C::MSG_G2C_Login>::value = 0x2F00101;
const uint32 engine::id<Protocol::Gate::G2C::MSG_G2C_CreateRole>::value = 0x2F00102;
const uint32 engine::id<Protocol::Gate::G2C::Role_BaseInfo>::value = 0x2F00111;
const uint32 engine::id<Protocol::Gate::G2C::Role_Model>::value = 0x2F00112;
const uint32 engine::id<Protocol::Gate::G2C::Role_Info>::value = 0x2F00121;

#endif