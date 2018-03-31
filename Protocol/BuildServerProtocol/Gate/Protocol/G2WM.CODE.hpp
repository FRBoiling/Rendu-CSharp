#ifndef Message_Gate_WorldManager_Protocol_G2WM_h
#define Message_Gate_WorldManager_Protocol_G2WM_h

namespace Message { namespace Gate { namespace WorldManager { namespace Protocol { namespace G2WM {
class MSG_G2WM_Heartbeat;
class MSG_G2WM_CreateRoleId;
} } } } }

const uint32 engine::id<Message::Gate::WorldManager::Protocol::G2WM::MSG_G2WM_Heartbeat>::value = 0x23000001;
const uint32 engine::id<Message::Gate::WorldManager::Protocol::G2WM::MSG_G2WM_CreateRoleId>::value = 0x23000101;

namespace Gate { namespace WorldManager { namespace Protocol { namespace G2WM { class Provider; } } } }
const uint32 engine::id<Gate::WorldManager::Protocol::G2WM::Provider>::value = 0x23000000;
#endif