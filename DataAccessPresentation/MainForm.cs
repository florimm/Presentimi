using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
