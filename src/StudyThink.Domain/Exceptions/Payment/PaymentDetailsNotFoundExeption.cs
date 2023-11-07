namespace StudyThink.Domain.Exceptions.Payment;
public class PaymentDetailsNotFoundExeption:NotFoundException
{
    public PaymentDetailsNotFoundExeption()
    {
        TitleMessage = "Payment details not found";
    }
}
