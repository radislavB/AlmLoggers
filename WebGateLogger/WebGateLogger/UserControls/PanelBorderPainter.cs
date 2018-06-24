using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace WebGateLogger.UserControls
{
  public partial class PanelBorderPainter : Component
  {
    private Panel m_panel;
    private Border3DStyle m_style = Border3DStyle.Etched;
    private Border3DSide m_side = Border3DSide.All;

    public PanelBorderPainter()
    {
      InitializeComponent();
    }

    public PanelBorderPainter(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
    }

    public Panel Panel
    {
      get { return m_panel; }
      set
      {

        if (m_panel != null)
        {
          m_panel.Paint -= new PaintEventHandler(OnPaint);
        }
        m_panel = value;
        m_panel.Paint += new PaintEventHandler(OnPaint);
      }
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
      ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle,
          m_style, m_side);
    }

    [DefaultValue(Border3DStyle.Etched)]
    public Border3DStyle Style
    {
      get { return m_style; }
      set { m_style = value; }
    }

    [Description("Side to paint")]
    [DefaultValue(Border3DSide.All)]
    public Border3DSide Side
    {
      get { return m_side; }
      set { m_side = value; }
    }
  }
}
