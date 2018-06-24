using System;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;

namespace LogComponents.Controls
{
  public partial class CustomPropertyGrid : PropertyGrid
  {
    public CustomPropertyGrid()
    {
      InitializeComponent();
    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      AdjustView();
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      AdjustView();
    }

    private void AdjustView()
    {
      //PropertyGridManipulator.ResizeDescriptionArea(this, -1);
      PropertyGridManipulator.MoveSplitter(this, 110);
    }
  }

  public static class PropertyGridManipulator
  {
    public static void MoveSplitter(PropertyGrid propertyGrid, int x)
    {
      BindingFlags flags = BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance;
      object propertyGridView = typeof(PropertyGrid).InvokeMember("gridView", flags, null, propertyGrid, null);

      flags = BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance;
      propertyGridView.GetType().InvokeMember("MoveSplitterTo", flags, null, propertyGridView, new object[] { x });
    }

    public static void MoveSplitterToLongestDisplayName(PropertyGrid propertyGrid, int iPadding)
    {
      try
      {
        Type pgObjectType = propertyGrid.SelectedObject.GetType();
        string longestDisplayName = "";
        // Iterate through all the properties of the class.
        foreach (PropertyInfo mInfo in pgObjectType.GetProperties())
        {
          // Iterate through all the Attributes for each property.
          foreach (Attribute attr in mInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false))
          {
            if (attr.GetType() == typeof(DisplayNameAttribute))
            {
              DisplayNameAttribute displayNameAttr = (DisplayNameAttribute)attr;
              if (displayNameAttr.DisplayName.Length > longestDisplayName.Length)
              {
                longestDisplayName = displayNameAttr.DisplayName;
              }
            }
          }
        }

        Size textSize = TextRenderer.MeasureText(longestDisplayName, propertyGrid.Font);
        PropertyGridManipulator.MoveSplitter(propertyGrid, textSize.Width + iPadding);
      }
      catch (Exception exception1)
      {
        MessageBox.Show(exception1.Message);
        //do nothing for now -- 
        //if exception was thrown the private method MoveSplitterTo
        //of the C# version 2.0 framework's PropertyGrid's 
        //PropertyGridView probably is no
        //longer named the same or has a different
        //method signature in the current C# framework
      }
    }

    public static bool ResizeDescriptionArea(PropertyGrid grid, int nNumLines)
    {
      try
      {
        PropertyInfo pi = grid.GetType().GetProperty("Controls");
        Control.ControlCollection cc = (Control.ControlCollection)pi.GetValue(grid, null);
        foreach (Control c in cc)
        {
          Type ct = c.GetType();
          string sName = ct.Name;

          if (sName == "DocComment")
          {
            pi = ct.GetProperty("Lines");
            pi.SetValue(c, nNumLines, null);
            FieldInfo fi = ct.BaseType.GetField("userSized", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(c, true);
          }
        }
        return true;
      }
      catch
      {
        return false;
      }
    }

  }
}
