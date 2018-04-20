#ifndef Protocol_BattleManager_BM2B_h
#define Protocol_BattleManager_BM2B_h

namespace Protocol { namespace BattleManager { namespace BM2B {
class MSG_BM2B_HEARTBEAT;
class MSG_BM2B_RETRUN_REGISTER;
} } }

const uint32 engine::id<Protocol::BattleManager::BM2B::MSG_BM2B_HEARTBEAT>::value = 0x5600001;
const uint32 engine::id<Protocol::BattleManager::BM2B::MSG_BM2B_RETRUN_REGISTER>::value = 0x5600002;

#endif