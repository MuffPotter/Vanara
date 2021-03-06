﻿using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The AllocateAndInitializeSid function allocates and initializes a security identifier (SID) with up to eight subauthorities.</summary>
		/// <param name="sia">
		/// A pointer to a SID_IDENTIFIER_AUTHORITY structure. This structure provides the top-level identifier authority value to set in the SID.
		/// </param>
		/// <param name="subAuthorityCount">
		/// Specifies the number of subauthorities to place in the SID. This parameter also identifies how many of the subauthority
		/// parameters have meaningful values. This parameter must contain a value from 1 to 8.
		/// <para>
		/// For example, a value of 3 indicates that the subauthority values specified by the dwSubAuthority0, dwSubAuthority1, and
		/// dwSubAuthority2 parameters have meaningful values and to ignore the remainder.
		/// </para>
		/// </param>
		/// <param name="dwSubAuthority0">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority1">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority2">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority3">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority4">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority5">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority6">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority7">Subauthority value to place in the SID.</param>
		/// <param name="pSid">A pointer to a variable that receives the pointer to the allocated and initialized SID structure.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa375213")]
		public static extern bool AllocateAndInitializeSid([In] PSID_IDENTIFIER_AUTHORITY sia,
			byte subAuthorityCount, int dwSubAuthority0, int dwSubAuthority1,
			int dwSubAuthority2, int dwSubAuthority3, int dwSubAuthority4,
			int dwSubAuthority5, int dwSubAuthority6, int dwSubAuthority7, out SafeAllocatedSID pSid);

		/// <summary>The CopySid function copies a security identifier (SID) to a buffer.</summary>
		/// <param name="cbDestSid">Specifies the length, in bytes, of the buffer receiving the copy of the SID.</param>
		/// <param name="destSid">A pointer to a buffer that receives a copy of the source SID structure.</param>
		/// <param name="sourceSid">
		/// A pointer to a SID structure that the function copies to the buffer pointed to by the pDestinationSid parameter.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa376404")]
		public static extern bool CopySid(int cbDestSid, IntPtr destSid, PSID sourceSid);

		/// <summary>
		/// The EqualSid function tests two security identifier (SID) values for equality. Two SIDs must match exactly to be considered equal.
		/// </summary>
		/// <param name="sid1">A pointer to the first SID structure to compare. This structure is assumed to be valid.</param>
		/// <param name="sid2">A pointer to the second SID structure to compare. This structure is assumed to be valid.</param>
		/// <returns>
		/// If the SID structures are equal, the return value is nonzero.
		/// <para>If the SID structures are not equal, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>If either SID structure is not valid, the return value is undefined.</para>
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446622")]
		public static extern bool EqualSid(PSID sid1, PSID sid2);

		/// <summary>
		/// The FreeSid function frees a security identifier (SID) previously allocated by using the AllocateAndInitializeSid function.
		/// </summary>
		/// <param name="pSid">A pointer to the SID structure to free.</param>
		/// <returns>
		/// If the function succeeds, the function returns NULL. If the function fails, it returns a pointer to the SID structure represented
		/// by the pSid parameter.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446631")]
		public static extern PSID FreeSid(SafeAllocatedSID pSid);

		/// <summary>The GetLengthSid function returns the length, in bytes, of a valid security identifier (SID).</summary>
		/// <param name="pSid">A pointer to the SID structure whose length is returned. The structure is assumed to be valid.</param>
		/// <returns>
		/// If the SID structure is valid, the return value is the length, in bytes, of the SID structure.
		/// <para>
		/// If the SID structure is not valid, the return value is undefined. Before calling GetLengthSid, pass the SID to the IsValidSid
		/// function to verify that the SID is valid.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446642")]
		public static extern int GetLengthSid(PSID pSid);

		/// <summary>
		/// <para>
		/// The <c>GetSidIdentifierAuthority</c> function returns a pointer to the SID_IDENTIFIER_AUTHORITY structure in a specified security
		/// identifier (SID).
		/// </para>
		/// </summary>
		/// <param name="pSid">
		/// <para>A pointer to the SID structure for which a pointer to the SID_IDENTIFIER_AUTHORITY structure is returned.</para>
		/// <para>
		/// This function does not handle SID structures that are not valid. Call the IsValidSid function to verify that the <c>SID</c>
		/// structure is valid before you call this function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a pointer to the SID_IDENTIFIER_AUTHORITY structure for the specified SID structure.
		/// </para>
		/// <para>
		/// If the function fails, the return value is undefined. The function fails if the SID structure pointed to by the pSid parameter is
		/// not valid. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function uses a 32-bit RID value. For applications that require a larger RID value, use CreateWellKnownSid and related functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsididentifierauthority
		// PSID_IDENTIFIER_AUTHORITY GetSidIdentifierAuthority( PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "67a06e7b-775f-424c-ab36-0fc9b93b801a")]
		public static extern PSID_IDENTIFIER_AUTHORITY GetSidIdentifierAuthority(PSID pSid);

		/// <summary>
		/// <para>
		/// The <c>GetSidLengthRequired</c> function returns the length, in bytes, of the buffer required to store a SID with a specified
		/// number of subauthorities.
		/// </para>
		/// </summary>
		/// <param name="nSubAuthorityCount">
		/// <para>Specifies the number of subauthorities to be stored in the SID structure.</para>
		/// </param>
		/// <returns>
		/// <para>The return value is the length, in bytes, of the buffer required to store the SID structure. This function cannot fail.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The SID structure specified in nSubAuthorityCount uses a 32-bit RID value. For applications that require longer RID values, use
		/// CreateWellKnownSid and related functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsidlengthrequired DWORD
		// GetSidLengthRequired( UCHAR nSubAuthorityCount );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "a481fb4f-20bd-4f44-a3d5-d8b8d6228339")]
		public static extern uint GetSidLengthRequired(byte nSubAuthorityCount);

		/// <summary>
		/// The GetSidSubAuthority function returns a pointer to a specified subauthority in a security identifier (SID). The subauthority
		/// value is a relative identifier (RID).
		/// </summary>
		/// <param name="pSid">A pointer to the SID structure from which a pointer to a subauthority is to be returned.</param>
		/// <param name="nSubAuthority">
		/// Specifies an index value identifying the subauthority array element whose address the function will return. The function performs
		/// no validation tests on this value. An application can call the GetSidSubAuthorityCount function to discover the range of
		/// acceptable values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a pointer to the specified SID subauthority. To get extended error information,
		/// call GetLastError.
		/// <para>
		/// If the function fails, the return value is undefined. The function fails if the specified SID structure is not valid or if the
		/// index value specified by the nSubAuthority parameter is out of bounds.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446657")]
		public static extern IntPtr GetSidSubAuthority(PSID pSid, uint nSubAuthority);

		/// <summary>
		/// The IsValidSid function validates a security identifier (SID) by verifying that the revision number is within a known range, and
		/// that the number of subauthorities is less than the maximum.
		/// </summary>
		/// <param name="pSid">A pointer to the SID structure to validate. This parameter cannot be NULL.</param>
		/// <returns>
		/// If the SID structure is valid, the return value is nonzero. If the SID structure is not valid, the return value is zero. There is
		/// no extended error information for this function; do not call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa379151")]
		public static extern bool IsValidSid(PSID pSid);

		/// <summary>Provides a <see cref="SafeHandle"/> to an allocated SID that is released at disposal using FreeSid.</summary>
		public class SafeAllocatedSID : SafeHANDLE, ISecurityObject
		{
			/// <summary>Initializes a new instance of the <see cref="SafeAllocatedSID"/> class.</summary>
			private SafeAllocatedSID() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedSID"/> to <see cref="PSID"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSID(SafeAllocatedSID h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => FreeSid(this).IsNull;
		}
	}
}