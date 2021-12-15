namespace ProtoSim.OmniTwitch {
    /// <summary>
    /// Provides a set of parameters related to a client join event.
    /// </summary>
    public class ClientJoinedArgs : EventArgs {
        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        public string ChannelName { get; private set; }

        internal ClientJoinedArgs(string? channelName) {
            ChannelName = channelName ?? string.Empty;
        }
    }
}