using System;

namespace ProtoSim.OmniTwitch {
    /// <summary>
    /// Provides a set of parameters related to a client part event.
    /// </summary>
    public class ClientPartedArgs : EventArgs {
        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        public string ChannelName { get; private set; }

        internal ClientPartedArgs(string? channelName) {
            ChannelName = channelName ?? string.Empty;
        }
    }
}