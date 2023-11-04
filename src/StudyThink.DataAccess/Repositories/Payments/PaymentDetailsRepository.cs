using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;

namespace StudyThink.DataAccess.Repositories.Payments;

public class PaymentDetailsRepository : BaseRepository, IPaymentRepository
{
    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(Payment model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Payment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Payment> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Payment model)
    {
        throw new NotImplementedException();
    }
}
