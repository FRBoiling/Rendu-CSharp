#ifndef Message_ClusterManager_World_Protocol_CM2W_h
#define Message_ClusterManager_World_Protocol_CM2W_h

namespace Message { namespace ClusterManager { namespace World { namespace Protocol { namespace CM2W {
class MSG_CM2W_HEARTBEAT;
class MSG_CM2W_RETRUN_REGISTER;
} } } } }

const uint32 engine::id<Message::ClusterManager::World::Protocol::CM2W::MSG_CM2W_HEARTBEAT>::value = 0x14000001;
const uint32 engine::id<Message::ClusterManager::World::Protocol::CM2W::MSG_CM2W_RETRUN_REGISTER>::value = 0x14000002;

namespace ClusterManager { namespace World { namespace Protocol { class CM2W; } } }
const uint32 engine::id<ClusterManager::World::Protocol::CM2W>::value = 0x14000000;
#endif