using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Interop
{
    [ComImport, SuppressUnmanagedCodeSecurity,
        Guid("28F54685-06FD-11D2-B27A-00A0C9223196"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IKsControl
    {
        [PreserveSig]
        int KsProperty(
          [In] ref KSMETHOD Property,
          [In] Int32 PropertyLength,
          [In, Out] IntPtr PropertyData,
          [In] Int32 DataLength,
          [In, Out] ref Int32 BytesReturned
          );

        [PreserveSig]
        int KsMethod(
          [In] ref KSMETHOD Method,
          [In] Int32 MethodLength,
          [In, Out] IntPtr MethodData,
          [In] Int32 DataLength,
          [In, Out] ref Int32 BytesReturned
          );

        [PreserveSig]
        int KsEvent(
          [In, Optional] ref KSMETHOD Event,
          [In] Int32 EventLength,
          [In, Out] IntPtr EventData,
          [In] Int32 DataLength,
          [In, Out] ref Int32 BytesReturned
          );
    }

    internal struct KSMETHOD
    {
        public Guid Set;
        public Int32 Id;
        public Int32 Flags;

        public KSMETHOD(Guid set, Int32 id, Int32 flags)
        {
            Set = set;
            Id = (Int32)id;
            Flags = (Int32)flags;
        }
    }
}
