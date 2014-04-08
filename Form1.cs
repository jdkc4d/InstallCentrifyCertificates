using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InstallCentrifyCertificates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public String CurrentDir;

        private void Form1_Load(object sender, EventArgs e)
        {
            //The entire program launches at load.

            //1. See if the certificate files are present
            // Get the current folder
            try
            {
                CurrentDir = Directory.GetCurrentDirectory();
                //MessageBox.Show(CurrentDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please run this program from your desktop.");
            }

            //Verify the certificates are in the same folder as this exe
            Boolean RootCertExist = File.Exists(CurrentDir + "\\CentrifyIwaTrustRoot.cer");
            Boolean HQProxy = File.Exists(CurrentDir + "\\HQ-CENTRIFY01.cer");
            Boolean OFAProxy = File.Exists(CurrentDir + "\\OFA-CENTRIFY02.cer");

            MessageBox.Show(RootCertExist.ToString() + HQProxy.ToString() + OFAProxy.ToString());

            //2. See if the certificates are already installed

            //3. Install the certificates
        }
    }
}
