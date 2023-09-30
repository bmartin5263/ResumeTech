using ResumeTech.Common.Auth;
using ResumeTech.Common.Domain;
using ResumeTech.Experiences.Common;
using ResumeTech.Experiences.Contacts;

namespace ResumeTech.Experiences.Educations;

// TODO: Rename to Degree?
public class Education : IEntity<EducationId>, IAuditedEntity, ISoftDeletable {
    public UserId OwnerId { get; private set; }

    public string Name { get; set; }
    public Location Location { get; set; } = new();
    public DegreeType DegreeType { get; set; }
    public string AreaOfStudy { get; set; }
    public Gpa? Gpa { get; set; }
    public IList<BulletPoint> BulletPoints { get; set; } = new List<BulletPoint>();

    // Common Entity Properties
    public EducationId Id { get; private set; } = EducationId.Generate();
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Default Constructor Needed for Persistence
    private Education() {
        Name = null!;
        Location = null!;
        AreaOfStudy = null!;
    }

    public Education(string Name, DegreeType DegreeType, string AreaOfStudy) {
        this.Name = Name;
        this.DegreeType = DegreeType;
        this.AreaOfStudy = AreaOfStudy;
    }
}