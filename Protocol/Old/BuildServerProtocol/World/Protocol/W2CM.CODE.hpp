#ifndef Protocol_World_W2CM_h
#define Protocol_World_W2CM_h

namespace Protocol { namespace World { namespace W2CM {
class MSG_W2CM_Heartbeat;
class MSG_W2CM_Register;
} } }

const uint32 engine::id<Protocol::World::W2CM::MSG_W2CM_Heartbeat>::value = 0x4100001;
const uint32 engine::id<Protocol::World::W2CM::MSG_W2CM_Register>::value = 0x4100002;

#endif