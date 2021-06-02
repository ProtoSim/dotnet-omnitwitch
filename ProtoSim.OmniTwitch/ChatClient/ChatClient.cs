using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using WebSocketSharp;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace ProtoSim.OmniTwitch {
    /// <summary>
    /// Provides a set of methods and events to interact with the Twitch IRC service.
    /// </summary>
    public class ChatClient : IDisposable {
        /// <summary>
        /// Occurs when the client connects.
        /// </summary>
        public EventHandler<ClientConnectedArgs>? Connected;
        /// <summary>
        /// Occurs when the client disconnects.
        /// </summary>
        public EventHandler<ClientDisconnectedArgs>? Disconnected;
        /// <summary>
        /// Occurs when the client joins a channel.
        /// </summary>
        public EventHandler<ClientJoinedArgs>? ClientJoined;
        /// <summary>
        /// Occurs when the client parts a channel.
        /// </summary>
        public EventHandler<ClientPartedArgs>? ClientParted;
        /// <summary>
        /// Occurs when a user joins a channel the client is in.
        /// </summary>
        public EventHandler<UserJoinedArgs>? UserJoined;
        /// <summary>
        /// Occurs when a user parts a channel the client is in.
        /// </summary>
        public EventHandler<UserPartedArgs>? UserParted;
        /// <summary>
        /// Occurs when a user sends a message to a channel the client is in.
        /// </summary>
        public EventHandler<ChatMessageArgs>? ChatMessage;
        /// <summary>
        /// Occurs when a user sends a command message to a channel the client is in.
        /// </summary>
        public EventHandler<ChatCommandArgs>? ChatCommand;
        
        /// <summary>
        /// Gets the nickname used by the client.
        /// </summary>
        public string Nickname { get; private init; } = string.Empty;
        /// <summary>
        /// Gets the token used by the client.
        /// </summary>
        public string Token { get; private init; } = string.Empty;
        /// <summary>
        /// Gets or sets the command identifier recognized by the client.
        /// </summary>
        public char CommandIdentifier { get; set; } = '!';
        /// <summary>
        /// Gets a boolean value indicating whether the client is connected.
        /// </summary>
        public bool IsConnected { get; private set; } = false;
        /// <summary>
        /// Gets the last message sent by the client.
        /// </summary>
        public string? LastMessageSent { get; private set; } = null;
        /// <summary>
        /// Gets a list of channel names the client is in.
        /// </summary>
        public List<string> Channels { get { return _channels.Select(i => i.Key).ToList(); } }
        /// <summary>
        /// Gets a list of usernames in the channels the client is in.
        /// </summary>
        public List<(string channelName, string username)> Users {
            get {
                var list = new List<(string, string)>();

                foreach (var user in _users)
                    list.Add((user.Key[0..user.Key.IndexOf('—')], user.Key[(user.Key.IndexOf('—') + 1)..]));

                return list;
            }
        }

        private WebSocket? socket;
        private static readonly string _socketUrl = "wss://irc-ws.chat.twitch.tv:443";
        private readonly Timer _timerPing = new Timer(1000 * 60 * 5) { AutoReset = true, Enabled = false };
        private readonly ConcurrentDictionary<string, string> _channels = new ConcurrentDictionary<string, string>();
        private readonly ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the ChatClient class, and sets the properties to the specified values.
        /// </summary>
        /// <param name="nickname">The nickname to use.</param>
        /// <param name="token">The token to use.</param>
        /// <param name="commandIdentifier">The command identifier character; default is '!'.</param>
        public ChatClient(string? nickname, string? token, char? commandIdentifier = '!') {
            if (string.IsNullOrEmpty(nickname))
                throw new ArgumentNullException(nameof(nickname), "Value cannot be null");

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token), "Value cannot be null");

            Nickname = nickname.ToLower();
            Token = token;
            CommandIdentifier = commandIdentifier ?? '!';
            _timerPing.Elapsed += TimerPing_OnElapsed;
        }

        /// <summary>
        /// Connects the client socket and starts raising events.
        /// </summary>
        public void Connect() {
            if (socket == null)
                socket = new WebSocket(_socketUrl);

            if (socket.IsAlive) {
                LogLine("Socket is already connected", LogLevel.Warn);
                return;
            }

            socket.OnOpen += Socket_OnOpen;
            socket.OnClose += Socket_OnClose;
            socket.OnError += Socket_OnError;
            socket.OnMessage += Socket_OnMessage;
            socket.Connect();
        }

        /// <summary>
        /// Disconnects the client socket and stops raising events.
        /// </summary>
        public void Disconnect() {
            if (socket == null) {
                LogLine($"Null {nameof(socket)}", LogLevel.Warn);
                return;
            }

            socket.Close();
            socket.OnOpen -= Socket_OnOpen;
            socket.OnClose -= Socket_OnClose;
            socket.OnError -= Socket_OnError;
            socket.OnMessage -= Socket_OnMessage;
            socket = null;
        }

        /// <summary>
        /// Joins the client to the specified channel.
        /// </summary>
        /// <param name="channelName">The name of the channel.</param>
        /// <returns>False if error.</returns>
        public bool JoinChannel(string? channelName) {
            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/empty {nameof(channelName)}", LogLevel.Warn);
                return false;
            }

            if (!SocketIsReady)
                return false;

            socket.Send($"JOIN #{channelName}");
            return true;
        }

        /// <summary>
        /// Joins the client to the specified channels.
        /// </summary>
        /// <param name="channelNames">The names of the channels.</param>
        /// <returns>False if error.</returns>
        public bool JoinChannels(List<string>? channelNames) {
            if (channelNames == null) {
                LogLine($"Null {nameof(channelNames)}", LogLevel.Warn);
                return false;
            }

            if (!SocketIsReady)
                return false;

            foreach (var channelName in channelNames) {
                if (string.IsNullOrEmpty(channelName)) {
                    LogLine($"Null/empty {nameof(channelName)}", LogLevel.Warn);
                    continue;
                }

                socket.Send($"JOIN #{channelName}");
            }

            return true;
        }

        /// <summary>
        /// Parts the client from the specified channel.
        /// </summary>
        /// <param name="channelName">The name of the channel.</param>
        /// <returns>False if error.</returns>
        public bool PartChannel(string? channelName) {
            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/empty {nameof(channelName)}", LogLevel.Warn);
                return false;
            }

            if (!SocketIsReady)
                return false;

            socket.Send($"PART #{channelName}");
            _channels.TryRemove(channelName, out _);
            ClientParted?.Invoke(this, new ClientPartedArgs(channelName));
            return true;
        }

        /// <summary>
        /// Parts the client from the specified channels.
        /// </summary>
        /// <param name="channelNames">The names of the channels.</param>
        /// <returns>False if error.</returns>
        public bool PartChannels(List<string>? channelNames) {
            if (channelNames == null) {
                LogLine($"Null {nameof(channelNames)}", LogLevel.Warn);
                return false;
            }

            if (!SocketIsReady)
                return false;

            foreach (var channelName in channelNames) {
                if (string.IsNullOrEmpty(channelName)) {
                    LogLine($"Null/empty {nameof(channelName)}", LogLevel.Warn);
                    continue;
                }

                socket.Send($"PART #{channelName}");
                _channels.TryRemove(channelName, out _);
                ClientParted?.Invoke(this, new ClientPartedArgs(channelName));
            }

            return true;
        }

        /// <summary>
        /// Gets a boolean value indicating whether the client is in the specified channel.
        /// </summary>
        /// <param name="channelName">The channel name</param>
        /// <returns>True if in channel</returns>
        public bool IsInChannel(string? channelName = null) {
            return GetValidChannelName(channelName) != null;
        }

        /// <summary>
        /// Sends the specified text as a message.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error</returns>
        public bool SendMessage(string? text, string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }
            
            if (string.IsNullOrEmpty(text)) {
                LogLine($"Null/emtpy {nameof(text)}", LogLevel.Error);
                return false;
            }

            if (!SocketIsReady)
                return false;

            LastMessageSent = text;

            while(text.Length > 500) {
                var subText = text[0..500];
                subText = subText[0..subText.LastIndexOf(' ')];
                text = text[subText.Length..];
                socket.Send($"PRIVMSG #{channelName} :{subText}");
            }

            socket.Send($"PRIVMSG #{channelName} :{text}");
            return true;
        }

        /// <summary>
        /// Sends the specified text as a whisper to the specified user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="message">The whisper text.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error</returns>
        public bool SendWhisper(string? username, string? message, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/empty {nameof(username)}", LogLevel.Warn);
                return false;
            }

            if (string.IsNullOrEmpty(message)) {
                LogLine($"Null/empty {nameof(message)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/w {username} {message}")) {
                LogLine($"Failed to send whisper: {username}, {message}", LogLevel.Error);
                return false;
            }

            LogLine($"Sent whisper: {username}, {message}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Bans the specified user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool BanUser(string? username, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/emtpy {nameof(username)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/ban {username}")) {
                LogLine($"Failed to ban user: {username}", LogLevel.Error);
                return false;
            }

            LogLine($"Banned user: {username}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Unbans the specified user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool UnbanUser(string? username, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/emtpy {nameof(username)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/unban {username}")) {
                LogLine($"Failed to unban user: {username}", LogLevel.Error);
                return false;
            }

            LogLine($"Unbanned user: {username}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Clears the chat.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool ClearChat(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/clear")) {
                LogLine("Failed to clear chat", LogLevel.Error);
                return false;
            }

            LogLine("Cleared chat", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Enables emote only mode.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool EnableEmoteOnly(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/emoteonly")) {
                LogLine("Failed to enable emote only", LogLevel.Error);
                return false;
            }

            LogLine("Enabled emote only", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Disables emote only mode.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool DisableEmoteOnly(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/emoteonlyoff")) {
                LogLine("Failed to disable emote only", LogLevel.Error);
                return false;
            }

            LogLine("Disabled emote only", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Initiates a host for the specified channel.
        /// </summary>
        /// <param name="channel">The name of the channel to host.</param>
        /// <param name="channelName">The name of the channel to host from; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool HostChannel(string? channel, string? channelName = null) {
            if (string.IsNullOrEmpty(channel)) {
                LogLine($"Null/emtpy {nameof(channel)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/host {channel}")) {
                LogLine($"Failed to host channel: {channel}", LogLevel.Error);
                return false;
            }

            LogLine($"Hosted channel: {channel}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Cancels a host for the specified channel.
        /// </summary>
        /// <param name="channel">The name of the channel to unhost.</param>
        /// <param name="channelName">The name of the channel to unhost from; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool UnhostChannel(string? channel, string? channelName = null) {
            if (string.IsNullOrEmpty(channel)) {
                LogLine($"Null/emtpy {nameof(channel)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/unhost {channel}")) {
                LogLine($"Failed to unhost channel: {channel}", LogLevel.Error);
                return false;
            }

            LogLine($"Unhosted channel: {channel}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Adds a stream marker with the specified description.
        /// </summary>
        /// <param name="description">The description text.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool AddStreamMarker(string? description, string? channelName = null) {
            if (string.IsNullOrEmpty(description)) {
                LogLine($"Null/emtpy {nameof(description)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/marker {description}")) {
                LogLine($"Failed to add stream marker: {description}", LogLevel.Error);
                return false;
            }

            LogLine($"Added stream marker: {description}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Adds the specified user as a moderator.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool ModUser(string? username, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/emtpy {nameof(username)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/mod {username}")) {
                LogLine($"Failed to mod user: {username}", LogLevel.Error);
                return false;
            }

            LogLine($"Modded user: {username}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Removes the specified user as a moderator.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool UnmodUser(string? username, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/emtpy {nameof(username)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/unmod {username}")) {
                LogLine($"Failed to unmod user: {username}", LogLevel.Error);
                return false;
            }

            LogLine($"Unmodded user: {username}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// List the moderators.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool ListMods(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/mods")) {
                LogLine("Failed to list mods", LogLevel.Error);
                return false;
            }

            LogLine("Listed mods", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Initiates a raid for the specified channel.
        /// </summary>
        /// <param name="channel">The name of the channel to raid.</param>
        /// <param name="channelName">The name of the channel to raid from; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool RaidChannel(string? channel, string? channelName = null) {
            if (string.IsNullOrEmpty(channel)) {
                LogLine($"Null/emtpy {nameof(channel)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/raid {channel}")) {
                LogLine($"Failed to raid channel: {channel}", LogLevel.Error);
                return false;
            }

            LogLine($"Raided channel: {channel}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Cancels a raid.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool CancelRaid(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/unraid")) {
                LogLine("Failed to cancel raid", LogLevel.Error);
                return false;
            }

            LogLine("Cancelled raid", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Enables slow mode for the specified time.
        /// </summary>
        /// <param name="seconds">The amount of time in seconds; default: 60.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool EnableSlowMode(int seconds = 60, string? channelName = null) {
            if (seconds <= 0 || seconds > int.MaxValue) {
                LogLine($"Invalid {nameof(seconds)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/slow {seconds}")) {
                LogLine($"Failed to enable slow mode: {seconds}", LogLevel.Error);
                return false;
            }

            LogLine($"Enabled slow mode: {seconds}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Disables slow mode.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool DisableSlowMode(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/slowoff")) {
                LogLine("Failed to disable slow mode", LogLevel.Error);
                return false;
            }

            LogLine("Disabled slow mode", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Enables subscriber only mode.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool EnableSubscribersOnly(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/subscribers")) {
                LogLine("Failed to enable subscribers only", LogLevel.Error);
                return false;
            }

            LogLine("Enabled subscribers only", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Disables subscriber only mode.
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool DisableSubscribersOnly(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/subscribersoff")) {
                LogLine("Failed to disable subscribers only", LogLevel.Error);
                return false;
            }

            LogLine("Disabled subscribers only", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Times out the specified user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="seconds">The amount of time in seconds; default: 600.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool TimeoutUser(string? username, int seconds = 600, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/empty {nameof(username)}", LogLevel.Warn);
                return false;
            }
            
            if (seconds <= 0 || seconds > int.MaxValue) {
                LogLine($"Invalid {nameof(seconds)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/timeout {username} {seconds}")) {
                LogLine($"Failed to timeout user: {username}, {seconds}", LogLevel.Error);
                return false;
            }

            LogLine($"Timed out user: {username}, {seconds}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Untimes out the specified user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool UntimeoutUser(string? username, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/emtpy {nameof(username)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/timeout {username} 1")) {
                LogLine($"Failed to untimeout user: {username}", LogLevel.Error);
                return false;
            }

            LogLine($"Untimed out user: {username}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// Adds the specified user as a VIP.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool VIPUser(string? username, string? channelName = null) {
            if (string.IsNullOrEmpty(username)) {
                LogLine($"Null/emtpy {nameof(username)}", LogLevel.Warn);
                return false;
            }

            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage($"/vip {username}")) {
                LogLine($"Failed to VIP user: {username}", LogLevel.Error);
                return false;
            }

            LogLine($"VIPed user: {username}", LogLevel.Info);
            return true;
        }

        /// <summary>
        /// List the VIPs
        /// </summary>
        /// <param name="channelName">The name of the channel; default: sole connected channel.</param>
        /// <returns>False if error.</returns>
        public bool ListVIPs(string? channelName = null) {
            channelName = GetValidChannelName(channelName);

            if (string.IsNullOrEmpty(channelName)) {
                LogLine($"Null/emtpy {nameof(channelName)}", LogLevel.Error);
                return false;
            }

            if (!SendMessage("/vips")) {
                LogLine("Failed to list VIPs", LogLevel.Error);
                return false;
            }

            LogLine("Listed VIPs", LogLevel.Info);
            return true;
        }

        private static void LogLine(string? text, LogLevel logLevel) {
            if (string.IsNullOrEmpty(text))
                return;

            Debug.WriteLine(text, logLevel.ToString());
        }

        private void TimerPing_OnElapsed(object sender, ElapsedEventArgs e) {
            LogLine("PING not received", LogLevel.Error);
            Disconnect();
            Connect();
        }

        [MemberNotNullWhen(true, nameof(socket))]
        private bool SocketIsReady {
            get {
                if (socket == null) {
                    LogLine($"Null {nameof(socket)}", LogLevel.Error);
                    return false;
                }

                if (!socket.IsAlive) {
                    LogLine("Socket is not connected", LogLevel.Error);
                    return false;
                }

                return true;
            }
        }

        private string? GetValidChannelName(string? channelName) {
            if (_channels.IsEmpty) {
                LogLine($"Emtpy {nameof(_channels)}", LogLevel.Warn);
                return null;
            }

            if (string.IsNullOrEmpty(channelName)) {
                if (_channels.Count > 1) {
                    LogLine("More than one Channel", LogLevel.Warn);
                    return null;
                }

                channelName = _channels.Values.ElementAt(0);
            }
            else
                _channels.TryGetValue(channelName, out channelName);

            return channelName;
        }

        private void Socket_OnOpen(object? sender, EventArgs e) {
            LogLine("Socket opened", LogLevel.Info);

            if (!SocketIsReady)
                return;

            socket.Send($"PASS oauth:{Token}");
            socket.Send($"NICK {Nickname}");
        }

        private void Socket_OnClose(object? sender, CloseEventArgs e) {
            if (e.WasClean)
                LogLine("Socket closed", LogLevel.Info);
            else
                LogLine($"Socket closed with error: [{e.Code}] {e.Reason}", LogLevel.Error);

            _timerPing.Stop();

            if (IsConnected) {
                IsConnected = false;
                Disconnected?.Invoke(this, new ClientDisconnectedArgs());
            }
        }

        private void Socket_OnError(object? sender, ErrorEventArgs e) {
            LogLine($"{e.Message}\n{e.Exception?.Message}", LogLevel.Error);
            Disconnect();
        }

        private void Socket_OnMessage(object? sender, MessageEventArgs e) {
            if (!SocketIsReady)
                return;

            if (string.IsNullOrEmpty(e.Data))
                return;

            var messages = e.Data.Trim().Split('\n').ToList();

            foreach (var item in messages) {
                var message = item.Trim();
                LogLine(message, LogLevel.Info);
                var tags = new Dictionary<string, string>();

                if (message.StartsWith("@")) {
                    var tagList = message[1..message.IndexOf(" ")].Split(";").ToList();

                    foreach (var tag in tagList) {
                        var tagDetails = tag.Split("=").ToList();

                        if (tagDetails.Count < 2)
                            continue;

                        tags.Add(tagDetails[0], tagDetails[1]);
                    }

                    foreach (var tag in tags)
                        LogLine(tag.ToString(), LogLevel.Info);

                    message = message[(message.IndexOf(" :") + 1)..];
                    LogLine(message, LogLevel.Info);
                }

                if (message.StartsWith(":tmi.twitch.tv 376")) {
                    socket.Send("CAP REQ :twitch.tv/membership twitch.tv/tags twitch.tv/commands\r\n");
                }
                else if (message.StartsWith(":tmi.twitch.tv CAP * ACK")) {
                    IsConnected = true;
                    Connected?.Invoke(this, new ClientConnectedArgs());
                }
                else if (Regex.IsMatch(message, @"^:\w+!\w+@\w+.tmi.twitch.tv.+")) {
                    var username = message[(message.IndexOf(':') + 1)..message.IndexOf('!')];
                    var messageType = message[(message.IndexOf(' ') + 1)..message.IndexOf(' ', message.IndexOf(' ') + 1)];
                    var channelName = string.Empty;

                    switch (messageType) {
                        case "JOIN":
                            channelName = message[(message.IndexOf('#') + 1)..];

                            if (username.Equals(Nickname)) {
                                if (_channels.TryAdd(channelName, channelName))
                                    ClientJoined?.Invoke(this, new ClientJoinedArgs(channelName));
                            }
                            else {
                                if (_users.TryAdd($"{username}—{channelName}", $"{username}—{channelName}"))
                                    UserJoined?.Invoke(this, new UserJoinedArgs(channelName, username));
                            }

                            break;

                        case "PART":
                            channelName = message[(message.IndexOf('#') + 1)..];

                            if (username.Equals(Nickname)) {
                                _channels.TryRemove(channelName, out _);
                                ClientParted?.Invoke(this, new ClientPartedArgs(channelName));
                            }
                            else {
                                _users.TryRemove($"{username}—{channelName}", out _);
                                UserParted?.Invoke(this, new UserPartedArgs(channelName, username));
                            }

                            break;

                        case "PRIVMSG":
                            channelName = message[(message.IndexOf('#') + 1)..message.IndexOf(' ', message.IndexOf('#') + 1)];
                            var userMessage = message[(message.IndexOf(" :") + 2)..];

                            if (userMessage.StartsWith(CommandIdentifier)) {
                                if (userMessage.Contains(' '))
                                    ChatCommand?.Invoke(this, new ChatCommandArgs(channelName, tags.GetValueOrDefault("room-id"), username, tags.GetValueOrDefault("display-name"), tags.GetValueOrDefault("user-id"), tags.GetValueOrDefault("color"), tags.GetValueOrDefault("subscriber")?.Equals("1") ?? tags.GetValueOrDefault("badges")?.Contains("subscriber") ?? false, tags.GetValueOrDefault("mod")?.Equals("1") ?? tags.GetValueOrDefault("user-type")?.Contains("mod") ?? false, username.Equals(channelName), tags.GetValueOrDefault("id"), userMessage, userMessage[1..], userMessage[userMessage.IndexOf(' ')..].Split(' ').ToList()));
                                else
                                    ChatCommand?.Invoke(this, new ChatCommandArgs(channelName, tags.GetValueOrDefault("room-id"), username, tags.GetValueOrDefault("display-name"), tags.GetValueOrDefault("user-id"), tags.GetValueOrDefault("color"), tags.GetValueOrDefault("subscriber")?.Equals("1") ?? tags.GetValueOrDefault("badges")?.Contains("subscriber") ?? false, tags.GetValueOrDefault("mod")?.Equals("1") ?? tags.GetValueOrDefault("user-type")?.Contains("mod") ?? false, username.Equals(channelName), tags.GetValueOrDefault("id"), userMessage, userMessage[1..], null));
                            }
                            else
                                ChatMessage?.Invoke(this, new ChatMessageArgs(channelName, tags.GetValueOrDefault("room-id"), username, tags.GetValueOrDefault("display-name"), tags.GetValueOrDefault("user-id"), tags.GetValueOrDefault("color"), tags.GetValueOrDefault("subscriber")?.Equals("1") ?? tags.GetValueOrDefault("badges")?.Contains("subscriber") ?? false, tags.GetValueOrDefault("mod")?.Equals("1") ?? tags.GetValueOrDefault("user-type")?.Contains("mod") ?? false, username.Equals(channelName), tags.GetValueOrDefault("id"), userMessage));

                            break;

                        default:
                            LogLine($"Unhandled type: {messageType}", LogLevel.Warn);
                            break;
                    }
                }
                else if (message.StartsWith("PING") || e.IsPing) {
                    socket.Send("PONG\r\n");
                    _timerPing.Stop();
                    _timerPing.Start();
                }
            }
        }

        /// <summary>
        /// Disposes the client socket
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    Disconnect();
                    _timerPing.Elapsed -= TimerPing_OnElapsed;
                    _timerPing.Dispose();
                }

                socket = null;
                disposedValue = true;
            }
        }

        /// <summary>
        /// Initiates the client disposal.
        /// </summary>
        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}