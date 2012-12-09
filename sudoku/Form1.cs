using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtRow1.Focus();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            //SudokuBoard board = new SudokuBoard();
            SudokuBoard board = new SudokuBoard(txtRow1.Text + txtRow2.Text + txtRow3.Text + txtRow4.Text + txtRow5.Text + txtRow6.Text + txtRow7.Text + txtRow8.Text + txtRow9.Text);
            btnSolve.Enabled = false;
            board.Solve();
            btnSolve.Enabled = true;
            string output = board.ToString();
            txtRow1.Text = output.Substring(0, 9);
            txtRow2.Text = output.Substring(9, 9);
            txtRow3.Text = output.Substring(18, 9);
            txtRow4.Text = output.Substring(27, 9);
            txtRow5.Text = output.Substring(36, 9);
            txtRow6.Text = output.Substring(45, 9);
            txtRow7.Text = output.Substring(54, 9);
            txtRow8.Text = output.Substring(63, 9);
            txtRow9.Text = output.Substring(72, 9);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRow1.Text = "";
            txtRow2.Text = "";
            txtRow3.Text = "";
            txtRow4.Text = "";
            txtRow5.Text = "";
            txtRow6.Text = "";
            txtRow7.Text = "";
            txtRow8.Text = "";
            txtRow9.Text = "";
        }

    }
}
