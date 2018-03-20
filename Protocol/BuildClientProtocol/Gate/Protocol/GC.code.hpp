#ifndef Message_Gate_Client_Protocol_GC_h
#define Message_Gate_Client_Protocol_GC_h

namespace Message { namespace Gate { namespace Client { namespace Protocol { namespace GC {
class MSG_G2C_ENCRYPTKEY;
} } } } }

const uint32 engine::id<Message::Gate::Client::Protocol::GC::MSG_G2C_ENCRYPTKEY>::value = 0x2F000010;

namespace Gate { namespace Client { namespace Protocol { namespace GC { class Provider; } } } }
const uint32 engine::id<Gate::Client::Protocol::GC::Provider>::value = 0x2F000000;
#endif