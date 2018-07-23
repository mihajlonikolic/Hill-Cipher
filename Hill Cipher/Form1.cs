using Hills_Cypher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hill_s_Cypher
{
    public partial class Form1 : Form
    {
        string[] abcBig = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "!", "?" };
        string[] abcLittle = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", ".", ",", "!", "?" };
        float det;
        float a11;
        float a12;
        float a21;
        float a22;

        float a11Adj;
        float a12Adj;
        float a21Adj;
        float a22Adj;

        float a11I;
        float a12I;
        float a21I;
        float a22I;

        string lastChar = "";

        int moduo = 30;
        public Form1()
        {
            InitializeComponent();
        }

        //take values of key matrix
        public void getValues()
        {
            try
            {
                a11 = float.Parse(a11TB.Text);
                a12 = float.Parse(a12TB.Text);
                a21 = float.Parse(a21TB.Text);
                a22 = float.Parse(a22TB.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Wrong number entry! Input correct numbers in the fields!",
                "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        //calculate inverse matrix
        public void inverseMatrix()
        {
            getValues();
            EuclidExtended ee = new EuclidExtended(long.Parse(detFunc().ToString()), long.Parse(moduo.ToString()));
            EuclidExtendedSolution result = ee.calculate();


            float pom1 = float.Parse(label13.Text);
            float pom2 = float.Parse(label12.Text);
            float pom3 = float.Parse(label11.Text);
            float pom4 = float.Parse(label10.Text);

            a11I = mod(result.X * pom1, moduo);
            a12I = mod(result.X * pom2, moduo);
            a21I = mod(result.X * pom3, moduo);
            a22I = mod(result.X * pom4, moduo);

            a11LBL.Text = a11I.ToString();
            a12LBL.Text = a12I.ToString();
            a21LBL.Text = a21I.ToString();
            a22LBL.Text = a22I.ToString();

        }

        //calculate adj matrix
        public void adjA()
        {
            getValues();
            a11Adj = mod(a22,moduo);
            a12Adj = mod(-a12,moduo);
            a21Adj = mod(-a21,moduo);
            a22Adj = mod(a11,moduo);

            label13.Text = a11Adj.ToString();
            label12.Text = a12Adj.ToString();
            label11.Text = a21Adj.ToString();
            label10.Text = a22Adj.ToString();
        }

        //calculate moduo
        public float mod(float a, int n)
        {
            float result = a % n;
            if ((a < 0 && n > 0) || (a > 0 && n < 0))
                result += n;
            return result;
        }
        //calculate determinant
        public float detFunc()
        {
            det = (a11 * a22 - a21 * a12);
            float det1;
            det1 = mod(det, moduo);
            return det1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getValues();

            EuclidExtended ee = new EuclidExtended(long.Parse(detFunc().ToString()), long.Parse(moduo.ToString()));
            EuclidExtendedSolution result = ee.calculate();
            if (result.D == 1)
            {
                detLBL.Text = detFunc().ToString();
                adjA();
                inverseMatrix();
            }
            else
            {
                MessageBox.Show("Invalid key! It's impossible to find an inverse matrix!",
                  "Error!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                Code();
            }
            else
            {
                Decode();
            }
           
        }

        public void Code()
        {
            var regexItem = new Regex("^[a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, ., , , !, ? ]*$");

            if (!regexItem.IsMatch(textBox1.Text))
            {

                MessageBox.Show("Wrong character! You can insert only alfabet characters and '.', ', ', '!', '?' in LowerCase notation!",
                "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);

            }
            else
            {
                try
                {
                    string plainText = textBox1.Text;
                    plainText = plainText.Replace(" ", String.Empty);
                    int length = plainText.Length;
                    if (length % 2 != 0)
                    {
                        lastChar = plainText[length - 1].ToString();
                    }

                    for (int j = 0; j < moduo; j++)
                    {
                        if (lastChar.ToString() == abcLittle[j])
                        {
                            lastChar = abcBig[j];
                        }
                    }
                    string cryptedText = "";


                    char p1;
                    char p2;
                    char c1;
                    char c2;
                    float x = 0;
                    float y = 0;


                    for (int i = 0; i < length - 1; i++)
                    {
                        p1 = plainText[i];
                        for (int j = 0; j < moduo; j++)
                        {
                            if (p1.ToString() == abcLittle[j])
                            {
                                x = (float)j;
                            }
                        }

                        p2 = plainText[i + 1];
                        for (int j = 0; j < moduo; j++)
                        {
                            if (p2.ToString() == abcLittle[j])
                            {
                                y = (float)j;
                            }
                        }
                        c1 = (char)((float.Parse(a11TB.Text) * x + float.Parse(a12TB.Text) * y) % moduo);
                        c2 = (char)((float.Parse(a21TB.Text) * x + float.Parse(a22TB.Text) * y) % moduo);

                        cryptedText = cryptedText + abcBig[c1];
                        cryptedText = cryptedText + abcBig[c2];
                        i++;
                    }

                    if (length % 2 != 0)
                    {
                        cryptedText = cryptedText + lastChar;
                    }

                    textBox2.Text = cryptedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong number entry! Input correct numbers in the fields!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                }
            }
        }

        public void Decode()
        {
            var regexItem = new Regex("^[A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, ., , , !, ? ]*$");

            if (!regexItem.IsMatch(textBox2.Text))
            {

                MessageBox.Show("Wrong character! You can insert only alfabet characters and '.', ', ', '!', '?' in UpperCase notation.",
                "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);

            }
            else
            {
                try
                {
                    string cryptText = textBox2.Text;
                    cryptText = cryptText.Replace(" ", String.Empty);
                    int length = cryptText.Length;

                    if (length % 2 != 0)
                    {
                        lastChar = cryptText[length - 1].ToString();
                    }

                    for (int j = 0; j < moduo; j++)
                    {
                        if (lastChar.ToString() == abcBig[j])
                        {
                            lastChar = abcLittle[j];
                        }
                    }

                    string plainText = "";


                    char p1;
                    char p2;
                    char c1;
                    char c2;
                    float x = 0;
                    float y = 0;


                    for (int i = 0; i < length - 1; i++)
                    {
                        c1 = cryptText[i];
                        for (int j = 0; j < moduo; j++)
                        {
                            if (c1.ToString() == abcBig[j])
                            {
                                x = (float)j;
                            }
                        }

                        c2 = cryptText[i + 1];
                        for (int j = 0; j < moduo; j++)
                        {
                            if (c2.ToString() == abcBig[j])
                            {
                                y = (float)j;
                            }
                        }
                        p1 = (char)((float.Parse(a11LBL.Text) * x + float.Parse(a12LBL.Text) * y) % moduo);
                        p2 = (char)((float.Parse(a21LBL.Text) * x + float.Parse(a22LBL.Text) * y) % moduo);

                        plainText = plainText + abcLittle[p1];
                        plainText = plainText + abcLittle[p2];
                        i++;
                    }

                    if (length % 2 != 0)
                    {
                        plainText = plainText + lastChar;
                    }

                    textBox1.Text = plainText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong number entry! Input correct numbers in the fields!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                button2.Text = "Code";
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;
            }
            else
            {
                if(radioButton2.Checked)
                {
                    button2.Text = "Decode";
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = false;
                }
            }
        }

    }


}
