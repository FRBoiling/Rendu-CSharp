#ifndef Message_World_ClusterManager_Protocol_W2CM_h
#define Message_World_ClusterManager_Protocol_W2CM_h

namespace Message { namespace World { namespace ClusterManager { namespace Protocol { namespace W2CM {
class MSG_W2CM_Heartbeat;
class MSG_W2CM_Register;
} } } } }

const uint32 engine::id<Message::World::ClusterManager::Protocol::W2CM::MSG_W2CM_Heartbeat>::value = 0x41000001;
const uint32 engine::id<Message::World::ClusterManager::Protocol::W2CM::MSG_W2CM_Register>::value = 0x41000002;

namespace World { namespace ClusterManager { namespace Protocol { namespace W2CM { class Provider; } } } }
const uint32 engine::id<World::ClusterManager::Protocol::W2CM::Provider>::value = 0x41000000;
#endif