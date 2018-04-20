#ifndef Protocol_WorldManager_WM2W_h
#define Protocol_WorldManager_WM2W_h

namespace Protocol { namespace WorldManager { namespace WM2W {
class MSG_WM2W_HEARTBEAT;
class MSG_WM2W_RETRUN_REGISTER;
} } }

const uint32 engine::id<Protocol::WorldManager::WM2W::MSG_WM2W_HEARTBEAT>::value = 0x3400001;
const uint32 engine::id<Protocol::WorldManager::WM2W::MSG_WM2W_RETRUN_REGISTER>::value = 0x3400002;

#endif