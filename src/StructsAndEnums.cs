using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;
using Foundation;

namespace Twilio.Video.iOS
{
	static class CFunctions
	{
		// extern void TVIAudioDeviceFormatChanged (TVIAudioDeviceContext _Nonnull context);
		//[DllImport ("__Internal")]
		[Export("TVIAudioDeviceFormatChanged")]
		static extern unsafe void TVIAudioDeviceFormatChanged (IntPtr context);

		// extern void TVIAudioDeviceWriteCaptureData (TVIAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes);
		//[DllImport ("__Internal")]
		[Export("TVIAudioDeviceWriteCaptureData")]
		static extern unsafe void TVIAudioDeviceWriteCaptureData (IntPtr context, sbyte* data, ulong sizeInBytes);

		// extern void TVIAudioDeviceReadRenderData (TVIAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes);
		//[DllImport ("__Internal")]
		[Export("TVIAudioDeviceReadRenderData")]
		static extern unsafe void TVIAudioDeviceReadRenderData (IntPtr context, sbyte* data, ulong sizeInBytes);

		// extern void TVIAudioDeviceExecuteWorkerBlock (TVIAudioDeviceContext _Nonnull context, TVIAudioDeviceWorkerBlock _Nonnull block);
		//[DllImport ("__Internal")]
		[Export("TVIAudioDeviceExecuteWorkerBlock")]
		static extern unsafe void TVIAudioDeviceExecuteWorkerBlock (IntPtr context, IntPtr block);

		// extern void TVIAudioSessionActivated (TVIAudioDeviceContext _Nonnull context);
		//[DllImport ("__Internal")]
		[Export("TVIAudioSessionActivated")]
		static extern unsafe void TVIAudioSessionActivated (IntPtr context);

		// extern void TVIAudioSessionDeactivated (TVIAudioDeviceContext _Nonnull context);
		//[DllImport ("__Internal")]
		[Export("TVIAudioSessionDeactivated")]
		static extern unsafe void TVIAudioSessionDeactivated (IntPtr context);

		// CGAffineTransform TVIVideoOrientationMakeTransform (TVIVideoOrientation orientation);
		//[DllImport ("__Internal")]
		[Export("TVIVideoOrientationMakeTransform")]
		static extern CGAffineTransform TVIVideoOrientationMakeTransform (TVIVideoOrientation orientation);

		// BOOL TVIVideoOrientationIsRotated (TVIVideoOrientation orientation);
		//[DllImport ("__Internal")]
		[Export("TVIVideoOrientationIsRotated")]
		static extern bool TVIVideoOrientationIsRotated (TVIVideoOrientation orientation);

		// BOOL TVIVideoOrientationIsValid (TVIVideoOrientation orientation);
		//[DllImport ("__Internal")]
		[Export("TVIVideoOrientationIsValid")]
		static extern bool TVIVideoOrientationIsValid (TVIVideoOrientation orientation);

		// TVIAspectRatio TVIAspectRatioMake (NSUInteger numerator, NSUInteger denominator);
		//[DllImport ("__Internal")]
		[Export("TVIAspectRatioMake")]
		static extern TVIAspectRatio TVIAspectRatioMake (ulong numerator, ulong denominator);
	}

	[Native]
	public enum TVITrackState : ulong
	{
		Ended = 0,
		Live
	}

	[Native]
	public enum TVIVideoOrientation : ulong
	{
		Up = 0,
		Left,
		Down,
		Right
	}

	// TODO
	// public enum TVIPixelFormat : uint
	// {
	// 	TVIPixelFormat32ARGB = kCVPixelFormatType_32ARGB,
	// 	TVIPixelFormat32BGRA = kCVPixelFormatType_32BGRA,
	// 	YUV420BiPlanarVideoRange = kCVPixelFormatType_420YpCbCr8BiPlanarVideoRange,
	// 	YUV420BiPlanarFullRange = kCVPixelFormatType_420YpCbCr8BiPlanarFullRange,
	// 	YUV420PlanarVideoRange = kCVPixelFormatType_420YpCbCr8Planar,
	// 	YUV420PlanarFullRange = kCVPixelFormatType_420YpCbCr8PlanarFullRange
	// }

	[Native]
	public enum TVICameraCaptureSource : ulong
	{
		FrontCamera = 0,
		BackCameraWide,
		BackCameraTelephoto
	}

