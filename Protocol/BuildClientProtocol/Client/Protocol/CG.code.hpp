#ifndef Message_Client_Gate_Protocol_CG_h
#define Message_Client_Gate_Protocol_CG_h

namespace Message { namespace Client { namespace Gate { namespace Protocol { namespace CG {
class MSG_C2G_HEARTBEAT;
class MSG_C2G_GET_ENCRYPTKEY;
} } } } }

const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_HEARTBEAT>::value = 0xF2000001;
const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_GET_ENCRYPTKEY>::value = 0xF2000010;

namespace Client { namespace Gate { namespace Protocol { namespace CG { class Provider; } } } }
const uint32 engine::id<Client::Gate::Protocol::CG::Provider>::value = 0xF2000000;
#endif