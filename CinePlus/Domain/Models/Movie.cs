namespace CinePlus.Domain.Models;

public class Movie(string name, string image, int durationInMinutes)
{
    #region Properties

    public long Id { get; private set; } = 0;
    public string Name { get; private set; } = name;
    public string Image { get; private set; } = image;
    public int DurationInMinutes { get; private set; } = durationInMinutes;
    public bool Active { get; private set; } = true;
    public IList<Session> Sessions { get; private set; } = [];

    #endregion

    #region Methods

    public void Update(string name, string image, int durationInMinutes)
    {
        Name = name;
        Image = image;
        DurationInMinutes = durationInMinutes;
    }

    public bool Activate()
    {
        if (Active == true) return false;

        Active = true;
        return true;
    }

    public bool Deactivate()
    {
        if (Active == false) return false;

        Active = false;
        return true;
    }

    public override string ToString() => $"[{Id}] {Name}";

    #endregion
}