using System.ComponentModel.DataAnnotations.Schema;

namespace APIFaturamento.Models {
    [Table("billing")]
    public class Billing {
        [Column("id")]
        public string Id {  get; set; }
        [Column("month")]
        public string Month {  get;  set; }
        [Column("weekDay")]
        public string WeekDay {  get;  set; }
        [Column("day")]
        public long Day {  get;  set; }
        [Column("moneyEarned")]
        public long MoneyEarned { get; set; }
  

        public void IdGenerate() {
            Id = Guid.NewGuid().ToString();
        }

        public void Today() {
            DateTime date = DateTime.Now;

            Month = date.ToString("MMMM");
            WeekDay = date.ToString("ddd");
            Day = (long)(date.Day);
        }

    }
}
