using System;

namespace ProtoSim.OmniTwitch {
    /// <summary>
    /// Provides a set of parameters related to a user join event.
    /// </summary>
    public class UserJoinedArgs : EventArgs {
        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        public string ChannelName { get; private set; }
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Username { get; private set; }

        internal UserJoinedArgs(string? channelName, string? username) {
            ChannelName = channelName ?? string.Empty;
            Username = username ?? string.Empty;
        }
    }
}