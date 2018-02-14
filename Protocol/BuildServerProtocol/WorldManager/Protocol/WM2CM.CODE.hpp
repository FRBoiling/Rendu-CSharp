#ifndef Message_WorldManager_ClusterManager_Protocol_WM2CM_h
#define Message_WorldManager_ClusterManager_Protocol_WM2CM_h

namespace Message { namespace WorldManager { namespace ClusterManager { namespace Protocol { namespace WM2CM {
class MSG_WM2CM_HEARTBEAT;
class MSG_WM2CM_REGISTER;
} } } } }

const uint32 engine::id<Message::WorldManager::ClusterManager::Protocol::WM2CM::MSG_WM2CM_HEARTBEAT>::value = 0x31000001;
const uint32 engine::id<Message::WorldManager::ClusterManager::Protocol::WM2CM::MSG_WM2CM_REGISTER>::value = 0x31000002;

namespace WorldManager { namespace ClusterManager { namespace Protocol { class WM2CM; } } }
const uint32 engine::id<WorldManager::ClusterManager::Protocol::WM2CM>::value = 0x31000000;
#endif