using System;
using System.Collections.Generic;

namespace PTUDW.Models;

public partial class TbAdv
{
    public int AdvId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? Type { get; set; }

    public string? Link { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }
}
