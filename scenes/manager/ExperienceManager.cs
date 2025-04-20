using Godot;
using survivor.scenes.auto_load;

namespace survivor.scenes.manager;

public partial class ExperienceManager : Node
{
    [Signal]
    public delegate void ExperienceUpdateEventHandler(int currentLevel, float totalExperience,
        float currentLevelProgress);

    [Signal]
    public delegate void LevelUpEventHandler(int newLevel);

    public int CurrentLevel { get; private set; } = 1;

    public float TotalExperience { get; private set; } = 0f;

    private const float BaseExp = 10f; // 升1级需要的基础经验
    private const float ExpIncrement = 4f; // 每级额外增加的经验

    public override void _Ready()
    {
        GameEvents.Instance.ExperienceVialCollected += OnExperienceVialCollected;
    }

    public void OnExperienceVialCollected(float experience)
    {
        IncrementExperience(experience);
    }

    public void IncrementExperience(float experience)
    {
        TotalExperience += experience;
        CheckLevelUp();
        EmitSignal(nameof(ExperienceUpdate), CurrentLevel, TotalExperience, GetCurrentLevelProgress());
        GD.Print($"当前经验：{TotalExperience}，当前等级：{CurrentLevel}，当前经验百分比：{GetCurrentLevelProgress()}");
    }

    private void CheckLevelUp()
    {
        if (TotalExperience >= GetTotalExpForLevel(CurrentLevel + 1))
        {
            CurrentLevel++;
            EmitSignal(nameof(LevelUp), CurrentLevel);
            GD.Print($"升级了！当前等级：{CurrentLevel}");
        }
    }

    public float GetCurrentLevelProgress()
    {
        float currentLevelStart = GetTotalExpForLevel(CurrentLevel);
        float nextLevelExp = GetExpForNextLevel(CurrentLevel);
        float expIntoLevel = TotalExperience - currentLevelStart;
        return Mathf.Clamp(expIntoLevel / nextLevelExp, 0, 1);
    }

    public static float GetTotalExpForLevel(int targetLevel)
    {
        float total = 0f;
        for (int i = 1; i < targetLevel; i++)
        {
            total += BaseExp + (i - 1) * ExpIncrement;
        }
        return total;
    }

    public static float GetExpForNextLevel(int currentLevel)
    {
        return BaseExp + (currentLevel - 1) * ExpIncrement;
    }
}