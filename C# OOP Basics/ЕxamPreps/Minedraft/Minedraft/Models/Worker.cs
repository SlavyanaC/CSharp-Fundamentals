public abstract class Worker
{
    private string id;

    public Worker(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}
