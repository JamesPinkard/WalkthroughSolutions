using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PLINQDataProcessingWithCancellation
{
    public partial class PLINQinAction : Form
    {
        public PLINQinAction()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the ints.
            Task.Factory.StartNew(() =>
                {
                    ProcessIntData();
                });
        }

        private void ProcessIntData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 10000000).ToArray();

            // Find the numbers where num % 3 == 0 is true, returned in descending order.
            int[] modThreeIsZero = null;

            try
            {
                modThreeIsZero = (from num in source.AsParallel() where num % 3 ==0 orderby num descending select num).ToArray();
                MessageBox.Show(String.Format("Found {0} numbers that match query!", modThreeIsZero.Count()));
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = ex.Message;
                });
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
