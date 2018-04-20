#ifndef Protocol_World_W2WM_h
#define Protocol_World_W2WM_h

namespace Protocol { namespace World { namespace W2WM {
class MSG_W2WM_Heartbeat;
class MSG_W2WM_Register;
} } }

const uint32 engine::id<Protocol::World::W2WM::MSG_W2WM_Heartbeat>::value = 0x4300001;
const uint32 engine::id<Protocol::World::W2WM::MSG_W2WM_Register>::value = 0x4300002;

#endif