﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignLogic;

namespace SignBrowser
{
    public partial class AddWindow : Form
    {
        public AddWindow()
        {
            InitializeComponent();
            // Set the next logical Id.
            this.IdTextbox.Text = FullButton.IdCounter.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddDBButton_Click(object sender, EventArgs e)
        {
            if (this.validateForm())
            {
                FileAccess.MakeButton(this.SignTextbox.Text, this.DescriptionTextbox.Text);
                MessageBox.Show("Button created succesfully!");

                // reset params
                this.IdTextbox.Text = FullButton.IdCounter.ToString();
                this.SignTextbox.Text = string.Empty;
                this.DescriptionTextbox.Text = string.Empty;
            }
            else
                return;
        }

        private bool validateForm()
        {
            bool check = true;
            if (this.SignTextbox.Text == string.Empty || this.SignTextbox.Text.Length > 1)
            {
                MessageBox.Show("Sign can only contain one character! Use the other components to add multi character phrases.");
                check = false;
            }

            if (this.DescriptionTextbox.Text == string.Empty)
            {
                check = false;
            }

            if (this.DescriptionTextbox.Text.Contains('\n'))
            {
                check = false;
                MessageBox.Show("Description cannot contain newLine characters!");
            }

            if (this.DescriptionTextbox.Text.Contains('\r'))
            {
                check = false;
                MessageBox.Show("Description cannot contain newLine characters!");
            }

            return check;
        }

        private void AddWindow_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void AddWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
