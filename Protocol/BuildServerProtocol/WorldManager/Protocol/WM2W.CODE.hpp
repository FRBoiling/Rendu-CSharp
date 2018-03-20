#ifndef Message_WorldManager_World_Protocol_WM2W_h
#define Message_WorldManager_World_Protocol_WM2W_h

namespace Message { namespace WorldManager { namespace World { namespace Protocol { namespace WM2W {
class MSG_WM2W_HEARTBEAT;
class MSG_WM2W_RETRUN_REGISTER;
} } } } }

const uint32 engine::id<Message::WorldManager::World::Protocol::WM2W::MSG_WM2W_HEARTBEAT>::value = 0x34000001;
const uint32 engine::id<Message::WorldManager::World::Protocol::WM2W::MSG_WM2W_RETRUN_REGISTER>::value = 0x34000002;

namespace WorldManager { namespace World { namespace Protocol { namespace WM2W { class Provider; } } } }
const uint32 engine::id<WorldManager::World::Protocol::WM2W::Provider>::value = 0x34000000;
#endif