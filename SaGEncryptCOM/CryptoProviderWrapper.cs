using System;
using System.Runtime.InteropServices;

namespace SaGEncryptCOM
{
    sealed class CryptoProviderWrapper
    {
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string MakeOwnerKeys([MarshalAs(UnmanagedType.VBByRefStr)] ref string sLockID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string MakeDispKeys([MarshalAs(UnmanagedType.VBByRefStr)] ref string sDispBlock, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string MakeDispBlock([MarshalAs(UnmanagedType.VBByRefStr)] ref string sDispID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sStartDate, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sEndDate, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sFlags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sDispBlock);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string MakeReqBlock(int nCommand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sStartDate, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sLockStatus, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sOpCode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sTouchKeyID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sPIN, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sParm, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sReqBlock);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string AccessOpCode([MarshalAs(UnmanagedType.VBByRefStr)] ref string sReqBlock, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sOpCode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sAccessOpCode);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string DecryptDataStr([MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sData);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string EncryptDataStr([MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sData);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string DecryptData([MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sData);
        [DllImport("Encrypt.Dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern string EncryptData([MarshalAs(UnmanagedType.VBByRefStr)] ref string sKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string sData);
    }
}
