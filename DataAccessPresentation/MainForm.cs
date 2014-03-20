using System;
using System.Windows.Forms;
using Common;
using StructureMap;

namespace DataAccessPresentation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var data = ObjectFactory.GetAllInstances<IDataResult>();
            foreach (var dataResult in data)
            {
                cboAccessData.Items.Add(dataResult.Name);
            }
        }

        private void btnParaqit_Click(object sender, EventArgs e)
        {
            var dr = ObjectFactory.GetNamedInstance<IDataResult>(cboAccessData.SelectedItem + "." + "DataAccess");
            var result = dr.Execute();
            foreach (var klienti in result)
            {
                var ki = new KlientiListViewItem(klienti);
                lvKlientet.Items.Add(ki);
            }
        }

        private void lvKlientet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKlientet.SelectedItems.Count > 0)
            {
                var klv = (KlientiListViewItem) lvKlientet.SelectedItems[0];
                lvFaturat.Items.Clear();
                foreach (var fatura in klv.Klienti.Faturat)
                {
                    var flv = new FaturaListViewItem(fatura);
                    lvFaturat.Items.Add(flv);
                }
            }
        }
    }
}
