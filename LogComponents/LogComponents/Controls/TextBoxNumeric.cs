using System.Windows.Forms;

namespace LogComponents.Controls
{
  public class TextBoxNumeric : TextBox
  {

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (e.Control && e.KeyCode == Keys.V)
      {
        if (Clipboard.ContainsText())
        {
          string text = Clipboard.GetText();
          if (!IsNumber(text))
          {
            e.SuppressKeyPress = true;
          }
        }
      }
      else if (!IsDigit(e.KeyValue))
      {
        if (!(e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter))
        {
          e.SuppressKeyPress = true;
        }
      }

      if (!e.SuppressKeyPress)
        base.OnKeyDown(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        CheckClipboard();
      }

      base.OnMouseDown(e);
    }

    private void CheckClipboard()
    {
      string text = Clipboard.GetText();

      if (!IsNumber(text))
      {
        Clipboard.Clear();
      }
    }

    private bool IsNumber(string text)
    {
      char c;
      for (int i = 0; i < text.Length; i++)
      {
        c = text[i];
        if (!char.IsDigit(c))
          return false;
      }

      return true;
    }

    private bool IsDigit(int keyValue)
    {
      return ((keyValue >= 48 && keyValue <= 57) || (keyValue >= 96 && keyValue <= 105));
    }

  }
}
