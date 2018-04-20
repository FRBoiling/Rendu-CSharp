#ifndef Protocol_ClusterManager_CM2WM_h
#define Protocol_ClusterManager_CM2WM_h

namespace Protocol { namespace ClusterManager { namespace CM2WM {
class MSG_CM2WM_HEARTBEAT;
class MSG_CM2WM_RETRUN_REGISTER;
} } }

const uint32 engine::id<Protocol::ClusterManager::CM2WM::MSG_CM2WM_HEARTBEAT>::value = 0x1300001;
const uint32 engine::id<Protocol::ClusterManager::CM2WM::MSG_CM2WM_RETRUN_REGISTER>::value = 0x1300002;

#endif