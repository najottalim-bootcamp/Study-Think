using AutoMapper;
using StudyThink.DataAccess.Interfaces.Payments;
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
        IFileService fileService, IMapper mapper)
    {
        this._repository = repository;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        =>await _repository.CountAsync();
        

    public async ValueTask<bool> CreateAsync(PaymentDetailsCretionDto model)
    {
        var paymentDetails=_mapper.Map<PaymentDetails>(model);
        //paymentDetails.IsPaid 
        var result = await _repository.CreateAsync(paymentDetails);
        return result;
        //PaymentDetails paymentDetails = _mapper.Map<PaymentDetails>(model);
        //bool dbResult = await _repository.CreateAsync(paymentDetails);

        //return dbResult;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> paymenDetailsIds)
    {
        foreach (var i in paymenDetailsIds)
        {
            PaymentDetails payment = await _repository.GetByIdAsync(i);

            if (payment != null)
            {
                await _repository.DeleteAsync(i);
            }
        }

        return true;
    }

    public ValueTask<IEnumerable<PaymentDetails>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<PaymentDetails> GetByIdAsync(long Id)
    {

        PaymentDetails payment = await _repository.GetByIdAsync(Id);

        if (payment == null)
        {
            throw new PaymentDetailsNotFoundExeption();
        }
        return payment;
    }

    public async ValueTask<bool> UpdateAsync(PaymentDetailsUpdateDto model)
    {
        PaymentDetails payment = _mapper.Map<PaymentDetails>(model);
        var result = await _repository.UpdateAsync(payment);

        return result;
    }
}
