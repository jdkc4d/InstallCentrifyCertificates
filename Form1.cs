using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace InstallCentrifyCertificates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public String CurrentDir;
        static String RootCertPath;
        static String HQCertPath;
        static String OFACertPath;

        private void Form1_Load(object sender, EventArgs e)
        {
            //The entire program launches at load.

            //1. See if the certificate files are present
            // Get the current folder
            try
            {
                CurrentDir = Directory.GetCurrentDirectory();
                //MessageBox.Show(CurrentDir);
                RootCertPath = CurrentDir + "\\CentrifyIwaTrustRoot.cer";
                HQCertPath = CurrentDir + "\\HQ-CENTRIFY01.cer";
                OFACertPath = CurrentDir + "\\OFA-CENTRIFY02.cer";

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please run this program from your desktop.");

            }

            if (CheckForCertFiles())
            {
                this.lbl_status.Text = "Certificates Loaded. Beginning installation...";
                this.pb_certs.PerformStep();

                //Let's install the root cert
                if(InstallCert(RootCertPath))
                {

                }
                else
                {
                    MessageBox.Show("Could not install certificate");
                    Application.Exit();
                }
                
            }
            else Application.Exit();
            //2. See if the certificates are already installed            
        }

        private Boolean CheckForCertFiles()
        {
            //Update status
            this.lbl_status.Text = "Checking for new certificates...";
            
            //Verify the certificates are in the same folder as this exe
            Boolean RootCertExist = File.Exists(CurrentDir + RootCertPath);
            Boolean HQProxy = File.Exists(CurrentDir + HQCertPath);
            Boolean OFAProxy = File.Exists(CurrentDir + OFACertPath);
            //MessageBox.Show(RootCertExist.ToString() + HQProxy.ToString() + OFAProxy.ToString());

            if (RootCertExist && HQProxy && OFAProxy)
            {
                //We are good to start
                return true;
            }
            else
            {
                MessageBox.Show("Could not find the certificate files. Please re-run this from the folder with the certificates", "Error!");
                return false;
            }
        }
        private Boolean InstallCert(String CertPath)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(CertPath);
                X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

                store.Open(OpenFlags.ReadWrite);
                store.Add(cert);
                store.Close();
            }
            catch (Exception certsEx)
            {
                return false;
            }
            return true;
        }
    }
}
