using System;
using System.Reflection;
using System.Windows.Forms;

namespace PAG_Manager
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version 1.5");
            this.labelCopyright.Text = "Made by Jacques Eluecque in 2019";
            this.labelCompanyName.Text = "Made for Mrs Rojek and the Northgate Science Team";
            this.textBoxDescription.Text = "This program will let you create, modify and award PAG's to an unlimited number of students, all in a portable, fast and convenient application" + Environment.NewLine + Environment.NewLine + "Updates can be found on this github page:" + Environment.NewLine + @"https://github.com/Jacques2/PAG-Manager/releases/latest";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int a = 0;
        private void ErrorSoundTesting_DO_NOT_USE(object sender, EventArgs e)
        {
            a++;
            if (a == 1)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._1);
                player.Play();
            }
            else if (a == 2)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._2);
                player.Play();
            }
            else if (a == 3)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._3);
                player.Play();
            }
            else if (a == 4)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._4);
                player.Play();
            }
            else if (a == 5)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._5);
                player.Play();
            }
            else if (a == 6)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._6);
                player.Play();
            }
            else if (a == 7)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._7);
                player.Play();
                a = 0;
            }
            else
            {
                a = 0;
            }
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {

        }
    }
}
