using System.Collections.Generic;

namespace Common
{
    public class Klienti
    {
        public Klienti()
        {
            this.Faturat = new List<Fatura>();
        }
        public int ID { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Adresa { get; set; }

        public List<Fatura> Faturat { get; set; }

        public string EmriMbiemri
        {
            get { return this.Emri + " " + this.Mbiemri; }
        }

        public override string ToString()
        {
            return this.EmriMbiemri + " " + "fatura (" + this.Faturat.Count  +")";
        }
    }
}