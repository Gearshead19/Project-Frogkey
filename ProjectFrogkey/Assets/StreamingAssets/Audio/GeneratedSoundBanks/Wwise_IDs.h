/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_CASTLEESTERRAMUSIC = 706813533U;
        static const AkUniqueID PLAY_DRINK_HEALTHPOTION = 3363411656U;
        static const AkUniqueID PLAY_DUNGEONMUSIC = 2194545525U;
        static const AkUniqueID PLAY_FORESTDUNGEON_AMB = 1858014972U;
        static const AkUniqueID PLAY_FORESTDUNGEON_BASICDOOR_CLOSE = 3406344955U;
        static const AkUniqueID PLAY_FORESTDUNGEON_BASICDOOR_OPEN = 228997405U;
        static const AkUniqueID PLAY_GAMEOVERJINGLE = 3458381909U;
        static const AkUniqueID PLAY_HOPPS_BASICATTACK = 536851419U;
        static const AkUniqueID PLAY_HOPPS_JUMP = 109051115U;
        static const AkUniqueID PLAY_HOPPS_WALK = 3862148652U;
        static const AkUniqueID PLAY_HOPPSHEAVYATTACK = 190067705U;
        static const AkUniqueID PLAY_KEY_PICKUP = 2881789206U;
        static const AkUniqueID PLAY_MAINTOWNMUSIC = 1134137730U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_OVERWORLDFORESTMUSIC = 693146296U;
        static const AkUniqueID PLAY_TITLESCREENMUSIC = 4182175493U;
        static const AkUniqueID PLAY_UNDERGROUNDFOREST_AMB = 2352500859U;
        static const AkUniqueID PLAY_UNDERGROUNDFORESTMUSIC = 1277548847U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace FORESTDUNGEONSTATES
        {
            static const AkUniqueID GROUP = 1606972574U;

            namespace STATE
            {
                static const AkUniqueID COMBAT = 2764240573U;
                static const AkUniqueID EXPLORING = 1823678183U;
                static const AkUniqueID LOWHEALTH = 1017222595U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace FORESTDUNGEONSTATES

        namespace GAMEPAUSE
        {
            static const AkUniqueID GROUP = 671786287U;

            namespace STATE
            {
                static const AkUniqueID ISPAUSED = 2443794319U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID NOTPAUSED = 2779060518U;
            } // namespace STATE
        } // namespace GAMEPAUSE

        namespace PLAYINGSONG
        {
            static const AkUniqueID GROUP = 1106389198U;

            namespace STATE
            {
                static const AkUniqueID MUSIC_CASTLEESTERRA = 380412565U;
                static const AkUniqueID MUSIC_FORESTDUNGEON = 4293875712U;
                static const AkUniqueID MUSIC_GAMEOVER = 2897915005U;
                static const AkUniqueID MUSIC_MAINTHEME = 1485340549U;
                static const AkUniqueID MUSIC_MAINTOWN = 387028970U;
                static const AkUniqueID MUSIC_UNDERGROUNDFOREST = 1984596375U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace PLAYINGSONG

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEP_SWITCHGROUP
        {
            static const AkUniqueID GROUP = 2116499235U;

            namespace SWITCH
            {
                static const AkUniqueID STONE = 1216965916U;
            } // namespace SWITCH
        } // namespace FOOTSTEP_SWITCHGROUP

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID AMB_FORESTDUNGEON = 2826179121U;
        static const AkUniqueID AMB_UNDERGROUNDFOREST = 1996464746U;
        static const AkUniqueID GAMEOVER_SOUNDBANK = 1817562479U;
        static const AkUniqueID HOPPS_SOUNDBANK = 2197452935U;
        static const AkUniqueID MUS_CASTLEESTERRA = 2546705169U;
        static const AkUniqueID MUS_FORESTDUNGEON = 973840868U;
        static const AkUniqueID MUS_MAINTOWN = 1922392942U;
        static const AkUniqueID MUS_OVERWORLDFOREST = 3591353126U;
        static const AkUniqueID MUS_TITLESCREEN = 3413408933U;
        static const AkUniqueID MUS_UNDERGROUNDFOREST = 2286727387U;
        static const AkUniqueID MUSIC_SOUNDBANK = 3589812408U;
        static const AkUniqueID SFX_DOOR_FORESTDUNGEON_CLOSE = 3253083610U;
        static const AkUniqueID SFX_DOOR_FORESTDUNGEON_OPEN = 1125626846U;
        static const AkUniqueID SFX_KEY_PICKUP = 173969489U;
        static const AkUniqueID SFX_POTION_DRINK = 2572880635U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID ENEMIES = 2242381963U;
        static const AkUniqueID ENVIRONMENT = 1229948536U;
        static const AkUniqueID HOPPS = 4006243373U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID FORESTDUNGEONVERB = 2137158287U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