	[Native]
	public enum TVICameraSourceError : ulong
	{
		None = 0,
		AlreadyRunning
	}

	[Native]
	public enum TVIError : ulong
	{
		Unknown = 0,
		AccessTokenInvalidError = 20101,
		AccessTokenHeaderInvalidError = 20102,
		AccessTokenIssuerInvalidError = 20103,
		AccessTokenExpiredError = 20104,
		AccessTokenNotYetValidError = 20105,
		AccessTokenGrantsInvalidError = 20106,
		AccessTokenSignatureInvalidError = 20107,
		SignalingConnectionError = 53000,
		SignalingConnectionDisconnectedError = 53001,
		SignalingConnectionTimeoutError = 53002,
		SignalingIncomingMessageInvalidError = 53003,
		SignalingOutgoingMessageInvalidError = 53004,
		RoomNameInvalidError = 53100,
		RoomNameTooLongError = 53101,
		RoomNameCharsInvalidError = 53102,
		RoomCreateFailedError = 53103,
		RoomConnectFailedError = 53104,
		RoomMaxParticipantsExceededError = 53105,
		RoomNotFoundError = 53106,
		RoomMaxParticipantsOutOfRangeError = 53107,
		RoomTypeInvalidError = 53108,
		RoomTimeoutOutOfRangeError = 53109,
		RoomStatusCallbackMethodInvalidError = 53110,
		RoomStatusCallbackInvalidError = 53111,
		RoomStatusInvalidError = 53112,
		RoomRoomExistsError = 53113,
		RoomInvalidParametersError = 53114,
		RoomMediaRegionInvalidError = 53115,
		RoomMediaRegionUnavailableError = 53116,
		RoomSubscriptionOperationNotSupportedError = 53117,
		RoomRoomCompletedError = 53118,
		ParticipantIdentityInvalidError = 53200,
		ParticipantIdentityTooLongError = 53201,
		ParticipantIdentityCharsInvalidError = 53202,
		ParticipantMaxTracksExceededError = 53203,
		ParticipantNotFoundError = 53204,
		ParticipantDuplicateIdentityError = 53205,
		TrackInvalidError = 53300,
		TrackNameInvalidError = 53301,
		TrackNameTooLongError = 53302,
		TrackNameCharsInvalidError = 53303,
		TrackNameIsDuplicatedError = 53304,
		TrackServerTrackCapacityReachedError = 53305,
		MediaClientLocalDescFailedError = 53400,
		MediaServerLocalDescFailedError = 53401,
		MediaClientRemoteDescFailedError = 53402,
		MediaServerRemoteDescFailedError = 53403,
		MediaNoSupportedCodecError = 53404,
		MediaConnectionError = 53405,
		MediaDataTrackFailedError = 53406,
		ConfigurationAcquireFailedError = 53500,
		ConfigurationAcquireTurnFailedError = 53501
	}

	[Native]
	public enum TVIIceCandidatePairState : ulong
	{
		Succeeded,
		Frozen,
		Waiting,
		InProgress,
		Failed,
		Cancelled,
		Unknown
	}

	[Native]
	public enum TVIIceTransportPolicy : ulong
	{
		All = 0,
		Relay = 1
	}

	public enum TVIIsacCodecSampleRate : ushort
	{
		Wideband = 16000,
		SuperWideband = 32000
	}

	[Native]
	public enum TVINetworkQualityLevel : long
	{
		Unknown = -1,
		Zero = 0,
		One,
		Two,
		Three,
		Four,
		Five
	}

	[Native]
	public enum TVIRoomState : ulong
	{
		Connecting = 0,
		Connected,
		Disconnected,
		Reconnecting
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct TVIAspectRatio
	{
		public nuint numerator;

		public nuint denominator;
	}

	[Native]
	public enum TVIVideoRenderingType : ulong
	{
		Metal = 0,
		OpenGLES
	}

	[Native]
	public enum TVILogLevel : ulong
	{
		Off = 0,
		Fatal,
		Error,
		Warning,
		Info,
		Debug,
		Trace,
		All
	}

	[Native]
	public enum TVILogModule : ulong
	{
		Core = 0,
		Platform,
		Signaling,
		WebRTC
	}
}
