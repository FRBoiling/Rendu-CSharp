#ifndef Protocol_ClusterManager_CM2B_h
#define Protocol_ClusterManager_CM2B_h

namespace Protocol { namespace ClusterManager { namespace CM2B {
class MSG_CM2B_HEARTBEAT;
class MSG_CM2B_RETRUN_REGISTER;
} } }

const uint32 engine::id<Protocol::ClusterManager::CM2B::MSG_CM2B_HEARTBEAT>::value = 0x1600001;
const uint32 engine::id<Protocol::ClusterManager::CM2B::MSG_CM2B_RETRUN_REGISTER>::value = 0x1600002;

#endif