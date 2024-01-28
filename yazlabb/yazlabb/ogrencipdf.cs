using System;
using System.Windows.Forms;
using Tesseract;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.parser;
using Npgsql;
using System.Text.RegularExpressions;
using System.Data;

namespace yazlabb
{
    public partial class ogrencipdf : Form
    {
        public ogrencipdf()
        {
            InitializeComponent();
        }

        string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
       

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                using (PdfReader pdfReader = new PdfReader(selectedFilePath))
                {
                    string allText = "";
                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                        string pageText = PdfTextExtractor.GetTextFromPage(pdfReader, page);
                        allText += pageText;
                    }

                   
                    string pattern = @"([A-Z]{3,4}\d{3})\s(.+)\s(AA|BA|BB|CB|CC|DC|DD|DF|FF)";
                    MatchCollection matches = Regex.Matches(allText, pattern);

                    using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();

                        foreach (Match match in matches)
                        {
                            string dersKodu = match.Groups[1].Value;
                            string dersAdi = match.Groups[2].Value;
                            string harfNotu = match.Groups[3].Value;

                      
                            string insertSql = "INSERT INTO pdf (dersinadi,dersinharfnotu ) VALUES (@dersadi, @harfnotu)";
                            using (NpgsqlCommand insertCommand = new NpgsqlCommand(insertSql, conn))
                            {
                                insertCommand.Parameters.AddWithValue("dersadi", dersAdi);
                                insertCommand.Parameters.AddWithValue("harfnotu", harfNotu);
                                insertCommand.ExecuteNonQuery();
                            }
                        }

                        conn.Close();
                    }
                }
                string listele = "select * from pdf";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(listele, connString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            derssecim form = new derssecim();
                form.Show();
        }
    }
        }
    
