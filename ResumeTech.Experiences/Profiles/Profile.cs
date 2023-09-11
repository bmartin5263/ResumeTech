using ResumeTech.Common.Attributes;
using ResumeTech.Common.Domain;
using ResumeTech.Experiences.Contacts;
using ResumeTech.Experiences.Educations;
using ResumeTech.Experiences.Jobs;
using ResumeTech.Experiences.Projects;
using ResumeTech.Identities.Domain;

namespace ResumeTech.Experiences.Profiles;

public class Profile : IEntity {
    public UserId OwnerId { get; private set; }
    
    [Const<ContactInfo>] private IList<ContactInfo>? ContactInfos { get; set; }
    [Const<Job>] private IList<Job>? Jobs { get; set; }
    [Const<IProject>] private IList<IProject>? Projects { get; set; }
    [Const<Education>] private IList<Education>? Educations { get; set; }

    // Common Entity Properties
    public ProfileId Id { get; private set; } = ProfileId.Generate();
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Default Constructor Needed for Persistence
    private Profile() { }

    public Profile(UserId ownerId) {
        OwnerId = ownerId;
    }
}