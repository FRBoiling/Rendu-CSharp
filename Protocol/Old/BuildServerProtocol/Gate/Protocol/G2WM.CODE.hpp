#ifndef Protocol_Gate_G2WM_h
#define Protocol_Gate_G2WM_h

namespace Protocol { namespace Gate { namespace G2WM {
class MSG_G2WM_Heartbeat;
class MSG_G2WM_CreateRoleId;
} } }

const uint32 engine::id<Protocol::Gate::G2WM::MSG_G2WM_Heartbeat>::value = 0x2300001;
const uint32 engine::id<Protocol::Gate::G2WM::MSG_G2WM_CreateRoleId>::value = 0x2300101;

#endif