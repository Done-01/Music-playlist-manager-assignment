public class Node
{
    public Song SongData {get;}
    public Node? Next {get; set;}
    public Node? Previous {get; set;}

    public Node(Song songData)
    {
        SongData = songData;
    }
}