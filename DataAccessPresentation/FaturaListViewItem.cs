using System.Windows.Forms;
using Common;

namespace DataAccessPresentation
{
    public class FaturaListViewItem : ListViewItem
    {
        private Fatura _fatura;

        public FaturaListViewItem(Fatura f)
        {
            _fatura = f;
            MbusheListen();
        }

        private void MbusheListen()
        {
            this.Text = _fatura.Nr;
            this.SubItems.Add(_fatura.Data.ToLongDateString());
            this.SubItems.Add(_fatura.Shuma.ToString("F2"));
        }

        public Fatura Fatura
        {
            get { return _fatura; }
            set
            {
                _fatura = value;
                MbusheListen();
            }
        }
    }
}