using System;

namespace Common
{
    public class PersonData
    {
        string firstName;
        string lirstName;
        DateTime birthDate;
        string townOfBirth;
        bool isMale;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LirstName { get => lirstName; set => lirstName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string TownOfBirth { get => townOfBirth; set => townOfBirth = value; }
        public bool IsMale { get => isMale; set => isMale = value; }
    }
}
