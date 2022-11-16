﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texttomeh2.Events;

namespace Texttomeh2
{
    // option page where the creation of different 'cards' happens
    public partial class OptionPage : Form
    {
        //Delegate
        public delegate void NovelsHandler(object sender, UpdateNovelsEventsArgs e);

        //Event for Delegate 
        //Type NovelsHandler matches the Delegate above
        //UpdateNovels is the variable used by Homepage form
        public event NovelsHandler UpdateNovels;

        // access to edit this list; will be used to pass on editing function to other forms
        public List<Form> novels;
        public OptionPage()
        {
            InitializeComponent();
            this.Visible = true;
        }

        //character form button
        private void charButton_Click(object sender, EventArgs e)
        {
            Character charForm = new Character();

            //temporary for testing, will be changed to a list for chars later
            charForm.novels = this.novels;
            charForm.UpdateNovels += new Character.NovelsHandler(UpdateNovels);

            this.Close();

            
        }

        // plot form button
        private void plotButton_Click(object sender, EventArgs e)
        {
            Plot plotForm = new Plot();
            this.Close();

            UpdateNovelsEventsArgs args = new UpdateNovelsEventsArgs(novels);

            //Event declared above
            UpdateNovels(this, args);
        }

        
    }
}
