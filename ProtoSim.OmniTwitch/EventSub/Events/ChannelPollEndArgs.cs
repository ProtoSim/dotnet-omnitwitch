using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelPollEnd event.
	/// </summary>
	public class ChannelPollEndArgs : EventArgs {
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
		public (string Id, string Title, int BitsVotes, int ChannelPointsVotes, int Votes) Choices = (string.Empty, string.Empty, 0, 0, 0);
		/// <summary>
		/// Gets the Bits Voting.
		/// </summary>
		public (bool IsEnabled, int AmountPerVote) BitsVoting;
		/// <summary>
		/// Gets the Channel Points Voting.
		/// </summary>
		public (bool IsEnabled, int AmountPerVote) ChannelPointsVoting;
		/// <summary>
		/// Gets the Status.
		/// </summary>
		public string Status { get; set; } = string.Empty;
        /// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Ended At.
		/// </summary>
		public string EndedAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelPollEndArgs.
		/// </summary>
		public ChannelPollEndArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelPollEndArgs with the provided values.
		/// </summary>
		public ChannelPollEndArgs(string pollId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string title, (string Id, string Title, int BitsVotes, int ChannelPointsVotes, int Votes) choices, (bool IsEnabled, int AmountPerVote) bitsVoting, (bool IsEnabled, int AmountPerVote) channelPointsVoting, string status, string startedAt, string endedAt) {
            PollId = pollId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Title = title;
            Choices = choices;
            BitsVoting = bitsVoting;
            ChannelPointsVoting = channelPointsVoting;
            Status = status;
            StartedAt = startedAt;
            EndedAt = endedAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}