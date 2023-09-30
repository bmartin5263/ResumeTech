using ResumeTech.Common.Domain;

namespace ResumeTech.Experiences.Profiles;

public readonly record struct ProfileId(Guid Value) : IEntityId, IWrapper<Guid> {
    public static ProfileId Generate() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString("N");
}