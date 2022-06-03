using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;


namespace LibraryManagement
{
    public partial class FormPDF : Form
    {
        public FormPDF(string text)
        {
            InitializeComponent();
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true})
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    try
                    {
                        PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                        document.Open();
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.InputEncoding = Encoding.Unicode;
                        document.Add(new iTextSharp.text.Paragraph(richTextBox1.Text));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        document.Close();
                    }
                }
            }
        }
    }
}
