using SQLite4Unity3d;

public class WordItem  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string EnglishWord { get; set; }
	public string TranslatedWord { get; set; }
    public string Examples { get; set; }
    public int UnitId { get; set; }

	public override string ToString ()
	{
        return string.Format(
            "[WordItem:Id={0}, EnglishWord={1},  TranslatedWord={2}, UnitId={3}, Examples={4}]", 
                       Id, EnglishWord, TranslatedWord, UnitId, Examples);
	}
}