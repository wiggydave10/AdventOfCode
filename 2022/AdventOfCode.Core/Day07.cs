using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;

namespace AdventOfCode.Core;

public class Day07 : IAdventOfCodeDay<int, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\07.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t07.txt";

	private string[] data;

	public async Task PrepData()
	{
		var lines = await File.ReadAllLinesAsync(dataFile);
		data = lines;
	}
	public async Task PrepTestData()
	{
		var lines = await File.ReadAllLinesAsync(testDataFile);
		data = lines;
	}

	public int RunMorning()
	{
		var fileStorage = GetFileStorage();
		var folders = fileStorage.GetFolders(includeSubfolders: true).ToList();
		var total = 0;
		foreach (var folder in folders)
		{
			var folderSize = folder.FolderSize();
			if (folderSize <= 100_000)
				total += folderSize;
		}
		return total;
	}

	public int RunEvening()
	{
		var totalSpace = 70_000_000;
		var updateSpace = 30_000_000;

		var fileStorage = GetFileStorage();
		var totalUsedSpace = fileStorage.FolderSize();
		var requiredToFree = updateSpace - (totalSpace - totalUsedSpace);
		var possibleFolders = new List<(Folder folder, int size)>();

		var folders = fileStorage.GetFolders(includeSubfolders: true).ToList();
		foreach (var folder in folders)
		{
			var folderSize = folder.FolderSize();
			if (folderSize >= requiredToFree)
				possibleFolders.Add((folder, folderSize));
		}
		return possibleFolders.OrderBy(x => x.size).First().size;
	}

	private Folder GetFileStorage()
	{
		var result = new Folder("/");
		var currentFolder = result;
		var isListing = false;
		foreach (var line in data)
		{
			var parts = line.Split(' ');
			if (isListing && parts[0] == "$")
			{
				isListing = false;
			}

			if (isListing)
			{
				switch (parts[0])
				{
					case "dir":
						currentFolder.FindOrCreateFolder(parts[1]);
						break;
					default:
						var file = new FileRep(parts[1], int.Parse(parts[0]));
						currentFolder.Files.Add(file);
						break;
				}
			} 
			else
			{
				if (parts[1] == "ls")
				{
					isListing = true;
					continue;
				}

				currentFolder = parts[2] switch
				{
					".." => currentFolder.ParentFolder,
					"/" => result,
					_ => currentFolder.FindOrCreateFolder(parts[2]),
				};
			}
		}
		return result;
	}
}

internal class Folder
{
	public Folder(string name, Folder? parentFolder = null)
	{
		Name = name;
		ParentFolder = parentFolder;
		Folders = new List<Folder>();
		Files = new List<FileRep>();
	}

	public string Name { get; set; }
	public Folder? ParentFolder { get; }
	public IList<Folder> Folders { get; set; }
	public IList<FileRep> Files { get; set; }

	public Folder FindOrCreateFolder(string name)
	{
		var folder = Folders.FirstOrDefault(x => x.Name == name);
		if (folder == null)
		{
			folder = new Folder(name, this);
			Folders.Add(folder);
		}
		return folder;
	}

	public int FolderSize()
	{
		var total = 0;
		foreach (var file in Files)
		{
				total += file.Size;
		}
		foreach (var folder in Folders)
		{
			total += folder.FolderSize();
		}
		return total;
	}

	public IEnumerable<Folder> GetFolders(bool includeSubfolders)
	{
		foreach (var folder in Folders)
		{
			yield return folder;
			foreach (var subFolder in folder.GetFolders(includeSubfolders))
			{
				yield return subFolder;
			}
		}
	}
}
internal class FileRep
{
	public FileRep(string name, int size)
	{
		Name = name;
		Size = size;
	}

	public string Name { get; set; }
	public int Size { get; set; }
}
