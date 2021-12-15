using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelPollBegin event.
	/// </summary>
	public class ChannelPollBeginArgs : EventArgs {
		/// <summary>
		/// Gets the Poll Id.
		/// </summary>
		public string PollId { get; set; } = string.Empty;
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
		/// Gets the Title.
		/// </summary>
		public string Title { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Choices.
		/// </summary>
		public List<(string Id, string Title, int BitsVotes, int ChannelPointsVotes, int Votes)> Choices = new();
		/// <summary>
		/// Gets the Bits Is Enabled.
		/// </summary>
		public bool BitsVotingIsEnabled { get; set; }
		/// <summary>
		/// Gets the Bits Amount Per Vote.
		/// </summary>
		public int BitsVotingAmountPerVote { get; set; }
		/// <summary>
		/// Gets the Channel Points Voting Is Enabled.
		/// </summary>
		public bool ChannelPointsVotingIsEnabled;
		/// <summary>
		/// Gets the Channel Points Voting Amount Per Vote.
		/// </summary>
		public int ChannelPointsVotingAmountPerVote;
		/// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Ends At.
		/// </summary>
		public string EndsAt { get; set; } = string.Empty;

		/// <summary>
		/// Creates a new default instance of ChannelPollBeginArgs.
		/// </summary>
		public ChannelPollBeginArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelPollBeginArgs with the provided values.
		/// </summary>
		public ChannelPollBeginArgs(string pollId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string title, List<(string Id, string Title, int BitsVotes, int ChannelPointsVotes, int Votes)> choices, bool bitsVotingIsEnabled, int bitsVotingAmountPerVote, bool channelPointsVotingIsEnabled, int channelPointsVotingAmountPerVote, string startedAt, string endsAt) {
			PollId = pollId;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			Title = title;
			Choices = choices;
			BitsVotingIsEnabled = bitsVotingIsEnabled;
			BitsVotingAmountPerVote = bitsVotingAmountPerVote;
			ChannelPointsVotingIsEnabled = channelPointsVotingIsEnabled;
			ChannelPointsVotingAmountPerVote = channelPointsVotingAmountPerVote;
			StartedAt = startedAt;
			EndsAt = endsAt;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}