#ifndef Message_Gate_ClusterManager_Protocol_G2CM_h
#define Message_Gate_ClusterManager_Protocol_G2CM_h

namespace Message { namespace Gate { namespace ClusterManager { namespace Protocol { namespace G2CM {
class MSG_G2CM_Heartbeat;
class MSG_G2CM_Register;
} } } } }

const uint32 engine::id<Message::Gate::ClusterManager::Protocol::G2CM::MSG_G2CM_Heartbeat>::value = 0x21000001;
const uint32 engine::id<Message::Gate::ClusterManager::Protocol::G2CM::MSG_G2CM_Register>::value = 0x21000002;

namespace Gate { namespace ClusterManager { namespace Protocol { namespace G2CM { class Provider; } } } }
const uint32 engine::id<Gate::ClusterManager::Protocol::G2CM::Provider>::value = 0x21000000;
#endif