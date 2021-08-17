using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelSubscriptionEnd event.
	/// </summary>
	public class ChannelSubscriptionEndArgs : EventArgs {
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
		/// Gets the Tier.
		/// </summary>
		public string Tier { get; set; } = string.Empty;
		/// <summary>
		/// Gets a boolean value indicating if it Is Gift.
		/// </summary>
		public bool IsGift { get; set; }

        /// <summary>
		/// Creates a new default instance of ChannelSubscriptionEndArgs.
		/// </summary>
		public ChannelSubscriptionEndArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelSubscriptionEndArgs with the provided values.
		/// </summary>
		public ChannelSubscriptionEndArgs(string userId, string userUsername, string userDisplayName, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string tier, bool isGift) {
            UserId = userId;
            UserUsername = userUsername;
            UserDisplayName = userDisplayName;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Tier = tier;
            IsGift = isGift;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}