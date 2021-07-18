using System.Collections.Generic;

namespace Domain.Aggregates.UserAgg.Enumerators
{
    public static class RolesTypes
    {
        public const string MANAGER = "Manager";
        public const string USER = "User";

        public static IEnumerable<string> GetValues()
        {
            yield return MANAGER;
            yield return USER;
        }
    }
}