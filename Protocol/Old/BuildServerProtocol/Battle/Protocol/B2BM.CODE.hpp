#ifndef Protocol_Battle_B2BM_h
#define Protocol_Battle_B2BM_h

namespace Protocol { namespace Battle { namespace B2BM {
class MSG_B2BM_HEARTBEAT;
class MSG_B2BM_REGISTER;
} } }

const uint32 engine::id<Protocol::Battle::B2BM::MSG_B2BM_HEARTBEAT>::value = 0x6500001;
const uint32 engine::id<Protocol::Battle::B2BM::MSG_B2BM_REGISTER>::value = 0x6500002;

#endif