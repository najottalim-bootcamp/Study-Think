using Dapper;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;

namespace StudyThink.DataAccess.Repositories.Payments;

public class PaymentDetailsRepository : BaseRepository, IPaymentRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM PaymentDetails";

            long result = await _connection.ExecuteScalarAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> CreateAsync(Payment model)
    {
        return false;
        try
        {
            await _connection.OpenAsync();
            string query = "";

            var patametrs = new
            {

            };

            var result = await _connection.ExecuteAsync(query, patametrs);

            
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
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
