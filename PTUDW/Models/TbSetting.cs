using System;
using System.Collections.Generic;

namespace PTUDW.Models;

public partial class TbSetting
{
    public int SettingId { get; set; }

    public string? SettingKey { get; set; }

    public string? SettingValue { get; set; }

    public string? SettingDescription { get; set; }
}
