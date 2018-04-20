#ifndef Protocol_ClusterManager_CM2BM_h
#define Protocol_ClusterManager_CM2BM_h

namespace Protocol { namespace ClusterManager { namespace CM2BM {
class MSG_CM2BM_HEARTBEAT;
class MSG_CM2BM_RETRUN_REGISTER;
} } }

const uint32 engine::id<Protocol::ClusterManager::CM2BM::MSG_CM2BM_HEARTBEAT>::value = 0x1500001;
const uint32 engine::id<Protocol::ClusterManager::CM2BM::MSG_CM2BM_RETRUN_REGISTER>::value = 0x1500002;

#endif