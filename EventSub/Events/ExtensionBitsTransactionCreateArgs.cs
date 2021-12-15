using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ExtensionBitsTransactionCreate event.
	/// </summary>
	public class ExtensionBitsTransactionCreateArgs : EventArgs {
		/// <summary>
		/// Gets the ExtensionClient Id.
		/// </summary>
		public string ExtensionClientId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Transaction Id.
		/// </summary>
		public string TransactionId { get; set; } = string.Empty;
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
		/// Gets the Product Name.
		/// </summary>
		public string ProductName { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Product Bits.
		/// </summary>
		public int ProductBits { get; set; }
		/// <summary>
		/// Gets the Product Sku.
		/// </summary>
		public string ProductSku { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Product InDevelopment.
		/// </summary>
		public bool ProductInDevelopment { get; set; }

		/// <summary>
		/// Creates a new default instance of ExtensionBitsTransactionCreateArgs.
		/// </summary>
		public ExtensionBitsTransactionCreateArgs() { }

		/// <summary>
		/// Creates a new instance of ExtensionBitsTransactionCreateArgs with the provided values.
		/// </summary>
		public ExtensionBitsTransactionCreateArgs(string extensionClientId, string transactionId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string userId, string userUsername, string userDisplayName, string productName, int productBits, string productSku, bool productInDevelopment) {
			ExtensionClientId = extensionClientId;
			TransactionId = transactionId;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			UserId = userId;
			UserUsername = userUsername;
			UserDisplayName = userDisplayName;
			ProductName = productName;
			ProductBits = productBits;
			ProductSku = productSku;
			ProductInDevelopment = productInDevelopment;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}