using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPictureBox : PictureBox
{
    public int BorderRadius { get; set; } = 9;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Enable anti-aliasing for smoother edges
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        // Create a rounded rectangle path for the PictureBox
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius * 2, BorderRadius * 2, 180, 90);  // Top-left corner
        path.AddArc(this.Width - BorderRadius * 2, 0, BorderRadius * 2, BorderRadius * 2, 270, 90);  // Top-right corner
        path.AddArc(this.Width - BorderRadius * 2, this.Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 0, 90);  // Bottom-right corner
        path.AddArc(0, this.Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 90, 90);  // Bottom-left corner
        path.CloseFigure();

        // Set the region of the PictureBox to the rounded rectangle
        this.Region = new Region(path);

        // Draw the image in the rounded region
        if (this.Image != null)
        {
            e.Graphics.SetClip(path);  // Clip the drawing to the rounded path
            //e.Graphics.DrawImage(this.Image, 0, 0, this.Width, this.Height); // Draw the image
        }
    }
}
