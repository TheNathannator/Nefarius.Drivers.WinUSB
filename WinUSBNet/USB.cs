/*  WinUSBNet library
 *  (C) 2010 Thomas Bleeker (www.madwizard.org)
 *
 *  Licensed under the MIT license, see license.txt or:
 *  http://www.opensource.org/licenses/mit-license.php
 */

using Windows.Win32;
using Windows.Win32.Devices.Usb;

namespace Nefarius.Drivers.WinUSB;

/// <summary>
///     USB base class code enumeration, as defined in the USB specification
/// </summary>
public enum USBBaseClass
{
    /// <summary>
    ///     Unknown non-zero class code. Used when the actual class code
    ///     does not match any of the ones defined in this enumeration.
    /// </summary>
    Unknown = -1,

    /// <summary>Base class defined elsewhere (0x00)</summary>
    None = 0x00,

    /// <summary>Audio base class (0x01)</summary>
    Audio = 0x01,

    /// <summary>Communications and CDC control base class (0x02)</summary>
    CommCDC = 0x02,

    /// <summary>HID base class (0x03)</summary>
    HID = 0x03,

    /// <summary>Physical base class (0x05)</summary>
    Physical = 0x05,

    /// <summary>Image base class (0x06)</summary>
    Image = 0x06,

    /// <summary>Printer base class (0x07)</summary>
    Printer = 0x07,

    /// <summary>Mass storage base class (0x08)</summary>
    MassStorage = 0x08,

    /// <summary>Hub base class (0x09)</summary>
    Hub = 0x09,

    /// <summary>CDC data base class (0x0A)</summary>
    CDCData = 0x0A,

    /// <summary>Smart card base class (0x0B)</summary>
    SmartCard = 0x0B,

    /// <summary>Content security base class (0x0D)</summary>
    ContentSecurity = 0x0D,

    /// <summary>Video base class (0x0E)</summary>
    Video = 0x0E,

    /// <summary>Personal health care base class (0x0F)</summary>
    PersonalHealthcare = 0x0F,

    /// <summary>Diagnostic device base class (0xDC)</summary>
    DiagnosticDevice = 0xDC,

    /// <summary>Wireless controller base class (0xE0)</summary>
    WirelessController = 0xE0,

    /// <summary>Miscellaneous base class (0xEF)</summary>
    Miscellaneous = 0xEF,

    /// <summary>Application specific base class (0xFE)</summary>
    ApplicationSpecific = 0xFE,

    /// <summary>Vendor specific base class (0xFF)</summary>
    VendorSpecific = 0xFF
}

/// <summary>
///     USB transfer type enumeration
/// </summary>
public enum USBTransferType
{
    /// <summary>The pipe is a control transfer pipe</summary>
    Control = USBD_PIPE_TYPE.UsbdPipeTypeControl,

    /// <summary>The pipe is an isochronous transfer pipe</summary>
    Isochronous = USBD_PIPE_TYPE.UsbdPipeTypeIsochronous,

    /// <summary>The pipe is a bulk transfer pipe</summary>
    Bulk = USBD_PIPE_TYPE.UsbdPipeTypeBulk,

    /// <summary>The pipe is an interrupt transfer pipe</summary>
    Interrupt = USBD_PIPE_TYPE.UsbdPipeTypeInterrupt,
}

/// <summary>
///     The recipient for bmRequestType.<br/>
///     OR together with a value from <see cref="USBRequestType"/> and <see cref="USBRequestDirection"/> to create a
///     bmRequestType value.
/// </summary>
public enum USBRequestRecipient : byte
{
    /// <summary>The device will receive the request.</summary>
    Device = (byte)PInvoke.BMREQUEST_TO_DEVICE,

    /// <summary>The interface will receive the request.</summary>
    Interface = (byte)PInvoke.BMREQUEST_TO_INTERFACE,

    /// <summary>The endpoint will receive the request.</summary>
    Endpoint = (byte)PInvoke.BMREQUEST_TO_ENDPOINT,

    /// <summary>Some other recipient will receive the request.</summary>
    Other = (byte)PInvoke.BMREQUEST_TO_OTHER,
}

/// <summary>
///     The request type for bmRequestType. (Pre-bit-shifted for your convenience.)<br/>
///     OR together with a value from <see cref="USBRequestRecipient"/> and <see cref="USBRequestDirection"/> to create
///     a bmRequestType value.
/// </summary>
public enum USBRequestType : byte
{
    /// <summary>A USB-defined request.</summary>
    Standard = (byte)(PInvoke.BMREQUEST_STANDARD << 5),

    /// <summary>A class-defined request.</summary>
    Class = (byte)(PInvoke.BMREQUEST_CLASS << 5),

    /// <summary>A vendor-defined request.</summary>
    Vendor = (byte)(PInvoke.BMREQUEST_VENDOR << 5),
}

/// <summary>
///     The direction for bmRequestType. (Pre-bit-shifted for your convenience.)<br/>
///     OR together with a value from <see cref="USBRequestRecipient"/> and <see cref="USBRequestType"/> to create a
///     bmRequestType value.
/// </summary>
public enum USBRequestDirection : byte
{
    /// <summary>Data is sent from the host to the device.</summary>
    HostToDevice = (byte)(PInvoke.BMREQUEST_HOST_TO_DEVICE << 7),

    /// <summary>Data is sent from the device to the host.</summary>
    DeviceToHost = (byte)(PInvoke.BMREQUEST_DEVICE_TO_HOST << 7)
}

/// <summary>
///     Standard bRequest values for a transfer.
/// </summary>
public enum USBRequest : byte
{
    /// <summary>Get the status of the recipient.</summary>
    GetStatus = (byte)PInvoke.USB_REQUEST_GET_STATUS,

    /// <summary>Disable a feature on the recipient.</summary>
    ClearFeature = (byte)PInvoke.USB_REQUEST_CLEAR_FEATURE,

    /// <summary>Enable a feature on the recipient.</summary>
    SetFeature = (byte)PInvoke.USB_REQUEST_SET_FEATURE,

    /// <summary>Set the address to use for the device.</summary>
    SetAddress = (byte)PInvoke.USB_REQUEST_SET_ADDRESS,

    /// <summary>Get a descriptor from the device.</summary>
    GetDescriptor = (byte)PInvoke.USB_REQUEST_GET_DESCRIPTOR,

    /// <summary>Update or add a descriptor to the device.</summary>
    SetDescriptor = (byte)PInvoke.USB_REQUEST_SET_DESCRIPTOR,

    /// <summary>Get the current configuration value for the device.</summary>
    GetConfiguration = (byte)PInvoke.USB_REQUEST_GET_CONFIGURATION,

    /// <summary>Set the current configuration state of the device.</summary>
    SetConfiguration = (byte)PInvoke.USB_REQUEST_SET_CONFIGURATION,

    /// <summary>Get the current alternate setting for an interface.</summary>
    GetInterface = (byte)PInvoke.USB_REQUEST_GET_INTERFACE,

    /// <summary>Set the current alternate setting of an interface.</summary>
    SetInterface = (byte)PInvoke.USB_REQUEST_SET_INTERFACE,

    /// <summary>Set, then get, an endpoint's synchronization frame.</summary>
    SyncFrame = (byte)PInvoke.USB_REQUEST_SYNC_FRAME,
}
