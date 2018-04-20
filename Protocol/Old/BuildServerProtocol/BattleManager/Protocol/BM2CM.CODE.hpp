#ifndef Protocol_BattleManager_BM2CM_h
#define Protocol_BattleManager_BM2CM_h

namespace Protocol { namespace BattleManager { namespace BM2CM {
class MSG_BM2CM_HEARTBEAT;
class MSG_BM2CM_REGISTER;
} } }

const uint32 engine::id<Protocol::BattleManager::BM2CM::MSG_BM2CM_HEARTBEAT>::value = 0x5100001;
const uint32 engine::id<Protocol::BattleManager::BM2CM::MSG_BM2CM_REGISTER>::value = 0x5100002;

#endif