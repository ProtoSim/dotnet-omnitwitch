using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a UserAuthorizationRevoke event.
	/// </summary>
	public class UserAuthorizationRevokeArgs : EventArgs {
		/// <summary>
		/// Gets the Client Id.
		/// </summary>
		public string ClientId { get; set; } = string.Empty;
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
		/// Creates a new default instance of UserAuthorizationRevokeArgs.
		/// </summary>
		public UserAuthorizationRevokeArgs() { }

		/// <summary>
		/// Creates a new instance of UserAuthorizationRevokeArgs with the provided values.
		/// </summary>
		public UserAuthorizationRevokeArgs(string clientId, string userId, string userUsername, string userDisplayName) {
			ClientId = clientId;
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