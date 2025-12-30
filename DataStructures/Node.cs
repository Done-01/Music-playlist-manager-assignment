public class Node
{
    public Song SongData { get; }
    public Node? Next { get; set; }
    public Node? Previous { get; set; }

    public override string ToString()
    {
        return $"Node: Song='{SongData?.Title}', " +
               $"HasNext={Next != null}, " +
               $"HasPrevious={Previous != null}";
    }

    public Node(Song songData)
    {
        SongData = songData;
    }
}