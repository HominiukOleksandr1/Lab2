using System;
using System.Drawing; 
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
       
        TextBox txtn;
        TextBox txtm;
        TextBox txtRez;
        DataGridView dgvMass;
        Button cmdStart;
        Button cmdClear;
        Button cmdExit;

        public Form1()
        {
            InitializeComponent();

            
            CreateUI();
        }

        
        private void CreateUI()
        {
            
            this.Text = "Двовимірні масиви";
            this.Size = new Size(750, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            
            Label lbl1 = new Label();
            lbl1.Text = "Кількість строк n =";
            lbl1.Location = new Point(20, 20);
            lbl1.AutoSize = true;
            this.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Text = "Кількість стовпців m =";
            lbl2.Location = new Point(20, 60);
            lbl2.AutoSize = true;
            this.Controls.Add(lbl2);

            Label lbl3 = new Label();
            lbl3.Text = "Результат:";
            lbl3.Location = new Point(20, 100);
            lbl3.AutoSize = true;
            this.Controls.Add(lbl3);

            
            txtn = new TextBox();
            txtn.Location = new Point(150, 15);
            txtn.Width = 50;
            this.Controls.Add(txtn);

            txtm = new TextBox();
            txtm.Location = new Point(150, 55);
            txtm.Width = 50;
            this.Controls.Add(txtm);

            
            txtRez = new TextBox();
            txtRez.Location = new Point(20, 120);
            txtRez.Width = 200;
            txtRez.Height = 220;
            txtRez.Multiline = true;
            this.Controls.Add(txtRez);

         
            dgvMass = new DataGridView();
            dgvMass.Location = new Point(250, 15);
            dgvMass.Width = 450;
            dgvMass.Height = 325;
            dgvMass.AllowUserToAddRows = false; 
            this.Controls.Add(dgvMass);

            
            cmdStart = new Button();
            cmdStart.Text = "Вычислить";
            cmdStart.Location = new Point(20, 360);
            cmdStart.Width = 100;
            cmdStart.Height = 30;
            cmdStart.Click += new EventHandler(cmdStart_Click); 
            this.Controls.Add(cmdStart);

            cmdClear = new Button();
            cmdClear.Text = "Очистка полей";
            cmdClear.Location = new Point(150, 360);
            cmdClear.Width = 100;
            cmdClear.Height = 30;
            cmdClear.Click += new EventHandler(cmdClear_Click); 
            this.Controls.Add(cmdClear);

            cmdExit = new Button();
            cmdExit.Text = "Завершить работу";
            cmdExit.Location = new Point(570, 360);
            cmdExit.Width = 130;
            cmdExit.Height = 30;
            cmdExit.Click += new EventHandler(cmdExit_Click); 
            this.Controls.Add(cmdExit);
        }

        

        private void cmdStart_Click(object sender, EventArgs e)
        {
            try
            {
                int n, m, nn = 0;
                float summ = 0, sr = 0;

                
                n = Int32.Parse(txtn.Text);
                m = Int32.Parse(txtm.Text);

                int[,] A = new int[n, m];
                Random rnd = new Random();

                dgvMass.RowCount = n;
                dgvMass.ColumnCount = m;

                
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        A[i, j] = rnd.Next(-50, 50);
                        dgvMass.Rows[i].Cells[j].Value = A[i, j];
                    }
                }

                
                for (int j = 0; j < m; j++)
                {
                    dgvMass.Columns[j].Width = 50;
                }

               
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (A[i, j] > 0)
                        {
                            summ = summ + A[i, j];
                            nn += 1;
                        }
                    }
                }

                if (nn > 0)
                {
                    sr = summ / nn;
                }

                txtRez.Text = "Середнє арифметичне = " +
                              Math.Round(sr, 5).ToString() + Environment.NewLine +
                              "Кількість додатних елементів = " + nn.ToString();
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите корректные числа в поля строк и столбцов!", "Ошибка ввода");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtm.Text = "";
            txtn.Text = "";
            txtRez.Text = "";
            dgvMass.Rows.Clear();
            dgvMass.Columns.Clear();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}