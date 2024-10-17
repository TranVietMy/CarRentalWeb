using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class XeImg
{
    public int ImgId { get; set; }

    public string? CarId { get; set; }

    public string? Img { get; set; }

    public virtual XeThue? Car { get; set; }
}
