#ifndef Protocol_Battle_B2CM_h
#define Protocol_Battle_B2CM_h

namespace Protocol { namespace Battle { namespace B2CM {
class MSG_B2CM_Heartbeat;
class MSG_B2CM_Register;
} } }

const uint32 engine::id<Protocol::Battle::B2CM::MSG_B2CM_Heartbeat>::value = 0x6100001;
const uint32 engine::id<Protocol::Battle::B2CM::MSG_B2CM_Register>::value = 0x6100002;

#endif