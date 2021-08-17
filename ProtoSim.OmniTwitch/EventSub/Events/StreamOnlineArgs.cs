using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a StreamOnline event.
	/// </summary>
	public class StreamOnlineArgs : EventArgs {
        /// <summary>
		/// Gets the Stream Id.
		/// </summary>
		public string StreamId { get; set; } = string.Empty;
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
		/// Gets the Type.
		/// </summary>
		public string Type { get; set; } = string.Empty;
        /// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of StreamOnlineArgs.
		/// </summary>
		public StreamOnlineArgs() { }

        /// <summary>
		/// Creates a new instance of StreamOnlineArgs with the provided values.
		/// </summary>
		public StreamOnlineArgs(string streamId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string type, string startedAt) {
            StreamId = streamId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Type = type;
            StartedAt = startedAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}