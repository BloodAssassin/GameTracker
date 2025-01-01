using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    public int BorderRadius { get; set; } = 5;
    public Color _defaultBackColor { get; set; } = Color.White;
    private Color _hoverBackColor;
    private Color _clickBackColor;
    private bool _isClicked = false;

    public RoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat; // Make sure the default button style is flat
        this._hoverBackColor = LightenColor(_defaultBackColor, 0.2f); // Lighter color for hover
        this._clickBackColor = LightenColor(_defaultBackColor, 0.4f); // Even lighter color for click
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        // Enable anti-aliasing to smooth the button's edges and fill
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        pevent.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        // Clear the background with the button's background color (ensure no artifacts)
        pevent.Graphics.Clear(this.BackColor);

        // Create a rounded rectangle path with more precise control over corner radii
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius * 2, BorderRadius * 2, 180, 90);  // Top-left corner
        path.AddArc(this.Width - BorderRadius * 2, 0, BorderRadius * 2, BorderRadius * 2, 270, 90);  // Top-right corner
        path.AddArc(this.Width - BorderRadius * 2, this.Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 0, 90);  // Bottom-right corner
        path.AddArc(0, this.Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 90, 90);  // Bottom-left corner
        path.CloseFigure();  // Close the path to form the complete rectangle with rounded corners

        // Set the region of the button to the rounded rectangle path
        this.Region = new System.Drawing.Region(path);

        // Fill the button's background with the current background color
        pevent.Graphics.FillPath(new SolidBrush(this.BackColor), path);

        // Draw the button's text centered inside the button
        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font,
            new Point(Width / 2 - TextRenderer.MeasureText(this.Text, this.Font).Width / 2,
            Height / 2 - TextRenderer.MeasureText(this.Text, this.Font).Height / 2), this.ForeColor);
    }


    // Handle mouse enter (hover)
    protected override void OnMouseEnter(EventArgs e)
    {
        this._hoverBackColor = LightenColor(_defaultBackColor, 0.2f);
        this._clickBackColor = LightenColor(_defaultBackColor, 0.4f);

        base.OnMouseEnter(e);
        if (!_isClicked) // Only change color on hover if not clicked
        {
            this.BackColor = _hoverBackColor; // Change background color on hover
        }
    }

    // Handle mouse leave (no longer hovering)
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        if (!_isClicked) // If not clicked, revert to default color
        {
            this.BackColor = _defaultBackColor; // Reset background color when hover ends
        }
        else
        {
            this.BackColor = _defaultBackColor; // If clicked, remain in clicked color
        }
    }

    // Handle mouse down (click)
    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        _isClicked = true; // Mark as clicked
        this.BackColor = _defaultBackColor; // Change background color on click
    }

    // Handle the mouse button up event (release the click)
    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        base.OnMouseUp(mevent);
        _isClicked = false; // Reset clicked state
        if (this.ClientRectangle.Contains(mevent.Location)) // Ensure we're still over the button after release
        {
            this.BackColor = _defaultBackColor; // Reset to hover color after mouse up
        }
        else
        {
            this.BackColor = _defaultBackColor; // If mouse is outside, reset to default color
        }
    }

    // Method to lighten a color by a factor
    private Color LightenColor(Color color, float factor)
    {
        int r = (int)(color.R + (255 - color.R) * factor);
        int g = (int)(color.G + (255 - color.G) * factor);
        int b = (int)(color.B + (255 - color.B) * factor);
        return Color.FromArgb(r, g, b);
    }
}
