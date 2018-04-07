#ifndef Protocol_WorldManager_WM2CM_h
#define Protocol_WorldManager_WM2CM_h

namespace Protocol { namespace WorldManager { namespace WM2CM {
class MSG_WM2CM_Heartbeat;
class MSG_WM2CM_Register;
} } }

const uint32 engine::id<Protocol::WorldManager::WM2CM::MSG_WM2CM_Heartbeat>::value = 0x3100001;
const uint32 engine::id<Protocol::WorldManager::WM2CM::MSG_WM2CM_Register>::value = 0x3100002;

#endif