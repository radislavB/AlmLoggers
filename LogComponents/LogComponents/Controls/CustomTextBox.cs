using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace LogComponents.Controls
{
  public partial class CustomTextBox : RichTextBox
  {
    Color m_selectionForeColor;
    Color m_selectionBackground;
    Font m_selectionFont;

    Color m_regularForeColor;
    Color m_regularBackground;
    Font m_regularFont;

    Color m_failedForeColor;

    bool m_isFailedStatus;

    public CustomTextBox()
    {
      InitializeComponent();
      HideSelection = false;
    }

    public void SetTextSelectionProperties(Color foreColor, Color background, Font font)
    {
      m_selectionForeColor = foreColor;
      m_selectionBackground = background;
      m_selectionFont = font;
    }

    public void SetTextFailedProperties(Color foreColor)
    {
      m_failedForeColor = foreColor;
    }

    public void SetTextRegularProperties(Color foreColor, Color background, Font font)
    {
      ForeColor = m_regularForeColor = foreColor;
      BackColor = m_regularBackground = background;
      Font = m_regularFont = font;
    }

    public void SelectStrings(ICollection<string> words, bool wholeWord)
    {
      if (words == null)
      {
        return;
      }

      if (m_isFailedStatus)
      {
        return;
      }

      RichTextBoxFinds options = (wholeWord ? RichTextBoxFinds.WholeWord : RichTextBoxFinds.None);

      foreach (string word in words)
      {
        if (word.Length > 1)
        {
          SelectString(word, options);
        }
      }

      SelectionStart = 0;
      SelectionLength = 0;
    }

    public void UnselectAll()
    {
      BackColor = m_regularBackground;
      Font = m_regularFont;
      SetForeColor();

      string text = this.Text;
      Clear();
      Text = text;
    }

    private void SetForeColor()
    {
      ForeColor = (m_isFailedStatus) ? m_failedForeColor : m_regularForeColor;
    }

    private void SelectString(string word, RichTextBoxFinds options)
    {
      if (string.IsNullOrEmpty(word))
      {
        return;
      }

      int index = 0;
      int prevIndex = 0;

      while (index != -1)
      {
        prevIndex = index;
        index = Find(word, index, options);
        if (index==-1 || prevIndex > index)
        {
          index = -1;
          continue;
        }

        if (index < this.TextLength)//str found
        {
          SelectionBackColor = m_selectionBackground;
          SelectionFont = m_selectionFont;
          SelectionColor = m_selectionForeColor;

          index += word.Length;
        }
      }
    }

    public void SetStatus(bool isFailed)
    {
      if (m_isFailedStatus != isFailed)
      {
        m_isFailedStatus = isFailed;
        SetForeColor();
      }
    }

  }
}
