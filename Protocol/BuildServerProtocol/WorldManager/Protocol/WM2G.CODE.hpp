#ifndef Message_WorldManager_Gate_Protocol_WM2G_h
#define Message_WorldManager_Gate_Protocol_WM2G_h

namespace Message { namespace WorldManager { namespace Gate { namespace Protocol { namespace WM2G {
class MSG_WM2G_Heartbeat;
class MSG_WM2G_Register;
} } } } }

const uint32 engine::id<Message::WorldManager::Gate::Protocol::WM2G::MSG_WM2G_Heartbeat>::value = 0x32000001;
const uint32 engine::id<Message::WorldManager::Gate::Protocol::WM2G::MSG_WM2G_Register>::value = 0x32000002;

namespace WorldManager { namespace Gate { namespace Protocol { namespace WM2G { class Provider; } } } }
const uint32 engine::id<WorldManager::Gate::Protocol::WM2G::Provider>::value = 0x32000000;
#endif