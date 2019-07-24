using System;
using System.Runtime.InteropServices;

namespace Citrullia
{
    /// <summary>
    /// Class containing the native API methods. Used for moving the forms-
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>An <see cref="IntPtr"/> with the value of 0 (zero). Used as the "lParam" in <see cref="SendMessage(IntPtr, IntPtr, IntPtr, IntPtr)"/>.</summary>
        internal static readonly IntPtr ZERO_INTPTR = new IntPtr(0);
        /// <summary>An <see cref="IntPtr"/> with the value of hexadecimal A1 (Decimal: x). Messages that the left mouse button is pressed while the cursor is within the nonclient area of a window.
        /// Used as the "Msg" in <see cref="SendMessage(IntPtr, IntPtr, IntPtr, IntPtr)"/>. </summary>
        internal static readonly IntPtr WM_NCLBUTTONDOWN = new IntPtr(0xA1);
        /// <summary>An <see cref="IntPtr"/> with the value of 2. Messages that the cursor is over the title bar. Used as the "wParam" in <see cref="SendMessage(IntPtr, IntPtr, IntPtr, IntPtr)"/>.</summary>
        internal static readonly IntPtr HT_CAPTION = new IntPtr(0x2);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// Source: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="Msg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, IntPtr Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Releases the mouse capture from a window in the current thread and restores normal mouse input processing.
        /// Source: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasecapture
        /// </summary>
        /// <returns>True, if successful; Otherwise, false.</returns>
        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();
    }
}
