using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    public int BorderRadius { get; set; } = 9;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Enable anti-aliasing for smoother edges
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        // Create a rounded rectangle path
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius * 2, BorderRadius * 2, 180, 90);  // Top-left corner
        path.AddArc(this.Width - BorderRadius * 2, 0, BorderRadius * 2, BorderRadius * 2, 270, 90);  // Top-right corner
        path.AddArc(this.Width - BorderRadius * 2, this.Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 0, 90);  // Bottom-right corner
        path.AddArc(0, this.Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 90, 90);  // Bottom-left corner
        path.CloseFigure();

        // Set the region of the panel to the rounded rectangle
        this.Region = new Region(path);

        // Fill the panel with the background color
        e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
    }
}
