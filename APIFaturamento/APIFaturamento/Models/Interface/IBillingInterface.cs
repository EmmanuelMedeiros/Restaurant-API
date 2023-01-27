using APIFaturamento.Models;

namespace APIFaturamento.Models.Interface
{
    public interface IBillingInterface
    {
        List<Billing> GetAll();
        Billing Create(Billing billing);
        Billing Update(Billing billing);
        Billing GetById(string id);

    }
}
