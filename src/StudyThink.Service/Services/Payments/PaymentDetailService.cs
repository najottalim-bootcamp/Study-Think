using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;
using StudyThink.Service.DTOs.Payment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Payments;

namespace StudyThink.Service.Services.Payments;

public class PaymentDetailService : IPaymentDetailsService
{
    private readonly IPaymentDetailsRepository _repository;
    private readonly IFileService _fileService;

    public PaymentDetailService(IPaymentDetailsRepository repository,
        IFileService fileService)
    {
        this._repository = repository;
        this._fileService = fileService;
    }

    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(PaymentDetailsCretionDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> paymenDetailsIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<PaymentDetails>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PaymentDetails> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(PaymentUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
