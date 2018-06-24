using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LogComponents.MVC;
using LogComponents.Controls;
using LogComponents.FilterControl;
using LogComponents;

namespace WebGateLogger.Mvc
{
  public partial class RequestAndResponseControl : MvcControl
  {
    private bool m_responceTruncated = false;

    public RequestAndResponseControl()
    {
      InitializeComponent();
      DoubleBuffered = true;
    }

    public override void Initialize()
    {

      Options.OnSaved += OnOptionsChanged;

      SetColorsAndFonts();
      SetSplitterSize();
    }

    public override string Caption
    {
      get
      {
        return "Request and response";
      }
    }

    public override int Order
    {
      get
      {
        return 10;
      }
    }

    protected override void OnMvcContextChanged()
    {
      if (MvcContext == null)
      {
        m_txtRequest.Text = string.Empty;
        m_txtResponse.Text = string.Empty;
        m_responceTruncated = false;
      }
      else
      {

        Frec frec = (Frec)MvcContext;

        m_txtResponse.SetStatus(frec.IsFailed);
        m_txtRequest.Text = frec.Request;


        if (frec.Response.Length <= Options.ParseMaximalResponseLength)
        {
          m_txtResponse.Text = frec.Response;
          m_responceTruncated = false;
        }
        else
        {
          string splitter = "\r\n\r\n\r\n\r\n==========================================================================\r\n\r\n";
          string suffix = string.Format("Responce was truncated to {0} characters. To change number of visible characters use Configuration->Advanced->Parsing", Options.ParseMaximalResponseLength);

          m_txtResponse.Text = frec.Response.Substring(0, Options.ParseMaximalResponseLength) + splitter + suffix;
          m_responceTruncated = true;

        }

        UpdateFilter(frec.Parent.FilterConfig);
      }
    }

    public override void SaveState()
    {
      Options.SplitterRightPanel = m_splitPanel.SplitterDistance;
    }

    public void UpdateFilter(FilterConfig filterConfig)
    {
      string[] emptyPropertyFilters = filterConfig.MainFilter.GetValues(FilterConfig.EMPTY_PROPERTY);
      UpdateFilterWords(m_txtRequest, emptyPropertyFilters);
      UpdateFilterWords(m_txtResponse, emptyPropertyFilters);
    }

    public int FindInResponce(BaseBookmark bookmark)
    {

      int startInnerTable = 0;
      if (bookmark.IsInjected && !string.IsNullOrEmpty(bookmark.Title))
      {
        string tableAttribute = "TABLE_NAME:" + bookmark.Title;
        startInnerTable = m_txtResponse.Find(tableAttribute);
        startInnerTable = Math.Max(startInnerTable - 15, 0);
      }

      int index = m_txtResponse.Find(bookmark.Bookmark, startInnerTable, RichTextBoxFinds.MatchCase);

      if (index == -1)
      {
        if (m_responceTruncated)
        {
          m_txtResponse.Find("Responce was truncated");
        }

        return -1;
      }


      while (index > 0 && m_txtResponse.Text[index - 1] == '_')
        index = m_txtResponse.Find(bookmark.Bookmark, index + 1, int.MaxValue, RichTextBoxFinds.MatchCase);

      return index;

    }

    #region Private methods

    private new Options Options
    {
      get
      {
        return (Options)base.Options;
      }
    }

    private void OnOptionsChanged(object sender, EventArgs e)
    {
      SetColorsAndFonts();
    }

    private void SetColorsAndFonts()
    {
      Options options = Options;
      m_txtRequest.SetTextRegularProperties(options.RequestForeColor, options.RequestBackColor, options.RequestFont);
      m_txtRequest.SetTextSelectionProperties(options.SelectionForeColor, options.SelectionBackColor, options.SelectionFont);

      m_txtResponse.SetTextRegularProperties(options.ResponseForeColor, options.ResponseBackColor, options.ResponceFont);
      m_txtResponse.SetTextSelectionProperties(options.SelectionForeColor, options.SelectionBackColor, options.SelectionFont);
      m_txtResponse.SetTextFailedProperties(options.ResponceErrorForeColor);
    }

    private void SetSplitterSize()
    {
      if (Options.SplitterRightPanel > 25)
      {
        m_splitPanel.SplitterDistance = Options.SplitterRightPanel;
      }
    }

    private void UpdateFilterWords(CustomTextBox textBox, string[] words)
    {
      textBox.UnselectAll();
      textBox.SelectStrings(words, false);
    }

    #endregion

  }
}
