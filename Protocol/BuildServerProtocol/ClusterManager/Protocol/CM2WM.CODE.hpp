#ifndef Message_ClusterManager_WorldManager_Protocol_CM2WM_h
#define Message_ClusterManager_WorldManager_Protocol_CM2WM_h

namespace Message { namespace ClusterManager { namespace WorldManager { namespace Protocol { namespace CM2WM {
class MSG_CM2WM_HEARTBEAT;
class MSG_CM2WM_RETRUN_REGISTER;
} } } } }

const uint32 engine::id<Message::ClusterManager::WorldManager::Protocol::CM2WM::MSG_CM2WM_HEARTBEAT>::value = 0x13000001;
const uint32 engine::id<Message::ClusterManager::WorldManager::Protocol::CM2WM::MSG_CM2WM_RETRUN_REGISTER>::value = 0x13000002;

namespace ClusterManager { namespace WorldManager { namespace Protocol { namespace CM2WM { class Provider; } } } }
const uint32 engine::id<ClusterManager::WorldManager::Protocol::CM2WM::Provider>::value = 0x13000000;
#endif