﻿using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelUnban event.
	/// </summary>
	public class ChannelUnbanArgs : EventArgs {
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
		/// Gets the Moderator's User Id.
		/// </summary>
		public string ModeratorUserId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Moderator's Username.
		/// </summary>
		public string ModeratorUsername { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Moderator's Display Name.
		/// </summary>
		public string ModeratorDisplayName { get; set; } = string.Empty;

		/// <summary>
		/// Creates a new default instance of ChannelUnbanArgs.
		/// </summary>
		public ChannelUnbanArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelUnbanArgs with the provided values.
		/// </summary>
		public ChannelUnbanArgs(string userId, string userUsername, string userDisplayName, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string moderatorUserId, string moderatorUsername, string moderatorDisplayName) {
			UserId = userId;
			UserUsername = userUsername;
			UserDisplayName = userDisplayName;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			ModeratorUserId = moderatorUserId;
			ModeratorUsername = moderatorUsername;
			ModeratorDisplayName = moderatorDisplayName;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}