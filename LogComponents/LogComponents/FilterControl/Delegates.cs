using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LogComponents
{
  public delegate ImageStatus ImageStatusDelegate(object currentObject);

  public delegate Color BackColorDelegate(object currentObject);

  public class ImageStatus
  {
    public Image Image {get; set;}

    public string Status { get; set; }

    public static ImageStatus Create(Image image)
    {
      ImageStatus imageStatus = new ImageStatus();
      imageStatus.Image = image;
      return imageStatus;
    }

    public static ImageStatus Create(Image image, String status)
    {
      ImageStatus imageStatus = new ImageStatus();
      imageStatus.Image = image;
      imageStatus.Status = status;
      return imageStatus;
    }
  }

}
