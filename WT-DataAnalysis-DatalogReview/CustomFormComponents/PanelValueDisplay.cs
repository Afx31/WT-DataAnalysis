namespace WT_DataAnalysis_DatalogReview.CustomFormComponents;

public static class PanelValueDisplay
{
    private static Panel _panel;
    private static Label _lblName;
    private static Label _lblValue;

    public static Panel CreatePanel(string controlName)
    {
        /* TODO
         * 
         * Spec:
         * - Dynamically with the width, decide on the label widths, height, size etc
         * 
         * Labels default margin left/right: 3px
         */

        _panel = new Panel()
        {
            Name = "VD_Panel_" + controlName.Replace(" ", ""),
            Height = 50,
            Dock = DockStyle.Top
        };
        _panel.Paint += Panel_CustomBorder;

        _lblName = new Label()
        {
            Text = controlName,
            Name = "LabelName",
            //BackColor = Color.Blue, // Test-Designing
            Location = new Point(2, 2),
            Size = new Size(250, 44),
            Font = new Font("Segoe UI", 20),
            ForeColor = Color.White,
        };

        _lblValue = new Label()
        {
            Name = "LabelValue",
            //BackColor = Color.Red, // Test-Designing
            Location = new Point(235, 2),
            Size = new Size(160, 44),
            Margin = new Padding(0),
            Font = new Font("Segoe UI", 22),
            ForeColor = Color.White,
        };

        _panel.Controls.Add(_lblValue);
        _panel.Controls.Add(_lblName);
        
        return _panel;
    }

    private static void Panel_CustomBorder(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.White, 2))
        {
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            e.Graphics.DrawRectangle(pen, 0, 0, _panel.Width - 1, _panel.Height - 1);
        }
    }
}
