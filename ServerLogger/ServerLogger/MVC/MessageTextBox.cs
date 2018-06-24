using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using LogComponents.Controls;
using LogComponents;
using LogComponents.FilterControl;

namespace ServerLogger.Mvc
{
  public partial class MessageTextBox : CustomTextBox
  {
    Options m_options;
    FilterGridControl m_filterGridControl;

    public MessageTextBox()
    {
      InitializeComponent();
    }

    public MessageTextBox(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
    }

    public void Initialize(Options options, FilterGridControl filterGridControl)
    {
      m_options = options;
      m_options.OnSaved += OnOptionsSaved;
      m_filterGridControl = filterGridControl;
      m_filterGridControl.FocusedIndexChanged += OnFocusedIndexChanged;
      m_filterGridControl.DataSourceChanged += OnFilterGridControlDataSourceChanged;
      m_filterGridControl.FilterChanged += OnFilterGridControlFilterChanged;
    }

    private void OnFilterGridControlFilterChanged(object sender, EventArgs e)
    {
      UpdateText();
    }

    private void OnFilterGridControlDataSourceChanged(object sender, EventArgs e)
    {
      UpdateText();
    }

    private void OnOptionsSaved(object sender, EventArgs e)
    {
      SetMessageColors(m_filterGridControl.FocusedObject<LogSubRequest>());
    }

    private void OnFocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
    {
      UpdateText();
    }

    private void UpdateText()
    {
      LogSubRequest logRow = m_filterGridControl.FocusedObject<LogSubRequest>();
      if (logRow != null)
      {
        if (Text != logRow.Message)
        {
          Text = logRow.Message;
          SetMessageColors(logRow);
        }
      }
      else
      {
        Text = string.Empty;
      }
    }

    private void SetMessageColors(LogSubRequest logRow)
    {
      if (logRow == null)
      {
        Text = string.Empty;
        return;
      }

      bool isFailed = logRow.IsErrType;

      SetTextRegularProperties(m_options.MessageForeColor, m_options.MessageBackColor, m_options.MessageFont);
      SetTextFailedProperties(m_options.MessageErrorForeColor);
      UnselectAll();

      //unselect all
      SelectionStart = 0;
      SelectionLength = TextLength;

      if (TextLength < 2)
        return;

      if (logRow.ContainsSQL)
      {
        //select sql words
        SetTextSelectionProperties(m_options.SqlForeColor, m_options.SqlBackColor, m_options.SqlFont);
        SelectStrings(Utilities.SqlReservedWords, true);
      }

      //select custom words
      SetTextSelectionProperties(m_options.CustomForeColor, m_options.CustomBackColor, m_options.CustomFont);
      SelectStrings(m_options.CustomSelectedWords, false);

      //select filter words
      string[] emptyPropertyValues = m_filterGridControl.FilterConfig.MainFilter.GetValues(FilterConfig.EMPTY_PROPERTY);
      SelectStrings(emptyPropertyValues, false);

      //set focus on zero
      SelectionStart = 0;
      SelectionLength = 0;
    }
  }
}
