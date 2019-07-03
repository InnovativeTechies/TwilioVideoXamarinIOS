using System;
using Foundation;
using LSP.Mobile.Infrastructure.Common.Log;
using Twilio.Video.iOS;

namespace LSP.Mobile.iOS.ViewController.Delegates.Video
{
    public class RemoteParticipantDelegate : TVIRemoteParticipantDelegate
    {
        #region Fields

        private static RemoteParticipantDelegate _instance;

        #endregion

        #region Properties

        public static RemoteParticipantDelegate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RemoteParticipantDelegate();
                }

                return _instance;
            }
        }

        #endregion

        #region Events

        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)> RemoteParticipantPublishedVideoTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)> RemoteParticipantUnpublishedVideoTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)> RemoteParticipantPublishedAudioTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)> RemoteParticipantUnpublishedAudioTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication)> RemoteParticipantPublishedDataTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication)> RemoteParticipantUnpublishedDataTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)> RemoteParticipantEnabledVideoTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)> RemoteParticipantDisabledVideoTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)> RemoteParticipantEnabledAudioTrackEvent;
        public event EventHandler<(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)> RemoteParticipantDisabledAudioTrackEvent;
        public event EventHandler<(TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant)> SubscribedToVideoTrackEvent;
        public event EventHandler<(TVIRemoteVideoTrackPublication publication, NSError error, TVIRemoteParticipant participant)> FailedToSubscribeToVideoTrackEvent;
        public event EventHandler<(TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant)> UnsubscribedFromVideoTrackEvent;
        public event EventHandler<(TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant)> SubscribedToAudioTrackEvent;
        public event EventHandler<(TVIRemoteAudioTrackPublication publication, NSError error, TVIRemoteParticipant participant)> FailedToSubscribeToAudioTrackEvent;
        public event EventHandler<(TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant)> UnsubscribedFromAudioTrackEvent;
        public event EventHandler<(TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant)> SubscribedToDataTrackEvent;
        public event EventHandler<(TVIRemoteDataTrackPublication publication, NSError error, TVIRemoteParticipant participant)> FailedToSubscribeToDataTrackEvent;
        public event EventHandler<(TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant)> UnsubscribedFromDataTrackEvent;

        #endregion

        #region Methods

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant publishedVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:publishedVideoTrack:")]
        public override void RemoteParticipantPublishedVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantPublishedVideoTrack));
            RemoteParticipantPublishedVideoTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant unpublishedVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:unpublishedVideoTrack:")]
        public override void RemoteParticipantUnpublishedVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantUnpublishedVideoTrack));
            RemoteParticipantUnpublishedVideoTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant publishedAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:publishedAudioTrack:")]
        public override void RemoteParticipantPublishedAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantPublishedAudioTrack));
            RemoteParticipantPublishedAudioTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant unpublishedAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:unpublishedAudioTrack:")]
        public override void RemoteParticipantUnpublishedAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantUnpublishedAudioTrack));
            RemoteParticipantUnpublishedAudioTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant publishedDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:publishedDataTrack:")]
        public override void RemoteParticipantPublishedDataTrack(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantPublishedDataTrack));
            RemoteParticipantPublishedDataTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant unpublishedDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:unpublishedDataTrack:")]
        public override void RemoteParticipantUnpublishedDataTrack(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantUnpublishedDataTrack));
            RemoteParticipantUnpublishedDataTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant enabledVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:enabledVideoTrack:")]
        public override void RemoteParticipantEnabledVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantEnabledVideoTrack));
            RemoteParticipantEnabledVideoTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant disabledVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:disabledVideoTrack:")]
        public override void RemoteParticipantDisabledVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantDisabledVideoTrack));
            RemoteParticipantDisabledVideoTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant enabledAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:enabledAudioTrack:")]
        public override void RemoteParticipantEnabledAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantEnabledAudioTrack));
            RemoteParticipantEnabledAudioTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant disabledAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication;
        [Export("remoteParticipant:disabledAudioTrack:")]
        public override void RemoteParticipantDisabledAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(RemoteParticipantDisabledAudioTrack));
            RemoteParticipantDisabledAudioTrackEvent?.Invoke(this, (participant, publication));
        }

        // @optional -(void)subscribedToVideoTrack:(TVIRemoteVideoTrack * _Nonnull)videoTrack publication:(TVIRemoteVideoTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("subscribedToVideoTrack:publication:forParticipant:")]
        public override void SubscribedToVideoTrack(TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(SubscribedToVideoTrack));
            SubscribedToVideoTrackEvent?.Invoke(this, (videoTrack, publication, participant));
        }

        // @optional -(void)failedToSubscribeToVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("failedToSubscribeToVideoTrack:error:forParticipant:")]
        public override void FailedToSubscribeToVideoTrack(TVIRemoteVideoTrackPublication publication, NSError error, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(FailedToSubscribeToVideoTrack));
            FailedToSubscribeToVideoTrackEvent?.Invoke(this, (publication, error, participant));
        }

        // @optional -(void)unsubscribedFromVideoTrack:(TVIRemoteVideoTrack * _Nonnull)videoTrack publication:(TVIRemoteVideoTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("unsubscribedFromVideoTrack:publication:forParticipant:")]
        public override void UnsubscribedFromVideoTrack(TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(UnsubscribedFromVideoTrack));
            UnsubscribedFromVideoTrackEvent?.Invoke(this, (videoTrack, publication, participant));
        }

        // @optional -(void)subscribedToAudioTrack:(TVIRemoteAudioTrack * _Nonnull)audioTrack publication:(TVIRemoteAudioTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("subscribedToAudioTrack:publication:forParticipant:")]
        public override void SubscribedToAudioTrack(TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(SubscribedToAudioTrack));
            SubscribedToAudioTrackEvent?.Invoke(this, (audioTrack, publication, participant));
        }

        // @optional -(void)failedToSubscribeToAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("failedToSubscribeToAudioTrack:error:forParticipant:")]
        public override void FailedToSubscribeToAudioTrack(TVIRemoteAudioTrackPublication publication, NSError error, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(FailedToSubscribeToAudioTrack));
            FailedToSubscribeToAudioTrackEvent?.Invoke(this, (publication, error, participant));
        }

        // @optional -(void)unsubscribedFromAudioTrack:(TVIRemoteAudioTrack * _Nonnull)audioTrack publication:(TVIRemoteAudioTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("unsubscribedFromAudioTrack:publication:forParticipant:")]
        public override void UnsubscribedFromAudioTrack(TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(UnsubscribedFromAudioTrack));
            UnsubscribedFromAudioTrackEvent?.Invoke(this, (audioTrack, publication, participant));
        }

        // @optional -(void)subscribedToDataTrack:(TVIRemoteDataTrack * _Nonnull)dataTrack publication:(TVIRemoteDataTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("subscribedToDataTrack:publication:forParticipant:")]
        public override void SubscribedToDataTrack(TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(SubscribedToDataTrack));
            SubscribedToDataTrackEvent?.Invoke(this, (dataTrack, publication, participant));
        }

        // @optional -(void)failedToSubscribeToDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("failedToSubscribeToDataTrack:error:forParticipant:")]
        public override void FailedToSubscribeToDataTrack(TVIRemoteDataTrackPublication publication, NSError error, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(FailedToSubscribeToDataTrack));
            FailedToSubscribeToDataTrackEvent?.Invoke(this, (publication, error, participant));
        }

        // @optional -(void)unsubscribedFromDataTrack:(TVIRemoteDataTrack * _Nonnull)dataTrack publication:(TVIRemoteDataTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("unsubscribedFromDataTrack:publication:forParticipant:")]
        public override void UnsubscribedFromDataTrack(TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RemoteParticipantDelegate), nameof(UnsubscribedFromDataTrack));
            UnsubscribedFromDataTrackEvent?.Invoke(this, (dataTrack, publication, participant));
        }

        #endregion
    }
}
