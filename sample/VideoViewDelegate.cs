using System;
using CoreMedia;
using Foundation;
using Twilio.Video.iOS;
using LSP.Mobile.Infrastructure.Common.Log;

namespace LSP.Mobile.iOS.ViewController.Delegates.Video
{
    public class VideoViewDelegate : TVIVideoViewDelegate
    {
        #region Fields

        static VideoViewDelegate _instance;

        #endregion

        #region Properties

        public static VideoViewDelegate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VideoViewDelegate();
                }

                return _instance;
            }
        }

        #endregion

        #region Events

        public event EventHandler<TVIVideoView> VideoViewDidReceiveDataEvent;
        public event EventHandler<(TVIVideoView view, CMVideoDimensions dimensions)> VideoDimensionsDidChangeEvent;
        public event EventHandler<(TVIVideoView view, TVIVideoOrientation orientation)> VideoOrientationDidChangeEvent;

        #endregion

        #region Methods

        // @optional -(void)videoViewDidReceiveData:(TVIVideoView * _Nonnull)view;
        [Export("videoViewDidReceiveData:")]
        public override void VideoViewDidReceiveData(TVIVideoView view)
        {
            LogHelper.Call(nameof(VideoViewDelegate), nameof(VideoViewDidReceiveData));
            VideoViewDidReceiveDataEvent?.Invoke(this, view);
        }

        // @optional -(void)videoView:(TVIVideoView * _Nonnull)view videoDimensionsDidChange:(CMVideoDimensions)dimensions;
        [Export("videoView:videoDimensionsDidChange:")]
        public override void VideoView(TVIVideoView view, CMVideoDimensions dimensions)
        {
            LogHelper.Call(nameof(VideoViewDelegate), nameof(VideoView));
            VideoDimensionsDidChangeEvent?.Invoke(this, (view, dimensions));
        }

        // @optional -(void)videoView:(TVIVideoView * _Nonnull)view videoOrientationDidChange:(TVIVideoOrientation)orientation;
        [Export("videoView:videoOrientationDidChange:")]
        public override void VideoView(TVIVideoView view, TVIVideoOrientation orientation)
        {
            LogHelper.Call(nameof(VideoViewDelegate), nameof(VideoView));
            VideoOrientationDidChangeEvent?.Invoke(this, (view, orientation));
        }

        #endregion
    }
}
