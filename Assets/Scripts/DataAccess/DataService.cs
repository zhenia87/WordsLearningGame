using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;
    private string _databaseName = "words.bytes";
    private static DataService instance;

    public static DataService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataService();
            }
            return instance;
        }
    }

	public DataService(){

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", _databaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, _databaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + _databaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + _databaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + _databaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + _databaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}
    #region QUERIES

    public IEnumerable<WordItem> GetAllWordItems()
    {
        return _connection.Table<WordItem>();
    }

    public int GetAmountWords()
    {
        return _connection.Table<WordItem>().Count();
    }

    public IEnumerable<WordItem> GetWordsByUnitId(int unitId)
    {
        return _connection.Table<WordItem>().Where(x => x.UnitId == unitId);
    }

    public WordItem CreateWordItem(string englishWord, string translatedWord)
    {
        var w = new WordItem
        {
            EnglishWord = englishWord,
            TranslatedWord = translatedWord,
        };
        _connection.Insert(w);
        return w;
    }

    #endregion
    
}
