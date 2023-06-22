using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data.Odbc;
using System.Text;

namespace cs_form_230622_pdf
{

    public partial class Form1 : Form
    {

        private int yPosition;

        XStringFormat xsf = new XStringFormat();


        public Form1()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            PdfSharp.Fonts.GlobalFontSettings.FontResolver = new FontResolver();

            xsf.Alignment = XStringAlignment.Far;

        }

        private void PDF出力_Click(object sender, EventArgs e)
        {
            printPDF();
        }

        private void printPDF()
        {

            PdfDocument document = new PdfDocument();
            // ページを追加
            PdfPage page = document.AddPage();
            // XGraphicsオブジェクトを作成
            XGraphics gfx = XGraphics.FromPdfPage(page);
            // XFontオブジェクトを作成
            XFont font = new XFont(this.梅フォント.Text, 12, XFontStyle.Regular);

            // データベースへの接続文字列を作成
            string connectionString = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost;Database=lightbox;User=root;Password=;";
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                // データベースに接続
                connection.Open();

                // 社員データを取得するSQLクエリを作成
                string query = "SELECT 社員コード, 氏名, 給与 FROM 社員マスタ";

                // OdbcCommandオブジェクトを作成
                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    // データを読み取るためのOdbcDataReaderオブジェクトを作成
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        headPrint(gfx, font);

                        // データ行の描画
                        while (reader.Read())
                        {
                            if (yPosition > 800)
                            {
                                page = document.AddPage();
                                gfx = XGraphics.FromPdfPage(page);
                                headPrint(gfx, font);
                            }

                            string employeeCode = reader.GetString(0).PadLeft(4, '0');
                            string name = reader.GetString(1);
                            int salary = reader.GetInt32(2);

                            gfx.DrawString(employeeCode, font, XBrushes.Black, new XRect(50, yPosition, 100, 20), XStringFormats.TopLeft);
                            gfx.DrawString(name, font, XBrushes.Black, new XRect(150, yPosition, 200, 20), XStringFormats.TopLeft);
                            gfx.DrawString(salary.ToString("N0").PadLeft(10), font, XBrushes.Black, new XRect(350, yPosition, 100, 20), xsf);

                            yPosition += 20;

                        }
                    }
                }

            }

            // ドキュメントを保存
            document.Save("社員一覧.pdf");

            // ドキュメントを閉じてリソースを解放
            document.Close();
        }

        private void headPrint(XGraphics gfx, XFont font)
        {

            yPosition = 50; // 列の開始位置

            // タイトル行の描画
            gfx.DrawString("社員コード", font, XBrushes.Black, new XRect(50, yPosition, 100, 20), XStringFormats.TopLeft);
            gfx.DrawString("氏名", font, XBrushes.Black, new XRect(150, yPosition, 200, 20), XStringFormats.TopLeft);
            gfx.DrawString("給与".PadLeft(10), font, XBrushes.Black, new XRect(350, yPosition, 100, 20), xsf);
            yPosition += 20;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.梅フォント.SelectedIndex = 0;
        }
    }
}