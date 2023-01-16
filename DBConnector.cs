using System;

public class DBConnector
{
	public DBConnector()
	{
		string connetionString = null;
		MySqlConnection cnn;
		connetionString = "Server=localhost;Database=bullseyedb2023;Uid=root;password=mysql";
		cnn = new MySqlConnection(connetionString);
	}
}
