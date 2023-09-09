using ResumeTech.Common;
using ResumeTech.Common.Domain;

namespace ResumeTech.Resources.Domain;

public class VideoRef : IEntity {

    // Common Entity Properties
    public VideoRefId Id { get; private set; } = VideoRefId.Generate();
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Default Constructor Needed for Persistence
    private VideoRef() { }
}