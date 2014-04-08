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
                    this.lbl_status.Text = "Root Certificate installation complete. Installing HQ Cert...";
                    this.pb_certs.PerformStep();
                }
                else
                {
                    Application.Exit();
                }
                
                //Now lets install the HQ cert
                if(InstallCert(HQCertPath))
                {
                    this.lbl_status.Text = "HQ Proxy Certificate installation complete. Installing OFA Cert...";
                    this.pb_certs.PerformStep();
                }
                else
                {
                    Application.Exit();
                }

                //Install OFA Cert
                if(InstallCert(OFACertPath))
                {
                    this.lbl_status.Text = "OFA Proxy Certificate installation complete. Finishing...";
                    this.pb_certs.PerformStep();
                }
                else
                {
                    Application.Exit();
                }
                //Let's finish this. 
                this.pb_certs.PerformStep();
                this.lbl_status.Text = "Installation Complete";
                MessageBox.Show("Installation has completed sucessfully.");
                Application.Exit();
            }
            else Application.Exit();
            //2. See if the certificates are already installed            
        }

        private Boolean CheckForCertFiles()
        {
            //Update status
            this.lbl_status.Text = "Checking for new certificates...";
            
            //Verify the certificates are in the same folder as this exe
            Boolean RootCertExist = File.Exists(RootCertPath);
            Boolean HQProxy = File.Exists(HQCertPath);
            Boolean OFAProxy = File.Exists(OFACertPath);
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
                MessageBox.Show("Error Installing Certificate: " + certsEx.Message + " Please re-run as Administrator.");
                return false;
            }
            return true;
        }
    }
}
