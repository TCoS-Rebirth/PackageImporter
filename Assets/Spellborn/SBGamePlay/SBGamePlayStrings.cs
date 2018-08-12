using System;
using Engine;

namespace SBGamePlay
{
    [Serializable] public class SBGamePlayStrings : UObject
    {
        public LocalizedString Unknown_Area;

        public LocalizedString Unknown_Shard;

        public LocalizedString Cannot_invite_player_you_not_in_guild;

        public LocalizedString Cannot_remove_member_you_not_in_guild;

        public LocalizedString Cannot_disband_guild_you_not_in_guild;

        public LocalizedString Cannot_leave_guild_you_not_in_guild;

        public LocalizedString Cannot_kick_member_you_not_in_party;

        public LocalizedString Cannot_disband_party_you_not_in_party;

        public LocalizedString Cannot_leave_party_you_not_in_party;

        public LocalizedString Invite_whom_;

        public LocalizedString Friend_whom_;

        public LocalizedString Ignore_whom_;

        public LocalizedString Fame;

        public LocalizedString Quest_Points;

        public LocalizedString No_help_found;

        public SBGamePlayStrings()
        {
        }
    }
}