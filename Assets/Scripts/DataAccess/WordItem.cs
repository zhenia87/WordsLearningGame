using SQLite4Unity3d;

public class WordItem  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string EnglishWord { get; set; }
	public string TranslatedWord { get; set; }

	public override string ToString ()
	{
        return string.Format("[Person: Id={0}, EnglishWord={1},  TranslatedWord={2}]", Id, EnglishWord, TranslatedWord);
	}
}