#ifndef Message_WorldManager_ClusterManager_Protocol_WM2CM_h
#define Message_WorldManager_ClusterManager_Protocol_WM2CM_h

namespace Message { namespace WorldManager { namespace ClusterManager { namespace Protocol { namespace WM2CM {
class MSG_WM2CM_Heartbeat;
class MSG_WM2CM_Register;
} } } } }

const uint32 engine::id<Message::WorldManager::ClusterManager::Protocol::WM2CM::MSG_WM2CM_Heartbeat>::value = 0x31000001;
const uint32 engine::id<Message::WorldManager::ClusterManager::Protocol::WM2CM::MSG_WM2CM_Register>::value = 0x31000002;

namespace WorldManager { namespace ClusterManager { namespace Protocol { namespace WM2CM { class Provider; } } } }
const uint32 engine::id<WorldManager::ClusterManager::Protocol::WM2CM::Provider>::value = 0x31000000;
#endif