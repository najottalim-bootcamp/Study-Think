using StudyThink.DataAccess.Interfaces.Coloborators;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;

namespace StudyThink.DataAccess.Repositories.Callaborators;

public class CallaboratorRepository : BaseRepository, ICalloboratorRepository
{
    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(Callaborator model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Callaborator>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Callaborator> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Callaborator model)
    {
        throw new NotImplementedException();
    }
}
