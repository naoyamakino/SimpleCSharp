/*
 * CMPT 383 (Fall 2010): Simple C# Program
 * Naoya Makino:301117541
 * http://www.cs.sfu.ca/CC/383/ted/383-10-3/SimpleCSharp.html
 */ 
using System;
using System.IO;
using System.Collections.Generic;
class SimpleCSharp
{
	public static Void Main()
	{
		//get the command line parameter
		String[] cmd = Environment.GetCommandLineArgs();
		
		if (cmd.Length < 2)//if no parameter is given
		{
			Console.WriteLine("Usage: " + cmd[0] + " <input file>" );
			return;
		}
		string line;
		string[] words;
		List<string> list = new List<string>();
		try
		{
			using (StreamReader s = File.OpenText(cmd[1]))//open the file
			{
				while ((line = s.ReadLine()) != null)//read each line
				{
					words = line.Split(' ');//split the line by a word
					foreach(string word in words)
						list.Add(word);
				}
				for(int i = 0; i< list.Count; i++)
				{
					int count=0;
					for(int j=0;j<list.Count;j++)	
						//count the number of occurrences for each word in the list
						if (list[i].Equals(list[j], StringComparison.OrdinalIgnoreCase))
						 	  count++;
					for(int j = 0;j<i;j++)
					{
						int k = 0;
						if (list[i].Equals(list[j], StringComparison.OrdinalIgnoreCase) == false)//if list[i] is unique from the previous words 
							k++;
						if(k == j)
							Console.WriteLine(list[i] + "\t" + count);//print it with the number of occurrences
					}	
				}
				
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}
		
	}
}

