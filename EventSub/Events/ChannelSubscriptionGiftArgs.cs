using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelSubscriptionGift event.
	/// </summary>
	public class ChannelSubscriptionGiftArgs : EventArgs {
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
		/// Gets the Total.
		/// </summary>
		public int Total { get; set; }
		/// <summary>
		/// Gets the Tier.
		/// </summary>
		public string Tier { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Cumulative Total.
		/// </summary>
		public int CumulativeTotal { get; set; }
		/// <summary>
		/// Gets a boolean value indicating if it Is Anonymous.
		/// </summary>
		public bool IsAnonymous { get; set; }

		/// <summary>
		/// Creates a new default instance of ChannelSubscriptionGiftArgs.
		/// </summary>
		public ChannelSubscriptionGiftArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelSubscriptionGiftArgs with the provided values.
		/// </summary>
		public ChannelSubscriptionGiftArgs(string userId, string userUsername, string userDisplayName, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, int total, string tier, int cumulativeTotal, bool isAnonymous) {
			UserId = userId;
			UserUsername = userUsername;
			UserDisplayName = userDisplayName;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			Total = total;
			Tier = tier;
			CumulativeTotal = cumulativeTotal;
			IsAnonymous = isAnonymous;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}