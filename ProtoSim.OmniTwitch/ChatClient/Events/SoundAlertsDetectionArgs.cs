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
        public string Username { get; private set; }
        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string UserDisplayName { get; private set; }
        /// <summary>
        /// Gets the Id of the user.
        /// </summary>
        public string UserId { get; private set; }
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
        /// The name of the sound alert.
        /// </summary>
        public string AlertName { get; private set; }
        /// <summary>
        /// Gets an integer value indicating the number of Bits used.
        /// </summary>
        public int BitsUsed { get; private set; }

        internal SoundAlertsDetectedArgs(string? channelName, string? channelId, string? username, string? userDisplayName, string? userId, string? userColorHex, bool isSubscriber, bool isModerator, bool isBroadcaster, string? alertName, int bitsUsed) {
            ChannelName = channelName ?? string.Empty;
            ChannelId = channelId ?? string.Empty;
            Username = username ?? string.Empty;
            UserDisplayName = userDisplayName ?? string.Empty;
            UserId = userId ?? string.Empty;
            UserColorHex = userColorHex ?? string.Empty;
            IsSubscriber = isSubscriber;
            IsModerator = isModerator;
            IsBroadcaster = isBroadcaster;
            AlertName = alertName ?? string.Empty;
            BitsUsed = bitsUsed;
        }
    }
}