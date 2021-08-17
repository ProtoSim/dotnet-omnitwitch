using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a StreamOffline event.
	/// </summary>
	public class StreamOfflineArgs : EventArgs {
        /// <summary>
		/// Gets the Broadcaster's User Id.
		/// </summary>
		public string BroadcasterUserId { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Broadcaster's Username.
		/// </summary>
		public string BroadcasterUsername { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Broadcaster's Display Name.
		/// </summary>
		public string BroadcasterDisplayName { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of StreamOfflineArgs.
		/// </summary>
		public StreamOfflineArgs() { }

        /// <summary>
		/// Creates a new instance of StreamOfflineArgs with the provided values.
		/// </summary>
		public StreamOfflineArgs(string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName) {
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}