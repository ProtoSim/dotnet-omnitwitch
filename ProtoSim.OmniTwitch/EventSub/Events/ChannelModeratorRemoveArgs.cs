using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelModeratorRemove event.
	/// </summary>
	public class ChannelModeratorRemoveArgs : EventArgs {
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
		/// Gets the User's Id.
		/// </summary>
		public string UserId { get; set; } = string.Empty;
        /// <summary>
		/// Gets the User's Username.
		/// </summary>
		public string UserUsername { get; set; } = string.Empty;
        /// <summary>
		/// Gets the User's Display Name.
		/// </summary>
		public string UserDisplayName { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelModeratorRemoveArgs.
		/// </summary>
		public ChannelModeratorRemoveArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelModeratorRemoveArgs with the provided values.
		/// </summary>
		public ChannelModeratorRemoveArgs(string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string userId, string userUsername, string userDisplayName) {
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            UserId = userId;
            UserUsername = userUsername;
            UserDisplayName = userDisplayName;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}