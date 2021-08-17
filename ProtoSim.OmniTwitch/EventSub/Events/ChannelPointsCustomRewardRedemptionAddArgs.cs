using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelPointsCustomRewardRedemptionAdd event.
	/// </summary>
	public class ChannelPointsCustomRewardRedemptionAddArgs : EventArgs {
        /// <summary>
		/// Gets the Redemption Id.
		/// </summary>
		public string RedemptionId { get; set; } = string.Empty;
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
		/// Gets the User Input.
		/// </summary>
		public string UserInput { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Status.
		/// </summary>
		public string Status { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Reward.
		/// </summary>
		public (string Id, string Title, int Cost, string Prompt) Reward = (string.Empty, string.Empty, 0, string.Empty);
		/// <summary>
		/// Gets the string representation of Redeemed At.
		/// </summary>
		public string RedeemedAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelPointsCustomRewardRedemptionAddArgs.
		/// </summary>
		public ChannelPointsCustomRewardRedemptionAddArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelPointsCustomRewardRedemptionAddArgs with the provided values.
		/// </summary>
		public ChannelPointsCustomRewardRedemptionAddArgs(string redemptionId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string userId, string userUsername, string userDisplayName, string userInput, string status, (string Id, string Title, int Cost, string Prompt) reward, string redeemedAt) {
            RedemptionId = redemptionId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            UserId = userId;
            UserUsername = userUsername;
            UserDisplayName = userDisplayName;
            UserInput = userInput;
            Status = status;
            Reward = reward;
            RedeemedAt = redeemedAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}