using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiki
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X, O
        }
        Player Jatekos;
        Random rnd = new Random();
        int playernyereseg = 0;
        int AInyereseg = 0;
        List<Button> buttons;




        public Form1()
        {
            InitializeComponent();
            Ujra();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CpuM(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int i = rnd.Next(buttons.Count);
                buttons[i].Enabled = false;
                Jatekos = Player.O;
                buttons[i].Text = Jatekos.ToString();
                buttons[i].BackColor = Color.Violet;
                buttons.RemoveAt(i);
                Game();
                Cputime.Stop();

            }
        }

        private void PlayerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Jatekos = Player.X;
            button.Text = Jatekos.ToString();
            button.Enabled = false;
            button.BackColor = Color.Red;
            buttons.Remove(button);
            Game();
            Cputime.Start();

        }

        private void Ujra(object sender, EventArgs e)
        {
            Ujra();
        }

        private void Game()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                Cputime.Stop();
                MessageBox.Show("Nyertél");
                playernyereseg++;
                label1.Text = "Saját Győzelem: " + playernyereseg;
                Ujra();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                Cputime.Stop();
                MessageBox.Show("Vesztettél :(");
                AInyereseg++;
                label2.Text = "AI Győzelem: " + AInyereseg;
                Ujra();

            }



        }

        private void Ujra()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = " ";
                x.BackColor = DefaultBackColor;
            }



        }

    }
}
