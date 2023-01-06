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
    public partial class Character : Form  // character form
    {
        public int cardNum;
        public Dictionary<int, Form> cards;

        // Delegate
        public delegate void CardsHandler(object sender, UpdateCardsEventsArgs e);

        //Event for Delegate 
        //Type CardsHandler matches the Delegate above
        //UpdateCards is the variable used by Novels form
        public event CardsHandler UpdateCards;

        // counts number of closes
        private int CloseCount = 0;

        // numbers used to determine location of added buttons
        private int numXLabel = 315;
        private int numYLabel = 79;
        private int numXTB = 438;
        private int numYTB = 79;
        private int addCount = 0;

        public Character()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // this.SetControls();
        }

        private void SetControls()
        {
            // makes form uneditable to user
            
            /* som reason isn't working correctly
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            */

        }


        private void button2_Click(object sender, EventArgs e)
        {

            /* Start of Math
             * 
             * 309 70, label is +6+9 for 1st
             * +9 for 1st TB
             * 
             * 110, 20 for labels, MS san 12
             * 128, 20 for TB, ms san 8.25
             * +6 between stuff
             * -40 from box edge(TB)
             * +6 from box edge(labels)
             * 
             * box size is 297
             * location is 309 70
             * 606 -> 566
             * 566 - 128 = 438(TB start), 79
             * 
             * 309 + 6 = 315(LB start), 79
             * 
             * every iteration adds tb/lb size + 6 for Y ONLY
             */
            if (addCount >= 7)
            {
                MessageBox.Show("Too many TBs!");
            }
            else
            {
                TextBox myTB = new TextBox();
                myTB.Location = new Point(numXTB, numYTB);
                myTB.Size = new Size(128, 20);
                myTB.Name = "progCreTB";
                myTB.Font = new Font("MS Sans Serif", 8.25f);

                // Adding TB to form
                this.Controls.Add(myTB);
                myTB.BringToFront();
                numYTB += 20 + 6;
                addCount += 1;

                TextBox myLB = new TextBox();
                myLB.Location = new Point(numXLabel, numYLabel);
                myLB.Size = new Size(110, 20);
                myLB.Name = "progCreLB";
                myLB.Font = new Font("MS Sans Serif", 12f);
                myLB.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.GradientInactiveCaption);
                myLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // Adding TB to form
                this.Controls.Add(myLB);
                myLB.BringToFront();
                numYLabel += 20 + 6;
                addCount += 1;
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (CloseCount == 0)
            {
                MessageBox.Show(cardNum.ToString());
                UpdateCardsEventsArgs args = new UpdateCardsEventsArgs(cards);
                cards.Add(cardNum, this);
                //Event declared above
                CloseCount += 1;
                UpdateCards(this, args);
            }
            this.Visible = false;

        }


        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Name = nameBox.Text;
        }
    }




}
