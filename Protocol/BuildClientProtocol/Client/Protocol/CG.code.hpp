#ifndef Message_Client_Gate_Protocol_CG_h
#define Message_Client_Gate_Protocol_CG_h

namespace Message { namespace Client { namespace Gate { namespace Protocol { namespace CG {
class MSG_C2G_Heartbeat;
class MSG_C2G_GetEncryptKey;
class MSG_C2G_Login;
class MSG_C2G_CreateRole;
} } } } }

const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_Heartbeat>::value = 0xF2000001;
const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_GetEncryptKey>::value = 0xF2000010;
const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_Login>::value = 0xF2001000;
const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_CreateRole>::value = 0xF2001001;

namespace Client { namespace Gate { namespace Protocol { namespace CG { class Provider; } } } }
const uint32 engine::id<Client::Gate::Protocol::CG::Provider>::value = 0xF2000000;
#endif