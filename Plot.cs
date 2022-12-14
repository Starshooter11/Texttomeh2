using System;
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
    public partial class Plot : Form
    {
        public int cardNum;
        public Dictionary<int, Form> cards;

        // Delegate
        public delegate void CardsHandler(Form sender, UpdateCardsEventsArgs e);

        //Event for Delegate 
        //Type CardsHandler matches the Delegate above
        //UpdateCards is the variable used by Novels form
        public event CardsHandler UpdateCards;
        public event CardsHandler DeleteCards;

        // counts number of closes
        private int CloseCount = 0;

        // numbers used to determine location of added buttons
        private int numXLabel = 315;
        private int numYLabel = 79;
        private int numXTB = 438;
        private int numYTB = 79;
        private int addCount = 0;
        public Plot()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CloseCount == 0)
            {
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
            UpdateCardsEventsArgs args = new UpdateCardsEventsArgs(cards);
            DeleteCards(this, args);
            this.Close();
        }


        private void eventName_TextChanged(object sender, EventArgs e)
        {
            this.Name = eventName.Text;
        }

    }

}
