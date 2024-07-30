using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Constants
    {
        //FormRate
        public static class FormRate
        {
            public const string Bad  = "BAD";
            public const string Average = "AVERAGE";
            public const string Good = "GOOD";
            public const string Excellent = "EXCELLENT";
        }

        //FormRate
        public static class AvailabilityStatus
        {
            public const string Available = "AVAILABLE";
            public const string Injury = "RIGHTFOOT";
            public const string LeftFootGoal = "LEFTFOOT";
        }

        public static class InjuryType
        {
            public const string MuscleInjury = "MUSCLEINJURY";
            public const string Fracture = "FRACTURE";
            public const string AnkleSprain = "SPRAIN";
            public const string Hernia = "SPRAIN";
            public const string KneeInjury = "SPRAIN";
            public const string TornACL = "SPRAIN";
        }

        public static class InjuryDurationTime
        {
            public const string OneWeek = "ONEWEEK";
            public const string TwoWeeks = "TWOWEEKS";
            public const string FourWeeks = "SPRAIN";
            public const string SixWeeks = "SPRAIN";
            public const string EightWeeks = "SPRAIN";
            public const string TenWeeks = "SPRAIN";
            public const string TwelveWeeks = "SPRAIN";
            public const string FourtneenWeeks = "SPRAIN";
            public const string SixteenWeeks = "SPRAIN";
            public const string EighteenWeeks = "SPRAIN";
            public const string TwentyWeeks = "SPRAIN";
            public const string TwentyTwoWeeks = "SPRAIN";
            public const string TwentyFourWeeks = "SPRAIN";
            public const string TwentySixWeeks = "SPRAIN";
            public const string TwentyEightWeeks = "SPRAIN";
            public const string FourtyWeeks = "SPRAIN";
            public const string FourtyTwoWeeks = "SPRAIN";
            public const string FourtyFourWeeks = "SPRAIN";
            public const string FourtySixWeeks = "SPRAIN";
            public const string FourtyEightWeeks = "SPRAIN";
            public const string FiftyWeeks = "SPRAIN";
            public const string FiftyTwoWeeks = "SPRAIN";
            public const string FiftyFourWeeks = "SPRAIN";
            public const string FiftySixWeeks = "SPRAIN";
            public const string FiftyEightWeeks = "SPRAIN";
            public const string SixtyWeeks = "SPRAIN";
        }


        //Match Scorer
        public static class GoalScoredType
        {
            public const string HeaderGoal = "HEADER";
            public const string RightFootGoal = "RIGHTFOOT";
            public const string LeftFootGoal = "LEFTFOOT";
        }

        //Match Assist
        public static class MatchAssist
        {
            public const string HeaderAssist = "HEADERASSIST";
            public const string RightFootAssist = "RIGHTFOOTASSIST";
            public const string LeftFootAssist = "LEFTFOOTASSIST";
       }
    }
}
    

