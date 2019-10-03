using System;
using AVFoundation;
using AudioToolbox;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace Twilio.Video.iOS
{
	// @interface TVIAudioCodec : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAudioCodec
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	[Static]
	partial interface Constants
	{
		// extern const uint32_t TVIAudioSampleRate8000;
		[Field ("TVIAudioSampleRate8000", "__Internal")]
		uint TVIAudioSampleRate8000 { get; }

		// extern const uint32_t TVIAudioSampleRate16000;
		[Field ("TVIAudioSampleRate16000", "__Internal")]
		uint TVIAudioSampleRate16000 { get; }

		// extern const uint32_t TVIAudioSampleRate24000;
		[Field ("TVIAudioSampleRate24000", "__Internal")]
		uint TVIAudioSampleRate24000 { get; }

		// extern const uint32_t TVIAudioSampleRate32000;
		[Field ("TVIAudioSampleRate32000", "__Internal")]
		uint TVIAudioSampleRate32000 { get; }

		// extern const uint32_t TVIAudioSampleRate44100;
		[Field ("TVIAudioSampleRate44100", "__Internal")]
		uint TVIAudioSampleRate44100 { get; }

		// extern const uint32_t TVIAudioSampleRate48000;
		[Field ("TVIAudioSampleRate48000", "__Internal")]
		uint TVIAudioSampleRate48000 { get; }

		// extern const size_t TVIAudioChannelsMono;
		[Field ("TVIAudioChannelsMono", "__Internal")]
		nuint TVIAudioChannelsMono { get; }

		// extern const size_t TVIAudioChannelsStereo;
		[Field ("TVIAudioChannelsStereo", "__Internal")]
		nuint TVIAudioChannelsStereo { get; }
	}

	// @interface TVIAudioFormat : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAudioFormat
	{
		// @property (readonly, assign, nonatomic) size_t numberOfChannels;
		[Export ("numberOfChannels")]
		nuint NumberOfChannels { get; }

		// @property (readonly, assign, nonatomic) uint32_t sampleRate;
		[Export ("sampleRate")]
		uint SampleRate { get; }

		// @property (readonly, assign, nonatomic) size_t framesPerBuffer;
		[Export ("framesPerBuffer")]
		nuint FramesPerBuffer { get; }

		// -(instancetype _Nullable)initWithChannels:(size_t)channels sampleRate:(uint32_t)sampleRate framesPerBuffer:(size_t)framesPerBuffer;
		[Export ("initWithChannels:sampleRate:framesPerBuffer:")]
		IntPtr Constructor (nuint channels, uint sampleRate, nuint framesPerBuffer);

		// -(size_t)bufferSize;
		[Export ("bufferSize")]
		nuint BufferSize { get; }

		// -(AudioStreamBasicDescription)streamDescription;
		[Export ("streamDescription")]
		AudioStreamBasicDescription StreamDescription { get; }
	}

	// typedef void (^TVIAudioDeviceWorkerBlock)();
	delegate void TVIAudioDeviceWorkerBlock ();

	// @protocol TVIAudioDeviceRenderer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIAudioDeviceRenderer
	{
		// @required -(TVIAudioFormat * _Nullable)renderFormat;
		[Abstract]
		[NullAllowed, Export ("renderFormat")]
		TVIAudioFormat RenderFormat { get; }

		// @required -(BOOL)initializeRenderer;
		[Abstract]
		[Export ("initializeRenderer")]
		bool InitializeRenderer { get; }

		// @required -(BOOL)startRendering:(TVIAudioDeviceContext _Nonnull)context;
		[Abstract]
		[Export ("startRendering:")]
		unsafe bool StartRendering (IntPtr context);

		// @required -(BOOL)stopRendering;
		[Abstract]
		[Export ("stopRendering")]
		bool StopRendering { get; }
	}

	// @protocol TVIAudioDeviceCapturer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIAudioDeviceCapturer
	{
		// @required -(TVIAudioFormat * _Nullable)captureFormat;
		[Abstract]
		[NullAllowed, Export ("captureFormat")]
		TVIAudioFormat CaptureFormat { get; }

		// @required -(BOOL)initializeCapturer;
		[Abstract]
		[Export ("initializeCapturer")]
		bool InitializeCapturer { get; }

		// @required -(BOOL)startCapturing:(TVIAudioDeviceContext _Nonnull)context;
		[Abstract]
		[Export ("startCapturing:")]
		unsafe bool StartCapturing (IntPtr context);

		// @required -(BOOL)stopCapturing;
		[Abstract]
		[Export ("stopCapturing")]
		bool StopCapturing { get; }
	}

	// @protocol TVIAudioDevice <TVIAudioDeviceRenderer, TVIAudioDeviceCapturer>
	[Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface TVIAudioDevice : TVIAudioDeviceRenderer, TVIAudioDeviceCapturer
	{
	}

    interface ITVIAudioDevice { }

    // @interface TVIAudioOptionsBuilder : NSObject
    [BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAudioOptionsBuilder
	{
		// @property (assign, nonatomic) BOOL audioJitterBufferFastAccelerate;
		[Export ("audioJitterBufferFastAccelerate")]
		bool AudioJitterBufferFastAccelerate { get; set; }

		// @property (assign, nonatomic) int audioJitterBufferMaxPackets;
		[Export ("audioJitterBufferMaxPackets")]
		int AudioJitterBufferMaxPackets { get; set; }

		// @property (getter = isSoftwareAecEnabled, assign, nonatomic) BOOL softwareAecEnabled;
		[Export ("softwareAecEnabled")]
		bool SoftwareAecEnabled { [Bind ("isSoftwareAecEnabled")] get; set; }

		// @property (assign, nonatomic) BOOL highpassFilter;
		[Export ("highpassFilter")]
		bool HighpassFilter { get; set; }

		// @property (assign, nonatomic) BOOL levelControl __attribute__((deprecated("levelControl is deprecated and setting it no longer has any effect. It will be removed in a future release.")));
		[Export ("levelControl")]
		bool LevelControl { get; set; }

		// @property (assign, nonatomic) CGFloat levelControlInitialPeakLevelDBFS __attribute__((deprecated("levelControlInitialPeakLevelDBFS is deprecated and setting it no longer has any effect. It will be removed in a future release.")));
		[Export ("levelControlInitialPeakLevelDBFS")]
		nfloat LevelControlInitialPeakLevelDBFS { get; set; }
	}

	// typedef void (^TVIAudioOptionsBuilderBlock)(TVIAudioOptionsBuilder * _Nonnull);
	delegate void TVIAudioOptionsBuilderBlock (TVIAudioOptionsBuilder arg0);

	// @interface TVIAudioOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIAudioOptions
	{
		// @property (readonly, assign, nonatomic) int audioJitterBufferMaxPackets;
		[Export ("audioJitterBufferMaxPackets")]
		int AudioJitterBufferMaxPackets { get; }

		// @property (readonly, assign, nonatomic) BOOL audioJitterBufferFastAccelerate;
		[Export ("audioJitterBufferFastAccelerate")]
		bool AudioJitterBufferFastAccelerate { get; }

		// @property (readonly, getter = isSoftwareAecEnabled, assign, nonatomic) BOOL softwareAecEnabled;
		[Export ("softwareAecEnabled")]
		bool SoftwareAecEnabled { [Bind ("isSoftwareAecEnabled")] get; }

		// @property (readonly, assign, nonatomic) BOOL highpassFilter;
		[Export ("highpassFilter")]
		bool HighpassFilter { get; }

		// @property (readonly, assign, nonatomic) BOOL levelControl __attribute__((deprecated("levelControl is deprecated and setting it no longer has any effect. It will be removed in a future release.")));
		[Export ("levelControl")]
		bool LevelControl { get; }

		// @property (readonly, assign, nonatomic) CGFloat levelControlInitialPeakLevelDBFS __attribute__((deprecated("levelControlInitialPeakLevelDBFS is deprecated and setting it no longer has any effect. It will be removed in a future release.")));
		[Export ("levelControlInitialPeakLevelDBFS")]
		nfloat LevelControlInitialPeakLevelDBFS { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVIAudioOptions Options ();

		// +(instancetype _Null_unspecified)optionsWithBlock:(TVIAudioOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIAudioOptions OptionsWithBlock (TVIAudioOptionsBuilderBlock block);
	}

	// @protocol TVIAudioSink <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIAudioSink
	{
		// @required -(void)renderSample:(CMSampleBufferRef)audioSample;
		[Abstract]
		[Export ("renderSample:")]
		unsafe void RenderSample (CMSampleBuffer audioSample);
	}

	// @interface TVITrack : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVITrack
	{
		// @property (readonly, getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, assign, nonatomic) TVITrackState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVITrackState State { get; }
	}

	// @interface TVIAudioTrack : TVITrack
	[BaseType (typeof(TVITrack))]
	[DisableDefaultCtor]
	interface TVIAudioTrack
	{
		// @property (readonly, nonatomic, strong) NSArray<id<TVIAudioSink>> * _Nonnull sinks;
		[Export ("sinks", ArgumentSemantic.Strong)]
		TVIAudioSink[] Sinks { get; }

		// -(void)addSink:(id<TVIAudioSink> _Nonnull)sink;
		[Export ("addSink:")]
		void AddSink (TVIAudioSink sink);

		// -(void)removeSink:(id<TVIAudioSink> _Nonnull)sink;
		[Export ("removeSink:")]
		void RemoveSink (TVIAudioSink sink);
	}

	// @interface TVITrackPublication : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVITrackPublication
	{
		// @property (readonly, nonatomic, strong) TVITrack * _Nullable track;
		[NullAllowed, Export ("track", ArgumentSemantic.Strong)]
		TVITrack Track { get; }

		// @property (readonly, getter = isTrackEnabled, assign, nonatomic) BOOL trackEnabled;
		[Export ("trackEnabled")]
		bool TrackEnabled { [Bind ("isTrackEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackName;
		[Export ("trackName")]
		string TrackName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackSid;
		[Export ("trackSid")]
		string TrackSid { get; }
	}

	// @interface TVIAudioTrackPublication : TVITrackPublication
	[BaseType (typeof(TVITrackPublication))]
	[DisableDefaultCtor]
	interface TVIAudioTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVIAudioTrack * _Nullable audioTrack;
		[NullAllowed, Export ("audioTrack", ArgumentSemantic.Strong)]
		TVIAudioTrack AudioTrack { get; }
	}

	// @interface TVIBaseTrackStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIBaseTrackStats
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackSid;
		[Export ("trackSid")]
		string TrackSid { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsLost;
		[Export ("packetsLost")]
		nuint PacketsLost { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull codec;
		[Export ("codec")]
		string Codec { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull ssrc;
		[Export ("ssrc")]
		string Ssrc { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }
	}

	// @interface TVIVideoFrame : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoFrame
	{
		// -(instancetype _Nullable)initWithTimestamp:(CMTime)timestamp buffer:(CVImageBufferRef _Nonnull)imageBuffer orientation:(TVIVideoOrientation)orientation __attribute__((objc_designated_initializer));
		[Export ("initWithTimestamp:buffer:orientation:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor (CMTime timestamp, CVImageBuffer imageBuffer, TVIVideoOrientation orientation);

		// -(instancetype _Nullable)initWithTimeInterval:(CFTimeInterval)timeInterval buffer:(CVImageBufferRef _Nonnull)imageBuffer orientation:(TVIVideoOrientation)orientation;
		[Export ("initWithTimeInterval:buffer:orientation:")]
		unsafe IntPtr Constructor (double timeInterval, CVImageBuffer imageBuffer, TVIVideoOrientation orientation);

		// @property (readonly, assign, nonatomic) CMTime timestamp;
		[Export ("timestamp", ArgumentSemantic.Assign)]
		CMTime Timestamp { get; }

		// @property (readonly, assign, nonatomic) size_t width;
		[Export ("width")]
		nuint Width { get; }

		// @property (readonly, assign, nonatomic) size_t height;
		[Export ("height")]
		nuint Height { get; }

		// @property (readonly, assign, nonatomic) CVImageBufferRef _Nonnull imageBuffer;
		[Export ("imageBuffer", ArgumentSemantic.Assign)]
		unsafe IntPtr ImageBuffer { get; }

		// @property (readonly, assign, nonatomic) TVIVideoOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		TVIVideoOrientation Orientation { get; }
	}

	// @interface TVIVideoFormat : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIVideoFormat: INativeObject
	{
		// @property (assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; set; }

		// @property (assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; set; }

		// @property (assign, nonatomic) TVIPixelFormat pixelFormat;
		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		/*TVIPixelFormat*/ ulong PixelFormat { get; set; }
	}

	// @protocol TVIVideoCaptureConsumer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIVideoCaptureConsumer
	{
		// @required -(void)consumeCapturedFrame:(TVIVideoFrame * _Nonnull)frame;
		[Abstract]
		[Export ("consumeCapturedFrame:")]
		void ConsumeCapturedFrame (TVIVideoFrame frame);

		// @required -(void)captureDidStart:(BOOL)success;
		[Abstract]
		[Export ("captureDidStart:")]
		void CaptureDidStart (bool success);
	}

	// @protocol TVIVideoCapturer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIVideoCapturer
	{
		// @required @property (readonly, getter = isScreencast, assign, nonatomic) BOOL screencast;
		[Abstract]
		[Export ("screencast")]
		bool Screencast { [Bind ("isScreencast")] get; }

		// @required @property (readonly, copy, nonatomic) NSArray<TVIVideoFormat *> * _Nonnull supportedFormats;
		[Abstract]
		[Export ("supportedFormats", ArgumentSemantic.Copy)]
		TVIVideoFormat[] SupportedFormats { get; }

		// @required -(void)startCapture:(TVIVideoFormat * _Nonnull)format consumer:(id<TVIVideoCaptureConsumer> _Nonnull)consumer;
		[Abstract]
		[Export ("startCapture:consumer:")]
		void StartCapture (TVIVideoFormat format, TVIVideoCaptureConsumer consumer);

		// @required -(void)stopCapture;
		[Abstract]
		[Export ("stopCapture")]
		void StopCapture ();
	}

	partial interface Constants
	{
		// extern const CMVideoDimensions TVIVideoConstraintsSize352x288;
		[Field ("TVIVideoConstraintsSize352x288", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSize352x288 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize480x360;
		[Field ("TVIVideoConstraintsSize480x360", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSize480x360 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize640x480;
		[Field ("TVIVideoConstraintsSize640x480", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSize640x480 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize960x540;
		[Field ("TVIVideoConstraintsSize960x540", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSize960x540 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize1280x720;
		[Field ("TVIVideoConstraintsSize1280x720", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSize1280x720 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize1280x960;
		[Field ("TVIVideoConstraintsSize1280x960", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSize1280x960 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate30;
		[Field ("TVIVideoConstraintsFrameRate30", "__Internal")]
		nuint TVIVideoConstraintsFrameRate30 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate24;
		[Field ("TVIVideoConstraintsFrameRate24", "__Internal")]
		nuint TVIVideoConstraintsFrameRate24 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate20;
		[Field ("TVIVideoConstraintsFrameRate20", "__Internal")]
		nuint TVIVideoConstraintsFrameRate20 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate15;
		[Field ("TVIVideoConstraintsFrameRate15", "__Internal")]
		nuint TVIVideoConstraintsFrameRate15 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate10;
		[Field ("TVIVideoConstraintsFrameRate10", "__Internal")]
		nuint TVIVideoConstraintsFrameRate10 { get; }
	}

	// @protocol TVICameraCapturerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVICameraCapturerDelegate
	{
		// @optional -(void)cameraCapturer:(TVICameraCapturer * _Nonnull)capturer didStartWithSource:(TVICameraCaptureSource)source;
		[Export ("cameraCapturer:didStartWithSource:")]
		void CameraCapturer (TVICameraCapturer capturer, TVICameraCaptureSource source);

		// @optional -(void)cameraCapturerWasInterrupted:(TVICameraCapturer * _Nonnull)capturer reason:(AVCaptureSessionInterruptionReason)reason;
		[Export ("cameraCapturerWasInterrupted:reason:")]
		void CameraCapturerWasInterrupted (TVICameraCapturer capturer, AVCaptureSessionInterruptionReason reason);

		// @optional -(void)cameraCapturer:(TVICameraCapturer * _Nonnull)capturer didFailWithError:(NSError * _Nonnull)error;
		[Export ("cameraCapturer:didFailWithError:")]
		void CameraCapturer (TVICameraCapturer capturer, NSError error);
	}

	// @interface TVICameraCapturer : NSObject <TVIVideoCapturer>
	[BaseType (typeof(NSObject))]
	interface TVICameraCapturer : TVIVideoCapturer
	{
		// @property (readonly, assign, nonatomic) TVICameraCaptureSource source;
		[Export ("source", ArgumentSemantic.Assign)]
		TVICameraCaptureSource Source { get; }

		// @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Export ("capturing")]
		bool Capturing { [Bind ("isCapturing")] get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVICameraCapturerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVICameraCapturerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TVICameraPreviewView * _Nonnull previewView;
		[Export ("previewView", ArgumentSemantic.Strong)]
		TVICameraPreviewView PreviewView { get; }

		// @property (readonly, getter = isInterrupted, assign, nonatomic) BOOL interrupted;
		[Export ("interrupted")]
		bool Interrupted { [Bind ("isInterrupted")] get; }

		// -(instancetype _Nullable)initWithSource:(TVICameraCaptureSource)source;
		[Export ("initWithSource:")]
		IntPtr Constructor (TVICameraCaptureSource source);

		// -(instancetype _Nullable)initWithSource:(TVICameraCaptureSource)source delegate:(id<TVICameraCapturerDelegate> _Nullable)delegate;
		[Export ("initWithSource:delegate:")]
		IntPtr Constructor (TVICameraCaptureSource source, [NullAllowed] TVICameraCapturerDelegate @delegate);

		// -(instancetype _Nullable)initWithSource:(TVICameraCaptureSource)source delegate:(id<TVICameraCapturerDelegate> _Nullable)delegate enablePreview:(BOOL)enablePreview;
		[Export ("initWithSource:delegate:enablePreview:")]
		IntPtr Constructor (TVICameraCaptureSource source, [NullAllowed] TVICameraCapturerDelegate @delegate, bool enablePreview);

		// -(BOOL)selectSource:(TVICameraCaptureSource)source;
		[Export ("selectSource:")]
		bool SelectSource (TVICameraCaptureSource source);

		// +(BOOL)isSourceAvailable:(TVICameraCaptureSource)source;
		[Static]
		[Export ("isSourceAvailable:")]
		bool IsSourceAvailable (TVICameraCaptureSource source);

		// +(NSArray<NSNumber *> * _Nonnull)availableSources;
		[Static]
		[Export ("availableSources")]
		NSNumber[] AvailableSources { get; }
	}

	// @interface TVICameraPreviewView : UIView
	[BaseType (typeof(UIView))]
	interface TVICameraPreviewView
	{
		// @property (readonly, assign, nonatomic) UIInterfaceOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		UIInterfaceOrientation Orientation { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export ("videoDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoDimensions { get; }
	}

	// @protocol TVIVideoSink <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIVideoSink
	{
		// @required @property (readonly, copy, nonatomic) TVIVideoFormat * _Nullable sourceRequirements;
		[Abstract]
		[NullAllowed, Export ("sourceRequirements", ArgumentSemantic.Copy)]
		TVIVideoFormat SourceRequirements { get; }

		// @required -(void)onVideoFrame:(TVIVideoFrame * _Nonnull)frame;
		[Abstract]
		[Export ("onVideoFrame:")]
		void OnVideoFrame (TVIVideoFrame frame);

		// @required -(void)onVideoFormatRequest:(TVIVideoFormat * _Nullable)format;
		[Abstract]
		[Export ("onVideoFormatRequest:")]
		void OnVideoFormatRequest ([NullAllowed] TVIVideoFormat format);
	}

    interface ITVIVideoSource : TVIVideoSource
    {

    }	

	// @protocol TVIVideoSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIVideoSource
	{
		// @required @property (nonatomic, weak) id<TVIVideoSink> _Nullable sink;
		[Abstract]
		[NullAllowed, Export ("sink", ArgumentSemantic.Weak)]
		TVIVideoSink Sink { get; set; }

		// @required @property (readonly, getter = isScreencast, assign, nonatomic) BOOL screencast;
		[Abstract]
		[Export ("screencast")]
		bool Screencast { [Bind ("isScreencast")] get; }

		// @required -(void)requestOutputFormat:(TVIVideoFormat * _Nonnull)outputFormat;
		[Abstract]
		[Export ("requestOutputFormat:")]
		void RequestOutputFormat (TVIVideoFormat outputFormat);
	}

	partial interface Constants
	{
		// extern NSString *const _Nonnull kTVICameraSourceErrorDomain;
		[Field ("kTVICameraSourceErrorDomain", "__Internal")]
		NSString kTVICameraSourceErrorDomain { get; }
	}

	// typedef void (^TVICameraSourceStartedBlock)(AVCaptureDevice * _Nonnull, TVIVideoFormat * _Nonnull, NSError * _Nullable);
	delegate void TVICameraSourceStartedBlock (AVCaptureDevice arg0, TVIVideoFormat arg1, [NullAllowed] NSError arg2);

	// typedef void (^TVICameraSourceStoppedBlock)(NSError * _Nullable);
	delegate void TVICameraSourceStoppedBlock ([NullAllowed] NSError arg0);

	// @interface TVICameraSource : NSObject <TVIVideoSource>
	[BaseType (typeof(NSObject))]
	interface TVICameraSource : TVIVideoSource
	{
		// -(instancetype _Nullable)initWithDelegate:(id<TVICameraSourceDelegate> _Nullable)delegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor ([NullAllowed] TVICameraSourceDelegate @delegate);

		// -(instancetype _Nullable)initWithOptions:(TVICameraSourceOptions * _Nonnull)options delegate:(id<TVICameraSourceDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:delegate:")]
		[DesignatedInitializer]
		IntPtr Constructor (TVICameraSourceOptions options, [NullAllowed] TVICameraSourceDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVICameraSourceDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVICameraSourceDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) AVCaptureDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		AVCaptureDevice Device { get; }

		// @property (readonly, nonatomic, strong) TVICameraPreviewView * _Nullable previewView;
		[NullAllowed, Export ("previewView", ArgumentSemantic.Strong)]
		TVICameraPreviewView PreviewView { get; }

		// -(void)startCaptureWithDevice:(AVCaptureDevice * _Nonnull)device;
		[Export ("startCaptureWithDevice:")]
		void StartCaptureWithDevice (AVCaptureDevice device);

		// -(void)startCaptureWithDevice:(AVCaptureDevice * _Nonnull)device completion:(TVICameraSourceStartedBlock _Nullable)completion;
		[Export ("startCaptureWithDevice:completion:")]
		void StartCaptureWithDevice (AVCaptureDevice device, [NullAllowed] TVICameraSourceStartedBlock completion);

		// -(void)startCaptureWithDevice:(AVCaptureDevice * _Nonnull)device format:(TVIVideoFormat * _Nonnull)format completion:(TVICameraSourceStartedBlock _Nullable)completion;
		[Export ("startCaptureWithDevice:format:completion:")]
		void StartCaptureWithDevice (AVCaptureDevice device, TVIVideoFormat format, [NullAllowed] TVICameraSourceStartedBlock completion);

		// -(void)stopCapture;
		[Export ("stopCapture")]
		void StopCapture ();

		// -(void)stopCaptureWithCompletion:(TVICameraSourceStoppedBlock _Nullable)completion;
		[Export ("stopCaptureWithCompletion:")]
		void StopCaptureWithCompletion ([NullAllowed] TVICameraSourceStoppedBlock completion);

		// -(void)selectCaptureDevice:(AVCaptureDevice * _Nonnull)device;
		[Export ("selectCaptureDevice:")]
		void SelectCaptureDevice (AVCaptureDevice device);

		// -(void)selectCaptureDevice:(AVCaptureDevice * _Nonnull)device completion:(TVICameraSourceStartedBlock _Nullable)completion;
		[Export ("selectCaptureDevice:completion:")]
		void SelectCaptureDevice (AVCaptureDevice device, [NullAllowed] TVICameraSourceStartedBlock completion);

		// -(void)selectCaptureDevice:(AVCaptureDevice * _Nonnull)device format:(TVIVideoFormat * _Nonnull)format completion:(TVICameraSourceStartedBlock _Nullable)completion;
		[Export ("selectCaptureDevice:format:completion:")]
		void SelectCaptureDevice (AVCaptureDevice device, TVIVideoFormat format, [NullAllowed] TVICameraSourceStartedBlock completion);

		// +(AVCaptureDevice * _Nullable)captureDeviceForPosition:(AVCaptureDevicePosition)position;
		[Static]
		[Export ("captureDeviceForPosition:")]
		[return: NullAllowed]
		AVCaptureDevice CaptureDeviceForPosition (AVCaptureDevicePosition position);

		// +(AVCaptureDevice * _Nullable)captureDeviceForPosition:(AVCaptureDevicePosition)position type:(AVCaptureDeviceType _Nonnull)deviceType __attribute__((availability(ios, introduced=10.0)));
		[iOS (10,0)]
		[Static]
		[Export ("captureDeviceForPosition:type:")]
		[return: NullAllowed]
		AVCaptureDevice CaptureDeviceForPosition (AVCaptureDevicePosition position, string deviceType);

		// +(NSOrderedSet<TVIVideoFormat *> * _Nonnull)supportedFormatsForDevice:(AVCaptureDevice * _Nonnull)captureDevice;
		[Static]
		[Export ("supportedFormatsForDevice:")]
		NSOrderedSet<TVIVideoFormat> SupportedFormatsForDevice (AVCaptureDevice captureDevice);
	}

	// @interface ManualOrientationControl (TVICameraSource)
	[Category]
	[BaseType (typeof(TVICameraSource))]
	interface TVICameraSource_ManualOrientationControl
	{
		// -(void)updateVideoOrientation:(TVIVideoOrientation)orientation;
		[Export ("updateVideoOrientation:")]
		void UpdateVideoOrientation (TVIVideoOrientation orientation);
	}

	// @interface AVCaptureDeviceControl (TVICameraSource)
	[Category]
	[BaseType (typeof(TVICameraSource))]
	interface TVICameraSource_AVCaptureDeviceControl
	{
		// @property (assign, nonatomic) float torchLevel;
        [Export("torchLevel")]
        float GetTorchLevel();

        [Export("setTorchLevel:")]
        void SetTorchLevel(float torchLevel);

        // @property (assign, nonatomic) AVCaptureTorchMode torchMode;
        [Export("torchMode", ArgumentSemantic.Assign)]
        AVCaptureTorchMode GetTorchMode();

        [Export("setTorchMode:", ArgumentSemantic.Assign)]
        void SetTorchMode(AVCaptureTorchMode torchMode);

        // @property (assign, nonatomic) CGFloat zoomFactor;
        [Export("zoomFactor")]
        nfloat GetZoomFactor();

        [Export("setZoomFactor:")]
        void SetZoomFactor(nfloat zoomFactor);
	}

	// @protocol TVICameraSourceDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVICameraSourceDelegate
	{
		// @optional -(void)cameraSourceInterruptionEnded:(TVICameraSource * _Nonnull)source;
		[Export ("cameraSourceInterruptionEnded:")]
		void CameraSourceInterruptionEnded (TVICameraSource source);

		// @optional -(void)cameraSourceWasInterrupted:(TVICameraSource * _Nonnull)source reason:(AVCaptureSessionInterruptionReason)reason;
		[Export ("cameraSourceWasInterrupted:reason:")]
		void CameraSourceWasInterrupted (TVICameraSource source, AVCaptureSessionInterruptionReason reason);

		// @optional -(void)cameraSource:(TVICameraSource * _Nonnull)source didFailWithError:(NSError * _Nonnull)error;
		[Export ("cameraSource:didFailWithError:")]
		void CameraSource (TVICameraSource source, NSError error);
	}

	// @interface TVICameraSourceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVICameraSourceOptionsBuilder
	{
		// @property (assign, nonatomic) BOOL enableManualOrientation;
		[Export ("enableManualOrientation")]
		bool EnableManualOrientation { get; set; }

		// @property (assign, nonatomic) BOOL enablePreview;
		[Export ("enablePreview")]
		bool EnablePreview { get; set; }

		// @property (assign, nonatomic) TVIVideoOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		TVIVideoOrientation Orientation { get; set; }

		// @property (assign, nonatomic) CGFloat zoomFactor;
		[Export ("zoomFactor")]
		nfloat ZoomFactor { get; set; }
	}

	// typedef void (^TVICameraSourceOptionsBuilderBlock)(TVICameraSourceOptionsBuilder * _Nonnull);
	delegate void TVICameraSourceOptionsBuilderBlock (TVICameraSourceOptionsBuilder arg0);

	// @interface TVICameraSourceOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVICameraSourceOptions
	{
		// @property (readonly, assign, nonatomic) BOOL enableManualOrientation;
		[Export ("enableManualOrientation")]
		bool EnableManualOrientation { get; }

		// @property (readonly, assign, nonatomic) BOOL enablePreview;
		[Export ("enablePreview")]
		bool EnablePreview { get; }

		// @property (readonly, assign, nonatomic) TVIVideoOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		TVIVideoOrientation Orientation { get; }

		// @property (readonly, assign, nonatomic) CGFloat zoomFactor;
		[Export ("zoomFactor")]
		nfloat ZoomFactor { get; }

		// +(instancetype _Nonnull)optionsWithBlock:(TVICameraSourceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVICameraSourceOptions OptionsWithBlock (TVICameraSourceOptionsBuilderBlock block);
	}

	// @interface TVIVideoCodec : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoCodec
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	// @interface TVIConnectOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIConnectOptionsBuilder
	{
		// @property (copy, nonatomic) NSArray<TVILocalAudioTrack *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		TVILocalAudioTrack[] AudioTracks { get; set; }

		// @property (getter = isAutomaticSubscriptionEnabled, assign, nonatomic) BOOL automaticSubscriptionEnabled;
		[Export ("automaticSubscriptionEnabled")]
		bool AutomaticSubscriptionEnabled { [Bind ("isAutomaticSubscriptionEnabled")] get; set; }

		// @property (copy, nonatomic) NSArray<TVILocalDataTrack *> * _Nonnull dataTracks;
		[Export ("dataTracks", ArgumentSemantic.Copy)]
		TVILocalDataTrack[] DataTracks { get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; set; }

		// @property (getter = isDominantSpeakerEnabled, assign, nonatomic) BOOL dominantSpeakerEnabled;
		[Export ("dominantSpeakerEnabled")]
		bool DominantSpeakerEnabled { [Bind ("isDominantSpeakerEnabled")] get; set; }

		// @property (nonatomic, strong) TVIEncodingParameters * _Nullable encodingParameters;
		[NullAllowed, Export ("encodingParameters", ArgumentSemantic.Strong)]
		TVIEncodingParameters EncodingParameters { get; set; }

		// @property (nonatomic, strong) TVIIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		TVIIceOptions IceOptions { get; set; }

		// @property (getter = areInsightsEnabled, assign, nonatomic) BOOL insightsEnabled;
		[Export ("insightsEnabled")]
		bool InsightsEnabled { [Bind ("areInsightsEnabled")] get; set; }

		// @property (getter = isNetworkQualityEnabled, assign, nonatomic) BOOL networkQualityEnabled;
		[Export ("networkQualityEnabled")]
		bool NetworkQualityEnabled { [Bind ("isNetworkQualityEnabled")] get; set; }

		// @property (copy, nonatomic) NSArray<TVIAudioCodec *> * _Nonnull preferredAudioCodecs;
		[Export ("preferredAudioCodecs", ArgumentSemantic.Copy)]
		TVIAudioCodec[] PreferredAudioCodecs { get; set; }

		// @property (copy, nonatomic) NSArray<TVIVideoCodec *> * _Nonnull preferredVideoCodecs;
		[Export ("preferredVideoCodecs", ArgumentSemantic.Copy)]
		TVIVideoCodec[] PreferredVideoCodecs { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomName;
		[NullAllowed, Export ("roomName")]
		string RoomName { get; set; }

		// @property (copy, nonatomic) NSArray<TVILocalVideoTrack *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		TVILocalVideoTrack[] VideoTracks { get; set; }
	}

	// @interface CallKit (TVIConnectOptionsBuilder)
	[Category]
	[BaseType (typeof(TVIConnectOptionsBuilder))]
	interface TVIConnectOptionsBuilder_CallKit
	{
		// @property (nonatomic, strong) NSUUID * _Nullable uuid;
        [NullAllowed, Export("uuid", ArgumentSemantic.Strong)]
        NSUuid GetUuid();

        [NullAllowed, Export("setUuid:", ArgumentSemantic.Strong)]
        void SetUuid(NSUuid uuid);
	}

	// typedef void (^TVIConnectOptionsBuilderBlock)(TVIConnectOptionsBuilder * _Nonnull);
	delegate void TVIConnectOptionsBuilderBlock (TVIConnectOptionsBuilder arg0);

	// @interface TVIConnectOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIConnectOptions
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalAudioTrack *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		TVILocalAudioTrack[] AudioTracks { get; }

		// @property (readonly, getter = isAutomaticSubscriptionEnabled, assign, nonatomic) BOOL automaticSubscriptionEnabled;
		[Export ("automaticSubscriptionEnabled")]
		bool AutomaticSubscriptionEnabled { [Bind ("isAutomaticSubscriptionEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalDataTrack *> * _Nonnull dataTracks;
		[Export ("dataTracks", ArgumentSemantic.Copy)]
		TVILocalDataTrack[] DataTracks { get; }

		// @property (readonly, nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; }

		// @property (readonly, getter = isDominantSpeakerEnabled, assign, nonatomic) BOOL dominantSpeakerEnabled;
		[Export ("dominantSpeakerEnabled")]
		bool DominantSpeakerEnabled { [Bind ("isDominantSpeakerEnabled")] get; }

		// @property (readonly, nonatomic, strong) TVIEncodingParameters * _Nullable encodingParameters;
		[NullAllowed, Export ("encodingParameters", ArgumentSemantic.Strong)]
		TVIEncodingParameters EncodingParameters { get; }

		// @property (readonly, nonatomic, strong) TVIIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		TVIIceOptions IceOptions { get; }

		// @property (readonly, getter = areInsightsEnabled, assign, nonatomic) BOOL insightsEnabled;
		[Export ("insightsEnabled")]
		bool InsightsEnabled { [Bind ("areInsightsEnabled")] get; }

		// @property (readonly, getter = isNetworkQualityEnabled, assign, nonatomic) BOOL networkQualityEnabled;
		[Export ("networkQualityEnabled")]
		bool NetworkQualityEnabled { [Bind ("isNetworkQualityEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIAudioCodec *> * _Nonnull preferredAudioCodecs;
		[Export ("preferredAudioCodecs", ArgumentSemantic.Copy)]
		TVIAudioCodec[] PreferredAudioCodecs { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIVideoCodec *> * _Nonnull preferredVideoCodecs;
		[Export ("preferredVideoCodecs", ArgumentSemantic.Copy)]
		TVIVideoCodec[] PreferredVideoCodecs { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable roomName;
		[NullAllowed, Export ("roomName")]
		string RoomName { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalVideoTrack *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		TVILocalVideoTrack[] VideoTracks { get; }

		// +(instancetype _Nonnull)optionsWithToken:(NSString * _Nonnull)token;
		[Static]
		[Export ("optionsWithToken:")]
		TVIConnectOptions OptionsWithToken (string token);

		// +(instancetype _Nonnull)optionsWithToken:(NSString * _Nonnull)token block:(TVIConnectOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithToken:block:")]
		TVIConnectOptions OptionsWithToken (string token, TVIConnectOptionsBuilderBlock block);
	}

	// @interface CallKit (TVIConnectOptions)
	[Category]
	[BaseType (typeof(TVIConnectOptions))]
	interface TVIConnectOptions_CallKit
	{
		// @property (readonly, nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export("uuid", ArgumentSemantic.Strong)]
		NSUuid GetUuid();
	}

	// @interface TVIDataTrack : TVITrack
	[BaseType (typeof(TVITrack))]
	[DisableDefaultCtor]
	interface TVIDataTrack
	{
		// @property (readonly, getter = isReliable, assign, nonatomic) BOOL reliable;
		[Export ("reliable")]
		bool Reliable { [Bind ("isReliable")] get; }

		// @property (readonly, getter = isOrdered, assign, nonatomic) BOOL ordered;
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxPacketLifeTime;
		[Export ("maxPacketLifeTime")]
		nuint MaxPacketLifeTime { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxRetransmits;
		[Export ("maxRetransmits")]
		nuint MaxRetransmits { get; }
	}

	partial interface Constants
	{
		// extern const int kTVIDataTrackOptionsDefaultMaxPacketLifeTime;
		[Field ("kTVIDataTrackOptionsDefaultMaxPacketLifeTime", "__Internal")]
		int kTVIDataTrackOptionsDefaultMaxPacketLifeTime { get; }

		// extern const int kTVIDataTrackOptionsDefaultMaxRetransmits;
		[Field ("kTVIDataTrackOptionsDefaultMaxRetransmits", "__Internal")]
		int kTVIDataTrackOptionsDefaultMaxRetransmits { get; }
	}

	// @interface TVIDataTrackOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIDataTrackOptionsBuilder
	{
		// @property (getter = isOrdered, assign, nonatomic) BOOL ordered;
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; set; }

		// @property (assign, nonatomic) int maxPacketLifeTime;
		[Export ("maxPacketLifeTime")]
		int MaxPacketLifeTime { get; set; }

		// @property (assign, nonatomic) int maxRetransmits;
		[Export ("maxRetransmits")]
		int MaxRetransmits { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }
	}

	// typedef void (^TVIDataTrackOptionsBuilderBlock)(TVIDataTrackOptionsBuilder * _Nonnull);
	delegate void TVIDataTrackOptionsBuilderBlock (TVIDataTrackOptionsBuilder arg0);

	// @interface TVIDataTrackOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIDataTrackOptions
	{
		// @property (readonly, getter = isOrdered, assign, nonatomic) BOOL ordered;
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; }

		// @property (readonly, assign, nonatomic) int maxPacketLifeTime;
		[Export ("maxPacketLifeTime")]
		int MaxPacketLifeTime { get; }

		// @property (readonly, assign, nonatomic) int maxRetransmits;
		[Export ("maxRetransmits")]
		int MaxRetransmits { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVIDataTrackOptions Options ();

		// +(instancetype _Null_unspecified)optionsWithBlock:(TVIDataTrackOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIDataTrackOptions OptionsWithBlock (TVIDataTrackOptionsBuilderBlock block);
	}

	// @interface TVIDataTrackPublication : TVITrackPublication
	[BaseType (typeof(TVITrackPublication))]
	[DisableDefaultCtor]
	interface TVIDataTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVIDataTrack * _Nullable dataTrack;
		[NullAllowed, Export ("dataTrack", ArgumentSemantic.Strong)]
		TVIDataTrack DataTrack { get; }
	}

	// typedef void (^TVIAVAudioSessionConfigurationBlock)();
	delegate void TVIAVAudioSessionConfigurationBlock ();

	// @interface TVIDefaultAudioDevice : NSObject <TVIAudioDevice>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIDefaultAudioDevice : TVIAudioDevice
	{
		// @property (copy, nonatomic) TVIAVAudioSessionConfigurationBlock _Nonnull block;
		[Export ("block", ArgumentSemantic.Copy)]
		TVIAVAudioSessionConfigurationBlock Block { get; set; }

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// +(instancetype _Nonnull)audioDevice;
		[Static]
		[Export ("audioDevice")]
		TVIDefaultAudioDevice AudioDevice ();

		// +(instancetype _Nonnull)audioDeviceWithBlock:(TVIAVAudioSessionConfigurationBlock _Nonnull)block;
		[Static]
		[Export ("audioDeviceWithBlock:")]
		TVIDefaultAudioDevice AudioDeviceWithBlock (TVIAVAudioSessionConfigurationBlock block);
	}

	// @interface TVIEncodingParameters : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIEncodingParameters
	{
		// -(instancetype _Nonnull)initWithAudioBitrate:(NSUInteger)maxAudioBitrate videoBitrate:(NSUInteger)maxVideoBitrate;
		[Export ("initWithAudioBitrate:videoBitrate:")]
		IntPtr Constructor (nuint maxAudioBitrate, nuint maxVideoBitrate);

		// @property (readonly, assign, nonatomic) NSUInteger maxAudioBitrate;
		[Export ("maxAudioBitrate")]
		nuint MaxAudioBitrate { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxVideoBitrate;
		[Export ("maxVideoBitrate")]
		nuint MaxVideoBitrate { get; }
	}

	partial interface Constants
	{
		// extern NSString *const _Nonnull kTVIErrorDomain;
		[Field ("kTVIErrorDomain", "__Internal")]
		NSString kTVIErrorDomain { get; }
	}

	// @interface TVIG722Codec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIG722Codec
	{
	}

	// @interface TVIH264Codec : TVIVideoCodec
	[BaseType (typeof(TVIVideoCodec))]
	interface TVIH264Codec
	{
	}

	// @interface TVIIceCandidatePairStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceCandidatePairStats
	{
		// @property (readonly, getter = isActiveCandidatePair, assign, nonatomic) BOOL activeCandidatePair;
		[Export ("activeCandidatePair")]
		bool ActiveCandidatePair { [Bind ("isActiveCandidatePair")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable relayProtocol;
		[NullAllowed, Export ("relayProtocol")]
		string RelayProtocol { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transportId;
		[NullAllowed, Export ("transportId")]
		string TransportId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localCandidateId;
		[NullAllowed, Export ("localCandidateId")]
		string LocalCandidateId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localCandidateIp;
		[NullAllowed, Export ("localCandidateIp")]
		string LocalCandidateIp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteCandidateId;
		[NullAllowed, Export ("remoteCandidateId")]
		string RemoteCandidateId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteCandidateIp;
		[NullAllowed, Export ("remoteCandidateIp")]
		string RemoteCandidateIp { get; }

		// @property (readonly, assign, nonatomic) TVIIceCandidatePairState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVIIceCandidatePairState State { get; }

		// @property (readonly, assign, nonatomic) uint64_t priority;
		[Export ("priority")]
		ulong Priority { get; }

		// @property (readonly, getter = isNominated, assign, nonatomic) BOOL nominated;
		[Export ("nominated")]
		bool Nominated { [Bind ("isNominated")] get; }

		// @property (readonly, getter = isWritable, assign, nonatomic) BOOL writable;
		[Export ("writable")]
		bool Writable { [Bind ("isWritable")] get; }

		// @property (readonly, getter = isReadable, assign, nonatomic) BOOL readable;
		[Export ("readable")]
		bool Readable { [Bind ("isReadable")] get; }

		// @property (readonly, assign, nonatomic) uint64_t bytesSent;
		[Export ("bytesSent")]
		ulong BytesSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t bytesReceived;
		[Export ("bytesReceived")]
		ulong BytesReceived { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval totalRoundTripTime;
		[Export ("totalRoundTripTime")]
		double TotalRoundTripTime { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval currentRoundTripTime;
		[Export ("currentRoundTripTime")]
		double CurrentRoundTripTime { get; }

		// @property (readonly, assign, nonatomic) double availableOutgoingBitrate;
		[Export ("availableOutgoingBitrate")]
		double AvailableOutgoingBitrate { get; }

		// @property (readonly, assign, nonatomic) double availableIncomingBitrate;
		[Export ("availableIncomingBitrate")]
		double AvailableIncomingBitrate { get; }

		// @property (readonly, assign, nonatomic) uint64_t requestsReceived;
		[Export ("requestsReceived")]
		ulong RequestsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t requestsSent;
		[Export ("requestsSent")]
		ulong RequestsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t responsesReceived;
		[Export ("responsesReceived")]
		ulong ResponsesReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t responsesSent;
		[Export ("responsesSent")]
		ulong ResponsesSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t retransmissionsReceived;
		[Export ("retransmissionsReceived")]
		ulong RetransmissionsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t retransmissionsSent;
		[Export ("retransmissionsSent")]
		ulong RetransmissionsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentRequestsReceived;
		[Export ("consentRequestsReceived")]
		ulong ConsentRequestsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentRequestsSent;
		[Export ("consentRequestsSent")]
		ulong ConsentRequestsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentResponsesReceived;
		[Export ("consentResponsesReceived")]
		ulong ConsentResponsesReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentResponsesSent;
		[Export ("consentResponsesSent")]
		ulong ConsentResponsesSent { get; }
	}

	// @interface TVIIceCandidateStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceCandidateStats
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable candidateType;
		[NullAllowed, Export ("candidateType")]
		string CandidateType { get; }

		// @property (readonly, getter = isDeleted, assign, nonatomic) BOOL deleted;
		[Export ("deleted")]
		bool Deleted { [Bind ("isDeleted")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable ip;
		[NullAllowed, Export ("ip")]
		string Ip { get; }

		// @property (readonly, getter = isRemote, assign, nonatomic) BOOL remote;
		[Export ("remote")]
		bool Remote { [Bind ("isRemote")] get; }

		// @property (readonly, assign, nonatomic) long port;
		[Export ("port")]
		nint Port { get; }

		// @property (readonly, assign, nonatomic) long priority;
		[Export ("priority")]
		nint Priority { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable protocol;
		[NullAllowed, Export ("protocol")]
		string Protocol { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transportId;
		[NullAllowed, Export ("transportId")]
		string TransportId { get; }
	}

	// @interface TVIIceServer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceServer
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull urlString;
		[Export ("urlString")]
		string UrlString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
		string Password { get; }

		// -(instancetype _Null_unspecified)initWithURLString:(NSString * _Nonnull)serverURLString;
		[Export ("initWithURLString:")]
		IntPtr Constructor (string serverURLString);

		// -(instancetype _Null_unspecified)initWithURLString:(NSString * _Nonnull)serverURLString username:(NSString * _Nullable)username password:(NSString * _Nullable)password;
		[Export ("initWithURLString:username:password:")]
		IntPtr Constructor (string serverURLString, [NullAllowed] string username, [NullAllowed] string password);
	}

	// @interface TVIIceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceOptionsBuilder
	{
		// @property (nonatomic, strong) NSArray<TVIIceServer *> * _Nullable servers;
		[NullAllowed, Export ("servers", ArgumentSemantic.Strong)]
		TVIIceServer[] Servers { get; set; }

		// @property (assign, nonatomic) TVIIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		TVIIceTransportPolicy TransportPolicy { get; set; }

		// @property (assign, nonatomic) BOOL abortOnIceServersTimeout;
		[Export ("abortOnIceServersTimeout")]
		bool AbortOnIceServersTimeout { get; set; }

		// @property (assign, nonatomic) NSTimeInterval iceServersTimeout;
		[Export ("iceServersTimeout")]
		double IceServersTimeout { get; set; }
	}

	// typedef void (^TVIIceOptionsBuilderBlock)(TVIIceOptionsBuilder * _Nonnull);
	delegate void TVIIceOptionsBuilderBlock (TVIIceOptionsBuilder arg0);

	// @interface TVIIceOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIIceOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<TVIIceServer *> * _Nonnull servers;
		[Export ("servers", ArgumentSemantic.Copy)]
		TVIIceServer[] Servers { get; }

		// @property (readonly, assign, nonatomic) TVIIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		TVIIceTransportPolicy TransportPolicy { get; }

		// @property (readonly, assign, nonatomic) BOOL abortOnIceServersTimeout;
		[Export ("abortOnIceServersTimeout")]
		bool AbortOnIceServersTimeout { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval iceServersTimeout;
		[Export ("iceServersTimeout")]
		double IceServersTimeout { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVIIceOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVIIceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIIceOptions OptionsWithBlock (TVIIceOptionsBuilderBlock block);
	}

	// @interface TVIIsacCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIIsacCodec
	{
		// @property (readonly, nonatomic) TVIIsacCodecSampleRate sampleRate;
		[Export ("sampleRate")]
		TVIIsacCodecSampleRate SampleRate { get; }
	}

	// @interface TVILocalAudioTrack : TVIAudioTrack
	[BaseType (typeof(TVIAudioTrack))]
	[DisableDefaultCtor]
	interface TVILocalAudioTrack
	{
		// @property (readonly, nonatomic, strong) TVIAudioOptions * _Nullable options;
		[NullAllowed, Export ("options", ArgumentSemantic.Strong)]
		TVIAudioOptions Options { get; }

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// +(instancetype _Nullable)track;
		[Static]
		[Export ("track")]
		[return: NullAllowed]
		TVILocalAudioTrack Track ();

		// +(instancetype _Nullable)trackWithOptions:(TVIAudioOptions * _Nullable)options enabled:(BOOL)enabled name:(NSString * _Nullable)name;
		[Static]
		[Export ("trackWithOptions:enabled:name:")]
		[return: NullAllowed]
		TVILocalAudioTrack TrackWithOptions ([NullAllowed] TVIAudioOptions options, bool enabled, [NullAllowed] string name);
	}

	// @interface TVILocalAudioTrackPublication : TVIAudioTrackPublication
	[BaseType (typeof(TVIAudioTrackPublication))]
	[DisableDefaultCtor]
	interface TVILocalAudioTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVILocalAudioTrack * _Nullable localTrack;
		[NullAllowed, Export ("localTrack", ArgumentSemantic.Strong)]
		TVILocalAudioTrack LocalTrack { get; }
	}

	// @interface TVILocalTrackStats : TVIBaseTrackStats
	[BaseType (typeof(TVIBaseTrackStats))]
	[DisableDefaultCtor]
	interface TVILocalTrackStats
	{
		// @property (readonly, assign, nonatomic) int64_t bytesSent;
		[Export ("bytesSent")]
		long BytesSent { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsSent;
		[Export ("packetsSent")]
		nuint PacketsSent { get; }

		// @property (readonly, assign, nonatomic) int64_t roundTripTime;
		[Export ("roundTripTime")]
		long RoundTripTime { get; }
	}

	// @interface TVILocalAudioTrackStats : TVILocalTrackStats
	[BaseType (typeof(TVILocalTrackStats))]
	[DisableDefaultCtor]
	interface TVILocalAudioTrackStats
	{
		// @property (readonly, assign, nonatomic) NSUInteger audioLevel;
		[Export ("audioLevel")]
		nuint AudioLevel { get; }

		// @property (readonly, assign, nonatomic) NSUInteger jitter;
		[Export ("jitter")]
		nuint Jitter { get; }
	}

	// @interface TVILocalDataTrack : TVIDataTrack
	[BaseType (typeof(TVIDataTrack))]
	[DisableDefaultCtor]
	interface TVILocalDataTrack
	{
		// -(void)sendString:(NSString * _Nonnull)message;
		[Export ("sendString:")]
		void SendString (string message);

		// -(void)sendData:(NSData * _Nonnull)message;
		[Export ("sendData:")]
		void SendData (NSData message);

		// +(instancetype _Nullable)track;
		[Static]
		[Export ("track")]
		[return: NullAllowed]
		TVILocalDataTrack Track ();

		// +(instancetype _Nullable)trackWithOptions:(TVIDataTrackOptions * _Nullable)options;
		[Static]
		[Export ("trackWithOptions:")]
		[return: NullAllowed]
		TVILocalDataTrack TrackWithOptions ([NullAllowed] TVIDataTrackOptions options);
	}

	// @interface TVILocalDataTrackPublication : TVIDataTrackPublication
	[BaseType (typeof(TVIDataTrackPublication))]
	[DisableDefaultCtor]
	interface TVILocalDataTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVILocalDataTrack * _Nullable localTrack;
		[NullAllowed, Export ("localTrack", ArgumentSemantic.Strong)]
		TVILocalDataTrack LocalTrack { get; }
	}

	// @interface TVIParticipant : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIParticipant
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identity;
		[Export ("identity")]
		string Identity { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sid;
		[NullAllowed, Export ("sid")]
		string Sid { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIAudioTrackPublication *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		TVIAudioTrackPublication[] AudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIVideoTrackPublication *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		TVIVideoTrackPublication[] VideoTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIDataTrackPublication *> * _Nonnull dataTracks;
		[Export ("dataTracks", ArgumentSemantic.Copy)]
		TVIDataTrackPublication[] DataTracks { get; }

		// -(TVITrackPublication * _Nullable)getTrack:(NSString * _Nonnull)sid;
		[Export ("getTrack:")]
		[return: NullAllowed]
		TVITrackPublication GetTrack (string sid);

		// -(TVIAudioTrackPublication * _Nullable)getAudioTrack:(NSString * _Nonnull)sid;
		[Export ("getAudioTrack:")]
		[return: NullAllowed]
		TVIAudioTrackPublication GetAudioTrack (string sid);

		// -(TVIVideoTrackPublication * _Nullable)getVideoTrack:(NSString * _Nonnull)sid;
		[Export ("getVideoTrack:")]
		[return: NullAllowed]
		TVIVideoTrackPublication GetVideoTrack (string sid);

		// -(TVIDataTrackPublication * _Nullable)getDataTrack:(NSString * _Nonnull)sid;
		[Export ("getDataTrack:")]
		[return: NullAllowed]
		TVIDataTrackPublication GetDataTrack (string sid);
	}

	// @interface TVILocalParticipant : TVIParticipant
	[BaseType (typeof(TVIParticipant))]
	[DisableDefaultCtor]
	interface TVILocalParticipant
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVILocalParticipantDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVILocalParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalAudioTrackPublication *> * _Nonnull localAudioTracks;
		[Export ("localAudioTracks", ArgumentSemantic.Copy)]
		TVILocalAudioTrackPublication[] LocalAudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalDataTrackPublication *> * _Nonnull localDataTracks;
		[Export ("localDataTracks", ArgumentSemantic.Copy)]
		TVILocalDataTrackPublication[] LocalDataTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalVideoTrackPublication *> * _Nonnull localVideoTracks;
		[Export ("localVideoTracks", ArgumentSemantic.Copy)]
		TVILocalVideoTrackPublication[] LocalVideoTracks { get; }

		// @property (readonly, assign, nonatomic) TVINetworkQualityLevel networkQualityLevel;
		[Export ("networkQualityLevel", ArgumentSemantic.Assign)]
		TVINetworkQualityLevel NetworkQualityLevel { get; }

		// -(BOOL)publishAudioTrack:(TVILocalAudioTrack * _Nonnull)track;
		[Export ("publishAudioTrack:")]
		bool PublishAudioTrack (TVILocalAudioTrack track);

		// -(BOOL)publishDataTrack:(TVILocalDataTrack * _Nonnull)track;
		[Export ("publishDataTrack:")]
		bool PublishDataTrack (TVILocalDataTrack track);

		// -(BOOL)publishVideoTrack:(TVILocalVideoTrack * _Nonnull)track;
		[Export ("publishVideoTrack:")]
		bool PublishVideoTrack (TVILocalVideoTrack track);

		// -(BOOL)unpublishAudioTrack:(TVILocalAudioTrack * _Nonnull)track;
		[Export ("unpublishAudioTrack:")]
		bool UnpublishAudioTrack (TVILocalAudioTrack track);

		// -(BOOL)unpublishDataTrack:(TVILocalDataTrack * _Nonnull)track;
		[Export ("unpublishDataTrack:")]
		bool UnpublishDataTrack (TVILocalDataTrack track);

		// -(BOOL)unpublishVideoTrack:(TVILocalVideoTrack * _Nonnull)track;
		[Export ("unpublishVideoTrack:")]
		bool UnpublishVideoTrack (TVILocalVideoTrack track);

		// -(void)setEncodingParameters:(TVIEncodingParameters * _Nullable)encodingParameters;
		[Export ("setEncodingParameters:")]
		void SetEncodingParameters ([NullAllowed] TVIEncodingParameters encodingParameters);
	}

	// @protocol TVILocalParticipantDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVILocalParticipantDelegate
	{
		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant publishedAudioTrack:(TVILocalAudioTrackPublication * _Nonnull)publishedAudioTrack;
		[Export ("localParticipant:publishedAudioTrack:")]
		void PublishedAudioTrack (TVILocalParticipant participant, TVILocalAudioTrackPublication publishedAudioTrack);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant failedToPublishAudioTrack:(TVILocalAudioTrack * _Nonnull)audioTrack withError:(NSError * _Nonnull)error;
		[Export ("localParticipant:failedToPublishAudioTrack:withError:")]
		void FailedToPublishAudioTrack (TVILocalParticipant participant, TVILocalAudioTrack audioTrack, NSError error);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant publishedDataTrack:(TVILocalDataTrackPublication * _Nonnull)publishedDataTrack;
		[Export ("localParticipant:publishedDataTrack:")]
		void PublishedDataTrack (TVILocalParticipant participant, TVILocalDataTrackPublication publishedDataTrack);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant failedToPublishDataTrack:(TVILocalDataTrack * _Nonnull)dataTrack withError:(NSError * _Nonnull)error;
		[Export ("localParticipant:failedToPublishDataTrack:withError:")]
		void FailedToPublishDataTrack (TVILocalParticipant participant, TVILocalDataTrack dataTrack, NSError error);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant publishedVideoTrack:(TVILocalVideoTrackPublication * _Nonnull)publishedVideoTrack;
		[Export ("localParticipant:publishedVideoTrack:")]
		void PublishedVideoTrack (TVILocalParticipant participant, TVILocalVideoTrackPublication publishedVideoTrack);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant failedToPublishVideoTrack:(TVILocalVideoTrack * _Nonnull)videoTrack withError:(NSError * _Nonnull)error;
		[Export ("localParticipant:failedToPublishVideoTrack:withError:")]
		void FailedToPublishVideoTrack (TVILocalParticipant participant, TVILocalVideoTrack videoTrack, NSError error);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant networkQualityLevelDidChange:(TVINetworkQualityLevel)networkQualityLevel;
		[Export ("localParticipant:networkQualityLevelDidChange:")]
		void NetworkQualityLevelDidChange (TVILocalParticipant participant, TVINetworkQualityLevel networkQualityLevel);
	}

	// @interface TVIVideoTrack : TVITrack
	[BaseType (typeof(TVITrack))]
	[DisableDefaultCtor]
	interface TVIVideoTrack
	{
		// @property (readonly, nonatomic, strong) NSArray<id<TVIVideoRenderer>> * _Nonnull renderers;
		[Export ("renderers", ArgumentSemantic.Strong)]
		TVIVideoRenderer[] Renderers { get; }

		// -(void)addRenderer:(id<TVIVideoRenderer> _Nonnull)renderer;
		[Export ("addRenderer:")]
		void AddRenderer (ITVIVideoRenderer renderer);

		// -(void)removeRenderer:(id<TVIVideoRenderer> _Nonnull)renderer;
		[Export ("removeRenderer:")]
		void RemoveRenderer (ITVIVideoRenderer renderer);
	}

	// @interface TVILocalVideoTrack : TVIVideoTrack
	[BaseType (typeof(TVIVideoTrack))]
	[DisableDefaultCtor]
	interface TVILocalVideoTrack
	{
		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// @property (readonly, nonatomic, strong) id<TVIVideoCapturer> _Nonnull capturer __attribute__((deprecated("TVIVideoCapturer is deprecated. Use TVIVideoSource instead.")));
		[Export ("capturer", ArgumentSemantic.Strong)]
		TVIVideoCapturer Capturer { get; }

		// @property (readonly, nonatomic, strong) TVIVideoConstraints * _Nonnull constraints __attribute__((deprecated("Constraints are deprecated. You should use TVIVideoSource as a replacement for TVIVideoCapturer.")));
		[Export ("constraints", ArgumentSemantic.Strong)]
		TVIVideoConstraints Constraints { get; }

		// +(instancetype _Nullable)trackWithCapturer:(id<TVIVideoCapturer> _Nonnull)capturer __attribute__((deprecated("Use trackWithSource: and provide a TVIVideoSource instead.")));
		[Static]
		[Export ("trackWithCapturer:")]
		[return: NullAllowed]
		TVILocalVideoTrack TrackWithCapturer (TVIVideoCapturer capturer);

		// +(instancetype _Nullable)trackWithCapturer:(id<TVIVideoCapturer> _Nonnull)capturer enabled:(BOOL)enabled constraints:(TVIVideoConstraints * _Nullable)constraints name:(NSString * _Nullable)name __attribute__((deprecated("Use trackWithSource:enabled:name: and provide a TVIVideoSource instead.")));
		[Static]
		[Export ("trackWithCapturer:enabled:constraints:name:")]
		[return: NullAllowed]
		TVILocalVideoTrack TrackWithCapturer (TVIVideoCapturer capturer, bool enabled, [NullAllowed] TVIVideoConstraints constraints, [NullAllowed] string name);

		// @property (readonly, nonatomic, strong) id<TVIVideoSource> _Nullable source;
		[NullAllowed, Export ("source", ArgumentSemantic.Strong)]
		TVIVideoSource Source { get; }

		// +(instancetype _Nullable)trackWithSource:(id<TVIVideoSource> _Nonnull)source;
		[Static]
		[Export ("trackWithSource:")]
		[return: NullAllowed]
		TVILocalVideoTrack TrackWithSource (ITVIVideoSource source);

		// +(instancetype _Nullable)trackWithSource:(id<TVIVideoSource> _Nonnull)source enabled:(BOOL)enabled name:(NSString * _Nullable)name;
		[Static]
		[Export ("trackWithSource:enabled:name:")]
		[return: NullAllowed]
		TVILocalVideoTrack TrackWithSource (ITVIVideoSource source, bool enabled, [NullAllowed] string name);
	}

	// @interface TVIVideoTrackPublication : TVITrackPublication
	[BaseType (typeof(TVITrackPublication))]
	[DisableDefaultCtor]
	interface TVIVideoTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVIVideoTrack * _Nullable videoTrack;
		[NullAllowed, Export ("videoTrack", ArgumentSemantic.Strong)]
		TVIVideoTrack VideoTrack { get; }
	}

	// @interface TVILocalVideoTrackPublication : TVIVideoTrackPublication
	[BaseType (typeof(TVIVideoTrackPublication))]
	[DisableDefaultCtor]
	interface TVILocalVideoTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVILocalVideoTrack * _Nullable localTrack;
		[NullAllowed, Export ("localTrack", ArgumentSemantic.Strong)]
		TVILocalVideoTrack LocalTrack { get; }
	}

	// @interface TVILocalVideoTrackStats : TVILocalTrackStats
	[BaseType (typeof(TVILocalTrackStats))]
	[DisableDefaultCtor]
	interface TVILocalVideoTrackStats
	{
		// @property (readonly, assign, nonatomic) CMVideoDimensions captureDimensions;
		[Export ("captureDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions CaptureDimensions { get; }

		// @property (readonly, assign, nonatomic) NSUInteger captureFrameRate;
		[Export ("captureFrameRate")]
		nuint CaptureFrameRate { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; }

		// @property (readonly, assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; }

		// @property (readonly, assign, nonatomic) uint32_t framesEncoded;
		[Export ("framesEncoded")]
		uint FramesEncoded { get; }
	}

	// @interface TVIOpusCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIOpusCodec
	{
	}

	// @interface TVIPcmaCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIPcmaCodec
	{
	}

	// @interface TVIPcmuCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIPcmuCodec
	{
	}

	// @interface TVIRemoteAudioTrack : TVIAudioTrack
	[BaseType (typeof(TVIAudioTrack))]
	[DisableDefaultCtor]
	interface TVIRemoteAudioTrack
	{
		// @property (getter = isPlaybackEnabled, assign, nonatomic) BOOL playbackEnabled;
		[Export ("playbackEnabled")]
		bool PlaybackEnabled { [Bind ("isPlaybackEnabled")] get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }
	}

	// @interface TVIRemoteAudioTrackPublication : TVIAudioTrackPublication
	[BaseType (typeof(TVIAudioTrackPublication))]
	[DisableDefaultCtor]
	interface TVIRemoteAudioTrackPublication
	{
		// @property (readonly, getter = isTrackSubscribed, assign, nonatomic) BOOL trackSubscribed;
		[Export ("trackSubscribed")]
		bool TrackSubscribed { [Bind ("isTrackSubscribed")] get; }

		// @property (readonly, nonatomic, strong) TVIRemoteAudioTrack * _Nullable remoteTrack;
		[NullAllowed, Export ("remoteTrack", ArgumentSemantic.Strong)]
		TVIRemoteAudioTrack RemoteTrack { get; }
	}

	// @interface TVIRemoteTrackStats : TVIBaseTrackStats
	[BaseType (typeof(TVIBaseTrackStats))]
	[DisableDefaultCtor]
	interface TVIRemoteTrackStats
	{
		// @property (readonly, assign, nonatomic) int64_t bytesReceived;
		[Export ("bytesReceived")]
		long BytesReceived { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsReceived;
		[Export ("packetsReceived")]
		nuint PacketsReceived { get; }
	}

	// @interface TVIRemoteAudioTrackStats : TVIRemoteTrackStats
	[BaseType (typeof(TVIRemoteTrackStats))]
	[DisableDefaultCtor]
	interface TVIRemoteAudioTrackStats
	{
		// @property (readonly, assign, nonatomic) NSUInteger audioLevel;
		[Export ("audioLevel")]
		nuint AudioLevel { get; }

		// @property (readonly, assign, nonatomic) NSUInteger jitter;
		[Export ("jitter")]
		nuint Jitter { get; }
	}

	// @interface TVIRemoteDataTrack : TVIDataTrack
	[BaseType (typeof(TVIDataTrack))]
	[DisableDefaultCtor]
	interface TVIRemoteDataTrack
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIRemoteDataTrackDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVIRemoteDataTrackDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }
	}

	// @protocol TVIRemoteDataTrackDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIRemoteDataTrackDelegate
	{
		// @optional -(void)remoteDataTrack:(TVIRemoteDataTrack * _Nonnull)remoteDataTrack didReceiveString:(NSString * _Nonnull)message;
		[Export ("remoteDataTrack:didReceiveString:")]
		void DidReceiveString (TVIRemoteDataTrack remoteDataTrack, string message);

		// @optional -(void)remoteDataTrack:(TVIRemoteDataTrack * _Nonnull)remoteDataTrack didReceiveData:(NSData * _Nonnull)message;
		[Export ("remoteDataTrack:didReceiveData:")]
		void DidReceiveData (TVIRemoteDataTrack remoteDataTrack, NSData message);
	}

	// @interface TVIRemoteDataTrackPublication : TVIDataTrackPublication
	[BaseType (typeof(TVIDataTrackPublication))]
	[DisableDefaultCtor]
	interface TVIRemoteDataTrackPublication
	{
		// @property (readonly, getter = isTrackSubscribed, assign, nonatomic) BOOL trackSubscribed;
		[Export ("trackSubscribed")]
		bool TrackSubscribed { [Bind ("isTrackSubscribed")] get; }

		// @property (readonly, nonatomic, strong) TVIRemoteDataTrack * _Nullable remoteTrack;
		[NullAllowed, Export ("remoteTrack", ArgumentSemantic.Strong)]
		TVIRemoteDataTrack RemoteTrack { get; }
	}

	// @interface TVIRemoteParticipant : TVIParticipant
	[BaseType (typeof(TVIParticipant))]
	[DisableDefaultCtor]
	interface TVIRemoteParticipant
	{
		// @property (readonly, getter = isConnected, assign, nonatomic) BOOL connected;
		[Export ("connected")]
		bool Connected { [Bind ("isConnected")] get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIRemoteParticipantDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVIRemoteParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteAudioTrackPublication *> * _Nonnull remoteAudioTracks;
		[Export ("remoteAudioTracks", ArgumentSemantic.Copy)]
		TVIRemoteAudioTrackPublication[] RemoteAudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteVideoTrackPublication *> * _Nonnull remoteVideoTracks;
		[Export ("remoteVideoTracks", ArgumentSemantic.Copy)]
		TVIRemoteVideoTrackPublication[] RemoteVideoTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteDataTrackPublication *> * _Nonnull remoteDataTracks;
		[Export ("remoteDataTracks", ArgumentSemantic.Copy)]
		TVIRemoteDataTrackPublication[] RemoteDataTracks { get; }
	}

	// @protocol TVIRemoteParticipantDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIRemoteParticipantDelegate
	{
		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant publishedVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:publishedVideoTrack:")]
		void RemoteParticipantPublishedVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant unpublishedVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:unpublishedVideoTrack:")]
		void RemoteParticipantUnpublishedVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant publishedAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:publishedAudioTrack:")]
		void RemoteParticipantPublishedAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant unpublishedAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:unpublishedAudioTrack:")]
		void RemoteParticipantUnpublishedAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant publishedDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:publishedDataTrack:")]
		void RemoteParticipantPublishedDataTrack(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant unpublishedDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:unpublishedDataTrack:")]
		void RemoteParticipantUnpublishedDataTrack(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant enabledVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:enabledVideoTrack:")]
		void RemoteParticipantEnabledVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant disabledVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:disabledVideoTrack:")]
		void RemoteParticipantDisabledVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant enabledAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:enabledAudioTrack:")]
		void RemoteParticipantEnabledAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant disabledAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
		[Export ("remoteParticipant:disabledAudioTrack:")]
		void RemoteParticipantDisabledAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)subscribedToVideoTrack:(TVIRemoteVideoTrack * _Nonnull)videoTrack publication:(TVIRemoteVideoTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("subscribedToVideoTrack:publication:forParticipant:")]
		void SubscribedToVideoTrack (TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)failedToSubscribeToVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("failedToSubscribeToVideoTrack:error:forParticipant:")]
		void FailedToSubscribeToVideoTrack (TVIRemoteVideoTrackPublication publication, NSError error, TVIRemoteParticipant participant);

		// @optional -(void)unsubscribedFromVideoTrack:(TVIRemoteVideoTrack * _Nonnull)videoTrack publication:(TVIRemoteVideoTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("unsubscribedFromVideoTrack:publication:forParticipant:")]
		void UnsubscribedFromVideoTrack (TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)subscribedToAudioTrack:(TVIRemoteAudioTrack * _Nonnull)audioTrack publication:(TVIRemoteAudioTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("subscribedToAudioTrack:publication:forParticipant:")]
		void SubscribedToAudioTrack (TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)failedToSubscribeToAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("failedToSubscribeToAudioTrack:error:forParticipant:")]
		void FailedToSubscribeToAudioTrack (TVIRemoteAudioTrackPublication publication, NSError error, TVIRemoteParticipant participant);

		// @optional -(void)unsubscribedFromAudioTrack:(TVIRemoteAudioTrack * _Nonnull)audioTrack publication:(TVIRemoteAudioTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("unsubscribedFromAudioTrack:publication:forParticipant:")]
		void UnsubscribedFromAudioTrack (TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)subscribedToDataTrack:(TVIRemoteDataTrack * _Nonnull)dataTrack publication:(TVIRemoteDataTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("subscribedToDataTrack:publication:forParticipant:")]
		void SubscribedToDataTrack (TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)failedToSubscribeToDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("failedToSubscribeToDataTrack:error:forParticipant:")]
		void FailedToSubscribeToDataTrack (TVIRemoteDataTrackPublication publication, NSError error, TVIRemoteParticipant participant);

		// @optional -(void)unsubscribedFromDataTrack:(TVIRemoteDataTrack * _Nonnull)dataTrack publication:(TVIRemoteDataTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("unsubscribedFromDataTrack:publication:forParticipant:")]
		void UnsubscribedFromDataTrack (TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant);
	}

	// @interface TVIRemoteVideoTrack : TVIVideoTrack
	[BaseType (typeof(TVIVideoTrack))]
	[DisableDefaultCtor]
	interface TVIRemoteVideoTrack
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }
	}

	// @interface TVIRemoteVideoTrackPublication : TVIVideoTrackPublication
	[BaseType (typeof(TVIVideoTrackPublication))]
	[DisableDefaultCtor]
	interface TVIRemoteVideoTrackPublication
	{
		// @property (readonly, getter = isTrackSubscribed, assign, nonatomic) BOOL trackSubscribed;
		[Export ("trackSubscribed")]
		bool TrackSubscribed { [Bind ("isTrackSubscribed")] get; }

		// @property (readonly, nonatomic, strong) TVIRemoteVideoTrack * _Nullable remoteTrack;
		[NullAllowed, Export ("remoteTrack", ArgumentSemantic.Strong)]
		TVIRemoteVideoTrack RemoteTrack { get; }
	}

	// @interface TVIRemoteVideoTrackStats : TVIRemoteTrackStats
	[BaseType (typeof(TVIRemoteTrackStats))]
	[DisableDefaultCtor]
	interface TVIRemoteVideoTrackStats
	{
		// @property (readonly, assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; }

		// @property (readonly, assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; }
	}

	// typedef void (^TVIRoomGetStatsBlock)(NSArray<TVIStatsReport *> * _Nonnull);
	delegate void TVIRoomGetStatsBlock (TVIStatsReport[] arg0);

	// @interface TVIRoom : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIRoom
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIRoomDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVIRoomDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TVILocalParticipant * _Nullable localParticipant;
		[NullAllowed, Export ("localParticipant", ArgumentSemantic.Strong)]
		TVILocalParticipant LocalParticipant { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteParticipant *> * _Nonnull remoteParticipants;
		[Export ("remoteParticipants", ArgumentSemantic.Copy)]
		TVIRemoteParticipant[] RemoteParticipants { get; }

		// @property (readonly, getter = isRecording, assign, nonatomic) BOOL recording;
		[Export ("recording")]
		bool Recording { [Bind ("isRecording")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }

		// @property (readonly, assign, nonatomic) TVIRoomState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVIRoomState State { get; }

		// @property (readonly, nonatomic, strong) TVIRemoteParticipant * _Nullable dominantSpeaker;
		[NullAllowed, Export ("dominantSpeaker", ArgumentSemantic.Strong)]
		TVIRemoteParticipant DominantSpeaker { get; }

		// -(TVIRemoteParticipant * _Nullable)getRemoteParticipantWithSid:(NSString * _Nonnull)sid;
		[Export ("getRemoteParticipantWithSid:")]
		[return: NullAllowed]
		TVIRemoteParticipant GetRemoteParticipantWithSid (string sid);

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)getStatsWithBlock:(TVIRoomGetStatsBlock _Nonnull)block;
		[Export ("getStatsWithBlock:")]
		void GetStatsWithBlock (TVIRoomGetStatsBlock block);
	}

	// @interface CallKit (TVIRoom)
	[Category]
	[BaseType (typeof(TVIRoom))]
	interface TVIRoom_CallKit
	{
		// @property (readonly, nonatomic) NSUUID * _Nullable uuid;
		[NullAllowed, Export("uuid")]
		NSUuid GetUuid();
	}

	// @protocol TVIRoomDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIRoomDelegate
	{
		// @optional -(void)didConnectToRoom:(TVIRoom * _Nonnull)room;
		[Export ("didConnectToRoom:")]
		void DidConnectToRoom (TVIRoom room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room didFailToConnectWithError:(NSError * _Nonnull)error;
		[Export ("room:didFailToConnectWithError:")]
		void RoomDidFailToConnectWithError(TVIRoom room, NSError error);

		// @optional -(void)room:(TVIRoom * _Nonnull)room didDisconnectWithError:(NSError * _Nullable)error;
		[Export ("room:didDisconnectWithError:")]
		void RoomDidDisconnectWithError(TVIRoom room, [NullAllowed] NSError error);

		// @optional -(void)room:(TVIRoom * _Nonnull)room isReconnectingWithError:(NSError * _Nonnull)error;
		[Export ("room:isReconnectingWithError:")]
		void RoomIsReconnectingWithError(TVIRoom room, NSError error);

		// @optional -(void)didReconnectToRoom:(TVIRoom * _Nonnull)room;
		[Export ("didReconnectToRoom:")]
		void DidReconnectToRoom (TVIRoom room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidConnect:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("room:participantDidConnect:")]
		void RoomParticipantDidConnect(TVIRoom room, TVIRemoteParticipant participant);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidDisconnect:(TVIRemoteParticipant * _Nonnull)participant;
		[Export ("room:participantDidDisconnect:")]
		void RoomParticipantDidDisconnect(TVIRoom room, TVIRemoteParticipant participant);

		// @optional -(void)roomDidStartRecording:(TVIRoom * _Nonnull)room;
		[Export ("roomDidStartRecording:")]
		void RoomDidStartRecording (TVIRoom room);

		// @optional -(void)roomDidStopRecording:(TVIRoom * _Nonnull)room;
		[Export ("roomDidStopRecording:")]
		void RoomDidStopRecording (TVIRoom room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room dominantSpeakerDidChange:(TVIRemoteParticipant * _Nullable)participant;
		[Export ("room:dominantSpeakerDidChange:")]
		void RoomDominantSpeakerDidChange(TVIRoom room, [NullAllowed] TVIRemoteParticipant participant);
	}

	// @interface TVIScreenCapturer : NSObject <TVIVideoCapturer>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIScreenCapturer : TVIVideoCapturer
	{
		// @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Export ("capturing")]
		bool Capturing { [Bind ("isCapturing")] get; }

		// -(instancetype _Null_unspecified)initWithView:(UIView * _Nonnull)view;
		[Export ("initWithView:")]
		IntPtr Constructor (UIView view);
	}

	// @interface TVIStatsReport : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIStatsReport
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull peerConnectionId;
		[Export ("peerConnectionId")]
		string PeerConnectionId { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVILocalAudioTrackStats *> * _Nonnull localAudioTrackStats;
		[Export ("localAudioTrackStats", ArgumentSemantic.Strong)]
		TVILocalAudioTrackStats[] LocalAudioTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVILocalVideoTrackStats *> * _Nonnull localVideoTrackStats;
		[Export ("localVideoTrackStats", ArgumentSemantic.Strong)]
		TVILocalVideoTrackStats[] LocalVideoTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIRemoteAudioTrackStats *> * _Nonnull remoteAudioTrackStats;
		[Export ("remoteAudioTrackStats", ArgumentSemantic.Strong)]
		TVIRemoteAudioTrackStats[] RemoteAudioTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIRemoteVideoTrackStats *> * _Nonnull remoteVideoTrackStats;
		[Export ("remoteVideoTrackStats", ArgumentSemantic.Strong)]
		TVIRemoteVideoTrackStats[] RemoteVideoTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIIceCandidateStats *> * _Nonnull iceCandidateStats;
		[Export ("iceCandidateStats", ArgumentSemantic.Strong)]
		TVIIceCandidateStats[] IceCandidateStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIIceCandidatePairStats *> * _Nonnull iceCandidatePairStats;
		[Export ("iceCandidatePairStats", ArgumentSemantic.Strong)]
		TVIIceCandidatePairStats[] IceCandidatePairStats { get; }
	}

	partial interface Constants
	{
		// extern const NSUInteger TVIVideoConstraintsMaximumFPS;
		[Field ("TVIVideoConstraintsMaximumFPS", "__Internal")]
		nuint TVIVideoConstraintsMaximumFPS { get; }

		// extern const NSUInteger TVIVideoConstraintsMinimumFPS;
		[Field ("TVIVideoConstraintsMinimumFPS", "__Internal")]
		nuint TVIVideoConstraintsMinimumFPS { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSizeNone;
		[Field ("TVIVideoConstraintsSizeNone", "__Internal")]
		/*CMVideoDimensions*/ IntPtr TVIVideoConstraintsSizeNone { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRateNone;
		[Field ("TVIVideoConstraintsFrameRateNone", "__Internal")]
		nuint TVIVideoConstraintsFrameRateNone { get; }

		// extern const TVIAspectRatio TVIVideoConstraintsAspectRatioNone;
		[Field ("TVIVideoConstraintsAspectRatioNone", "__Internal")]
		/*TVIAspectRatio*/ IntPtr TVIVideoConstraintsAspectRatioNone { get; }

		// extern const TVIAspectRatio TVIAspectRatio11x9;
		[Field ("TVIAspectRatio11x9", "__Internal")]
		/*TVIAspectRatio*/ IntPtr TVIAspectRatio11x9 { get; }

		// extern const TVIAspectRatio TVIAspectRatio4x3;
		[Field ("TVIAspectRatio4x3", "__Internal")]
		/*TVIAspectRatio*/ IntPtr TVIAspectRatio4x3 { get; }

		// extern const TVIAspectRatio TVIAspectRatio16x9;
		[Field ("TVIAspectRatio16x9", "__Internal")]
		/*TVIAspectRatio*/ IntPtr TVIAspectRatio16x9 { get; }
	}

	// @interface TVIVideoConstraintsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoConstraintsBuilder
	{
		// @property (assign, nonatomic) CMVideoDimensions maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MaxSize { get; set; }

		// @property (assign, nonatomic) CMVideoDimensions minSize;
		[Export ("minSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MinSize { get; set; }

		// @property (assign, nonatomic) NSUInteger maxFrameRate;
		[Export ("maxFrameRate")]
		nuint MaxFrameRate { get; set; }

		// @property (assign, nonatomic) NSUInteger minFrameRate;
		[Export ("minFrameRate")]
		nuint MinFrameRate { get; set; }

		// @property (assign, nonatomic) TVIAspectRatio aspectRatio;
		[Export ("aspectRatio", ArgumentSemantic.Assign)]
		TVIAspectRatio AspectRatio { get; set; }
	}

	// typedef void (^TVIVideoConstraintsBuilderBlock)(TVIVideoConstraintsBuilder * _Nonnull);
	delegate void TVIVideoConstraintsBuilderBlock (TVIVideoConstraintsBuilder arg0);

	// @interface TVIVideoConstraints : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIVideoConstraints
	{
		// +(instancetype _Null_unspecified)constraints;
		[Static]
		[Export ("constraints")]
		TVIVideoConstraints Constraints ();

		// +(instancetype _Null_unspecified)constraintsWithBlock:(TVIVideoConstraintsBuilderBlock _Nonnull)builderBlock;
		[Static]
		[Export ("constraintsWithBlock:")]
		TVIVideoConstraints ConstraintsWithBlock (TVIVideoConstraintsBuilderBlock builderBlock);

		// @property (readonly, assign, nonatomic) CMVideoDimensions maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MaxSize { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions minSize;
		[Export ("minSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MinSize { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxFrameRate;
		[Export ("maxFrameRate")]
		nuint MaxFrameRate { get; }

		// @property (readonly, assign, nonatomic) NSUInteger minFrameRate;
		[Export ("minFrameRate")]
		nuint MinFrameRate { get; }

		// @property (readonly, assign, nonatomic) TVIAspectRatio aspectRatio;
		[Export ("aspectRatio", ArgumentSemantic.Assign)]
		TVIAspectRatio AspectRatio { get; }
	}

   	interface ITVIVideoRenderer : TVIVideoRenderer
    {

    }

	// @protocol TVIVideoRenderer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIVideoRenderer
	{
		// @required -(void)renderFrame:(TVIVideoFrame * _Nonnull)frame;
		[Abstract]
		[Export ("renderFrame:")]
		void RenderFrame (TVIVideoFrame frame);

		// @required -(void)updateVideoSize:(CMVideoDimensions)videoSize orientation:(TVIVideoOrientation)orientation;
		[Abstract]
		[Export ("updateVideoSize:orientation:")]
		void UpdateVideoSize (CMVideoDimensions videoSize, TVIVideoOrientation orientation);

		// @optional @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull optionalPixelFormats;
		[Export ("optionalPixelFormats", ArgumentSemantic.Copy)]
		NSNumber[] OptionalPixelFormats { get; }

		// @optional -(void)invalidateRenderer;
		[Export ("invalidateRenderer")]
		void InvalidateRenderer ();
	}

	// @protocol TVIVideoViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface TVIVideoViewDelegate
	{
		// @optional -(void)videoViewDidReceiveData:(TVIVideoView * _Nonnull)view;
		[Export ("videoViewDidReceiveData:")]
		void VideoViewDidReceiveData (TVIVideoView view);

		// @optional -(void)videoView:(TVIVideoView * _Nonnull)view videoDimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export ("videoView:videoDimensionsDidChange:")]
		void VideoView (TVIVideoView view, CMVideoDimensions dimensions);

		// @optional -(void)videoView:(TVIVideoView * _Nonnull)view videoOrientationDidChange:(TVIVideoOrientation)orientation;
		[Export ("videoView:videoOrientationDidChange:")]
		void VideoView (TVIVideoView view, TVIVideoOrientation orientation);
	}

	// @interface TVIVideoView : UIView <TVIVideoRenderer>
	[BaseType (typeof(UIView))]
	interface TVIVideoView : TVIVideoRenderer
	{
		// -(instancetype _Null_unspecified)initWithFrame:(CGRect)frame delegate:(id<TVIVideoViewDelegate> _Nullable)delegate;
		[Export ("initWithFrame:delegate:")]
		IntPtr Constructor (CGRect frame, [NullAllowed] TVIVideoViewDelegate @delegate);

		// -(instancetype _Null_unspecified)initWithFrame:(CGRect)frame delegate:(id<TVIVideoViewDelegate> _Nullable)delegate renderingType:(TVIVideoRenderingType)renderingType;
		[Export ("initWithFrame:delegate:renderingType:")]
		IntPtr Constructor (CGRect frame, [NullAllowed] TVIVideoViewDelegate @delegate, TVIVideoRenderingType renderingType);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIVideoViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVIVideoViewDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL viewShouldRotateContent;
		[Export ("viewShouldRotateContent")]
		bool ViewShouldRotateContent { get; set; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export ("videoDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoDimensions { get; }

		// @property (readonly, assign, nonatomic) TVIVideoOrientation videoOrientation;
		[Export ("videoOrientation", ArgumentSemantic.Assign)]
		TVIVideoOrientation VideoOrientation { get; }

		// @property (readonly, assign, atomic) BOOL hasVideoData;
		[Export ("hasVideoData")]
		bool HasVideoData { get; }

		// @property (getter = shouldMirror, assign, nonatomic) BOOL mirror;
		[Export ("mirror")]
		bool Mirror { [Bind ("shouldMirror")] get; set; }
	}

	// @interface TVIVp8Codec : TVIVideoCodec
	[BaseType (typeof(TVIVideoCodec))]
	interface TVIVp8Codec
	{
		// @property (readonly, getter = isSimulcast, nonatomic) BOOL simulcast;
		[Export ("simulcast")]
		bool Simulcast { [Bind ("isSimulcast")] get; }

		// -(instancetype _Nonnull)initWithSimulcast:(BOOL)simulcast;
		[Export ("initWithSimulcast:")]
		IntPtr Constructor (bool simulcast);
	}

	// @interface TVIVp9Codec : TVIVideoCodec
	[BaseType (typeof(TVIVideoCodec))]
	interface TVIVp9Codec
	{
	}

	// @interface TwilioVideo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TwilioVideo
	{
      	// @property (nonatomic, strong, class) id<TVIAudioDevice> _Nonnull audioDevice;
        [Static]
        [Export("audioDevice", ArgumentSemantic.Strong)]
        ITVIAudioDevice GetAudioDevice();

        [Static]
        [Export("setAudioDevice:", ArgumentSemantic.Strong)]
        void SetAudioDevice(ITVIAudioDevice audioDevice);

		// +(TVIRoom * _Nonnull)connectWithOptions:(TVIConnectOptions * _Nonnull)options delegate:(id<TVIRoomDelegate> _Nullable)delegate;
		[Static]
		[Export ("connectWithOptions:delegate:")]
		TVIRoom ConnectWithOptions (TVIConnectOptions options, [NullAllowed] TVIRoomDelegate @delegate);

		// +(NSString * _Nonnull)version;
		[Static]
		[Export ("version")]
		string Version { get; }

		// +(TVILogLevel)logLevel;
		// +(void)setLogLevel:(TVILogLevel)logLevel;
		[Static]
		[Export ("logLevel")]
		TVILogLevel LogLevel { get; set; }

		// +(TVILogLevel)logLevelForModule:(TVILogModule)module;
		[Static]
		[Export ("logLevelForModule:")]
		TVILogLevel LogLevelForModule (TVILogModule module);

		// +(void)setLogLevel:(TVILogLevel)logLevel module:(TVILogModule)module;
		[Static]
		[Export ("setLogLevel:module:")]
		void SetLogLevel (TVILogLevel logLevel, TVILogModule module);
	}
}
