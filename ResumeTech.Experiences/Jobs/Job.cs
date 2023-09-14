using ResumeTech.Common.Domain;
using ResumeTech.Identities.Domain;

namespace ResumeTech.Experiences.Jobs;

public class Job : IEntity<JobId>, IAuditedEntity, ISoftDeletable, IOwnedEntity {
    public UserId OwnerId { get; private set; }
    public string CompanyName { get; set; }

    // Common Entity Properties
    public JobId Id { get; private set; } = JobId.Generate();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Default Constructor Needed for Persistence
    private Job() {
        CompanyName = null!;
    }

    public Job(UserId Owner, string CompanyName) {
        this.OwnerId = Owner;
        this.CompanyName = CompanyName;
    }
}