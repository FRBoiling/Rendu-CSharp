#ifndef Protocol_ClusterManager_CM2W_h
#define Protocol_ClusterManager_CM2W_h

namespace Protocol { namespace ClusterManager { namespace CM2W {
class MSG_CM2W_HEARTBEAT;
class MSG_CM2W_RETRUN_REGISTER;
} } }

const uint32 engine::id<Protocol::ClusterManager::CM2W::MSG_CM2W_HEARTBEAT>::value = 0x14000001;
const uint32 engine::id<Protocol::ClusterManager::CM2W::MSG_CM2W_RETRUN_REGISTER>::value = 0x14000002;

#endif