using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Objeler
{
    public static class FormYardımcisi
    {
        public static void RakamYaz(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //base.OnKeyPress(e);
        } //sadece rakam yaz
        public static void RakamDegerYaz(object sender, KeyPressEventArgs e, TextBox tb)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if(e.KeyChar == '0' && tb.Text.IndexOf('0') == 0)
            {
                e.Handled = true;
            }
            else if(tb.Text.IndexOf('0') == 0 && e.KeyChar != '0')
            {
                tb.Text = "";
                tb.SelectionStart = 1;
            }
            //base.OnKeyPress(e);
        } //sadece rakam değer yaz
        public static void FloatYaz(object sender, KeyPressEventArgs e, TextBox tb)
        {
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (tb.Text.Contains(',') || tb.Text.Length == 0)
                {
                    e.Handled = true;
                }
                else if(e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar!=',')
            {
                e.Handled = true;
            }
            else if ((tb.Text.IndexOf('0') == 0 && !tb.Text.Contains(',')) && !Char.IsControl(e.KeyChar))
            {
                tb.Text = "0,";
                tb.SelectionStart = 2;
                //e.Handled = true;
            }
        } //sadece float yazar
        public static void HarfYaz(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //base.OnKeyPress(e);
        } //sadece harf yaz


        public static DataTable DgvOku(DataGridView gridView)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    if (column.ValueType != null)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }
                }

                foreach (DataGridViewRow row in gridView.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.GetType() != typeof(DataGridViewImageCell) && !(cell.Value == null || cell.Value == DBNull.Value || String.IsNullOrWhiteSpace(cell.Value.ToString())))
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste okunurken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
                return null;
                //throw new Exception(ex.Message);
            }
        }
        public static void ExcelYazdır(DataGridView dgv , string worksheetName)
        {
            try
            {
                if (dgv.Rows.Count <= 0)
                {
                    MessageBox.Show("Liste boş", "Sistem Mesajı", MessageBoxButtons.OK);
                    return;
                }

                var dt = Objeler.FormYardımcisi.DgvOku(dgv);

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Excel dosyası (*.xlsx)|*.xlsx;";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    XLWorkbook workbook = new XLWorkbook();
                    workbook.Worksheets.Add(dt, worksheetName);
                    workbook.SaveAs(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel'e yazdırılırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
            
        }
        public static void PrintDGV(string başlık, DataGridView dgv)
        {
            try
            {
                if (dgv.Rows.Count <= 0)
                {
                    MessageBox.Show("Liste boş", "Sistem Mesajı", MessageBoxButtons.OK);
                    return;
                }

                DGVPrinterHelper.DGVPrinter printer = new DGVPrinterHelper.DGVPrinter();
                printer.Title = başlık;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.HeaderCellAlignment = System.Drawing.StringAlignment.Near;
                printer.Footer = "Car Hire System";
                printer.FooterSpacing = 15;
                printer.ColumnWidth = DGVPrinterHelper.DGVPrinter.ColumnWidthSetting.DataWidth;

                printer.PrintDataGridView(dgv);               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazdırılırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }

    }
}
