using Domain.Common;

namespace Domain.Entities
{
    public class MafiaFamily : Entity
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<FamilyMember> FamilyMembers { get; private set; }
    }
}