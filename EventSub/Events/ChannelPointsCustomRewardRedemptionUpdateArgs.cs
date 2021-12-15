using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelPointsCustomRewardRedemptionUpdate event.
	/// </summary>
	public class ChannelPointsCustomRewardRedemptionUpdateArgs : EventArgs {
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
		/// Gets the Reward Id.
		/// </summary>
		public string RewardId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Reward Title.
		/// </summary>
		public string RewardTitle { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Reward Cost.
		/// </summary>
		public int RewardCost { get; set; } = 0;
		/// <summary>
		/// Gets the Reward Prompt.
		/// </summary>
		public string RewardPrompt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Redeemed At.
		/// </summary>
		public string RedeemedAt { get; set; } = string.Empty;

		/// <summary>
		/// Creates a new default instance of ChannelPointsCustomRewardRedemptionUpdateArgs.
		/// </summary>
		public ChannelPointsCustomRewardRedemptionUpdateArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelPointsCustomRewardRedemptionUpdateArgs with the provided values.
		/// </summary>
		public ChannelPointsCustomRewardRedemptionUpdateArgs(string redemptionId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string userId, string userUsername, string userDisplayName, string userInput, string status, string rewardId, string rewardTitle, int rewardCost, string rewardPrompt, string redeemedAt) {
			RedemptionId = redemptionId;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			UserId = userId;
			UserUsername = userUsername;
			UserDisplayName = userDisplayName;
			UserInput = userInput;
			Status = status;
			RewardId = rewardId;
			RewardTitle = rewardTitle;
			RewardCost = rewardCost;
			RewardPrompt = rewardPrompt;
			RedeemedAt = redeemedAt;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}