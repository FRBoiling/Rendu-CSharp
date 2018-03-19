#ifndef Message_Client_Gate_Protocol_CG_h
#define Message_Client_Gate_Protocol_CG_h

namespace Message { namespace Client { namespace Gate { namespace Protocol { namespace CG {
class MSG_C2G_HEARTBEAT;
} } } } }

const uint32 engine::id<Message::Client::Gate::Protocol::CG::MSG_C2G_HEARTBEAT>::value = 0xF2000001;

namespace Client { namespace Gate { namespace Protocol { class CG; } } }
const uint32 engine::id<Client::Gate::Protocol::CG>::value = 0xF2000000;
#endif