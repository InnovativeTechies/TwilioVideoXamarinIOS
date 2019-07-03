using System;
using AVFoundation;
using Foundation;
using LSP.Mobile.Infrastructure.Common.Log;
using Twilio.Video.iOS;

namespace LSP.Mobile.iOS.ViewController.Delegates.Video
{
    public class CameraSourceDelegate : TVICameraSourceDelegate
    {
        #region Fields

        private static CameraSourceDelegate _instance;

        #endregion

        #region Properties

        public static CameraSourceDelegate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CameraSourceDelegate();
                }

                return _instance;
            }
        }

        #endregion

        #region Events

        public event EventHandler<TVICameraSource> CameraSourceInterruptionEndedEvent;
        public event EventHandler<(TVICameraSource source, AVCaptureSessionInterruptionReason reason)> CameraSourceWasInterruptedEvent;
        public event EventHandler<(TVICameraSource source, NSError error)> CameraSourceEvent;

        #endregion

        #region Methods

        // @optional -(void)cameraSourceInterruptionEnded:(TVICameraSource * _Nonnull)source;
        [Export("cameraSourceInterruptionEnded:")]
        public override void CameraSourceInterruptionEnded(TVICameraSource source)
        {
            LogHelper.Call(nameof(CameraSourceDelegate), nameof(CameraSourceInterruptionEnded));
            CameraSourceInterruptionEndedEvent?.Invoke(this, source);
        }

        // @optional -(void)cameraSourceWasInterrupted:(TVICameraSource * _Nonnull)source reason:(AVCaptureSessionInterruptionReason)reason;
        [Export("cameraSourceWasInterrupted:reason:")]
        public override void CameraSourceWasInterrupted(TVICameraSource source, AVCaptureSessionInterruptionReason reason)
        {
            LogHelper.Call(nameof(CameraSourceDelegate), nameof(CameraSourceWasInterrupted));
            CameraSourceWasInterruptedEvent?.Invoke(this, (source, reason));
        }

        // @optional -(void)cameraSource:(TVICameraSource * _Nonnull)source didFailWithError:(NSError * _Nonnull)error;
        [Export("cameraSource:didFailWithError:")]
        public override void CameraSource(TVICameraSource source, NSError error)
        {
            LogHelper.Call(nameof(CameraSourceDelegate), nameof(CameraSource));
            CameraSourceEvent?.Invoke(this, (source, error));
        }

        #endregion
    }
}
