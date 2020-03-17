using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;
using CoreVideo;

namespace Twilio.Video.iOS
{
	// typedef void (^TVIAudioDeviceWorkerBlock)();
	delegate void TVIAudioDeviceWorkerBlock();

	public static class CFunctions
	{
		// extern void TVIAudioDeviceFormatChanged (TVIAudioDeviceContext _Nonnull context) __attribute__((swift_name("AudioDeviceFormatChanged(context:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVIAudioDeviceFormatChanged (void* context);

		// extern void TVIAudioDeviceWriteCaptureData (TVIAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes) __attribute__((swift_name("AudioDeviceWriteCaptureData(context:data:sizeInBytes:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVIAudioDeviceWriteCaptureData (void* context, sbyte* data, nuint sizeInBytes);

		// extern void TVIAudioDeviceReadRenderData (TVIAudioDeviceContext _Nonnull context, int8_t * _Nonnull data, size_t sizeInBytes) __attribute__((swift_name("AudioDeviceReadRenderData(context:data:sizeInBytes:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVIAudioDeviceReadRenderData (void* context, sbyte* data, nuint sizeInBytes);

		// extern void TVIAudioDeviceExecuteWorkerBlock (TVIAudioDeviceContext _Nonnull context, TVIAudioDeviceWorkerBlock _Nonnull block) __attribute__((swift_name("AudioDeviceExecuteWorkerBlock(context:block:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void TVIAudioDeviceExecuteWorkerBlock (void* context, TVIAudioDeviceWorkerBlock block);

		// CGAffineTransform TVIVideoOrientationMakeTransform (TVIVideoOrientation orientation) __attribute__((swift_name("VideoOrientation.makeTransform(orientation:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern CGAffineTransform TVIVideoOrientationMakeTransform (TVIVideoOrientation orientation);

		// BOOL TVIVideoOrientationIsRotated (TVIVideoOrientation orientation) __attribute__((swift_name("VideoOrientation.isRotated(orientation:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern bool TVIVideoOrientationIsRotated (TVIVideoOrientation orientation);

		// BOOL TVIVideoOrientationIsValid (TVIVideoOrientation orientation) __attribute__((swift_name("VideoOrientation.isValid(orientation:)")));
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern bool TVIVideoOrientationIsValid (TVIVideoOrientation orientation);
	}

	[Native]
	public enum TVITrackState : ulong
	{
		Ended = 0,
		Live
	}

	public enum TVIPixelFormat : uint
	{
		TVIPixelFormat32ARGB = CVPixelFormatType.CV32ARGB,
		TVIPixelFormat32BGRA = CVPixelFormatType.CV32BGRA,
		YUV420BiPlanarVideoRange = CVPixelFormatType.CV420YpCbCr8BiPlanarVideoRange,
		YUV420BiPlanarFullRange = CVPixelFormatType.CV420YpCbCr8BiPlanarFullRange,
		YUV420PlanarVideoRange = CVPixelFormatType.CV420YpCbCr8Planar,
		YUV420PlanarFullRange = CVPixelFormatType.CV420YpCbCr8PlanarFullRange
	}

	[Native]
	public enum TVIVideoOrientation : ulong
	{
		Up = 0,
		Left,
		Down,
		Right
	}

	[Native]
	public enum TVICameraSourceError : ulong
	{
		None = 0,
		AlreadyRunning
	}

	[Native]
	public enum TVICameraSourceOptionsRotationTags : ulong
	{
		Keep = 0,
		Remove
	}

	[Native]
	public enum TVIError : long
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
		SignalingDnsResolutionError = 53005,
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
		ParticipantInvalidSubscribeRuleError = 53215,
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
	public enum TVINetworkQualityVerbosity : ulong
	{
		None = 0,
		Minimal
	}

	[Native]
	public enum TVIRoomState : ulong
	{
		Connecting = 0,
		Connected,
		Disconnected,
		Reconnecting
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
