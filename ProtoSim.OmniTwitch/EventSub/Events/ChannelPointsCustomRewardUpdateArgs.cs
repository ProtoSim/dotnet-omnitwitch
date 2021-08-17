using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelPointsCustomRewardUpdate event.
	/// </summary>
	public class ChannelPointsCustomRewardUpdateArgs : EventArgs {
        /// <summary>
		/// Gets the Reward Id.
		/// </summary>
		public string RewardId { get; set; } = string.Empty;
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
		/// Gets a boolean value indicating if it Is Enabled.
		/// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
		/// Gets a boolean value indicating if it Is Paused.
		/// </summary>
        public bool IsPaused { get; set; }
        /// <summary>
		/// Gets a boolean value indicating if it Is In Stock.
		/// </summary>
        public bool IsInStock { get; set; }
        /// <summary>
		/// Gets the Reward Title.
		/// </summary>
        public string RewardTitle { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Reward Cost.
		/// </summary>
        public int RewardCost { get; set; }
        /// <summary>
		/// Gets the Reward Prompt.
		/// </summary>
        public string RewardPrompt { get; set; } = string.Empty;
        /// <summary>
		/// Gets a boolean value indicating if User Input Is Required.
		/// </summary>
        public bool IsUserInputRequired { get; set; }
        /// <summary>
		/// Gets a boolean value indicating if Redemptions Should Skip Request Queue.
		/// </summary>
        public bool ShouldRedemptionsSkipRequestQueue { get; set; }
        /// <summary>
		/// Gets the Max Per Stream.
		/// </summary>
        public (bool IsEnabled, int Value) MaxPerStream;
        /// <summary>
		/// Gets the Max Per User Per Stream.
		/// </summary>
        public (bool IsEnabled, int Value) MaxPerUserPerStream;
        /// <summary>
		/// Gets the Background Color.
		/// </summary>
        public string BackgroundColor { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Image.
		/// </summary>
        public (string Url1x, string Url2x, string Url4x) Image = (string.Empty, string.Empty, string.Empty);
        /// <summary>
		/// Gets the Default Image.
		/// </summary>
        public (string Url1x, string Url2x, string Url4x) DefaultImage = (string.Empty, string.Empty, string.Empty);
        /// <summary>
		/// Gets the Global Cooldown.
		/// </summary>
        public (bool IsEnabled, int Seconds) GlobalCooldown;
        /// <summary>
        /// Gets the string representation of Cooldown Expires At.
        /// </summary>
        public string CooldownExpiresAt { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Redemptions Redeemed Current Stream.
		/// </summary>
        public string RedemptionsRedeemedCurrentStream { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelPointsCustomRewardUpdateArgs.
		/// </summary>
		public ChannelPointsCustomRewardUpdateArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelPointsCustomRewardUpdateArgs with the provided values.
		/// </summary>
		public ChannelPointsCustomRewardUpdateArgs(string rewardId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, bool isEnabled, bool isPaused, bool isInStock, string rewardTitle, int rewardCost, string rewardPrompt, bool isUserInputRequired, bool shouldRedemptionsSkipRequestQueue, (bool IsEnabled, int Value) maxPerStream, (bool IsEnabled, int Value) maxPerUserPerStream, string backgroundColor, (string Url1x, string Url2x, string Url4x) image, (string Url1x, string Url2x, string Url4x) defaultImage, (bool IsEnabled, int Seconds) globalCooldown, string cooldownExpiresAt, string redemptionsRedeemedCurrentStream) {
            RewardId = rewardId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            IsEnabled = isEnabled;
            IsPaused = isPaused;
            IsInStock = isInStock;
            RewardTitle = rewardTitle;
            RewardCost = rewardCost;
            RewardPrompt = rewardPrompt;
            IsUserInputRequired = isUserInputRequired;
            ShouldRedemptionsSkipRequestQueue = shouldRedemptionsSkipRequestQueue;
            MaxPerStream = maxPerStream;
            MaxPerUserPerStream = maxPerUserPerStream;
            BackgroundColor = backgroundColor;
            Image = image;
            DefaultImage = defaultImage;
            GlobalCooldown = globalCooldown;
            CooldownExpiresAt = cooldownExpiresAt;
            RedemptionsRedeemedCurrentStream = redemptionsRedeemedCurrentStream;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}