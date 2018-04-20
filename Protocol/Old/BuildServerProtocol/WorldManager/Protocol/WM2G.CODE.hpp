#ifndef Protocol_WorldManager_WM2G_h
#define Protocol_WorldManager_WM2G_h

namespace Protocol { namespace WorldManager { namespace WM2G {
class MSG_WM2G_Heartbeat;
class MSG_WM2G_Register;
} } }

const uint32 engine::id<Protocol::WorldManager::WM2G::MSG_WM2G_Heartbeat>::value = 0x3200001;
const uint32 engine::id<Protocol::WorldManager::WM2G::MSG_WM2G_Register>::value = 0x3200002;

#endif