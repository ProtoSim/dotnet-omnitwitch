using System;

namespace ProtoSim.OmniTwitch {
    /// <summary>
    /// Provides a set of parameters related to a chat command event.
    /// </summary>
    public class SoundAlertsDetectedArgs : EventArgs {
        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        public string ChannelName { get; private set; }
        /// <summary>
        /// Gets the Id of the channel.
        /// </summary>
        public string ChannelId { get; private set; }
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Username { get; } = "soundalerts";
        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string UserDisplayName { get; } = "SoundAlerts";
        /// <summary>
        /// Gets the Id of the user.
        /// </summary>
        public string UserId { get; } = null;
        /// <summary>
        /// Gets the hex color for the user.
        /// </summary>
        public string UserColorHex { get; private set; }
        /// <summary>
        /// Gets a boolean value indicating whether the user is a subscriber.
        /// </summary>
        public bool IsSubscriber { get; private set; }
        /// <summary>
        /// Gets a boolean value indicating whether the user is a moderator.
        /// </summary>
        public bool IsModerator { get; private set; }
        /// <summary>
        /// Gets a boolean value indicating whether the user is the broadcaster.
        /// </summary>
        public bool IsBroadcaster { get; private set; }
        /// <summary>
        /// Gets the message Id.
        /// </summary>
        public string MessageId { get; private set; }
        /// <summary>
        /// Gets the message text.
        /// </summary>
        public string Message { get; private set; }

        internal ChatMessageArgs(string? channelName, string? channelId, string? userColorHex, bool isSubscriber, bool isModerator, bool isBroadcaster, string? messageId, string? message) {
            ChannelName = channelName ?? string.Empty;
            ChannelId = channelId ?? string.Empty;
            Username = username ?? string.Empty;
            UserDisplayName = userDisplayName ?? string.Empty;
            UserId = userId ?? string.Empty;
            UserColorHex = userColorHex ?? string.Empty;
            IsSubscriber = isSubscriber;
            IsModerator = isModerator;
            IsBroadcaster = isBroadcaster;
            MessageId = messageId ?? string.Empty;
            Message = message ?? string.Empty;
        }
    }
}