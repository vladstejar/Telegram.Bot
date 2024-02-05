using System.Collections.Generic;
using System.Linq;
#if !NET8_0_OR_GREATER
using Newtonsoft.Json.Converters;
#endif
using Telegram.Bot.Converters;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Passport;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a message.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Message
{
    /// <summary>
    /// Unique message identifier inside this chat
    /// </summary>
    [DataMember(IsRequired = true)]
    public int MessageId { get; set; }

    /// <summary>
    /// Optional. Unique identifier of a message thread to which the message belongs; for supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Optional. Sender, empty for messages sent to channels
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User? From { get; set; }

    /// <summary>
    /// Optional. Sender of the message, sent on behalf of a chat. The channel itself for channel messages.
    /// The supergroup itself for messages from anonymous group administrators. The linked channel for messages
    /// automatically forwarded to the discussion group
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Chat? SenderChat { get; set; }

    /// <summary>
    /// Date the message was sent
    /// </summary>
    [DataMember(IsRequired = true)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime Date { get; set; }

    /// <summary>
    /// Conversation the message belongs to
    /// </summary>
    [DataMember(IsRequired = true)]
    public Chat Chat { get; set; } = default!;

    /// <summary>
    /// Optional. For forwarded messages, sender of the original message
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User? ForwardFrom { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the message is sent to a forum topic
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? IsTopicMessage { get; set; }

    /// <summary>
    /// Optional. For messages forwarded from channels or from anonymous administrators, information about the
    /// original sender chat
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Chat? ForwardFromChat { get; set; }

    /// <summary>
    /// Optional. For messages forwarded from channels, identifier of the original message in the channel
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? ForwardFromMessageId { get; set; }

    /// <summary>
    /// Optional. For messages forwarded from channels, signature of the post author if present
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? ForwardSignature { get; set; }

    /// <summary>
    /// Optional. Sender's name for messages forwarded from users who disallow adding a link to their account in
    /// forwarded messages
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? ForwardSenderName { get; set; }

    /// <summary>
    /// Optional. For forwarded messages, date the original message was sent
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? ForwardDate { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the message is a channel post that was automatically forwarded to the connected
    /// discussion group
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? IsAutomaticForward { get; set; }

    /// <summary>
    /// Optional. For replies, the original message. Note that the <see cref="Message"/> object in this field
    /// will not contain further <see cref="ReplyToMessage"/> fields even if it itself is a reply.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Message? ReplyToMessage { get; set; }

    /// <summary>
    /// Optional. Bot through which the message was sent
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User? ViaBot { get; set; }

    /// <summary>
    /// Optional. Date the message was last edited
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if messages from the chat can't be forwarded to other chats.
    /// Returned only in <see cref="Requests.GetChatRequest"/>.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HasProtectedContent { get; set; }

    /// <summary>
    /// Optional. The unique identifier of a media message group this message belongs to
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? MediaGroupId { get; set; }

    /// <summary>
    /// Optional. Signature of the post author for messages in channels, or the custom title of an anonymous
    /// group administrator
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? AuthorSignature { get; set; }

    /// <summary>
    /// Optional. For text messages, the actual text of the message, 0-4096 characters
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Text { get; set; }

    /// <summary>
    /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear
    /// in the text
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? Entities { get; set; }

    /// <summary>
    /// Gets the entity values.
    /// </summary>
    /// <value>
    /// The entity contents.
    /// </value>
    public IEnumerable<string>? EntityValues =>
        Text is null
            ? default
            : Entities?.Select(entity => Text.Substring(entity.Offset, entity.Length));

    /// <summary>
    /// Optional. Message is an animation, information about the animation. For backward compatibility, when this
    /// field is set, the <see cref="Document"/> field will also be set
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Animation? Animation { get; set; }

    /// <summary>
    /// Optional. Message is an audio file, information about the file
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Audio? Audio { get; set; }

    /// <summary>
    /// Optional. Message is a general file, information about the file
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Document? Document { get; set; }

    /// <summary>
    /// Optional. Message is a photo, available sizes of the photo
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public PhotoSize[]? Photo { get; set; }

    /// <summary>
    /// Optional. Message is a sticker, information about the sticker
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Sticker? Sticker { get; set; }

    /// <summary>
    /// Optional. Message is a forwarded story
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Story? Story { get; set; }

    /// <summary>
    /// Optional. Message is a video, information about the video
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Video? Video { get; set; }

    /// <summary>
    /// Optional. Message is a video note, information about the video message
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public VideoNote? VideoNote { get; set; }

    /// <summary>
    /// Optional. Message is a voice message, information about the file
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Voice? Voice { get; set; }

    /// <summary>
    /// Optional. Caption for the animation, audio, document, photo, video or voice, 0-1024 characters
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <summary>
    /// Optional. For messages with a caption, special entities like usernames, URLs, bot commands, etc. that
    /// appear in the caption
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary>
    /// Gets the caption entity values.
    /// </summary>
    /// <value>
    /// The caption entity contents.
    /// </value>
    public IEnumerable<string>? CaptionEntityValues =>
        Caption is null
            ? default
            : CaptionEntities?.Select(entity => Caption.Substring(entity.Offset, entity.Length));

    /// <summary>
    /// Optional. <see langword="true"/>, if the message media is covered by a spoiler animation
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HasMediaSpoiler { get; set; }

    /// <summary>
    /// Optional. Message is a shared contact, information about the contact
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Contact? Contact { get; set; }

    /// <summary>
    /// Optional. Message is a dice with random value
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Dice? Dice { get; set; }

    /// <summary>
    ///Optional. Message is a game, information about the game
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Game? Game { get; set; }

    /// <summary>
    /// Optional. Message is a native poll, information about the poll
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Poll? Poll { get; set; }

    /// <summary>
    /// Optional. Message is a venue, information about the venue. For backward compatibility, when this field
    /// is set, the <see cref="Location"/> field will also be set
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Venue? Venue { get; set; }

    /// <summary>
    /// Optional. Message is a shared location, information about the location
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Location? Location { get; set; }

    /// <summary>
    /// Optional. New members that were added to the group or supergroup and information about them
    /// (the bot itself may be one of these members)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User[]? NewChatMembers { get; set; }

    /// <summary>
    /// Optional. A member was removed from the group, information about them (this member may be the bot itself)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User? LeftChatMember { get; set; }

    /// <summary>
    /// Optional. A chat title was changed to this value
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? NewChatTitle { get; set; }

    /// <summary>
    /// Optional. A chat photo was change to this value
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public PhotoSize[]? NewChatPhoto { get; set; }

    /// <summary>
    /// Optional. Service message: the chat photo was deleted
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? DeleteChatPhoto { get; set; }

    /// <summary>
    /// Optional. Service message: the group has been created
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? GroupChatCreated { get; set; }

    /// <summary>
    /// Optional. Service message: the supergroup has been created. This field can't be received in a message
    /// coming through updates, because bot can't be a member of a supergroup when it is created. It can only be
    /// found in <see cref="ReplyToMessage"/> if someone replies to a very first message in a directly created
    /// supergroup.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? SupergroupChatCreated { get; set; }

    /// <summary>
    /// Optional. Service message: the channel has been created. This field can't be received in a message coming
    /// through updates, because bot can't be a member of a channel when it is created. It can only be found in
    /// <see cref="ReplyToMessage"/> if someone replies to a very first message in a channel.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? ChannelChatCreated { get; set; }

    /// <summary>
    /// Optional. Service message: auto-delete timer settings changed in the chat
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public MessageAutoDeleteTimerChanged? MessageAutoDeleteTimerChanged { get; set; }

    /// <summary>
    /// Optional. The group has been migrated to a supergroup with the specified identifier
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public long? MigrateToChatId { get; set; }

    /// <summary>
    /// Optional. The supergroup has been migrated from a group with the specified identifier
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public long? MigrateFromChatId { get; set; }

    /// <summary>
    /// Optional. Specified message was pinned. Note that the Message object in this field will not contain
    /// further <see cref="ReplyToMessage"/> fields even if it is itself a reply.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Message? PinnedMessage { get; set; }

    /// <summary>
    /// Optional. Message is an invoice for a
    /// <a href="https://core.telegram.org/bots/api#payments">payment</a>, information about the invoice
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Invoice? Invoice { get; set; }

    /// <summary>
    /// Optional. Message is a service message about a successful payment, information about the payment
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public SuccessfulPayment? SuccessfulPayment { get; set; }

    /// <summary>
    /// Optional. Service message: a user was shared with the bot
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public UserShared? UserShared { get; set; }

    /// <summary>
    /// Optional. Service message: a chat was shared with the bot
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ChatShared? ChatShared { get; set; }

    /// <summary>
    /// Optional. The domain name of the website on which the user has logged in
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? ConnectedWebsite { get; set; }

    /// <summary>
    /// Optional. Service message: the user allowed the bot added to the attachment menu to write messages
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public WriteAccessAllowed? WriteAccessAllowed { get; set; }

    /// <summary>
    /// Optional. Telegram Passport data
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public PassportData? PassportData { get; set; }

    /// <summary>
    /// Optional. Service message. A user in the chat triggered another user's proximity alert while
    /// sharing Live Location
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ProximityAlertTriggered? ProximityAlertTriggered { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic created
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ForumTopicCreated? ForumTopicCreated { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic edited
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ForumTopicEdited? ForumTopicEdited { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic closed
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ForumTopicClosed? ForumTopicClosed { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic reopened
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ForumTopicReopened? ForumTopicReopened { get; set; }

    /// <summary>
    /// Optional. Service message: the 'General' forum topic hidden
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public GeneralForumTopicHidden? GeneralForumTopicHidden { get; set; }

    /// <summary>
    /// Optional. Service message: the 'General' forum topic unhidden
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public GeneralForumTopicUnhidden? GeneralForumTopicUnhidden { get; set; }

    /// <summary>
    /// Optional. Service message: video chat scheduled
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public VideoChatScheduled? VideoChatScheduled { get; set; }

    /// <summary>
    /// Optional. Service message: video chat started
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public VideoChatStarted? VideoChatStarted { get; set; }

    /// <summary>
    /// Optional. Service message: video chat ended
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public VideoChatEnded? VideoChatEnded { get; set; }

    /// <summary>
    /// Optional. Service message: new participants invited to a video chat
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public VideoChatParticipantsInvited? VideoChatParticipantsInvited { get; set; }

    /// <summary>
    /// Optional. Service message: data sent by a Web App
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public WebAppData? WebAppData { get; set; }

    /// <summary>
    /// Optional. Inline keyboard attached to the message. <see cref="LoginUrl"/> buttons are represented as
    /// ordinary url buttons.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Gets the <see cref="MessageType"/> of the <see cref="Message"/>
    /// </summary>
    /// <value>
    /// The <see cref="MessageType"/> of the <see cref="Message"/>
    /// </value>
    #if NET8_0_OR_GREATER
    [JsonIgnore]
    #else
    [JsonIgnore]
    #endif
    public MessageType Type =>
        this switch
        {
            { Text: not null }                          => MessageType.Text,
            { Photo: not null }                         => MessageType.Photo,
            { Audio: not null }                         => MessageType.Audio,
            { Video: not null }                         => MessageType.Video,
            { Voice: not null }                         => MessageType.Voice,
            { Animation: not null }                     => MessageType.Animation,
            { Document: not null }                      => MessageType.Document,
            { Sticker: not null }                       => MessageType.Sticker,
            { Story: not null }                         => MessageType.Story,
            // Venue also contains Location
            { Location: not null } and { Venue: null }  => MessageType.Location,
            { Venue: not null }                         => MessageType.Venue,
            { Contact: not null }                       => MessageType.Contact,
            { Game: not null }                          => MessageType.Game,
            { VideoNote: not null }                     => MessageType.VideoNote,
            { Invoice: not null }                       => MessageType.Invoice,
            { SuccessfulPayment: not null }             => MessageType.SuccessfulPayment,
            { ConnectedWebsite: not null }              => MessageType.WebsiteConnected,
            { NewChatMembers.Length: > 0 }              => MessageType.ChatMembersAdded,
            { LeftChatMember: not null }                => MessageType.ChatMemberLeft,
            { NewChatTitle: not null }                  => MessageType.ChatTitleChanged,
            { NewChatPhoto: not null }                  => MessageType.ChatPhotoChanged,
            { PinnedMessage: not null }                 => MessageType.MessagePinned,
            { DeleteChatPhoto: not null }               => MessageType.ChatPhotoDeleted,
            { GroupChatCreated: not null }              => MessageType.GroupCreated,
            { SupergroupChatCreated: not null }         => MessageType.SupergroupCreated,
            { ChannelChatCreated: not null }            => MessageType.ChannelCreated,
            { MigrateToChatId: not null }               => MessageType.MigratedToSupergroup,
            { MigrateFromChatId: not null }             => MessageType.MigratedFromGroup,
            { Poll: not null }                          => MessageType.Poll,
            { Dice: not null }                          => MessageType.Dice,
            { MessageAutoDeleteTimerChanged: not null } => MessageType.MessageAutoDeleteTimerChanged,
            { ProximityAlertTriggered: not null }       => MessageType.ProximityAlertTriggered,
            { VideoChatScheduled: not null }            => MessageType.VideoChatScheduled,
            { VideoChatStarted: not null }              => MessageType.VideoChatStarted,
            { VideoChatEnded: not null }                => MessageType.VideoChatEnded,
            { VideoChatParticipantsInvited: not null }  => MessageType.VideoChatParticipantsInvited,
            { WebAppData: not null }                    => MessageType.WebAppData,
            { ForumTopicCreated: not null }             => MessageType.ForumTopicCreated,
            { ForumTopicEdited: not null }              => MessageType.ForumTopicEdited,
            { ForumTopicClosed: not null }              => MessageType.ForumTopicClosed,
            { ForumTopicReopened: not null }            => MessageType.ForumTopicReopened,
            { GeneralForumTopicHidden: not null }       => MessageType.GeneralForumTopicHidden,
            { GeneralForumTopicUnhidden: not null }     => MessageType.GeneralForumTopicUnhidden,
            { WriteAccessAllowed: not null }            => MessageType.WriteAccessAllowed,
            { UserShared: not null }                    => MessageType.UserShared,
            { ChatShared: not null }                    => MessageType.ChatShared,
            _                                           => MessageType.Unknown
        };
}
