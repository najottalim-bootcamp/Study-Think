using AutoMapper;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Repositories.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;
using StudyThink.Domain.Exceptions.Payment;
using StudyThink.Service.DTOs.Payment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Payments;

namespace StudyThink.Service.Services.Payments;

public class PaymentDetailService : IPaymentDetailsService
{
    private readonly IPaymentDetailsRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public PaymentDetailService(IPaymentDetailsRepository repository,
        IFileService fileService,IMapper mapper)
    {
        this._repository = repository;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
    {


        long count = await _repository.CountAsync();

        if (count == 0)
            throw new PaymentDetailsNotFoundExeption();
        return count;
    }

    public async ValueTask<bool> CreateAsync(PaymentDetailsCretionDto model)
    {
        PaymentDetails paymentDetails = _mapper.Map<PaymentDetails>(model);
        bool dbResult = await _repository.CreateAsync(paymentDetails);

        return dbResult;
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
