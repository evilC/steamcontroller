using System;
using System.Runtime.InteropServices;

namespace Kolrabi.SteamController
{
    internal class SteamControllerLib
    {
        [DllImport("SteamController", EntryPoint = "SteamController_EnumControllerDevices", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr EnumControllerDevices();

        [DllImport("SteamController", EntryPoint = "SteamController_NextControllerDevice", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NextControllerDevice(IntPtr pCurrentEnum);

        [DllImport("SteamController", EntryPoint = "SteamController_Open", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Open(IntPtr pEnum);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_Close", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Close(IntPtr pDevice);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_IsWirelessDongle", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool IsWirelessDongle(IntPtr pDevice);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_TurnOff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TurnOff(IntPtr pDevice);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_QueryWirelessState", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool QueryWirelessState(IntPtr pDevice, out WirelessState state);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_EnablePairing", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool EnablePairing(IntPtr pDevice, bool enable, byte deviceType);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_CommitPairing", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool CommitPairing(IntPtr pDevice, bool connect);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_Configure", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool Configure(IntPtr pDevice, uint value);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_SetHomeButtonBrightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetHomeButtonBrightness(IntPtr pDevice, byte value);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_SetTimeOut", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetTimeout(IntPtr pDevice, ushort value);

        internal struct InputEvent
        {
            public uint eventType;

            public uint timeStamp;
            public uint buttons;

            public byte leftTrigger;
            public byte rightTrigger;

            public short leftX, leftY;
            public short rightX, rightY;

            public short qx, qy, qz;
            public short ax, ay, az;
            public short gx, gy, gz;
        }

        internal struct ConnectionEvent
        {
            public uint eventType;
            public byte details;
        }

        internal struct BatteryEvent
        {
            public uint eventType;
            public ushort voltage;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Event
        {
            [FieldOffsetAttribute(0)]
            public byte eventType;

            [FieldOffsetAttribute(0)]
            public InputEvent input;

            [FieldOffsetAttribute(0)]
            public ConnectionEvent connection;

            [FieldOffsetAttribute(0)]
            public BatteryEvent battery;
        }

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_ReadEvent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool ReadEvent(IntPtr pDevice, out Event evt);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_TriggerHaptic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool TriggerHaptic(IntPtr pDevice, ushort motor, ushort onTime, ushort offTime, ushort count);

        [DllImportAttribute("SteamController", EntryPoint = "SteamController_PlayMelody", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool PlayMelody(IntPtr pDevice, uint id);
    }
}

