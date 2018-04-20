#ifndef Protocol_Gate_G2CM_h
#define Protocol_Gate_G2CM_h

namespace Protocol { namespace Gate { namespace G2CM {
class MSG_G2CM_Heartbeat;
class MSG_G2CM_Register;
} } }

const uint32 engine::id<Protocol::Gate::G2CM::MSG_G2CM_Heartbeat>::value = 0x2100001;
const uint32 engine::id<Protocol::Gate::G2CM::MSG_G2CM_Register>::value = 0x2100002;

#endif