using System.Windows.Forms;
using Common;

namespace DataAccessPresentation
{
    public class KlientiListViewItem : ListViewItem
    {
        private Klienti _klienti;

        public KlientiListViewItem(Klienti k)
        {
            _klienti = k;
            MbusheListen();
        }

        private void MbusheListen()
        {
            this.Text = _klienti.EmriMbiemri;
            this.SubItems.Add(_klienti.Adresa);
            this.SubItems.Add(_klienti.Faturat.Count.ToString());
        }

        public Klienti Klienti
        {
            get { return _klienti; }
            set
            {
                _klienti = value;
                MbusheListen();
            }
        }
    }
}