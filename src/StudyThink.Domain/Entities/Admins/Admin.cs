using StudyThink.Domain.Enums;

namespace StudyThink.Domain.Entities.Admins;

public class Admin : Human
{
    public Role Role { get; set; }

}
