using APIFaturamento.Context;
using Microsoft.EntityFrameworkCore;

namespace APIFaturamento.Models.Interface.Implementation {
    public class BillingImplementation : IBillingInterface {

        private MySQLContext _context;
        public BillingImplementation(MySQLContext context) {
            _context = context;
        }

        public List<Billing> GetAll() {

            return _context.Billings.ToList();

        }

        public Billing Create(Billing billing) {
            try {
                _context.Billings.Add(billing);
                _context.SaveChanges();
                return billing;
            } catch(Exception ex) {
                throw;
            }
        }

        public Billing GetById(string id) {
            if(_context.Billings.Any(b => b.Id == id)) {
                try {
                    Billing billing = _context.Billings.FirstOrDefault(b => b.Id == id);
                    return billing;
                }catch(Exception ex) {
                    throw;
                }
            } else {
                return null;
            }
        }

        public Billing Update(Billing billing) {
            if(_context.Billings.Any(b => b.Id == billing.Id)) {
                try {
                    var oldBilling = _context.Billings.FirstOrDefault(b => b.Id == billing.Id);
                    billing.Id = oldBilling.Id;
                    billing.Month = oldBilling.Month;
                    billing.Day = oldBilling.Day;
                    billing.WeekDay = oldBilling.WeekDay;
                    _context.Entry(oldBilling).CurrentValues.SetValues(billing);
                    _context.SaveChanges();
                    return billing;
                }catch(Exception error) {
                    throw;
                }
            } else {
                return null;
            }
        }

    }
}
