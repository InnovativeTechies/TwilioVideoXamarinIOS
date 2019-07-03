using System;
using Foundation;
using LSP.Mobile.Infrastructure.Common.Log;
using Twilio.Video.iOS;

namespace LSP.Mobile.iOS.ViewController.Delegates.Video
{
    public class RoomDelegate : TVIRoomDelegate
    {
        #region Fields

        private static RoomDelegate _instance;

        #endregion

        #region Properties

        public static bool InProgress { get; set; } = false;

        public static RoomDelegate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoomDelegate();
                }

                return _instance;
            }
        }

        #endregion

        #region Events

        public event EventHandler<TVIRoom> DidConnectToRoomEvent;
        public event EventHandler<(TVIRoom room, NSError error)> RoomDidFailToConnectWithErrorEvent;
        public event EventHandler<(TVIRoom room, NSError error)> RoomDidDisconnectWithErrorEvent;
        public event EventHandler<(TVIRoom room, TVIRemoteParticipant participant)> RoomParticipantDidConnectEvent;
        public event EventHandler<(TVIRoom room, TVIRemoteParticipant participant)> RoomParticipantDidDisconnectEvent;
        public event EventHandler<TVIRoom> RoomDidStartRecordingEvent;
        public event EventHandler<TVIRoom> RoomDidStopRecordingEvent;

        #endregion

        #region Methods

        public TVIRoom ConnectToRoom(string token, TVILocalAudioTrack localAudioTrack, TVILocalVideoTrack localVideoTrack, string roomName)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(ConnectToRoom));
            InProgress = true;

            var connectOptions = TVIConnectOptions.OptionsWithToken(token, builder =>
            {
                builder.AudioTracks = new[] { localAudioTrack };
                builder.VideoTracks = new[] { localVideoTrack };
                builder.RoomName = roomName;
            });

            return TwilioVideo.ConnectWithOptions(connectOptions, Instance);
        }

        // @optional -(void)didConnectToRoom:(TVIRoom * _Nonnull)room;
        [Export("didConnectToRoom:")]
        public override void DidConnectToRoom(TVIRoom room)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(DidConnectToRoom));
            DidConnectToRoomEvent?.Invoke(this, room);
        }

        // @optional -(void)room:(TVIRoom * _Nonnull)room didFailToConnectWithError:(NSError * _Nonnull)error;
        [Export("room:didFailToConnectWithError:")]
        public override void RoomDidFailToConnectWithError(TVIRoom room, NSError error)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(RoomDidFailToConnectWithError));
            RoomDidFailToConnectWithErrorEvent?.Invoke(this, (room, error));
        }

        // @optional -(void)room:(TVIRoom * _Nonnull)room didDisconnectWithError:(NSError * _Nullable)error;
        [Export("room:didDisconnectWithError:")]
        public override void RoomDidDisconnectWithError(TVIRoom room, NSError error)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(RoomDidDisconnectWithError));
            RoomDidDisconnectWithErrorEvent?.Invoke(this, (room, error));
        }

        // @optional -(void)room:(TVIRoom * _Nonnull)room participantDidConnect:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("room:participantDidConnect:")]
        public override void RoomParticipantDidConnect(TVIRoom room, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(RoomParticipantDidConnect));
            RoomParticipantDidConnectEvent?.Invoke(this, (room, participant));
        }

        // @optional -(void)room:(TVIRoom * _Nonnull)room participantDidDisconnect:(TVIRemoteParticipant * _Nonnull)participant;
        [Export("room:participantDidDisconnect:")]
        public override void RoomParticipantDidDisconnect(TVIRoom room, TVIRemoteParticipant participant)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(RoomParticipantDidDisconnect));
            RoomParticipantDidDisconnectEvent?.Invoke(this, (room, participant));
        }

        // @optional -(void)roomDidStartRecording:(TVIRoom * _Nonnull)room;
        [Export("roomDidStartRecording:")]
        public override void RoomDidStartRecording(TVIRoom room)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(RoomDidStartRecording));
            RoomDidStartRecordingEvent?.Invoke(this, room);
        }

        // @optional -(void)roomDidStopRecording:(TVIRoom * _Nonnull)room;
        [Export("roomDidStopRecording:")]
        public override void RoomDidStopRecording(TVIRoom room)
        {
            LogHelper.Call(nameof(RoomDelegate), nameof(RoomDidStopRecording));
            RoomDidStopRecordingEvent?.Invoke(this, room);
        }

        #endregion
    }
}
