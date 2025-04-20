using Godot;
using System;

public partial class AbilityUpgrade : Resource
{

    [Export]
    public String Id { get; set; }

    [Export]
    public String Name { get; set; }

    [Export]
    public String Description { get; set; }
}
