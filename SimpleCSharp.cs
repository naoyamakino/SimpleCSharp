/*
 * CMPT 383 (Fall 2010): Simple C# Program
 * Naoya Makino:301117541
 * http://www.cs.sfu.ca/CC/383/ted/383-10-3/SimpleCSharp.html
 * September 16th, 2010
 */ 
using System;
using System.IO;
using System.Collections.Generic;
class SimpleCSharp
{
	public static Void Main()
	{
		string line;
		string[] words;
		List<string> list = new List<string>();
		List<string> output = new List<string>();
		try
		{
			using (StreamReader s = File.OpenText("simple.txt"))//open the file
			{
				/*
				 * Reference: http://www.codeguru.com/csharp/csharp/cs_syntax/anandctutorials/article.php/c5861
				 * 			  http://msdn.microsoft.com/en-us/library/system.io.streamreader.aspx
				 */ 
				while ((line = s.ReadLine()) != null)//read each line
				{
					/*
					 * Reference: http://dotnetperls.com/string-split
					 */ 
					words = line.Split(' ');//split the line by a word
					foreach(string word in words) //reference: http://dotnetperls.com/list
						list.Add(word);
				}
				for(int i = 0; i< list.Count; i++)
				{
					int count=0;
					for(int j=0;j<list.Count;j++)	
						//count the number of occurrences for each word in the list
						if (list[i].Equals(list[j], StringComparison.OrdinalIgnoreCase))
						 	  count++;
					if(!output.Contains(list[i].ToLower()))
					{
						Console.WriteLine(list[i] + "\t" + count);//print it with the number of occurrences
						output.Add(list[i].ToLower());
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

