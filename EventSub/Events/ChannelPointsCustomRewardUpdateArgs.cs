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
		/// Gets the Max Per Stream Is Enabled.
		/// </summary>
        public bool MaxPerStreamIsEnabled;
        /// <summary>
		/// Gets the Max Per Stream Value.
		/// </summary>
        public int MaxPerStreamValue;
        /// <summary>
		/// Gets the Max Per User Per Stream IsEnabled.
		/// </summary>
        public bool MaxPerUserPerStreamIsEnabled;
        /// <summary>
		/// Gets the Max Per User Per Stream Value.
		/// </summary>
        public int MaxPerUserPerStreamValue;
        /// <summary>
		/// Gets the Background Color.
		/// </summary>
        public string BackgroundColor { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Image Url1x.
		/// </summary>
        public string ImageUrl1x { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Image Url2x.
		/// </summary>
        public string ImageUrl2x { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Image Url4x.
		/// </summary>
        public string ImageUrl4x { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Default Image Url1x.
		/// </summary>
        public string DefaultImageUrl1x { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Default Image Url2x.
		/// </summary>
        public string DefaultImageUrl2x { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Default Image Url4x.
		/// </summary>
        public string DefaultImageUrl4x { get; set; } = string.Empty;
        /// <summary>
		/// Gets the Global Cooldown Is Enabled.
		/// </summary>
        public bool GlobalCooldownIsEnabled;
        /// <summary>
		/// Gets the Global Cooldown Seconds.
		/// </summary>
        public int GlobalCooldownSeconds;
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
		public ChannelPointsCustomRewardUpdateArgs(string rewardId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, bool isEnabled, bool isPaused, bool isInStock, string rewardTitle, int rewardCost, string rewardPrompt, bool isUserInputRequired, bool shouldRedemptionsSkipRequestQueue, bool maxPerStreamIsEnabled, int maxPerStreamValue, bool maxPerUserPerStreamIsEnabled, int maxPerUserPerStreamValue, string backgroundColor, string imageUrl1x, string imageUrl2x, string imageUrl4x, string defaultImageUrl1x, string defaultImageUrl2x, string defaultImageUrl4x, bool globalCooldownIsEnabled, int globalCooldownSeconds, string cooldownExpiresAt, string redemptionsRedeemedCurrentStream) {
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
            MaxPerStreamIsEnabled = maxPerStreamIsEnabled;
            MaxPerStreamValue = maxPerStreamValue;
            MaxPerUserPerStreamIsEnabled = maxPerUserPerStreamIsEnabled;
            MaxPerUserPerStreamValue = maxPerUserPerStreamValue;
            BackgroundColor = backgroundColor;
            ImageUrl1x = imageUrl1x;
            ImageUrl2x = imageUrl2x;
            ImageUrl4x = imageUrl4x;
            DefaultImageUrl1x = defaultImageUrl1x;
            DefaultImageUrl2x = defaultImageUrl2x;
            DefaultImageUrl4x = defaultImageUrl4x;
            GlobalCooldownIsEnabled = globalCooldownIsEnabled;
            GlobalCooldownSeconds = globalCooldownSeconds;
            CooldownExpiresAt = cooldownExpiresAt;
            RedemptionsRedeemedCurrentStream = redemptionsRedeemedCurrentStream;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}