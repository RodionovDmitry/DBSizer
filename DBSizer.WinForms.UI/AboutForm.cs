using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBSizer
{
    public partial class AboutForm : Form
    {
        private const string url = "http://ru.linkedin.com/pub/dmitry-rodionov/1/41b/349/";
        public AboutForm()
        {
            InitializeComponent();
            linkEdIn.Links.Add(0, linkEdIn.Text.Length, url);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:rgbdart@gmail.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}