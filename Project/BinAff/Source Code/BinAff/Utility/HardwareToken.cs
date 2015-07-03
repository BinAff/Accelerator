using System;
using System.Management;

namespace BinAff.Utility.Hardware
{

    internal static class Token
    {

        internal static String GetIdentifier(String wmiClass, String wmiProperty)
        {
            foreach (ManagementObject mo in new ManagementClass(wmiClass).GetInstances())
            {
                try
                {
                    return mo[wmiProperty].ToString();
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        internal static String GetIdentifier(String wmiClass, String wmiProperty, String wmiMustBeTrue)
        {
            foreach (ManagementObject mo in new ManagementClass(wmiClass).GetInstances())
            {
                try
                {
                    if ((Boolean)mo[wmiMustBeTrue])
                    {
                        return mo[wmiProperty].ToString();
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

    }

    public static class NetworkCard
    {

        /// <summary>
        /// Network Card Identifier
        /// </summary>
        public static String MacId
        {
            get
            {
                return Token.GetIdentifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
            }
        }

    }

    /// <summary>
    /// Motherboard / Mainboard / Baseboard identifiers
    /// </summary>
    public static class MotherBoard
    {

        /// <summary>
        /// Mainboard / Motherboard Serial Number
        /// </summary>
        public static String SerialNumber
        {
            get
            {
                return Token.GetIdentifier("Win32_BaseBoard", "SerialNumber");
            }
        }

        /// <summary>
        /// Mainboard / Motherboard Model
        /// </summary>
        public static String Model
        {
            get
            {
                return Token.GetIdentifier("Win32_BaseBoard", "Model");
            }
        }

        /// <summary>
        /// Mainboard / Motherboard Name
        /// </summary>
        public static String Name
        {
            get
            {
                return Token.GetIdentifier("Win32_BaseBoard", "Name");
            }
        }

        /// <summary>
        /// Mainboard / Motherboard Manufacturer
        /// </summary>
        public static String Manufacturer
        {
            get
            {
                return Token.GetIdentifier("Win32_BaseBoard", "Manufacturer");
            }
        }

    }

    /// <summary>
    /// Processor Identifiers
    /// </summary>
    public static class Processor
    {

        /// <summary>
        /// Processor Identifier
        /// </summary>
        public static String Identifier
        {
            get
            {
                return Token.GetIdentifier("Win32_Processor", "ProcessorId");
            }
        }

        /// <summary>
        /// Processor's Unique Identifier
        /// </summary>
        public static String UniqueId
        {
            get
            {
                return Token.GetIdentifier("Win32_Processor", "UniqueId");
            }
        }

        /// <summary>
        /// Processor Name
        /// </summary>
        public static String Name
        {
            get
            {
                return Token.GetIdentifier("Win32_Processor", "Name");
            }
        }

        /// <summary>
        /// Processor Manufacturer
        /// </summary>
        public static String Manufacturer
        {
            get
            {
                return Token.GetIdentifier("Win32_Processor", "Manufacturer");
            }
        }

        /// <summary>
        /// Processor's Maximum Clock Speed
        /// </summary>
        public static String MaxClockSpeed
        {
            get
            {
                return Token.GetIdentifier("Win32_Processor", "MaxClockSpeed");
            }
        }

    }
    
    /// <summary>
    /// BIOS Identifiers
    /// </summary>
    public static class Bios
    {

        /// <summary>
        /// BIOS Identification Code
        /// </summary>
        public static String IdentificationCode
        {
            get
            {
                return Token.GetIdentifier("Win32_BIOS", "IdentificationCode");
            }
        }

        /// <summary>
        /// BIOS Serial Number
        /// </summary>
        public static String SerialNumber
        {
            get
            {
                return Token.GetIdentifier("Win32_BIOS", "SerialNumber");
            }
        }

        /// <summary>
        /// BIOS Version
        /// </summary>
        public static String Version
        {
            get
            {
                return Token.GetIdentifier("Win32_BIOS", "Version");
            }
        }

        /// <summary>
        /// BIOS Manufacturer
        /// </summary>
        public static String Manufacturer
        {
            get
            {
                return Token.GetIdentifier("Win32_BIOS", "Manufacturer");
            }
        }

        /// <summary>
        /// BIOS Release Date
        /// </summary>
        public static String ReleaseDate
        {
            get
            {
                return Token.GetIdentifier("Win32_BIOS", "ReleaseDate");
            }
        }

    }

    /// <summary>
    /// Hard Disk Drive Identifiers
    /// </summary>
    public static class HardDisk
    {

        /// <summary>
        /// Hard Disk Drive Model
        /// </summary>
        public static String Model
        {
            get
            {
                return Token.GetIdentifier("Win32_DiskDrive", "Model");
            }
        }

        /// <summary>
        /// Hard Disk Drive Signature
        /// </summary>
        public static String Signature
        {
            get
            {
                return Token.GetIdentifier("Win32_DiskDrive", "Signature");
            }
        }

        /// <summary>
        /// Hard Disk Drive Total Heads
        /// </summary>
        public static String TotalHeads
        {
            get
            {
                return Token.GetIdentifier("Win32_DiskDrive", "TotalHeads");
            }
        }

        /// <summary>
        /// Hard Disk Drive Manufacturer
        /// </summary>
        public static String Manufacturer
        {
            get
            {
                return Token.GetIdentifier("Win32_DiskDrive", "Manufacturer");
            }
        }

        /// <summary>
        /// Hard Disk Drive Type
        /// </summary>
        public static String Type
        {
            get
            {
                return Token.GetIdentifier("Win32_DiskDrive", "Type");
            }
        }

        /// <summary>
        /// Hard Disk Drive Interface Type
        /// </summary>
        public static String InterfaceType
        {
            get
            {
                return Token.GetIdentifier("Win32_DiskDrive", "InterfaceType");
            }
        }

    }

    /// <summary>
    /// Video Controller Identifiers
    /// </summary>
    public static class VideoController
    {

        /// <summary>
        /// Video Controller Name
        /// </summary>
        public static String Name
        {
            get
            {
                return Token.GetIdentifier("Win32_VideoController", "Name");
            }
        }

        /// <summary>
        /// Video Controller Driver Version
        /// </summary>
        public static String DriverVersion
        {
            get
            {
                return Token.GetIdentifier("Win32_VideoController", "DriverVersion");
            }
        }

    }

}