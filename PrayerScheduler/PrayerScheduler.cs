namespace PrayerScheduler;

public class PrayerScheduler
{

    
    // TODO
    public int NumDailyPrayers {get;}
    // TODO
    public int NumNonDailyPrayers {get;}

    public List<Prayer> DailyPrayers { get; } = new();

    private Queue<Prayer> nonDailyPrayers = new(); 
    public List<Prayer> NonDailyPrayers
    {
        get
        {
            return nonDailyPrayers.ToList();
        }
    }

    public List<Prayer> AnsweredPrayers { get; } = new();

    public PrayerScheduler()
    {
    }

    // TODO
    public void AddPrayer(Prayer prayer)
    {
        // if answered
        // add it to answered

        //if unanswered
        // if daily, add to dailys


    }

    // TODO
    public void AnswerPrayer(int id)
    {
        
    
    }

    // TODO
    public List<Prayer> GetPrayers(int numPrayers)
    {
        List<Prayer> prayers = new List<Prayer>();


        return prayers;
    }

}


