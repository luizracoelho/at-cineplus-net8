namespace CinePlus.Domain.Models;

public class Movie
{
    #region Properties

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Image { get; private set; }
    public int DurationInMinutes { get; private set; }
    public bool Active { get; private set; }
    public IList<Session> Sessions { get; private set; }

    #endregion

    #region Constructors

    public Movie(string name, string image, int durationInMinutes)
    {
        Id = 0;
        Active = true;
        Sessions = new List<Session>();
        Update(name, image, durationInMinutes);
    }

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