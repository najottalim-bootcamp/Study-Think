using Dapper;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.Domain.Entities.Payments;

namespace StudyThink.DataAccess.Repositories.Payments;

public class PaymentDetailsRepository : BaseRepository2, IPaymentDetailsRepository
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

    public async ValueTask<bool> CreateAsync(PaymentDetails model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"INSERT INTO PaymentDetails(CardHolderName,CardNumber,ExpirationDate,CardCodeCVV," +
                $"CardPoneNumber,StudentId,CreatedAt,IsPaid,CourseId) " +
                $"VALUES(@CardHolderName,@CardNumber,@ExpirationDate,@CardCodeCVV,@CardPoneNumber,@StudentId,@CreatedAt," +
                $"@IsPaid,@CourseId)";
            var result = await _connection.ExecuteAsync(query, model);
            return result > 0;
        }
        catch (Exception)
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

    public ValueTask<PaymentDetails> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(PaymentDetails model)
    {
        throw new NotImplementedException();
    }
}
