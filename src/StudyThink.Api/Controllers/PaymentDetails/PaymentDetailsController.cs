using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyThink.Service.DTOs.Payment;
using StudyThink.Service.DTOs.Student;
using StudyThink.Service.Interfaces.Payments;

namespace StudyThink.Api.Controllers.PaymentDetails;
[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentDetailsController : ControllerBase
{
    private readonly IPaymentDetailsService _paymentDetailsService;
    private readonly int _maxPageSize = 30;

    public PaymentDetailsController(IPaymentDetailsService paymentDetailsService)
    {
        this._paymentDetailsService = paymentDetailsService;
    }
    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _paymentDetailsService.CountAsync());
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] PaymentDetailsCretionDto dto)
        => Ok(await _paymentDetailsService.CreateAsync(dto));
}
