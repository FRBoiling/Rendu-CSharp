#ifndef Message_World_WorldManager_Protocol_W2WM_h
#define Message_World_WorldManager_Protocol_W2WM_h

namespace Message { namespace World { namespace WorldManager { namespace Protocol { namespace W2WM {
class MSG_W2WM_HEARTBEAT;
class MSG_W2WM_REGISTER;
} } } } }

const uint32 engine::id<Message::World::WorldManager::Protocol::W2WM::MSG_W2WM_HEARTBEAT>::value = 0x43000001;
const uint32 engine::id<Message::World::WorldManager::Protocol::W2WM::MSG_W2WM_REGISTER>::value = 0x43000002;

namespace World { namespace WorldManager { namespace Protocol { class W2WM; } } }
const uint32 engine::id<World::WorldManager::Protocol::W2WM>::value = 0x43000000;
#endif