using ResumeTech.Common;
using ResumeTech.Common.Domain;

namespace ResumeTech.ExperienceManagement.Domain;

public class Film : IProject, IEntity {
    public string Title { get; set; }
    
    // Common Project Properties
    public string Name { get; set; }
    public DateOnlyRange Dates { get; set; }
    public IProjectId ProjectId => Id;

    // Common Entity Properties
    public FilmId Id { get; private set; } = FilmId.Generate();
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Default Constructor Needed for Persistence
    private Film() {
        Name = null!;
        Title = null!;
    }

    public Film(string name, string title) {
        Name = name;
        Title = title;
    }
}