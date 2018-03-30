#ifndef Message_Gate_Client_Protocol_GC_h
#define Message_Gate_Client_Protocol_GC_h

namespace Message { namespace Gate { namespace Client { namespace Protocol { namespace GC {
class MSG_G2C_Heartbeat;
class MSG_G2C_EncryptKey;
class MSG_G2C_Login;
class MSG_G2C_CreateRole;
class Role_BaseInfo;
class Role_Model;
class Role_Info;
} } } } }

const uint32 engine::id<Message::Gate::Client::Protocol::GC::MSG_G2C_Heartbeat>::value = 0x2F000001;
const uint32 engine::id<Message::Gate::Client::Protocol::GC::MSG_G2C_EncryptKey>::value = 0x2F000010;
const uint32 engine::id<Message::Gate::Client::Protocol::GC::MSG_G2C_Login>::value = 0x2F001000;
const uint32 engine::id<Message::Gate::Client::Protocol::GC::MSG_G2C_CreateRole>::value = 0x2F001001;
const uint32 engine::id<Message::Gate::Client::Protocol::GC::Role_BaseInfo>::value = 0x2F001050;
const uint32 engine::id<Message::Gate::Client::Protocol::GC::Role_Model>::value = 0x2F001051;
const uint32 engine::id<Message::Gate::Client::Protocol::GC::Role_Info>::value = 0x2F001052;

namespace Gate { namespace Client { namespace Protocol { namespace GC { class Provider; } } } }
const uint32 engine::id<Gate::Client::Protocol::GC::Provider>::value = 0x2F000000;
#endif