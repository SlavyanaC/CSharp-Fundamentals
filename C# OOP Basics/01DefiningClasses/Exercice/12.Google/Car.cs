using System.Text;

public class Car
{
    private string model;
    private string speed;

    public Car()
    {
        this.model = string.Empty;
        this.speed = string.Empty;
    }

    public Car(string model, string speed)
        : this()
    {
        this.model = model;
        this.speed = speed;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public override string ToString()
    {
        return $"{this.model} {this.speed}";
    }
}