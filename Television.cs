namespace oop_lab_aparker2024
{
    public class Television
    {
        private string manufactor;
        private int screenSize;
        private bool powerOn;
        private int channel;
        private int volume;

        public Television(string manufactor, int screenSize)
        {
            this.manufactor = manufactor;
            this.screenSize = screenSize;
            this.powerOn = false;
            this.channel = 2;
            this.volume = 20;
        }

    public Television()
    {

    }

    public int GetVolume()
    {
        return volume;
    }
    public int GetChannel()
    {
        return channel;
    }
    public string GetManufactor()
    {
        return manufactor;
    }
    public int GetScreenSize()
    {
        return screenSize;
    }
    
 
    public void SetChannel(int channel)
    {
        this.channel = channel;

    }
    public void SetManufactor(string manufactor)
    { 
        this.manufactor = manufactor;
    }

    public void Power()
    {
        this.powerOn = !powerOn;
    }


    public void DecreaseVolume()
    {
        this.volume -= 1;
    }
    public void IncreaseVolume()
    {
        this.volume += 1;
    }


    public override string ToString()
    {
        return "A " + screenSize + " inch " + manufactor + " has been turned on";
       
    }
    }
}